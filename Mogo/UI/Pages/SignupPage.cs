using System;

using Xamarin.Forms;

namespace Mogo
{
	public class SignupPage : ContentPage
	{
		Entry name;
		Entry email;
		Entry password;
		Button signup;

		public SignupPage ()
		{
			Title = "Mogo";
			Image backgroundImage = new Image {
				Source = ImageSource.FromResource ("Mogo.images.login_background.png"),
				Aspect = Aspect.AspectFill
		
			}; 

			RelativeLayout backgroundLayout = new RelativeLayout () {
				Padding = 0,
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};

			backgroundLayout.Children.Add (backgroundImage, 
				Constraint.Constant (0), 
				Constraint.Constant (0),
				Constraint.RelativeToParent ((parent) => parent.Width),
				Constraint.RelativeToParent ((parent) => parent.Height));
			
			name = new Entry () { 
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Placeholder = "Name",
				TextColor = Color.Gray
			};

			email = new Entry () { 
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Placeholder = "Email address",
				TextColor = Color.Gray,
				Keyboard = Keyboard.Email
			};

			password = new Entry () { 
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Placeholder = "Password",
				IsPassword = true,
				TextColor = Color.Gray
			};

			name.TextChanged += Name_TextChanged;
			email.TextChanged += Email_TextChanged;
			password.TextChanged += Password_TextChanged;

			signup = new Button {
				HorizontalOptions = LayoutOptions.Center,
				BackgroundColor = Color.FromRgba (175, 189, 34, 50),
				Text = "SIGNUP",
				TextColor = Color.White,
				FontAttributes = FontAttributes.Bold,
				BorderColor = Color.White,
				BorderWidth = 2,
				WidthRequest = 150,
				IsEnabled = false
			};
			signup.Clicked += Signup_Clicked;

			StackLayout buttonsLayout = new StackLayout () {
				Padding = 10,
				Orientation = StackOrientation.Vertical,
				BackgroundColor = Color.Transparent,
				Children = { name, email, password, signup }
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

			Content = backgroundLayout;
		}

		void Password_TextChanged (object sender, TextChangedEventArgs e)
		{
			bool areDataComplete = !String.IsNullOrEmpty (e.NewTextValue) && !String.IsNullOrEmpty (email.Text) && !String.IsNullOrEmpty (email.Text);
			signup.IsEnabled = areDataComplete;
		}

		void Email_TextChanged (object sender, TextChangedEventArgs e)
		{
			bool areDataComplete = !String.IsNullOrEmpty (e.NewTextValue) && !String.IsNullOrEmpty (password.Text) && !String.IsNullOrEmpty (name.Text);
			signup.IsEnabled = areDataComplete;
		}

		void Name_TextChanged (object sender, TextChangedEventArgs e)
		{
			bool areDataComplete = !String.IsNullOrEmpty (e.NewTextValue) && !String.IsNullOrEmpty (password.Text) && !String.IsNullOrEmpty (email.Text);
			signup.IsEnabled = areDataComplete;
		}

		async void Signup_Clicked (object sender, EventArgs e)
		{
			UserService userService = new UserService ();
			userService.ResponseReceived += UserService_ResponseReceived;
			await userService.Register (email.Text, password.Text, name.Text);
		}

		async void UserService_ResponseReceived (User item)
		{
			UserManager userManager = new UserManager ();
			if (!String.IsNullOrEmpty (item.Key)) {
				userManager.CleanAllData ();
				userManager.Create (item);
				await Navigation.PushModalAsync (new LoggedInRootPage ());
			} else {
				bool answer = await DisplayAlert ("Registration Error", "Email Already Registered", "OK", "Forgot Password");
				if (answer == false) {
					await Navigation.PopToRootAsync ();
					var url = "http://mogoradio.com/Security/ForgotUser.aspx?email=" + item.Email;
					Device.OpenUri (new Uri (url));
				}
			}
		}
			
	}
}


