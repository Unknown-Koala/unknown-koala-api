using Microsoft.AspNetCore.Mvc;
using Unknown.Koala.Domain.Catalog;

namespace Unknown.Koala.Domain.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        
    }
    
    [HttpGet]
    public IActionResult GetItems()
    {
        return Ok("hello world. ");
    }
}

