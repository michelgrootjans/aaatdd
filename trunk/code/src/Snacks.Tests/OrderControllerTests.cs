using NUnit.Framework;
using Rhino.Mocks;
using TestUtilities;
using Utilities;

namespace Snacks.Tests
{
    [TestFixture]
    public class when_ordercontroller_is_told_to_place_a_new_order : ArrangeActAssert<IOrderController>
    {
        private IMapper<SnackOrderDto, SnackOrder> mapper;
        private SnackOrderDto snackOrderDto;
        private IRepository repository;
        private SnackOrder snackOrder;
        private User user;
        private double originalUserCredit = 25;
        private long userId = 54;

        public override void Arrange()
        {
            mapper = RegisterStubInContainer<IMapper<SnackOrderDto, SnackOrder>>();
            repository = Dependency<IRepository>();
            snackOrderDto = new SnackOrderDto{Price = 2, UserId = userId};
            
            user =  new User(originalUserCredit);
            snackOrder = new SnackOrder();

            mapper.Stub(m => m.Map(snackOrderDto)).Return(snackOrder);
            repository.Stub(r => r.Get<User>(userId)).Return(user);
        }

        public override IOrderController CreateSUT()
        {
            return new OrderController(repository);
        }

        public override void Act()
        {
            sut.RegisterOrder(snackOrderDto);
        }

        [Test]
        public void should_debit_the_order_amount_from_the_users_credit()
        {
            repository.AssertWasCalled(r => r.Get<User>(snackOrderDto.UserId));
            user.Credit.ShouldBeEqualTo(originalUserCredit - snackOrderDto.Price);
            repository.AssertWasCalled(r => r.Save(user));
        }

        [Test]
        public void should_save_the_order_to_the_repository()
        {
            mapper.AssertWasCalled(m => m.Map(snackOrderDto));
            repository.AssertWasCalled(r => r.Save(snackOrder));
        }
    }

}