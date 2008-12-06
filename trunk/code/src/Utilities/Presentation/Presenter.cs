using Utilities.Containers;

namespace Utilities.Presentation
{
    public class Presenter
    {
        public static void Register(IView view)
        {
            var factory = Container.GetImplementationOf<IPresenterFactory>();
            factory.CreatePresenterFor(view);
        }
    }
}