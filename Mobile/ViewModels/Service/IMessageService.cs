using System;
using System.Threading.Tasks;

namespace Mobile.ViewModels.Services
{
	public interface IMessageService
	{
		Task<bool> ShowAsync(string title, string message);
	}
}

