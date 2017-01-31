using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mogo
{
	public class HistoryTunesListData : TunesListData
	{
		//TODO: Data integration 5: Matt - Create an event on the ListData
		public event OnHistoryTunesReceivedHandler OnHistoryTunesReceived;

		public delegate void OnHistoryTunesReceivedHandler (TunesListData tuneCollection);

		public TuneManager TargetTunes {
			get;
			set;
		}

		public HistoryTunesListData ()
		{
			//TODO: Data integration 3: Matt - Invoke the manager and subscribe the event
			TargetTunes = new TuneManager ();
			TargetTunes.OnHistoryTunesReceived += TargetTunes_OnHistoryTunesReceived;
			TargetTunes.BeginHistoryTunes ("stevem@adsfactory.com", "51");
		}

		/// <summary>
		/// Targets the tunes on history tunes received.
		/// </summary>
		/// <param name="tuneCollection">Tune collection.</param>
		//TODO: Data integration 4: Matt - Populate the data with the event
		void TargetTunes_OnHistoryTunesReceived (List<Tune> tuneCollection)
		{
			for (int i = 0; i < tuneCollection.Count; i++) {
				this.Add(new TunesItem
					{ 
						IconSource = tuneCollection[i].ImageUrl,
						Title = "Title:" + tuneCollection[i].Title,
						Author = "Author:" + tuneCollection[i].Author
					});
			}
			OnHistoryTunesReceived (this);
		}

	}
}

