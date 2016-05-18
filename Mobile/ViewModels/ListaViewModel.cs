using System.Collections.Generic;
using Mobile.Models;

namespace Mobile.ViewModels
{
    public class ListaViewModel : BaseViewModel
	{
		private List<ComissaoInfo> comissoes;
		public List<ComissaoInfo> Comissoes {
			get { return comissoes; }
			set { comissoes = value; OnPropertyChanged (); }
		}
	}
}

