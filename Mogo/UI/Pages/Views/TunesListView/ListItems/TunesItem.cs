using System;
using System.ComponentModel;

namespace Mogo
{
	public class TunesItem : INotifyPropertyChanged
	{
		#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this,
					new PropertyChangedEventArgs(propertyName));
			}
		}
		#endregion

		private string _title;
		public string Title {
			get { return _title; }
			set {
				_title = value;
				OnPropertyChanged ("Title");
			}
		}

		private string _author;
		public string Author {
			get { return _author; }
			set {
				_author = value;
				OnPropertyChanged ("Author");
			}
		}

		private string _iconSource;
		public string IconSource {
			get { return _iconSource; }
			set {
				_iconSource = value;
				OnPropertyChanged ("IconSource");
			}
		}
	}
}


