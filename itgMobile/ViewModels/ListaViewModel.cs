using System;
using itgMobile.ViewModels;
using System.Collections.Generic;
using itgMobile.Models;

namespace itgMobile.ViewModels
{
	public class ListaViewModel : BaseViewModel
	{
		
		private List<ComissaoInfo> _comissoes;
		public List<ComissaoInfo> Comissoes {
			get { return _comissoes; }
			set {
				_comissoes = value;
				OnPropertyChanged ();
			}
		}

		public ListaViewModel ()
		{

		}			

	}
}

