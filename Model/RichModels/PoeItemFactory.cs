using System;
using System.Collections.Generic;
using System.Linq;
using Model.SimpleModels;

namespace Model.RichModels
{
	public class PoeItemFactory
	{
		public PoeItem Create(StashItem inputItem)
		{
			return new PoeItem
			{
				Name = inputItem.Name,
				ExternalId = inputItem.ExternalId,
				ItemLevel = Convert.ToInt32(inputItem.ItemLevel),
				Icon = inputItem.Icon,
				TypeLine = inputItem.TypeLine,
				Corrupted = Convert.ToBoolean(inputItem.Corrupted),
				Identified = Convert.ToBoolean(inputItem.Identified),
				Note = inputItem.Note,
				InventoryId = inputItem.InventoryId,
				NumberOfSockets = inputItem.Sockets.Count(),
				NumberOfLinkedSockets = GetLinkedSockets(inputItem.Sockets),
				ExplicitMods = new List<PoeMod>()
			};
		}

		private int GetLinkedSockets(IEnumerable<ItemSocket> sockets)
		{
			var links = 0;

			//for (var groupId = 0; groupId < 6; groupId++)
			//{
			//	sockets.Where(s => s.group == groupId)

			//}

			return links;
		}
	}

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

	public class PoeMod
	{
		public string Text { get; set; }
		public int Value { get; set; }
	}
}
