using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace itgMobile.Views
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

