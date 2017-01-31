using Xamarin.Forms;

namespace Mogo
{
	public class SettingsPage : ContentPage
	{
		public SettingsPage ()
		{
			Title = "Settings";
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Hello Settings" }
				}
			};
		}
	}
}

