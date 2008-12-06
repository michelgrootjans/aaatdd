/*
 * Created by: 
 * Created: zaterdag 6 december 2008
 */

using Snacks.Domain.Entities;
using Snacks.Dto;
using Utilities;

namespace Snacks.Domain
{
    public class SnackDtoMapper : IMapper<SnackOrderDto, Snack>
    {
        public Snack Map(SnackOrderDto snackOrderDto)
        {
            var snack = new Snack();

            snack.Name = snackOrderDto.SnackName;
            snack.Price = snackOrderDto.SnackPrice;

            return snack;
        }
    }
}