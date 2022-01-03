using System;

namespace RentersLife.ViewModels
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string LoginErrorMessage { get; set; }
        public string RegistationErrorMessage { get; set; }
    }
}
