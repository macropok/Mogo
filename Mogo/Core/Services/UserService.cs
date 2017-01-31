using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Mogo
{
	public class UserService : BaseService<User,string>
	{
		#region implemented abstract members of BaseService

		protected override string LocalApiUrl {
			get {
				return Configuration.ApiUrl;
			}
		}

		#endregion

		public UserService ()
		{
		}

		//private const string APILocation = "http://beta.mogoradio.com/json/syncreply/";

		public async Task<string> Register (string email, string password, string name)
		{
			HttpHelper httpHelper = new HttpHelper ();
			StringBuilder url = new StringBuilder (Configuration.ApiUrl);
			url.Append ("addNewMogoUser?emailAddress=");
			url.Append (email);
			url.Append ("&first=");
			url.Append (name);
			url.Append ("&password=");
			url.Append (password);
			url.Append ("&last=---&token=---");


			//	string apiCall = string.Format (LocalApiUrl + "{0}?emailAddress={1}&first={2}&last={3}&token={4}&fbid={5}", "addNewMogoUser", email, first, last, token, FBID);
			string response = await httpHelper.GET (url.ToString ());
			JObject jsonObject = JObject.Parse (response);
			string key = JsonConvert.DeserializeObject<string> (jsonObject ["result"].ToString ());

			OnResponseReceived (new User{ Email = email, Password = password, Name = name, Key = key });
			return response;
			//	await httpHelper.GET(
		}

		public async Task<string> Login (string email, string password)
		{
			HttpHelper httpHelper = new HttpHelper ();
			StringBuilder url = new StringBuilder (Configuration.ApiUrl);
			url.Append ("getLogin?email=");
			url.Append (email);
			url.Append ("&password=");
			url.Append (password);

			string response = await httpHelper.GET (url.ToString ());
			JObject jsonObject = JObject.Parse (response);
			string key = JsonConvert.DeserializeObject<string> (jsonObject ["result"].ToString ());

			OnResponseReceived (new User{ Email = email, Password = password, Key = key });
			return response;
		}


		//		public static async Task<User.NewUserID> addNewMogoUser (string email, string token, string first, string last, string FBID)
		//		{
		//			var client = new HttpClient ();
		//
		//			string apiCall = string.Format (APILocation + "{0}?emailAddress={1}&first={2}&last={3}&token={4}&fbid={5}", "addNewMogoUser", email, first, last, token, FBID);
		//
		//
		//			var msg = await client.GetAsync (apiCall);
		//			if (msg.IsSuccessStatusCode) {
		//				using (var stream = await msg.Content.ReadAsStreamAsync ()) {
		//					using (var streamReader = new StreamReader (stream)) {
		//						var str = await streamReader.ReadToEndAsync ();
		//						var obj = await Task.Factory.StartNew (() => JsonConvert.DeserializeObject<User.NewUserID> (str));
		//						return obj;
		//					}
		//				}
		//			}
		//			return null;
		//		}
		/*
		 * MoGo Users Fields
[id] int NOT NULL IDENTITY(1,1) ,
[DataCappID] varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
[email] varchar(200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
[token] varchar(300) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
[fbid] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
[first] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
[last] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
[aboutMe] text COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
[Address] varchar(200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
[City] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
[state] varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
[cell] varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
[home] varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
[bookmarks] varchar(10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
[zip] varchar(15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
[photo] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
[level] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
[hideEmail] varchar(10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
[bookmarksInt] int NULL ,
[userLevel] varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
[password] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,

usage:  To Get a MoGoUser by email: getMogoUsers("email",userEmail,"");

So, getMogoUsers(FieldFromAbove,valueToLookInField,NotUsed);

		 */

		public static async Task<User.MG_UserRoot> getMogoUsers (string field, string fieldVal, string userID)
		{
			var client = new HttpClient ();

			string apiCall = string.Format ("{0}{1}?field={2}&FieldVal={3}&userID={4}", Configuration.ApiUrl, "getMogoUsers", field, fieldVal, userID);

			var msg = await client.GetAsync (apiCall);
			if (msg.IsSuccessStatusCode) {
				using (var stream = await msg.Content.ReadAsStreamAsync ()) {
					using (var streamReader = new StreamReader (stream)) {
						var str = await streamReader.ReadToEndAsync ();
						var obj = await Task.Factory.StartNew (() => JsonConvert.DeserializeObject<User.MG_UserRoot> (str));
						return obj;
					}
				}
			}
			return null;
		}

	}
}

