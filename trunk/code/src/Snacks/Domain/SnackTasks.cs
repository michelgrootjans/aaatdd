using System.Collections.Generic;
using Snacks.Domain.Entities;
using Snacks.Dto;
using Utilities.Mapping;
using Utilities.Repository;

namespace Snacks.Domain
{
    public class SnackTasks : ISnackTasks
    {
        private readonly IRepository repository;

        public SnackTasks(IRepository repository)
        {
            this.repository = repository;
        }

        public void Request(SnackRequestDto snackRequestDto)
        {
            var snack = Map.This(snackRequestDto).ToA<Snack>();
            var user = repository.Get<User>(snackRequestDto.UserId);
            user.Request(snack);
            repository.Save(user);
        }

        public IEnumerable<SnackRequestDto> GetAllSnackRequests()
        {
            var snacks = repository.FindAll<Snack>();

            foreach (var snack in snacks)
                yield return Map.This(snack).ToA<SnackRequestDto>();
        }
    }
}