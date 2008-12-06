namespace Snacks.Presentation
{
    public interface IPresenterFactory
    {
        IPresenter CreatePresenterFor(IView view);
    }
}