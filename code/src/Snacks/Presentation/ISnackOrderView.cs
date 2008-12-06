using System;

namespace Snacks.Presentation
{
    public interface ISnackOrderView : IView
    {
        event EventHandler RequestSnack;

        string UserId { get; }
        string SnackName { get; }
        string SnackPrice { get; }
    }
}