namespace Mobile.ViewModels
{

    public class AbrirPdfViewModel : BaseViewModel
    {
        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged(); }
        }
    }
}
