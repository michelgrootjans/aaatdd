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
    public class when_snackpresenter_is_told_to_request_a_snack_for_a_user : ArrangeActAssert<IRequestSnackPresenter>
    {
        private ISnacksController controller;
        private IRequestSnackView view;
        private SnackRequestDto snackDto;
        private IMapper<IRequestSnackView, SnackRequestDto> mapper;

        public override void Arrange()
        {
            snackDto = new SnackRequestDto();

            view = Dependency<IRequestSnackView>();
            controller = RegisterDependencyInContainer<ISnacksController>();
            mapper = RegisterDependencyInContainer<IMapper<IRequestSnackView, SnackRequestDto>>();

            mapper.Stub(m => m.Map(view)).Return(snackDto);
        }

        public override IRequestSnackPresenter CreateSUT()
        {
            return new RequestSnackPresenter(view);
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