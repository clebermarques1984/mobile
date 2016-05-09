using System;
using System.Collections.Generic;
using Xamarin.Forms;
using itgMobile.ViewModels;

namespace itgMobile.Views
{
	public partial class ListaView : ContentPage
	{
		public ListaView ()
		{
			BindingContext = new ListaViewModel ();
			InitializeComponent ();
		}
	}
}

