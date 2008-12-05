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
    [TestFixture]
    public class when_ordercontroller_is_told_to_place_a_new_order : ArrangeActAssert<ISnacksController>
    {
        private IMapper<SnackOrderDto, Snack> mapper;
        private SnackOrderDto snackDto;
        private IRepository repository;
        private Snack clubSandwich;
        private User user;
        private double originalUserCredit = 25;
        private long userId = 54;
            
        public override void Arrange()
        {
            snackDto = new SnackOrderDto{UserId = userId, Price = 2};
            user =  new User(originalUserCredit);
            clubSandwich = new Snack();

            mapper = RegisterDependencyInContainer<IMapper<SnackOrderDto, Snack>>();
            repository = Dependency<IRepository>();

            mapper.Stub(m => m.Map(snackDto)).Return(clubSandwich);
            repository.Stub(r => r.Get<User>(userId)).Return(user);
        }

        public override ISnacksController CreateSUT()
        {
            return new SnacksController(repository);
        }

        public override void Act()
        {
            sut.Request(snackDto);
        }

        [Test]
        public void should_debit_the_order_amount_from_the_users_credit()
        {
            user.Credit.ShouldBeEqualTo(originalUserCredit - snackDto.Price);
        }

        [Test]
        public void should_save_the_user_to_the_repository()
        {
            repository.AssertWasCalled(r => r.Save(user));
        }

        [Test]
        public void should_save_the_order_to_the_repository()
        {
            repository.AssertWasCalled(r => r.Save(clubSandwich));
        }
    }
}