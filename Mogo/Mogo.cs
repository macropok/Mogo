using Xamarin.Forms;

namespace Mogo
{

	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			MainPage = new WelcomePage ();
			//MainPage = new DrawerMenu();
		}

		protected override void OnStart ()
		{
			
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{

		}
	}
}
