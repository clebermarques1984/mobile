using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Mobile.ViewModels
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		// here's your shared IsBusy property
		private bool isBusy;

		public bool IsBusy
		{
			get { return isBusy; }
			set
			{
				isBusy = value;
				// again, this is very important
				OnPropertyChanged();
			}
		}

		// this little bit is how we trigger the PropertyChanged notifier.
		public event PropertyChangedEventHandler PropertyChanged;

		public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

