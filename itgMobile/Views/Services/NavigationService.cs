using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using itgMobile.ViewModels.Services;

namespace itgMobile.Views.Services
{
	public class NavigationService : INavigationService 
	{
		#region INavigationService implementation

		public async Task NavigateToHome()
		{
			await Application.Current.MainPage.Navigation.PushAsync (new HomeView());
		}

		public async Task NavigateToConsulta()
		{
			await Application.Current.MainPage.Navigation.PushAsync (new ConsultaView());
		}

		public async Task NavigateToLista(ListaView view)
		{
			await Application.Current.MainPage.Navigation.PushAsync (view);
		}

		public async Task NavigateToAbrirPdf()
		{
			await Application.Current.MainPage.Navigation.PushAsync (new AbrirPdfView());
		}

		#endregion
	}
}

