using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text;

namespace Mogo
{

	public class FreePlayViewModel
	{
		public ObservableCollection<UserModel> FreePlaysList { private set; get; }

		public FreePlayViewModel ()
		{
			TuneResultData targetData = new TuneResultData ();
			List<TuneResultContent> items = new List<TuneResultContent> ();
		//	new Task (() => {
				items = targetData.Read ();
				if (FreePlaysList == null || FreePlaysList.Count != items.Count) {
					List<UserModel> itemsForBinding = new List<UserModel> ();
					for (int i = 0; i < items.Count; i++) {
						StringBuilder contentBuilder = new StringBuilder (items [i].album);
						contentBuilder.Append (" - ");
						contentBuilder.Append (items [i].length);
						UserModel single = new UserModel {
							Id = items [i].uniqueid,
							Avatar = items [i].artURL,
							Name = items [i].artist,
							Content = contentBuilder.ToString (),
							Value = 0
						};
						itemsForBinding.Add (single);
					}
			
					FreePlaysList = new ObservableCollection<UserModel> (itemsForBinding);

				
				}
			//}).Start();
		}
	}
}


