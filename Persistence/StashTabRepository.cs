using System.Data.SQLite;

namespace Persistence
{
	public class StashTabRepository
	{
	}

	public class Database
	{
		public string DbFile
		{
			get { return  @"C:\Users\JanDaniel\Documents\GitHub\StashGrabber\SimpleDb.sqlite"; }
		}

		public void CreateDatbase()
		{
			var conn = new SQLiteConnection("Data Source=" + DbFile);
			using (conn)
			{
				conn.Open();
				var cmd = new SQLiteCommand(
					@"create table ItemsRaw (
						 ID								integer identity primary key AUTOINCREMENT,
						 Name							varchar(100) not null,
						 ExternalId						varchar(100) not null,
						 Updated						datetime not null
					)", conn);

				cmd.ExecuteNonQuery();
			}
		}
	}
}
