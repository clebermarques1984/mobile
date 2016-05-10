using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Mobile.Views
{
	public partial class HomeView : ContentPage
	{
		public HomeView ()
		{
			BindingContext = new ViewModels.HomeViewModel ();
			InitializeComponent ();
		}
	}
}

