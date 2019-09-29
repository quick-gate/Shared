using QGate.XamarinForms.Controls.Dialogs.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QGate.XamarinForms.Controls.Dialogs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ErrorDialogControl : ContentView
    {
        private ErrorDialogVm _vm = new ErrorDialogVm();
        public ErrorDialogControl()
        {
            InitializeComponent();
            BindingContext = _vm;
        }

        public void Show(Exception exception)
        {
            _vm.DevMessage = exception == null ? null : exception.ToString();
            popupLayout.Show();
        }

        private void ShowDetailButton_Clicked(object sender, EventArgs e)
        {
            DetailPopup.Show(true);
        }
    }
}