using System;

namespace Snacks.Presentation
{
    public interface ISnackOrderView
    {
        event EventHandler RequestSnack;

        long UserId { get; }
        string SnackName { get; }
        double SnackPrice { get; }
    }
}