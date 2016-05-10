using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Mobile.ViewModels;

namespace Mobile.Views
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

