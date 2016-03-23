using System.Linq;
using Model.RichModels;
using Model.SimpleModels;
using NUnit.Framework;

namespace Model.Test.RichModels
{
	public class PoeItemFactoryTest
	{
		[Test]
		public void WhatDoesItTest()
		{
			var factory = new PoeItemFactory();
			var inputItem = new StashItem
			{
				ExplicitMods = new[]
				{
					"10% increased Elemental Damage"
				}
			};
			var item = factory.Create(inputItem);

			Assert.That(item.ExplicitMods.First().Text, Is.EqualTo("10% increased Elemental Damage"));
			Assert.That(item.ExplicitMods.First().Value, Is.EqualTo(10));

		}
	}
}
