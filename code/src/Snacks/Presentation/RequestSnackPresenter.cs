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
        private readonly ISnackTasks tasks;

        public RequestSnackPresenter(IRequestSnackView requestSnackView)
        {
            view = requestSnackView;
            tasks = Container.GetImplementationOf<ISnackTasks>();
            
            requestSnackView.RequestSnack += RequestSnack;
        }

        private void RequestSnack(object sender, EventArgs e)
        {
            var snackOrderDto = Map.This(view).ToA<SnackRequestDto>();
            tasks.Request(snackOrderDto);
        }
    }
}