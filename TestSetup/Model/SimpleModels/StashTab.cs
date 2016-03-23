using System.Collections.Generic;

namespace Model
{
	public class StashTab
	{
		public int numTabs { get; set; }
		public IEnumerable<StashItem> items { get; set; }
	}
}