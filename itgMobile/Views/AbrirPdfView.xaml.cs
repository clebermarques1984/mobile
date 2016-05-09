using System;
using System.Collections.Generic;
using itgMobile.ViewModels;
using Xamarin.Forms;

namespace itgMobile.Views
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

