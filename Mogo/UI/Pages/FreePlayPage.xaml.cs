using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Mogo
{
	public partial class FreePlayPage : ContentPage
	{
		
		public FreePlayPage ()
		{
			Title = "Free Plays";
			InitializeComponent ();

			BindingContext = new FreePlayViewModel();
		}
	}
}

