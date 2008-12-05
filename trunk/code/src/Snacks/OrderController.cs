using Utilities.Mapping;
using Utilities.Repository;

namespace Snacks
{
    public class OrderController : ISnackOrderController
    {
        private readonly IRepository repository;

        public OrderController(IRepository repository)
        {
            this.repository = repository;
        }

        public void Request(SnackOrderDto snackOrderDto)
        {
            var user = repository.Get<User>(snackOrderDto.UserId);
            user.Debit(snackOrderDto.Price);
            repository.Save(user);

            var order = Map.This(snackOrderDto).ToA<Snack>();
            repository.Save(order);
        }
    }
}