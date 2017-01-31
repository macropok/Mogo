using Xamarin.Forms;
using System.Collections.Generic;

namespace Mogo
{
	public class DrawerMenuListView : ListView
	{

		public DrawerMenuListView ()
		{
			List<DrawerMenuItem> data = new DrawerMenuListData ();

			ItemsSource = data;
			VerticalOptions = LayoutOptions.Fill;
			BackgroundColor = Color.Transparent;
			HeightRequest = 300;

			DataTemplate cell = new DataTemplate (typeof(DrawerMenuCell));

			ItemTemplate = cell;

			SelectedItem = data [0];
		}
	}
}

