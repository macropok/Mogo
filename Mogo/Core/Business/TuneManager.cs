using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mogo
{
	public class TuneManager : BaseBusiness<Tune,string>
	{
		//TODO: Data integration 1: Steve - Write the Event that will be raised when the data are available
		public event OnHistoryTunesReceivedHandler OnHistoryTunesReceived;

		public delegate void OnHistoryTunesReceivedHandler (List<Tune> tuneCollection);

		public TuneManager () : base (new TuneData ())
		{
		}

		//TODO: Data integration 2: Steve - Write the Async call
		public async void BeginHistoryTunes (string email, string userId)
		{
			List<Tune> tunes = new List<Tune> ();
			Mogo.User.MG_UserRoot e = await UserService.getMogoUsers ("email", email, userId);
			for (int i = 0; i < e.result.Count; i++) {
				
				tunes.Add (new Tune {
					ImageUrl = e.result [i].photo,
					Title = e.result [i].first + " " + e.result [i].last,
					Author = e.result [i].aboutMe
				});
			}
			if (OnHistoryTunesReceived != null) {
				OnHistoryTunesReceived (tunes);
			}
		}
		//Steve - the following are calls to the API that return the requested object.
		//getAudioByField and getMogoUsers both return a list of records that match the request. Argument 1 is the field in the
		//table and arguement 2 is the value to seach for

		//User Table Fields
		/*
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DataCappID] [varchar](20) NULL,
	[email] [varchar](200) NULL,
	[token] [varchar](300) NULL,
	[fbid] [varchar](50) NULL,
	[first] [varchar](50) NULL,
	[last] [varchar](50) NULL,
	[aboutMe] [text] NULL,
	[Address] [varchar](200) NULL,
	[City] [varchar](50) NULL,
	[state] [varchar](20) NULL,
	[cell] [varchar](20) NULL,
	[home] [varchar](20) NULL,
	[bookmarks] [varchar](10) NULL,
	[zip] [varchar](15) NULL,
	[photo] [varchar](255) NULL,
	[level] [varchar](255) NULL,
	[hideEmail] [varchar](10) NULL,
	[bookmarksInt] [int] NULL,
	[userLevel] [varchar](100) NULL,
	[password] [varchar](50) NULL,
			 */

		//MG_Main Table
		/*
			 * [userID] [varchar](20) NULL,
	[ownerID] [varchar](20) NULL,
	[channel] [varchar](250) NULL,
	[location] [varchar](250) NULL,
	[description] [text] NULL,
	[artist] [varchar](250) NULL,
	[length] [varchar](250) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[artistID] [varchar](20) NULL,
	[album] [varchar](250) NULL,
	[track] [varchar](250) NULL,
	[albumArt] [varchar](250) NULL,
	[dataAdded] [datetime] NULL,
	[private] [varchar](10) NULL,
	[likes] [int] NULL,
	[listens] [int] NULL,
	[aboutArtist] [text] NULL,
	[aboutAlbum] [text] NULL,
	[isMessage] [int] NULL,
	[isVideo] [int] NULL,
	[artistCity] [varchar](30) NULL,
	[artistState] [varchar](30) NULL,
	[artistStartMonth] [varchar](12) NULL,
	[artistStartYear] [varchar](4) NULL,
	[artistFormerJob] [varchar](30) NULL,
	[artistIncome] [varchar](12) NULL,
			 * */
		//var e = await UserService.addNewMogoUser ("stevetest@mytester.com", "token", "first", "last", "fbid");
		//var e = await TuneService.getAudioByField ("artist", "ART WILLIAMS", "51");
		//var e = await TuneService.GetChannels();
		//	var e = await UserService.getMogoUsers ("email", "stevem@adsfactory.com", "51");
		//		User user = new User {
		//			Name = e.result [0].last,
		//			Username = e.result [0].emailAddress,
		//			Email = e.result [0].emailAddress
		//
		//		};

		//	System.Console.WriteLine (user.Name);
		//	Debug.Log (e.result.ToString ());

	}
}

