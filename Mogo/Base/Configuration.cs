using System;
using Xamarin.Forms;

namespace Mogo
{
	/// <summary>
	/// Configuration.
	/// </summary>
	public static partial class Configuration
	{
		/// <summary>
		/// The database path.
		/// </summary>
		private static string _databasePath;

		/// <summary>
		/// Gets or sets the database path.
		/// </summary>
		/// <value>The database path.</value>
		public static string DatabasePath {
			get {
				if (string.IsNullOrEmpty (_databasePath)) {
					_databasePath = "mogo.db";
				}
				return _databasePath;
			}
			set { _databasePath = value; }
		}

		/// <summary>
		/// Gets the API token.
		/// </summary>
		/// <value>The API token.</value>
		public static string ApiToken {
			get { return "h524hezne2gmh29nf5waqtpw"; }
		}

		/// <summary>
		/// Gets the API URL.
		/// </summary>
		/// <value>The API URL.</value>
		public static string ApiUrl { get { return "http://beta.mogoradio.com/json/syncreply/"; } }

		/// <summary>
		/// Gets the insight key.
		/// </summary>
		/// <value>The Xamarin insight API key.</value>
		public static string InsightKey {
			get {
				return "e8ec8bd11f1f1b1000310abe31191ede59fda70c";
			}
		}

		/// <summary>
		/// Gets or sets the new user key.
		/// </summary>
		/// <value>The new user key.</value>
		public static string NewUserKey {
			get { return "new_user"; }
		}
	}
}

