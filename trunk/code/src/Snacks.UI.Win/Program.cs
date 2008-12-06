using System;
using System.Windows.Forms;

namespace Snacks.UI.Win
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationStartup.Run();
            Application.Run(new RequestSnackView());
        }
    }
}