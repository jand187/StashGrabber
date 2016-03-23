using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Model.SimpleModels;
using Persistence;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    public class StashTabController : Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new[] {"value1", "value2"};
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public IActionResult Post([FromBody] StashTab value)
        {
			var xx = value;
			var repo = new StashTabRepository();
	        var result = repo.Save(value.items);

	        return Json(result);
        }
    }
}
