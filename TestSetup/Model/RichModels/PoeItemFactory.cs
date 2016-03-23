using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;

namespace Model.RichModel
{
	public class PoeItemFactory
	{
		private IModMapper mapper;

		public PoeItemFactory(IModMapper mapper = null) 
		{
			this.mapper = mapper?? new ModMapper();
		}

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
				ExplicitMods = MapMods(inputItem.ExplicitMods),
			};
		}

		private IEnumerable<PoeMod> MapMods(IEnumerable<string> explicitMods)
		{

			return explicitMods.Select(m => mapper.Map(m));
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
}