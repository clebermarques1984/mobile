using System;
using System.Collections.Generic;

using Xamarin.Forms;
using itgMobile.ViewModels;

namespace itgMobile.Views
{
	public partial class ConsultaView : ContentPage
	{
		public ConsultaView ()
		{
			BindingContext = new ConsultaViewModel ();
			InitializeComponent ();
		}
	}
}

