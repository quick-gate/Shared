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
            _vm.Message = ErrorDialogVm.CustomMessage;
            popupLayout.Show();
        }

        public void Show(string message)
        {
            _vm.DevMessage = message;
            _vm.Message = ErrorDialogVm.CustomMessage;
            popupLayout.Show();
        }

        public void Show(string message, string devMessage)
        {
            _vm.Message = string.IsNullOrWhiteSpace(message) ? ErrorDialogVm.CustomMessage : message;
            _vm.DevMessage = devMessage;
            popupLayout.Show();
        }

        private void ShowDetailButton_Clicked(object sender, EventArgs e)
        {
            DetailPopup.Show(true);
        }
    }
}