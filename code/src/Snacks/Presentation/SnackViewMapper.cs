using Snacks.Dto;
using Utilities;

namespace Snacks.Presentation
{
    public class SnackViewMapper : IMapper<ISnackOrderView, SnackRequestDto>
    {
        public SnackRequestDto Map(ISnackOrderView view)
        {
            var snackOrderDto = new SnackRequestDto();

            long userId;
            long.TryParse(view.UserId, out userId);
            snackOrderDto.UserId = userId;

            snackOrderDto.SnackName = view.SnackName;

            double snackPrice;
            double.TryParse(view.SnackPrice, out snackPrice);
            snackOrderDto.SnackPrice = snackPrice;

            return snackOrderDto;
        }
    }
}