using System;
using System.Collections.Generic;
using Mobile.ViewModels;
using Xamarin.Forms;

namespace Mobile.Views
{
	public partial class AbrirPdfView : ContentPage
	{
		public AbrirPdfView ()
		{
            BindingContext = new AbrirPdfViewModel ();
			InitializeComponent ();
		}
	}
}

