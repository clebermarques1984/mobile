using itgMobile.Core;

namespace itgMobile.ViewModels
{

    public class AbrirPdfViewModel : BaseViewModel
    {
        private bool _status;
        public bool Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged();
            }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        public AbrirPdfViewModel()
        {

        }
    }
}
