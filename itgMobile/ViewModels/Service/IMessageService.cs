using System;
using System.Threading.Tasks;

namespace itgMobile.ViewModels.Services
{
	public interface IMessageService
	{
		Task<bool> ShowAsync(string title, string message);
	}
}

