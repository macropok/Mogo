using System;

using Xamarin.Forms;
using Xamarin;

namespace Mogo
{
	public class WelcomePage : NavigationPage
	{
		public WelcomePage () : base (new LoggedInRootPage()) //WelcomeContentPage ())
		{
			BarBackgroundColor = Color.FromRgba (175, 189, 34, 80);
			BarTextColor = Color.FromRgba (250, 250, 250, 250);
		}
	}
}


