using System;

using Xamarin.Forms;

namespace Mogo
{
	public class SigninPage : ContentPage
	{
		Entry email;
		Entry password;
		Button signin;

		protected override void OnDisappearing ()
		{
			password.Text = "";
			base.OnDisappearing ();
		}

		public SigninPage ()
		{
			Title = "Mogo";
			Image backgroundImage = new Image { 
				Source = ImageSource.FromResource ("Mogo.images.login_background.png"),
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Aspect = Aspect.AspectFill
			}; 

			RelativeLayout backgroundLayout = new RelativeLayout () {
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};

			backgroundLayout.Children.Add (backgroundImage, 
				Constraint.Constant (0), 
				Constraint.Constant (0),
				Constraint.RelativeToParent ((parent) => parent.Width ),
				Constraint.RelativeToParent ((parent) => parent.Height ));
			
			email = new Entry () { 
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Placeholder = "Email",
				TextColor = Color.Gray,
				Keyboard = Keyboard.Email
			};

			password = new Entry () { 
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Placeholder = "Password",
				IsPassword = true,
				TextColor = Color.Gray
			};

			email.TextChanged += Email_TextChanged;
			password.TextChanged += Password_TextChanged;

			 signin = new Button {
				HorizontalOptions = LayoutOptions.Center,
				BackgroundColor = Color.FromRgba (175, 189, 34, 50),
				Text = "SIGNIN",
				TextColor = Color.White,
				FontAttributes = FontAttributes.Bold,
				BorderColor = Color.White,
				BorderWidth = 2,
				WidthRequest = 150,
				IsEnabled = false
			};


			StackLayout buttonsLayout = new StackLayout () {
				Padding = 10,
				Orientation = StackOrientation.Vertical,
				BackgroundColor = Color.Transparent,
				Children = { email, password, signin }
			};

			StackLayout generalLayout = new StackLayout () {
				Padding = 10,
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Orientation = StackOrientation.Vertical,
				BackgroundColor = BackgroundColor = Color.FromRgba (255, 255, 255, 100),
				Children = { buttonsLayout }
			};
			backgroundLayout.Children.Add (generalLayout, 
				Constraint.Constant (0), 
				Constraint.Constant (0),
				Constraint.RelativeToParent ((parent) => parent.Width),
				Constraint.RelativeToParent ((parent) => parent.Height));
			signin.Clicked += Signin_Clicked;

			Content = backgroundLayout;
		}

		void Password_TextChanged (object sender, TextChangedEventArgs e)
		{
			bool areDataComplete = !String.IsNullOrEmpty (e.NewTextValue) && !String.IsNullOrEmpty (email.Text);
			signin.IsEnabled = areDataComplete;
		}

		void Email_TextChanged (object sender, TextChangedEventArgs e)
		{
			bool areDataComplete = !String.IsNullOrEmpty (e.NewTextValue) && !String.IsNullOrEmpty (password.Text);
			signin.IsEnabled = areDataComplete;
		}

		async void Signin_Clicked (object sender, EventArgs e)
		{
			UserService userService = new UserService ();
			userService.ResponseReceived += UserService_ResponseReceived;
			//await userService.Login (email.Text, password.Text);
			await Navigation.PushAsync(new LoggedInRootPage());
		}

		async void UserService_ResponseReceived (User item)
		{
			UserManager userManager = new UserManager ();
			if (!String.IsNullOrEmpty (item.Key)) {
				userManager.CleanAllData ();
				userManager.Create (item);
				await Navigation.PushModalAsync (new LoggedInRootPage ());
			} else {
				bool answer = await DisplayAlert ("Login Error", "Username and Password not valid", "OK", "Forgot Password");
				if (answer == false) {
					await Navigation.PopToRootAsync ();
					var url = "http://mogoradio.com/Security/ForgotUser.aspx?email=" + item.Email;
					Device.OpenUri (new Uri (url));
				}
			}
		}
	}
}


