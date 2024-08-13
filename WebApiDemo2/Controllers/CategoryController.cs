using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo2.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiDemo2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigins")]
    
    public class CategoryController : ControllerBase
    {
        ICategoryRepo _repo;
        // GET: api/<CategoryController>
        public CategoryController(ICategoryRepo repo)
        {
                _repo = repo;   
        }
        [EnableCors("AllowOrigins")]
        [HttpGet]
        public List<CategoryModel> Get()
        {
            return _repo.GetAll();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public CategoryModel Get(int id)
        {
            return _repo.FindByCategoryID(id);  
        }

        // POST api/<CategoryController>
        [HttpPost]
        public void Post([FromBody] CategoryModel value)
        {
            _repo.AddCategory(value);   
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CategoryModel value)
        {
            _repo.UpdateCategory(id, value);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.DeleteCategory(id);
        }
    }
}
