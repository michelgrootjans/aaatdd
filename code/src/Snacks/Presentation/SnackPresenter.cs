using System;
using Snacks.Domain;
using Snacks.Dto;
using Utilities.Containers;
using Utilities.Mapping;

namespace Snacks.Presentation
{
    public class SnackPresenter : ISnackPresenter
    {
        private readonly ISnackOrderView view;
        private ISnacksController controller;

        public SnackPresenter(ISnackOrderView snackOrderView)
        {
            view = snackOrderView;
            controller = Container.GetImplementationOf<ISnacksController>();
            
            snackOrderView.RequestSnack += RequestSnack;
        }

        private void RequestSnack(object sender, EventArgs e)
        {
            var snackOrderDto = Map.This(view).ToA<SnackOrderDto>();
            controller.Request(snackOrderDto);
        }
    }
}