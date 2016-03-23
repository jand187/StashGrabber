using System.Collections.Generic;
using Newtonsoft.Json;

namespace Model
{
	public class StashItem
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("id")]
		public string ExternalId { get; set; }

		[JsonProperty("ilvl")]
		public string ItemLevel { get; set; }

		[JsonProperty("icon")]
		public string Icon { get; set; }

		[JsonProperty("typeLine")]
		public string TypeLine { get; set; }

		[JsonProperty("corrupted")]
		public string Corrupted { get; set; }

		[JsonProperty("identified")]
		public string Identified { get; set; }

		[JsonProperty("note")]
		public string Note { get; set; }

		[JsonProperty("inventoryId")]
		public string InventoryId { get; set; }

		[JsonProperty("sockets")]
		public IEnumerable<ItemSocket> Sockets { get; set; }

		[JsonProperty("properties")]
		public IEnumerable<ItemProperty> Properties { get; set; }

		[JsonProperty("requirements")]
		public IEnumerable<ItemProperty> Requirements { get; set; }

		[JsonProperty("implicitMods")]
		public IEnumerable<string> ImplicitMods { get; set; }

		[JsonProperty("explicitMods")]
		public IEnumerable<string> ExplicitMods { get; set; }

	}
}