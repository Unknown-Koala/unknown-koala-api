using Microsoft.AspNetCore.Mvc;
using Unknown.Koala.Domain.Catalog;
using Unknown.Koala.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Unknown.Koala.Api.Controllers
{
    [ApiController]
    [Route("/catalog")]
    public class CatalogController : ControllerBase
    {
        private readonly StoreContext _db;

        public CatalogController(StoreContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult GetItems()
        {
            return Ok(_db.Items);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetItem(int id)
        {
            var item = _db.Items.Find(id);
            if(item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Post(Item item)
        {
            _db.Items.Add(item);
            _db.SaveChanges();
            return Created($"/catalog/{item.Id}", item);
        }

        [HttpPost("{id:int}/ratings")]
        public IActionResult PostRating(int id, [FromBody] Rating rating)
        {
            var item = _db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            item.AddRating(rating);
            _db.SaveChanges();

            return Ok(item);
        }
        [HttpPut("{id:int}")]
        public IActionResult PutItem(int id, [FromBody] Item item)
        {
           if(id != item.Id)
            {
                return BadRequest();
            }
            
           var existingItem = _db.Items.Find(id); 

           if (existingItem != null)
            {
                existingItem.Name = item.Name;
                existingItem.Description = item.Description;
                existingItem.Brand = item.Brand;
                existingItem.Price = item.Price;

                _db.SaveChanges();

                 return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id:int}")]
        [Authorize("delete:catalog")]
        public IActionResult Delete(int id)
        {
            var item = _db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            
            _db.Items.Remove(item);
            _db.SaveChanges();

            return Ok();
        }
    }
}

