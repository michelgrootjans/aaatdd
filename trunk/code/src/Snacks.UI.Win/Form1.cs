using System;
using System.Windows.Forms;
using Snacks.Presentation;

namespace Snacks.UI.Win
{
    public partial class RequestSnackView : Form, ISnackOrderView
    {
        public event EventHandler RequestSnack;

        public RequestSnackView()
        {
            InitializeComponent();
            RequestSnack += delegate { }; //little trick so I don't have to check for a null event handler
        }

        private void RequestSnackView_Load(object sender, EventArgs e)
        {
            btnRequestSnack.Click += delegate { RequestSnack(this, EventArgs.Empty); };

            var factory = Utilities.Containers.Container.GetImplementationOf<IPresenterFactory>();
            factory.CreatePresenterFor(this);
        }

        public string UserId
        {
            get { return txtUserId.Text; }
        }

        public string SnackName
        {
            get { return txtSnack.Text; }
        }

        public string SnackPrice
        {
            get { return "0"; }
        }
    }
}
