/*
 * Created by: 
 * Created: zaterdag 6 december 2008
 */

using NUnit.Framework;
using Snacks.Domain;
using Snacks.Presentation;
using TestUtilities;

namespace Snacks.Tests.Presentation
{
    [TestFixture]
    public class when_presenterfactory_is_told_to_get_a_presenter_for_a_snack_view: ArrangeActAssert<IPresenterFactory>
    {
        private IPresenter presenter;
        private ISnackOrderView view;

        public override void Arrange()
        {
            view = Dependency<ISnackOrderView>();
            RegisterDependencyInContainer<ISnacksController>();
        }

        public override IPresenterFactory CreateSUT()
        {
            return new PresenterFactory();
        }

        public override void Act()
        {
            presenter = sut.CreatePresenterFor(view);
        }

        [Test]
        public void should_return_a_snack_order_presenter()
        {
            presenter.ShouldBeInstanceOf<ISnackOrderPresenter>();
        }
    }
}