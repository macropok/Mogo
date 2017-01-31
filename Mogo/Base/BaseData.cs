using System.Collections.Generic;
using SQLite;
using System.Threading.Tasks;

namespace Mogo
{
	/// <summary>
	/// Base data.
	/// </summary>
	public class BaseData<TEntity, TKey> where TEntity : BaseEntity<TKey>, new()
	{
		/// <summary>
		/// Gets or sets the database connection.
		/// </summary>
		/// <value>The database connection.</value>
		public SQLiteConnection DatabaseConnection {
			get;
			set;
		}

		/// <summary>
		/// Initializes a new instance of the BaseData class.
		/// </summary>
		public BaseData () : this (new SQLiteConnection (Configuration.DatabasePath))
		{

		}

		/// <summary>
		/// Initializes a new instance of the BaseData class.
		/// </summary>
		/// <param name="databaseConnection">Database connection.</param>
		public BaseData (SQLiteConnection databaseConnection)
		{
			DatabaseConnection = databaseConnection;
			DatabaseConnection.CreateTable<TEntity> (CreateFlags.AllImplicit);
		}

		public virtual async Task Create (List<TEntity> item)
		{
			new Task (() => {
				for (int i = 0; i < item.Count; i++) {
					Create (item [i]);
				}
			}).Start ();
		}

		/// <summary>
		/// Upsert / Create the specified item or updates the existing one.
		/// </summary>
		/// <param name="item">Item.</param>
		public virtual void Create (TEntity item)
		{
			TEntity itemDb = Read (item.Key);

			if (itemDb == null)
				DatabaseConnection.Insert (item, typeof(TEntity));
			else
				Update (item);
		}

		/// <summary>
		/// Read the list of items.
		/// </summary>
		public List<TEntity> Read ()
		{
			var returnItem = new List<TEntity> ();
			TableQuery<TEntity> itemList = DatabaseConnection.Table<TEntity> ();
			List<TEntity> items = new List<TEntity> (itemList);
			for (int i = 0; i < items.Count; i++) {
				returnItem.Add (items[i]);
			}
			return returnItem;
		}

		/// <summary>
		/// Read the item with specified key.
		/// </summary>
		/// <param name="key">Key.</param>
		public TEntity Read (TKey key)
		{
			return DatabaseConnection.Find<TEntity> (key);
		}

		/// <summary>
		/// Updates the specified item.
		/// </summary>
		/// <param name="item">Item.</param>
		public void Update (TEntity item)
		{
			DatabaseConnection.Update (item, typeof(TEntity));
		}

		/// <summary>
		/// Delete the item with the specified key.
		/// </summary>
		/// <param name="key">Key.</param>
		public void Delete (TKey key)
		{
			TEntity item = Read (key);
			if (item != null) {
				DatabaseConnection.Delete (item);
			}
		}
	}
}

