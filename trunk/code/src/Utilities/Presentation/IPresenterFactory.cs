namespace Utilities.Presentation
{
    public interface IPresenterFactory
    {
        IPresenter CreatePresenterFor(IView view);
    }
}