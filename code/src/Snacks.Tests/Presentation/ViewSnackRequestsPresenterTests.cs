/*
 * Created by: 
 * Created: zondag 7 december 2008
 */

using System;
using NUnit.Framework;
using Snacks.Domain;
using Snacks.Domain.Entities;
using Snacks.Presentation;
using TestUtilities;
using Utilities.Repository;
using Rhino.Mocks;

namespace Snacks.Tests.Presentation
{
    [TestFixture]
    public class ViewSnackRequestsPresenterTests : ArrangeActAssert<IViewSnackRequestsPresenter>
    {
        private IViewSnackRequestsView view;
        private ISnacksController controller;

        public override void Arrange()
        {
            view = Dependency<IViewSnackRequestsView>();
            controller = RegisterDependencyInContainer<ISnacksController>();
        }

        public override IViewSnackRequestsPresenter CreateSUT()
        {
            return new ViewSnackRequestsPresenter(view);
        }

        public override void Act()
        {
            view.Raise(v => v.GetAllSnackRequests += null, view, EventArgs.Empty);
        }

        [Test]
        public void should_get_requests_from_repository()
        {
            controller.AssertWasCalled(r => r.GetAllSnackRequests());
        }
    }
}