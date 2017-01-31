using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Mogo
{
	public class TuneService : BaseService<Tune,string>
	{
		#region implemented abstract members of BaseService

		protected override string LocalApiUrl {
			get {
				return Configuration.ApiUrl;
			}
		}

		#endregion

		public TuneService ()
		{
		}

		//private const string ApiToken = "h524hezne2gmh29nf5waqtpw";
		private static string APILocation = Configuration.ApiUrl;

		//http://beta.mogoradio.com/getrandomaudio?field=channel&fieldVal=Fast%20Start%20School&format=json
		/*
[userID] varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
[ownerID] varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
[channel] varchar(250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
[location] varchar(250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
[description] text COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
[artist] varchar(250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
[length] varchar(250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
[id] int NOT NULL IDENTITY(1,1) ,
[artistID] varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
[album] varchar(250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
[track] varchar(250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
[albumArt] varchar(250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
[dataAdded] datetime NULL ,
[private] varchar(10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
[likes] int NULL ,
[listens] int NULL ,
[aboutArtist] text COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
[aboutAlbum] text COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
[isMessage] int NULL ,
[isVideo] int NULL ,
[artistCity] varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
[artistState] varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
[artistStartMonth] varchar(12) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
[artistStartYear] varchar(4) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
[artistFormerJob] varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
[artistIncome] varchar(12) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,

Usage: To get all audio by a particular artist

getAudioByField("artist",ArtistName,UserID)


		 */




		public static async Task<Tune.MG_MainRoot> getAudioByField (string field, string fieldVal, string userID) //supply field from list above and supply value in field to match, supply userID to be used in activity
		{
			var client = new HttpClient ();

			string apiCall = string.Format ("{4}{0}?field={1}&FieldVal={2}&userID={3}", "getAudioByField", field, fieldVal, userID, APILocation);

			var msg = await client.GetAsync (apiCall);
			if (msg.IsSuccessStatusCode) {
				using (var stream = await msg.Content.ReadAsStreamAsync ()) {
					using (var streamReader = new StreamReader (stream)) {
						var str = await streamReader.ReadToEndAsync ();
						//	var obj = await Task.Factory.StartNew
						var obj = await Task.Factory.StartNew (() => JsonConvert.DeserializeObject<Tune.MG_MainRoot> (str));
						return obj;
					}
				}
			}
			return null;
		}

		//generates a random audioObject when field supplied from above list of fields and a value to match is supplied by fieldVal
		public static async Task<Tune.MG_MainRoot> getRandomAudio (string field, string fieldVal, string userID) //supply field from list above and supply value in field to match, supply userID to be used in activity
		{
			var client = new HttpClient ();

			string apiCall = string.Format ("{4}{0}?field={1}&FieldVal={2}&userID={3}", "getRandomAudio", field, fieldVal, userID, APILocation);

			var msg = await client.GetAsync (apiCall);
			if (msg.IsSuccessStatusCode) {
				using (var stream = await msg.Content.ReadAsStreamAsync ()) {
					using (var streamReader = new StreamReader (stream)) {
						var str = await streamReader.ReadToEndAsync ();
						//	var obj = await Task.Factory.StartNew
						var obj = await Task.Factory.StartNew (() => JsonConvert.DeserializeObject<Tune.MG_MainRoot> (str));
						return obj;
					}
				}
			}
			return null;
		}

		//returns the next audio track when passed the audioID of the current track
		public static async Task<Tune.MG_MainRoot> getNextAudioTrack (string audioID, string userID) //supply field from list above and supply value in field to match, supply userID to be used in activity
		{
			var client = new HttpClient ();

			string apiCall = string.Format ("{3}{0}?audioID={1}&userID={2}", "getNextAudioTrack", audioID, userID, APILocation);

			var msg = await client.GetAsync (apiCall);
			if (msg.IsSuccessStatusCode) {
				using (var stream = await msg.Content.ReadAsStreamAsync ()) {
					using (var streamReader = new StreamReader (stream)) {
						var str = await streamReader.ReadToEndAsync ();
						//	var obj = await Task.Factory.StartNew
						var obj = await Task.Factory.StartNew (() => JsonConvert.DeserializeObject<Tune.MG_MainRoot> (str));
						return obj;
					}
				}
			}
			return null;
		}

		//returns the previous audio track when passed the audioID of the current track
		public static async Task<Tune.MG_MainRoot> getPrevAudioTrack (string audioID, string userID) //supply field from list above and supply value in field to match, supply userID to be used in activity
		{
			var client = new HttpClient ();

			string apiCall = string.Format ("{3}{0}?audioID={1}&userID={2}", "getPrevAudioTrack", audioID, userID, APILocation);

			var msg = await client.GetAsync (apiCall);
			if (msg.IsSuccessStatusCode) {
				using (var stream = await msg.Content.ReadAsStreamAsync ()) {
					using (var streamReader = new StreamReader (stream)) {
						var str = await streamReader.ReadToEndAsync ();
						//	var obj = await Task.Factory.StartNew
						var obj = await Task.Factory.StartNew (() => JsonConvert.DeserializeObject<Tune.MG_MainRoot> (str));
						return obj;
					}
				}
			}
			return null;
		}

		//returns all albums by artist supplied in the artist paramemeter
		public static async Task<Tune.MG_MainRoot> getAlbumsByArtists (string artist, string userID) //supply field from list above and supply value in field to match, supply userID to be used in activity
		{
			var client = new HttpClient ();

			string apiCall = string.Format ("{3}{0}?audioID={1}&userID={2}", "getAlbumsByArtists", artist, userID, APILocation);

			var msg = await client.GetAsync (apiCall);
			if (msg.IsSuccessStatusCode) {
				using (var stream = await msg.Content.ReadAsStreamAsync ()) {
					using (var streamReader = new StreamReader (stream)) {
						var str = await streamReader.ReadToEndAsync ();
						//	var obj = await Task.Factory.StartNew
						var obj = await Task.Factory.StartNew (() => JsonConvert.DeserializeObject<Tune.MG_MainRoot> (str));
						return obj;
					}
				}
			}
			return null;
		}

		public static async Task<Tune.ChannelsRoot> GetChannels (string userID) //returns all channels (stations)
		{
			var client = new HttpClient ();

//			string sdff = APILocation + "getChannels?field=&fieldVal&userID=51";


			var msg = await client.GetAsync (APILocation + "getChannels?field=&fieldVal&userID=51");
			if (msg.IsSuccessStatusCode) {
				using (var stream = await msg.Content.ReadAsStreamAsync ()) {
					using (var streamReader = new StreamReader (stream)) {
						var str = await streamReader.ReadToEndAsync ();
						var obj = await Task.Factory.StartNew (() => JsonConvert.DeserializeObject<Tune.ChannelsRoot> (str));
						return obj;
					}
				}
			}
			return null;
		}




	}



}




	
