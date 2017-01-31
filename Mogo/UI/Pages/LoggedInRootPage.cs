using Xamarin.Forms;

using System;
using System.Collections.Generic;

namespace Mogo
{
	public class LoggedInRootPage : MasterDetailPage
	{
		Dictionary<string,Page> pages;

		public LoggedInRootPage ()
		{
			pages = new Dictionary<string, Page> ();
			NavigationPage.SetHasNavigationBar (this, false);
			var menuPage = new DrawerMenu ();

			menuPage.Menu.ItemSelected += (sender, e) => NavigateTo (e.SelectedItem as DrawerMenuItem);

			Master = menuPage;

			Detail = new NavigationPage (new RadioPage ()) { 
				BarBackgroundColor = Color.FromHex ("5CA0CB"),
				BarTextColor = Color.White
			};

		}

		protected override bool OnBackButtonPressed ()
		{
			return true;
		}

		async void NavigateTo (DrawerMenuItem menu)
		{
			if (menu.TargetType.Name == "WelcomePage") {
				UserManager userManager = new UserManager ();
				userManager.CleanAllData ();
				await Detail.Navigation.PopModalAsync ();
			} else {
				Page displayPage = null;
				if (!pages.ContainsKey (menu.TargetType.Name)) {
					pages.Add (menu.TargetType.Name, (Page)Activator.CreateInstance (menu.TargetType));
				}
				displayPage = pages [menu.TargetType.Name];

				Detail = new NavigationPage (displayPage) { 
					BarBackgroundColor = Color.FromHex ("5CA0CB"),
					BarTextColor = Color.White
				};

				IsPresented = false;
			}
		}
	}
}
