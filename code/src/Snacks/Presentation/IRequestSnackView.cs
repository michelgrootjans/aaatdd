using System;
using Utilities.Presentation;

namespace Snacks.Presentation
{
    public interface IRequestSnackView : IView
    {
        event EventHandler RequestSnack;

        string UserId { get; }
        string SnackName { get; }
        string SnackPrice { get; }
    }
}