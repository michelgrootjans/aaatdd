/*
 * Created by: 
 * Created: zondag 7 december 2008
 */

using System;
using Snacks.Domain;
using Utilities.Containers;

namespace Snacks.Presentation
{
    public class ViewSnackRequestsPresenter : IViewSnackRequestsPresenter
    {
        private readonly IViewSnackRequestsView view;
        private readonly ISnackTasks tasks;

        public ViewSnackRequestsPresenter(IViewSnackRequestsView view)
        {
            this.view = view;
            tasks = Container.GetImplementationOf<ISnackTasks>();

            view.GetAllSnackRequests += GetAllSnackRequests;
        }

        private void GetAllSnackRequests(object sender, EventArgs e)
        {
            view.SnackRequests = tasks.GetAllSnackRequests();
        }
    }
}