using Snacks.Dto;

namespace Snacks.Domain
{
    public interface ISnacksController
    {
        void Request(SnackRequestDto snackRequestDto);
    }
}