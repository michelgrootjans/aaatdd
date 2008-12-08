using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Rhino.Mocks;
using Snacks.Domain;
using Snacks.Domain.Entities;
using Snacks.Dto;
using TestUtilities;
using Utilities;
using Utilities.Repository;

namespace Snacks.Tests.Domain
{
    public class SnacksControllerTest : ArrangeActAssert<ISnackTasks>
    {
        protected IRepository repository;

        public override void Arrange()
        {
            repository = Dependency<IRepository>();
        }

        public override ISnackTasks CreateSUT()
        {
            return new SnackTasks(repository);
        }
    }

    [TestFixture]
    public class when_snackscontroller_is_told_to_requesta_new_snack : SnacksControllerTest
    {
        private IMapper<SnackRequestDto, Snack> mapper;
        private SnackRequestDto snackDto;
        private Snack clubSandwich;
        private User user;
        private const double originalUserCredit = 25;
        private const long userId = 54;
            
        public override void Arrange()
        {
            base.Arrange();

            snackDto = new SnackRequestDto{UserId = userId, SnackPrice = 2};
            user =  new User(originalUserCredit);
            clubSandwich = new Snack{Price = snackDto.SnackPrice};

            mapper = RegisterDependencyInContainer<IMapper<SnackRequestDto, Snack>>();

            mapper.Stub(m => m.Map(snackDto)).Return(clubSandwich);
            repository.Stub(r => r.Get<User>(userId)).Return(user);
        }

        public override void Act()
        {
            sut.Request(snackDto);
        }

        [Test]
        public void should_debit_the_order_amount_from_the_users_credit()
        {
            user.Credit.ShouldBeEqualTo(originalUserCredit - snackDto.SnackPrice);
        }

        [Test]
        public void should_save_the_user_to_the_repository()
        {
            repository.AssertWasCalled(r => r.Save(user));
        }

        [Test]
        public void user_should_have_a_snack_assigned()
        {
            user.Snacks.Count().ShouldBeEqualTo(1);
            user.Snacks[0].ShouldBeSameAs(clubSandwich);
        }
    }
    
    [TestFixture]
    public class when_snackscontroller_is_told_to_get_all_snackrequests : SnacksControllerTest
    {
        private IMapper<Snack, SnackRequestDto> mapper;
        private Snack snack1;
        private Snack snack2;
        private Snack snack3;
        private IList<SnackRequestDto> dtos;

        public override void Arrange()
        {
            base.Arrange();

            snack1 = new Snack();
            snack2 = new Snack();
            snack3 = new Snack();

            mapper = RegisterDependencyInContainer<IMapper<Snack, SnackRequestDto>>();

            repository.Stub(r => r.FindAll<Snack>()).Return(new List<Snack>{snack1, snack2, snack3});
        }

        public override void Act()
        {
            dtos = sut.GetAllSnackRequests().ToList();
        }

        [Test]
        public void should_return_as_many_dtos_as_entities_in_repository()
        {
            dtos.Count.ShouldBeEqualTo(3);
        }

        [Test]
        public void should_get_the_requests_from_the_repository()
        {
            repository.AssertWasCalled(r => r.FindAll<Snack>());
        }

        [Test]
        public void should_map_the_reslts_to_dtos()
        {
            mapper.AssertWasCalled(r => r.Map(snack1));
            mapper.AssertWasCalled(r => r.Map(snack2));
            mapper.AssertWasCalled(r => r.Map(snack3));
        }
    }
}