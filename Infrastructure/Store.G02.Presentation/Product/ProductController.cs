using Microsoft.AspNetCore.Mvc;
using Store.G02.ServicesAbstructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G02.Presentation.Product
{
    [ApiController]
    [Route("api/products")]
    public class ProductController(IServiceManager _serviceManager) : ControllerBase
    {
        [HttpGet]   
        public  async Task<IActionResult> GetAllProduct()
        {
           var product=await _serviceManager.ProductService.GetAllProductAnsyc();
            if (product == null) return BadRequest(); 
            return Ok(product);
            
        }
    }
}
