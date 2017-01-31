using System.Collections.Generic;

namespace Mogo
{
	/// <summary>
	/// This class models the User
	/// </summary>
	public class User : BaseEntity<string>
	{
		public User ()
		{

		}

		/// <summary>
		/// The user token is the unique identifier of the session
		/// </summary>
		/// <value>The user token.</value>
		public string UserToken {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the username.
		/// </summary>
		/// <value>The username.</value>
		public string Username {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the email.
		/// </summary>
		/// <value>The email.</value>
		public string Email {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Password {
			get;
			set;
		}

		public class UserStats
		{
			public string stations { get; set; }
			public string videos { get; set; }
			public string likes { get; set; }
			public string follwers { get; set; }
			public string follows { get; set; }
			public string bookmarks { get; set; }
			public string waiting { get; set; }
			public string audio { get; set; }
			public string messages { get; set; }
			public string notifications { get; set; }
		}

		public class MG_Users
		{
			public string id { get; set; }
			public string dataCappID { get; set; }
			public string fbid { get; set; }
			public string emailAddress { get; set; }
			public string first { get; set; }
			public string last { get; set; }
			public string areFollowing { get; set; }
			public string hideEmail { get; set; }
			public string aboutMe { get; set; }
			public string address { get; set; }
			public string city { get; set; }
			public string state { get; set; }
			public string level { get; set; }
			public string userLevel { get; set; }
			public string zip { get; set; }
			public string phone { get; set; }
			public string cell { get; set; }
			public string photo { get; set; }
			public string bookmarks { get; set; }
			public UserStats userStats { get; set; }
		}

		public class MG_UserRoot
		{
			public List<MG_Users> result { get; set; }
		}

		public class NewUserID
		{
			public string result { get; set; }
		}

	}
}

