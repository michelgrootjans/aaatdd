using Utilities.Mapping;
using Utilities.Repository;

namespace Snacks
{
    public class SnacksController : ISnacksController
    {
        private readonly IRepository repository;

        public SnacksController(IRepository repository)
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