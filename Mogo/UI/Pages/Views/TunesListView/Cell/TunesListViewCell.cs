using Xamarin.Forms;

namespace Mogo
{
	public class TunesListViewCell : ViewCell
	{
		public TunesListViewCell ()
		{
			var image = new Image
			{
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.FillAndExpand
			};
			image.SetBinding(Image.SourceProperty, new Binding("IconSource"));

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
				TextColor = Color.FromHex ("808071"),
				FontSize = 10
			};
			titleLabel.SetBinding(Label.TextProperty, "Title");
		
			Label authorLabel = new Label
			{
				HorizontalOptions= LayoutOptions.FillAndExpand,
				TextColor = Color.FromHex ("ECECEC"),
				FontSize = 15,
				FontAttributes = FontAttributes.Bold
			};
			authorLabel.SetBinding(Label.TextProperty, "Author");


			var progressBar = new ProgressBar ();
			progressBar.HorizontalOptions = LayoutOptions.FillAndExpand;
			progressBar.VerticalOptions = LayoutOptions.End;
	        
			StackLayout titleLayout = new StackLayout()
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Orientation = StackOrientation.Vertical,
				Children = { authorLabel, titleLabel, progressBar }
			};
			return titleLayout;
		}
	}
}


