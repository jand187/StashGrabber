using System.Collections.Generic;

namespace Model.RichModel
{
	public class PoeItem
	{
		public string Name { get; set; }

		public string ExternalId { get; set; }

		public int ItemLevel { get; set; }

		public string Icon { get; set; }

		public string TypeLine { get; set; }

		public bool Corrupted { get; set; }

		public bool Identified { get; set; }

		public string Note { get; set; }

		public string InventoryId { get; set; }

		public int NumberOfSockets { get; set; }

		public int NumberOfLinkedSockets { get; set; }

		public IEnumerable<PoeMod> ExplicitMods { get; set; }
	}
}