using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Mogo
{
	public partial class FavoritesPage : ContentPage
	{
		public FavoritesPage ()
		{
			Title = "Favorites";
			InitializeComponent ();

			BindingContext = new FavoritesViewModel();
		}
	}
}

