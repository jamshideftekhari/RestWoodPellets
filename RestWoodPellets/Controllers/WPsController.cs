using Microsoft.AspNetCore.Mvc;
using RestWoodPellets.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestWoodPellets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WPsController : ControllerBase
    {
        WPListRepo wp = new WPListRepo();
        // GET: api/<WPsController>
        [HttpGet]
        public IEnumerable<WoodPallet> Get()
        {
            //return new string[] { "value1", "value2" };
            return wp.Get();
        }

        // GET api/<WPsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<WPsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<WPsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WPsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
