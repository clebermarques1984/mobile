﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace itgMobile.ViewModels
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		// here's your shared IsBusy property
		private bool _isBusy;

		public bool IsBusy
		{
			get { return _isBusy; }
			set
			{
				_isBusy = value;
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

