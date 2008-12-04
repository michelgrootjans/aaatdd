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

        public void RegisterOrder(SnackOrderDto snackOrderDto)
        {
            var user = repository.Get<IDebitableUser>(snackOrderDto.UserId);
            user.Debit(snackOrderDto.Price);
            repository.Save(user);

            var order = Map.This(snackOrderDto).ToA<SnackOrder>();
            repository.Save(order);
        }
    }
}