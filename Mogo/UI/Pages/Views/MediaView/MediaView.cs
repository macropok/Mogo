using System;

using Xamarin.Forms;

namespace Mogo
{
	public class MediaView : View
	{
		public Action StopAction;

		public MediaView ()
		{

		}

		public static readonly BindableProperty FileSourceProperty = 
			BindableProperty.Create<MediaView,string> (
				p => p.FileSource, string.Empty);

		public string FileSource {
			get { return (string)GetValue (FileSourceProperty); }
			set { SetValue (FileSourceProperty, value); }
		}

		public void Stop ()
		{
			if (StopAction != null)
				StopAction ();
		}
	}
}


