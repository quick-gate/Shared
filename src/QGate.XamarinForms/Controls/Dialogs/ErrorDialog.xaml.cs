using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QGate.XamarinForms.Controls.Dialogs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ErrorDialog : ContentView
    {
        public ErrorDialog()
        {
            InitializeComponent();
        }

        public void Show()
        {
            popupLayout.Show();
        }
    }
}