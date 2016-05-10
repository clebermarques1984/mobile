namespace Mobile.ViewModels
{

    public class AbrirPdfViewModel : BaseViewModel
    {
        private bool status;
        public bool Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged();
            }
        }

        private string message;
        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                OnPropertyChanged();
            }
        }
    }
}
