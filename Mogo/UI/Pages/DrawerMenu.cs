using Xamarin.Forms;

namespace Mogo
{
	public class DrawerMenu : ContentPage
	{
		public DrawerMenuListView Menu { get; set; }

		public DrawerMenu ()
		{
			Title = "menu"; 
			Icon = "menu.png";

			BackgroundColor = Color.FromHex ("4B4943");

			Menu = new DrawerMenuListView ();

			var menuLabel = new ContentView {
				Content = new Label {
					Text = "",
					TextColor = Color.FromHex ("777669")
				}
			};

			var menuLogo = new Image () {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Fill,
				Source = ImageSource.FromResource ("Mogo.images.menuLogo.png")
			};
			 menuLogo.HeightRequest = 150;

			var layout = new StackLayout { 
				Spacing = 0, 
				VerticalOptions = LayoutOptions.Start
			};

			layout.Children.Add (menuLabel);
			layout.Children.Add (Menu);
			layout.Children.Add (menuLogo);
			layout.TranslationY = 20;
			Content = layout;
		}
	}
}


