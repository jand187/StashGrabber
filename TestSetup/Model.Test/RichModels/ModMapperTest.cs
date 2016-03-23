using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Model.RichModel;
using NUnit.Framework;

namespace Model.Test.RichModels
{
	public class ModMapperTest
	{
		public static IEnumerable<ModInput> ModInputs
		{
			get
			{
				yield return new ModInput {InputText = "1% increased Elemental Damage", ModText = "% increased Elemental Damage", Value1 = 1};
				yield return new ModInput {InputText = "20% increased Elemental Damage", ModText = "% increased Elemental Damage", Value1 = 20};
				yield return new ModInput {InputText = "300% increased Elemental Damage", ModText = "% increased Elemental Damage", Value1 = 300};
				yield return new ModInput {InputText = "94% increased Physical Damage", ModText = "% increased Physical Damage", Value1 = 94};
				yield return new ModInput {InputText = "Adds 31-55 Cold Damage", ModText = "Adds 31-55 Cold Damage", Value1 = 31, Value2 = 55};
				yield return new ModInput {InputText = "25% increased Attack Speed", ModText = "% increased Attack Speed", Value1 = 25};
				yield return new ModInput {InputText = "26% increased Mana Regeneration Rate", ModText = "% increased Mana Regeneration Rate", Value1 = 26};
				yield return new ModInput {InputText = "20% increased Stun Duration on Enemies", ModText = "% increased Stun Duration on Enemies", Value1 = 20};
				yield return new ModInput {InputText = "20% to Cold Resistance", ModText = "% to Cold Resistance", Value1 = 20};
			}
		}

		public static IEnumerable<string> ModInputs2
		{
			get
			{
				var manifestResourceNames = typeof(ModMapperTest).Assembly.GetManifestResourceNames();
				using (var stream = typeof(ModMapperTest).Assembly.GetManifestResourceStream("Model.Test.TestData.Phys dmg 5.json"))
				{
					using (var reader = new StreamReader(stream))
					{
						var json = reader.ReadToEnd();
						var tab = Newtonsoft.Json.JsonConvert.DeserializeObject<StashTab>(json);
						return tab.items.SelectMany(i => i.ExplicitMods);
					}
				}
			}
		}

		[Test]
		[TestCaseSource(nameof(ModInputs))]
		public void CanMapMods(ModInput input)
		{
			var mod = new ModMapper().Map(input.InputText);

			Assert.That(mod.Text, Is.EqualTo(input.ModText));
			Assert.That(mod.Value1, Is.EqualTo(input.Value1));
			Assert.That(mod.Value2, Is.EqualTo(input.Value2));
		}

		[Test]
		[TestCaseSource(nameof(ModInputs2))]
		public void FileTest(string modText)
		{
			var mod = new ModMapper().Map(modText);
		}
	}

	public class ModInput
	{
		public string InputText { get; set; }
		public string ModText { get; set; }
		public int Value1 { get; set; }
		public int Value2 { get; set; }

		public override string ToString()
		{
			return InputText;
		}
	}
}
