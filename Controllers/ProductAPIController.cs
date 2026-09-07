using CURDUSingAPIEFCore.Models;
using CURDUSingAPIEFCore.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CURDUSingAPIEFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController] // validation automatically 
    public class ProductAPIController : ControllerBase
    {

        IProduct repo;
        public ProductAPIController(IProduct _repo)
        {
            repo = _repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var res = await this.repo.GetProducts();
            if (res == null)
                return BadRequest();
            return Ok(res);   
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product rec)
        { 
            var res = await this.repo.AddProduct(rec);
            if (res == null)
                return BadRequest();
            // return Created();
            return Created("/api/ProductAPI", res);
        }

        [HttpPut()]
        public async Task<IActionResult> Update(Product rec)
        {
            if (rec == null)
                return BadRequest();

            await this.repo.UpdateProduct(rec);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Int64 id)
        { 
          if(id==0) return BadRequest();
          await this.repo.DeleteProduct(id);
            return NoContent();
        }
    }
}
