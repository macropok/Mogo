using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SQLite;

namespace Mogo
{
	public class TuneResultContent : BaseEntity<string>
	{
		public string userID { get; set; }

		public string ownerID { get; set; }

		public string channel { get; set; }

		public string location { get; set; }

		public string description { get; set; }

		public string artist { get; set; }

		public string length { get; set; }

		[JsonProperty(PropertyName ="id")]
		public string uniqueid { 
			get {
				return Key;
			}
			set { 
				Key = value;
			}
		}

		public string artistID { get; set; }

		public string album { get; set; }

		public string albumArt { get; set; }

		public string artURL { get; set; }

		public string trackNo { get; set; }

		public string locationUrl { get; set; }

		public string likes { get; set; }

		public string listens { get; set; }

		public string private_field { get; set; }

		public bool isBookmarked { get; set; }

		public int isVideo { get; set; }

		public int isMessage { get; set; }

		public bool isHistory { get; set; }

		public string audioID { get; set; }

		public string dateLogged { get; set; }

		public string aboutArtist { get; set; }

		public string aboutAlbum { get; set; }
	}

	public class TuneResult : BaseEntity<String>
	{
		public TuneResultContent result { get; set; }
	}

	public class TuneResultList : BaseEntity<String>
	{
		public List<TuneResultContent> result { get; set; }
	}
}

