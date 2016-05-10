using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Mobile.ViewModels;

namespace Mobile.Views
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

