using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Model.SimpleModels;

namespace Persistence
{
	public class StashTabRepository
	{
		public SaveResult Save(IEnumerable<StashItem> items)
		{
			var result = new SaveResult();

			using (var conn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=StashGrabber;Integrated Security=True"))
			{
				conn.Open();

				foreach (var item in items)
				{
					var stashItems = conn.Query<StashItem>("SELECT * FROM ItemsRaw WHERE ExternalId=@ExternalId", item);
					if (stashItems.Any())
					{
						conn.Execute(@"
							UPDATE ItemsRaw 
							SET 
								Name = @Name, 
								ItemLevel = @ItemLevel, 
								Icon = @Icon, 
								TypeLine = @TypeLine, 
								Corrupted = @Corrupted, 
								Identified = @Identified, 
								Note = @Note, 
								InventoryId  = @InventoryId ,
								LastUpdated = GETDATE()
							WHERE 
								ExternalId = @ExternalId", items);
						result.ItemsUpdated++;
					}
					else
					{
						conn.Execute(@"
							INSERT INTO ItemsRaw 
							VALUES	(@Name, @ExternalId, @ItemLevel, @Icon, @TypeLine, @Corrupted, @Identified, @Note, @InventoryId, GETDATE())", item);
						result.ItemsInserted++;
					}
				}
			}

			return result;
		}
	}

	public class SaveResult
	{
		public int ItemsInserted { get; set; }
		public int ItemsUpdated { get; set; }
	}
}
