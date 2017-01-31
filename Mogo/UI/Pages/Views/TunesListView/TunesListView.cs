using Xamarin.Forms;
using System.Collections.Generic;

namespace Mogo
{
	public class TunesListView : ListView
	{
		private TunesListData _data;

		public TunesListData Data {
			get
			{ 
				return _data; 
			}
			set {
				_data = value;
			}
		}

		public TunesListView (TunesListData data)
		{
			//SeparatorVisibility = SeparatorVisibility.None;
			VerticalOptions = LayoutOptions.Fill;
			BackgroundColor = Color.FromHex ("2C2B25");
			Update (data);
		}

		public void Update (TunesListData data)
		{
			Data = data;
			ItemsSource = Data;
			DataTemplate cell = new DataTemplate (typeof(TunesListViewCell));
			ItemTemplate = cell;
		}
	}
}


