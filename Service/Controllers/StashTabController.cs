using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Service.Controllers
{
    [Route("api/[controller]")]
    public class StashTabController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]StashTab value)
        {

            var xx = value;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class StashTab
    {
        public int numTabs { get; set; }
        public IEnumerable<StashItem> items { get; set; }
    }

    public class StashItem
    {
        public string name { get; set; }
        public string ilvl { get; set; }
        public string icon { get; set; }
        public string typeLine { get; set; }
        public string corrupted { get; set; }
        public string identified { get; set; }
        public string note { get; set; }
        public IEnumerable<ItemSocket> sockets { get; set; }
        public IEnumerable<ItemProperty> properties { get; set; }
    }

    public class ItemSocket
    {
        public int group { get; set; }
        public string attr { get; set; }
    }

    public class ItemProperty
    {
        public string name { get; set; }
        public IEnumerable<object> values { get; set; }

        public int displayMode { get; set; }
    }
}


/*

    	{
						"verified": false,
						"w": 1,
						"h": 3,
						"support": true,
						"league": "Standard",
						"id": "f7ed5e4f97524d119676ec1439617ce2d055a3def66167fe9aaadd2b012010ff",
						"lockedToCharacter": false,
						"properties": [
								{
										"name": "Dagger",
										"values": [],
										"displayMode": 0
								},
								{
										"name": "Physical Damage",
										"values": [
												[
														"19-76",
														0
												]
										],
										"displayMode": 0
								},
								{
										"name": "Critical Strike Chance",
										"values": [
												[
														"8.75%",
														1
												]
										],
										"displayMode": 0
								},
								{
										"name": "Attacks per Second",
										"values": [
												[
														"1.20",
														0
												]
										],
										"displayMode": 0
								}
						],
						"requirements": [
								{
										"name": "Level",
										"values": [
												[
														"53",
														0
												]
										],
										"displayMode": 0
								},
								{
										"name": "Dex",
										"values": [
												[
														"58",
														0
												]
										],
										"displayMode": 1
								},
								{
										"name": "Int",
										"values": [
												[
														"123",
														0
												]
										],
										"displayMode": 1
								}
						],
						"implicitMods": [
								"60% increased Global Critical Strike Chance"
						],
						"explicitMods": [
								"18% increased Spell Damage",
								"+17 to Dexterity",
								"25% increased Critical Strike Chance",
								"+26% to Global Critical Strike Multiplier"
						],
						"frameType": 2,
						"x": 11,
						"y": 0,
						"inventoryId": "Stash125",
						"socketedItems": []
				},

    */
