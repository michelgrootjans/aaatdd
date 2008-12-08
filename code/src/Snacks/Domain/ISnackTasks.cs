using System.Collections.Generic;
using Snacks.Dto;

namespace Snacks.Domain
{
    public interface ISnackTasks
    {
        void Request(SnackRequestDto snackRequestDto);
        IEnumerable<SnackRequestDto> GetAllSnackRequests();
    }
}