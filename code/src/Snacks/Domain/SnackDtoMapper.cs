/*
 * Created by: 
 * Created: zaterdag 6 december 2008
 */

using Snacks.Domain.Entities;
using Snacks.Dto;
using Utilities;

namespace Snacks.Domain
{
    public class SnackDtoMapper : IMapper<SnackRequestDto, Snack>
    {
        public Snack Map(SnackRequestDto snackRequestDto)
        {
            var snack = new Snack();

            snack.Name = snackRequestDto.SnackName;
            snack.Price = snackRequestDto.SnackPrice;

            return snack;
        }
    }
}