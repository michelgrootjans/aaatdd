using System;
using System.Collections.Generic;
using NUnit.Framework;
using Snacks.Domain;
using Snacks.Dto;
using Snacks.Presentation;
using TestUtilities;
using Rhino.Mocks;
using Utilities;

namespace Snacks.Tests.Presentation
{
    [TestFixture]
    public class when_snackpresenter_is_told_to_request_a_snack_for_a_user : ArrangeActAssert<ISnackPresenter>
    {
        private ISnacksController controller;
        private ISnackOrderView view;
        private SnackOrderDto snackDto;
        private IMapper<ISnackOrderView, SnackOrderDto> mapper;

        public override void Arrange()
        {
            snackDto = new SnackOrderDto();

            view = Dependency<ISnackOrderView>();
            controller = RegisterDependencyInContainer<ISnacksController>();
            mapper = RegisterDependencyInContainer<IMapper<ISnackOrderView, SnackOrderDto>>();

            mapper.Stub(m => m.Map(view)).Return(snackDto);
        }

        public override ISnackPresenter CreateSUT()
        {
            return new SnackPresenter(view);
        }

        public override void Act()
        {
            view.Raise(v => v.RequestSnack += null, view, EventArgs.Empty);
        }

        [Test]
        public void should_translate_the_view_to_a_dto()
        {
            mapper.AssertWasCalled(m => m.Map(view));
        }

        [Test]
        public void should_call_the_snackcontroller()
        {
            controller.AssertWasCalled(c => c.Request(snackDto));
        }
    }
}