using System;
using Mobile.ViewModels.Services;

namespace Mobile.Views.Services
{
	public class MessageService : IMessageService
	{
		public MessageService ()
		{
		}

		#region IMessageService implementation

		public async System.Threading.Tasks.Task<bool> ShowAsync (string title,string message)
		{
			return await Xamarin.Forms.Application.Current.MainPage.DisplayAlert (title, message, "Sim", "Não");
		}

		#endregion
	
	}
}

