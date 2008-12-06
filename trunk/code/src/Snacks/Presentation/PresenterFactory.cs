/*
 * Created by: 
 * Created: zaterdag 6 december 2008
 */

using Utilities.Presentation;

namespace Snacks.Presentation
{
    public class PresenterFactory : IPresenterFactory
    {
        public IPresenter CreatePresenterFor(IView view)
        {
            return new SnackPresenter(view as ISnackOrderView);
        }
    }
}