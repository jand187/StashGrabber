using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Model.RichModel
{
	public interface IModMapper
	{
		PoeMod Map(string modString);
	}
	
	public class ModMapper : IModMapper
	{
		private IEnumerable<Regex> modDefinitions
		{
			get
			{
				// yield return new Regex(@"(?<value1>\d+)(?<modText>% increased .+?)");
				yield return new Regex(@"(?<value1>\d+)(?<modText>% increased Elemental Damage)");
				yield return new Regex(@"(?<value1>\d+)(?<modText>% increased Physical Damage)");
				yield return new Regex(@"(?<value1>\d+)(?<modText>% increased Fire Damage)");
				yield return new Regex(@"(?<value1>\d+)(?<modText>% increased Cold Damage)");
				yield return new Regex(@"(?<value1>\d+)(?<modText>% increased Lightning Damage)");
				yield return new Regex(@"(?<value1>\d+)(?<modText>% increased Chaos Damage)");

				yield return new Regex(@"(?<value1>\d+)(?<modText>% increased Attack Speed)");
				yield return new Regex(@"(?<value1>\d+)(?<modText>% increased Critical Strike Chance)");
				yield return new Regex(@"(?<value1>\d+)(?<modText>% increased Stun Duration on Enemies)");
				yield return new Regex(@"(?<value1>\d+)(?<modText>% increased Mana Regeneration Rate)");

				
				yield return new Regex(@"(?<value1>\d+)(?<modText>% reduced Enemy Stun Threshold)");
				yield return new Regex(@"(?<value1>\d+)(?<modText>% reduced Attribute Requirements)");



				yield return new Regex(@"(?<decimal1>\d+\.\d+)(?<modText>% of Physical Attack Damage Leeched as Life)");



				//yield return new Regex(@"(?<value1>\d+)(?<modText>% to \w+ Resistance)");
				yield return new Regex(@"(?<value1>\d+)(?<modText>% to Fire Resistance)");
				yield return new Regex(@"(?<value1>\d+)(?<modText>% to Cold Resistance)");
				yield return new Regex(@"(?<value1>\d+)(?<modText>% to Lightning Resistance)");
				yield return new Regex(@"(?<value1>\d+)(?<modText>% to Chaos Resistance)");


				yield return new Regex(@"(?<value1>\d+)(?<modText>% to Global Critical Strike Multiplier)");


				//yield return new Regex(@"\+(?<value1>\d+)(?<modText> Life gained \w)");
				yield return new Regex(@"\+(?<value1>\d+)(?<modText> Life gained on Kill)");
				yield return new Regex(@"\+(?<value1>\d+)(?<modText> Life gained for each Enemy hit by Attacks)");
				yield return new Regex(@"\+(?<value1>\d+)(?<modText> Life gained for each Enemy hit by your Attacks)");


				//yield return new Regex(@"\+(?<value1>\d+)(?<modText> to \w+)");
				yield return new Regex(@"\+(?<value1>\d+)(?<modText> to Accuracy Rating)");
				yield return new Regex(@"\+(?<value1>\d+)(?<modText> to Strength)");
				yield return new Regex(@"\+(?<value1>\d+)(?<modText> to Dexterity)");
				yield return new Regex(@"\+(?<value1>\d+)(?<modText> to Intelligence)");


				//yield return new Regex(@"(?<modText>Adds (?<value1>\d+)-(?<value2>\d+) \w Damage)");
				yield return new Regex(@"(?<modText>Adds (?<value1>\d+)-(?<value2>\d+) Physical Damage)");
				yield return new Regex(@"(?<modText>Adds (?<value1>\d+)-(?<value2>\d+) Fire Damage)");
				yield return new Regex(@"(?<modText>Adds (?<value1>\d+)-(?<value2>\d+) Cold Damage)");
				yield return new Regex(@"(?<modText>Adds (?<value1>\d+)-(?<value2>\d+) Lightning Damage)");
				yield return new Regex(@"(?<modText>Adds (?<value1>\d+)-(?<value2>\d+) Chaos Damage)");
			}
		}

		public PoeMod Map(string modString)
		{
			var match = modDefinitions
				.Single(m => m.IsMatch(modString))
				.Match(modString);

			if (match.Success)
				return new PoeMod
				{
					Text = match.Groups["modText"].Value,
					//Value1 = Convert.ToInt32(match.Groups["value1"].Value),
					Value1 = Convert.ToInt32(match.Groups["value1"].Success ? match.Groups["value1"].Value: "0"),
					Value2 = Convert.ToInt32(match.Groups["value2"].Success ? match.Groups["value2"].Value: "0"),
					Decimal1 = Convert.ToDecimal(match.Groups["Decimal1"].Success ? match.Groups["Decimal1"].Value: "0"),
					
				};

			return new PoeMod
			{
				Text = $"Mod not recognised ('{modString}')"
			};
		}
	}
}