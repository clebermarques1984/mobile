using Xamarin.Forms;
using Mobile.ViewModels;

namespace Mobile.Views
{
    public partial class AbrirPdfView : ContentPage
	{
        public AbrirPdfView()
            : this(new AbrirPdfViewModel())
        {

        }
		public AbrirPdfView (AbrirPdfViewModel viewModel)
		{
            BindingContext = viewModel;
			InitializeComponent ();
		}
	}
}

