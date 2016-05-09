using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace itgMobile.ViewModels
{
	class HomeViewModel : BaseViewModel
	{

		public ICommand ConsultaCommand { get; set; }
		public ICommand ExitCommand { get; set; }

		private readonly Services.INavigationService _navigationService;

		public HomeViewModel()
		{
			this.ConsultaCommand = new Command(this.Consulta);
			this.ExitCommand = new Command(this.Sair);
			this._navigationService = DependencyService.Get<Services.INavigationService>();
		}

		private async void Consulta()
		{
			await this._navigationService.NavigateToConsulta();
		}

		private async void Sair()
		{
            //Implements exit function
            //itgMobile.Core.ItgWebService.itgEspecifico.quitApp();
        }

    }
}
