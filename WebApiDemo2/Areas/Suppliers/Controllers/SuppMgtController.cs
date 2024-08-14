using Microsoft.AspNetCore.Mvc;
using WebApiDemo2.Areas.Suppliers.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiDemo2.Areas.Suppliers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppMgtController : ControllerBase
    {
        // GET: api/<SuppMgtController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<SuppMgtController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}
        ISuppRepo _repo;
        public SuppMgtController(ISuppRepo repo)
        {
            _repo = repo;   
        }

        // POST api/<SuppMgtController>
        [HttpPost]
        public void Post([FromBody] SuppModel value)
        {
            _repo.Enroll(value);

        }

        // PUT api/<SuppMgtController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] SuppModel value)
        {
            _repo.Update(id, value);    
        }

        // DELETE api/<SuppMgtController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
