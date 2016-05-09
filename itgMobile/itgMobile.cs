using System;

using Xamarin.Forms;
using itgMobile.Views;

namespace itgMobile
{
	public class App : Application
	{
		public App ()
		{
			DependencyService.Register<ViewModels.Services.IMessageService,Views.Services.MessageService> ();
			DependencyService.Register<ViewModels.Services.INavigationService,Views.Services.NavigationService> ();
			// The root page of your application
			MainPage = new NavigationPage(new HomeView());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

