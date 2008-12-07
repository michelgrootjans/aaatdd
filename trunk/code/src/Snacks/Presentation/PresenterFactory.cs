/*
 * Created by: 
 * Created: zaterdag 6 december 2008
 */

using System;
using Utilities.Presentation;

namespace Snacks.Presentation
{
    public class PresenterFactory : IPresenterFactory
    {
        public IPresenter CreatePresenterFor(IView view)
        {
            if (view is IRequestSnackView)
                return new RequestSnackPresenter(view as IRequestSnackView);
            if (view is IViewSnackRequestsView)
                return new ViewSnackRequestsPresenter(view as IViewSnackRequestsView);

            throw new InvalidOperationException(string.Format("Couldn't find a presenter for '{0}'", view));
        }
    }
}