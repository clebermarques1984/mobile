using System;
using System.Threading.Tasks;
using itgMobile.Views;

namespace itgMobile.ViewModels.Services
{
	public interface INavigationService
	{
		Task NavigateToHome();
		Task NavigateToConsulta();
		Task NavigateToLista(ListaView view);
		Task NavigateToAbrirPdf(AbrirPdfView view);
	}
}

