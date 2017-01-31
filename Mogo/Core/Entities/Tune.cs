using System;
using System.Collections.Generic;

namespace Mogo
{
	public class Tune : BaseEntity<string>
	{
		public Tune ()
		{
		}

		public bool IsFavorite {
			get;
			set;
		}

		public DateTime LastPlayed {
			get;
			set;
		}

		public string ImageUrl {
			get;
			set;
		}

		public string Title {
			get;
			set;
		}

		public string Author {
			get;
			set;
		}

		public TimeSpan Duration {
			get;
			set;
		}

		public string TuneUrl {
			get;
			set;
		}

		public class Channels
		{
			public string stationName { get; set; }
			public string stationImage { get; set; }
			public string stationDescroption { get; set; }
		}

		public class ChannelsRoot
		{
			public List<Channels> result { get; set; }
		}


		public class MG_Main
		{
			public string userID { get; set; }
			public string ownerID { get; set; }
			public string channel { get; set; }
			public string location { get; set; }
			public string description { get; set; }
			public string artist { get; set; }
			public string length { get; set; }
			public string id { get; set; }
			public string artistID { get; set; }
			public string album { get; set; }
			public string albumArt { get; set; }
			public string artURL { get; set; }
			public string trackNo { get; set; }
			public string locationUrl { get; set; }
			public string likes { get; set; }
			public string listens { get; set; }
			public string audioID { get; set; }
			public string dateLogged { get; set; }
			public string aboutArtist { get; set; }
			public string aboutAlbum { get; set; }
			public string private_field { get; set; }
			public bool isBookmarked { get; set; }
			public int isVideo { get; set; }
			public int isMessage { get; set; }
		}

		public class MG_MainRoot
		{
			public List<MG_Main> result { get; set; }
		}


	}
}

