using System.Collections.Generic;

namespace Mogo
{
	public class DrawerMenuListData : List<DrawerMenuItem>
	{
		public DrawerMenuListData ()
		{
			this.Add (new DrawerMenuItem () { 
				Title = "Horses", 
				IconSource = "radio.png", 
				TargetType = typeof(HorsesPage)
			});

			this.Add (new DrawerMenuItem () { 
				Title = "Reference Sires", 
				IconSource = "history.png", 
				TargetType = typeof(HistoryPage)
			});

			this.Add (new DrawerMenuItem () { 
				Title = "Sale Info", 
				IconSource = "favorites.png", 
				TargetType = typeof(FavoritesPage)
			});

			this.Add (new DrawerMenuItem () {
				Title = "Favorites",
				IconSource = "freePlays.png",
				TargetType = typeof(FreePlayPage)
			});
			this.Add (new DrawerMenuItem () {
				Title = "Search",
				IconSource = "settings.png",
				TargetType = typeof(SettingsPage)
			});
			this.Add (new DrawerMenuItem () {
				Title = "Help",
				IconSource = "settings.png",
				TargetType = typeof(SettingsPage)
			});


			this.Add (new DrawerMenuItem () {
				Title = "Logout",

				TargetType = typeof(WelcomePage)
			});
		}
	}
}

