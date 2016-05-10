using System;
using System.Threading.Tasks;
using Mobile.Views;

namespace Mobile.ViewModels.Services
{
	public interface INavigationService
	{
		Task NavigateToHome();
		Task NavigateToConsulta();
		Task NavigateToLista(ListaView view);
		Task NavigateToAbrirPdf(AbrirPdfView view);
	}
}

