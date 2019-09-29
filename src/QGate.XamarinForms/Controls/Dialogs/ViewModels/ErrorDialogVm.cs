﻿using QGate.XamarinForms.Mvvm;

namespace QGate.XamarinForms.Controls.Dialogs.ViewModels
{
    public class ErrorDialogVm: VmBase
    {
        private string _message = "Oops! Something went worng. Please try again later.";
        private string _devMessage;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public string DevMessage
        {
            get { return _devMessage; }
            set { SetProperty(ref _devMessage, value); }
        }
    }
}
