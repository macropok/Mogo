using System;
using Xamarin.Forms;
namespace Mogo
{
	public class HorseView : ContentPage
	{
		Image horseImage;
		WebView webView;
		public HorseView (String ID)
		{
			horseImage = new Image{
				Source = ImageSource.FromResource("Mogo.images.horse.png"),
			};
			horseImage.SetBinding (Image.SourceProperty, "horseImage");

			webView = new WebView{
			};
			webView.SetBinding (WebView.SourceProperty, "webView");

			Grid grid = new Grid {
				HorizontalOptions=LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.Fill,
				RowDefinitions = {
					new RowDefinition {Height = new GridLength(1, GridUnitType.Star)},
					new RowDefinition {Height = new GridLength(1, GridUnitType.Star)}
				},
				ColumnDefinitions={
					new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)}
				}
					
			};

			grid.Children.Add (horseImage,0,0);
			grid.Children.Add (webView,0,1);
			Content = grid;

		}
	}
}

