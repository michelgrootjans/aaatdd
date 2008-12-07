using System.Collections.Generic;
using Snacks.Domain.Entities;
using Snacks.Dto;
using Utilities.Mapping;
using Utilities.Repository;

namespace Snacks.Domain
{
    public class SnacksController : ISnacksController
    {
        private readonly IRepository repository;

        public SnacksController(IRepository repository)
        {
            this.repository = repository;
        }

        public void Request(SnackRequestDto snackRequestDto)
        {
            var user = repository.Get<User>(snackRequestDto.UserId);
            user.Debit(snackRequestDto.SnackPrice);
            repository.Save(user);

            var order = Map.This(snackRequestDto).ToA<Snack>();
            repository.Save(order);
        }

        public IEnumerable<SnackRequestDto> GetAllSnackRequests()
        {
            var snacks = repository.FindAll<Snack>();

            foreach (var snack in snacks)
                yield return Map.This(snack).ToA<SnackRequestDto>();
        }
    }
}