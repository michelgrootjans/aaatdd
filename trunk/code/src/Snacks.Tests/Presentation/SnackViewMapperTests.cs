/*
 * Created by: 
 * Created: zaterdag 6 december 2008
 */

using NUnit.Framework;
using Rhino.Mocks;
using Snacks.Dto;
using Snacks.Presentation;
using TestUtilities;
using Utilities;

namespace Snacks.Tests.Presentation
{
    [TestFixture]
    public class SnackViewMapperTests : ArrangeActAssert<IMapper<IRequestSnackView, SnackRequestDto>>
    {
        private IRequestSnackView view;
        private SnackRequestDto dto;
        private const long userId = 45;
        private const double snackPrice = 2.5;
        private const string snackName = "Club";

        public override void Arrange()
        {
            view = Dependency<IRequestSnackView>();
            view.Stub(v => v.UserId).Return(userId.ToString());
            view.Stub(v => v.SnackName).Return(snackName);
            view.Stub(v => v.SnackPrice).Return(snackPrice.ToString());
        }

        public override IMapper<IRequestSnackView, SnackRequestDto> CreateSUT()
        {
            return new SnackViewMapper();
        }

        public override void Act()
        {
            dto = sut.Map(view);
        }

        [Test]
        public void should_translate_the_userId_correctly()
        {
            dto.UserId.ShouldBeEqualTo(userId);
        }

        [Test]
        public void should_translate_the_snackprice_correctly()
        {
            dto.SnackPrice.ShouldBeEqualTo(snackPrice);
        }

        [Test]
        public void should_translate_the_snackname_correctly()
        {
            dto.SnackName.ShouldBeEqualTo(snackName);
        }
    }
}