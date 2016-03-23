using System.Linq;
using Model.RichModel;
using NUnit.Framework;

namespace Model.Test.RichModels
{
	class PoeItemFactoryTest
	{
		[Test]
		public void WhatDoesItTest()
		{
			var factory = new PoeItemFactory();
			var inputItem = new StashItem
			{
				ImplicitMods = new string[0] ,
				ExplicitMods = new[]
				{
					"10% increased Elemental Damage"
				},
				Properties = new ItemProperty[0],
				Requirements = new ItemProperty[0],
				Sockets = new ItemSocket[0],
			};
			var item = factory.Create(inputItem);

			Assert.That(item.ExplicitMods.First().Text, Is.EqualTo("10% increased Elemental Damage"));
			Assert.That(item.ExplicitMods.First().Value1, Is.EqualTo(10));
		}
	}
}
