using Xamarin.Forms;

namespace Mogo
{
	public class DrawerMenuCell : ViewCell
	{
		public DrawerMenuCell ()
		{
			var image = new Image
			{
				HorizontalOptions = LayoutOptions.Start
			};
			image.SetBinding(Image.SourceProperty, new Binding("IconSource"));
			image.WidthRequest = image.HeightRequest = 20;
			image.TranslationX = 20;
			StackLayout nameLayout = CreateNameLayout();

			StackLayout viewLayout = new StackLayout()
			{
				Orientation = StackOrientation.Horizontal,
				Children = { image, nameLayout }
			};
			View = viewLayout;
		}

		static StackLayout CreateNameLayout()
		{

			Label titleLabel = new Label
			{
				HorizontalOptions= LayoutOptions.FillAndExpand,
				TextColor = Color.FromHex ("777669")
			};
			titleLabel.SetBinding(Label.TextProperty, "Title");
			titleLabel.TranslationX = 20;
			StackLayout titleLayout = new StackLayout()
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Orientation = StackOrientation.Vertical,
				Children = { titleLabel }
			};
			return titleLayout;
		}
	}
}


