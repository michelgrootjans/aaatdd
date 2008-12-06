/*
 * Created by: 
 * Created: zaterdag 6 december 2008
 */

using NUnit.Framework;
using Snacks.Domain;
using Snacks.Domain.Entities;
using Snacks.Dto;
using TestUtilities;
using Utilities;

namespace Snacks.Tests.Domain
{
    [TestFixture]
    public class SnackDtoMapperTests : ArrangeActAssert<IMapper<SnackOrderDto, Snack>>
    {
        private Snack snack;
        private string snackName;
        private SnackOrderDto snackDto;
        private double snackPrice;

        public override void Arrange()
        {
            snackName = "Club";
            snackPrice = 2.1;

            snackDto = new SnackOrderDto { SnackName = snackName, SnackPrice = snackPrice};
        }

        public override IMapper<SnackOrderDto, Snack> CreateSUT()
        {
            return new SnackDtoMapper();
        }

        public override void Act()
        {
            snack = sut.Map(snackDto);
        }

        [Test]
        public void should_map_name_correctly_to_a_new_snack()
        {
            snack.Name.ShouldBeEqualTo(snackName);
        }

        [Test]
        public void should_map_price_correctly_to_a_new_snack()
        {
            snack.Price.ShouldBeEqualTo(snackPrice);
        }
    }
}