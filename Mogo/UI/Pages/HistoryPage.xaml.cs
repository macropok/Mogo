using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Mogo
{
	public partial class HistoryPage : ContentPage
	{
		public HistoryPage ()
		{
			Title = "History";
			InitializeComponent ();

			BindingContext = new HistoryViewModel();
		}
	}
}

