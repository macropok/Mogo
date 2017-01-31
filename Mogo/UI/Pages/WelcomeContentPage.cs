using System;

using Xamarin.Forms;

namespace Mogo
{
	public class WelcomeContentPage : ContentPage
	{
		public WelcomeContentPage ()
		{

			NavigationPage.SetHasNavigationBar (this, false);
			Padding = 0;
			Image backgroundImage = new Image { 
				Source = ImageSource.FromResource ("Mogo.images.login_background.png"),
				Aspect = Aspect.AspectFill
			};

			RelativeLayout backgroundLayout = new RelativeLayout () {
				TranslationX = 0,
				TranslationY = 0,
				Padding = 0,
				VerticalOptions = LayoutOptions.Fill,
				HorizontalOptions = LayoutOptions.Fill
			};


			backgroundLayout.Children.Add (backgroundImage, 
				Constraint.Constant (0), 
				Constraint.Constant (0),
				Constraint.RelativeToParent ((parent) => parent.Width ),
				Constraint.RelativeToParent ((parent) => parent.Height));

			Button signin = new Button {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				BackgroundColor = Color.FromRgb (0, 182, 221),
				Text = "SIGN IN",
				WidthRequest = 110,
				TextColor = Color.White,
				FontAttributes = FontAttributes.Bold
			};

			Button signup = new Button {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				BackgroundColor = Color.FromRgb (175, 189, 34),
				Text = "SIGN UP",
				WidthRequest = 110,
				TextColor = Color.White,
				FontAttributes = FontAttributes.Bold
			};

			Image logo = new Image {
				Source = ImageSource.FromResource ("Mogo.images.mogo_logo_big_white.png"),
				BackgroundColor = Color.Transparent,
				HeightRequest = 200,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.FillAndExpand,
				TranslationY = 100
			};

			StackLayout buttonsLayout = new StackLayout () {
				
				Padding = 10,
				VerticalOptions = LayoutOptions.EndAndExpand,
				Orientation = StackOrientation.Horizontal,
				BackgroundColor = Color.Transparent,
				Children = { signin, signup }
			};

			StackLayout generalLayout = new StackLayout () {
				Padding = 10,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Orientation = StackOrientation.Vertical,
				BackgroundColor = Color.Transparent,
				Children = { logo, buttonsLayout }
			};

			backgroundLayout.Children.Add (generalLayout, 
				Constraint.Constant (0), 
				Constraint.Constant (0),
				Constraint.RelativeToParent ((parent) => parent.Width),
				Constraint.RelativeToParent ((parent) => parent.Height));
			
			Content = backgroundLayout;

			signin.Clicked += Signin_Clicked;
			signup.Clicked += Signup_Clicked;
		}

		void Signup_Clicked (object sender, EventArgs e)
		{
			Navigation.PushAsync (new SignupPage (), false);
		}

		void Signin_Clicked (object sender, EventArgs e)
		{
			Navigation.PushAsync (new SigninPage (), false);
		}
	}

}