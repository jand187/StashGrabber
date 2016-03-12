using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using Model.SimpleModels;

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
        public void Post([FromBody] StashTab value)
        {
			var xx = value;
        }
    }
}
