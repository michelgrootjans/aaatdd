/*
 * Created by: 
 * Created: zondag 7 december 2008
 */

using System;
using Snacks.Domain;
using Utilities.Containers;
using Utilities.Presentation;

namespace Snacks.Presentation
{
    public class ViewSnackRequestsPresenter : IViewSnackRequestsPresenter
    {
        private readonly IViewSnackRequestsView view;
        private readonly ISnacksController controller;

        public ViewSnackRequestsPresenter(IViewSnackRequestsView view)
        {
            this.view = view;
            controller = Container.GetImplementationOf<ISnacksController>();

            view.GetAllSnackRequests += GetAllSnackRequests;
        }

        private void GetAllSnackRequests(object sender, EventArgs e)
        {
            view.SnackRequests = controller.GetAllSnackRequests();
        }
    }
}