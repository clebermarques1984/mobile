using Xamarin.Forms;
using Mobile.ViewModels;

namespace Mobile.Views
{
    public partial class ListaView : ContentPage
	{
        public ListaView()
            :this(new ListaViewModel())
        {

        }
		public ListaView (ListaViewModel viewModel)
		{
			BindingContext = viewModel;
			InitializeComponent ();
		}
	}
}

