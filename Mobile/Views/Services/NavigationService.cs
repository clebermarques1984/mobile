using System.Threading.Tasks;
using Xamarin.Forms;
using Mobile.ViewModels.Services;

namespace Mobile.Views.Services
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

		public async Task NavigateToAbrirPdf(AbrirPdfView view)
		{
			await Application.Current.MainPage.Navigation.PushAsync (view);
		}

		#endregion
	}
}

