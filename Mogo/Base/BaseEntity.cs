using System;
using SQLite;
using Newtonsoft.Json;

namespace Mogo
{
	/// <summary>
	/// Base entity.
	/// </summary>
	public class BaseEntity : BaseEntity<int>
	{
		[PrimaryKey, AutoIncrement,JsonProperty (PropertyName = "objectId")]
		public new int Key {
			get;
			set;
		}
	}

	/// <summary>
	/// Base entity.
	/// </summary>
	public class BaseEntity<TKey>
	{
		/// <summary>
		/// Initializes a new instance of the BaseEntity class.
		/// </summary>
		public BaseEntity ()
		{

		}

		/// <summary>
		/// Gets or sets the key.
		/// </summary>
		/// <value>The key.</value>
		[JsonProperty (PropertyName = "objectId"), PrimaryKey]
		public virtual TKey Key {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the last update.
		/// </summary>
		/// <value>The last update.</value>
		[JsonProperty (PropertyName = "updatedAt")]
		public DateTime LastUpdate {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the last update.
		/// </summary>
		/// <value>The last update.</value>
		[JsonProperty (PropertyName = "createdAt")]
		public DateTime CreationDate {
			get;
			set;
		}

		[JsonProperty (PropertyName = "code")]
		public int Code {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the error.
		/// </summary>
		/// <value>The error.</value>
		[JsonProperty (PropertyName = "error")]
		public string Error {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the status.
		/// </summary>
		/// <value>The status.</value>
		public string Status {
			get;
			set;
		}

		public string ToJson ()
		{
			return JsonConvert.SerializeObject (this);
		}
	}
}

