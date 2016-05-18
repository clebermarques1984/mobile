using System.Windows.Input;
using Xamarin.Forms;

namespace Mobile.ViewModels
{
    class HomeViewModel : BaseViewModel
    {
        public ICommand ConsultaCommand { get; }
        public ICommand ExitCommand { get; }

        private readonly Services.INavigationService navigationService;

        public HomeViewModel()
        {
            ConsultaCommand = new Command(Consulta);
            navigationService = DependencyService.Get<Services.INavigationService>();
            //this.ExitCommand = new Command(this.Sair);
        }

        private async void Consulta()
        {
            await navigationService.NavigateToConsulta();
        }

        //private async void Sair()
        //{
        //    //Implements exit function
        //    Mobile.Core.ItgWebService.Especifico.QuitApp();
        //}
    }
}
