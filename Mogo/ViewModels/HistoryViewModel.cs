using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mogo
{
	public class HistoryViewModel
	{
		public ObservableCollection<UserModel> HistoryList { private set; get; }

		public HistoryViewModel ()
		{
			HistoryList = new ObservableCollection<UserModel> ();
			new Task (() => {
				TuneResultData targetData = new TuneResultData ();
				List<TuneResultContent> items = new List<TuneResultContent> ();
				items = targetData.Read ();
				items = items.FindAll (x => x.isHistory);
				HistoryList = new ObservableCollection<UserModel> ();

				for (int i = 0; i < items.Count; i++) {
					HistoryList.Add (new UserModel {
						Id = items [i].uniqueid,
						Avatar = items [i].artURL,
						Name = items [i].artist,
						Content = String.Format ("{0} - {1}", items [i].album, items [i].length),
						Value = 0
					});
				}
			}).Start ();
		}
	}
}


