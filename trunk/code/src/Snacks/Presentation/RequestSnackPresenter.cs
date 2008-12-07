using System;
using Snacks.Domain;
using Snacks.Dto;
using Utilities.Containers;
using Utilities.Mapping;

namespace Snacks.Presentation
{
    public class RequestSnackPresenter : IRequestSnackPresenter
    {
        private readonly IRequestSnackView view;
        private readonly ISnacksController controller;

        public RequestSnackPresenter(IRequestSnackView requestSnackView)
        {
            view = requestSnackView;
            controller = Container.GetImplementationOf<ISnacksController>();
            
            requestSnackView.RequestSnack += RequestSnack;
        }

        private void RequestSnack(object sender, EventArgs e)
        {
            var snackOrderDto = Map.This(view).ToA<SnackRequestDto>();
            controller.Request(snackOrderDto);
        }
    }
}