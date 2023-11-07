using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Unknown.Koala.Domain.Orders;
using Unknown.Koala.Data; 


namespace Unknown.Koala.Api.Controllers
{
    [ApiController]
    [Route("/api/Orders")]

    public class OrdersController : ControllerBase
    {
        private readonly StoreContext _db;

        public OrdersController(StoreContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok(_db.Orders);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOrder(int id)
        {
            var order = _db.Orders.Find(id);
            if(order == null)
            {
                return NotFound();
            }
            return Ok();
        }
        [HttpPost]
        public IActionResult Post(Order order)
        {
            _db.Orders.Add(order);
            _db.SaveChanges();
            return Created($"/api/Orders/{order.Id}", order);
        }

        [HttpPut("{id:int}")]
        public IActionResult PutOrder(int id, [FromBody] Order order)
        {
            if(id != order.Id)
            {
                return BadRequest();
            }
            
            var existingOrder = _db.Orders.Find(id); 

            if (existingOrder != null)
            {
                existingOrder.Items = order.Items;
                existingOrder.CreatedDate = order.CreatedDate;

                _db.SaveChanges();

                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var order = _db.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }
            
            _db.Orders.Remove(order);
            _db.SaveChanges();

            return Ok();
        }
    }
}