using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContosoPets.Api.Data;
using TShirtAppAPI.Models;

namespace ContosoPets.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TShirtOrdersController : ControllerBase
    {
        private readonly ContosoPetsContext _context;

        public TShirtOrdersController(ContosoPetsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<TShirtOrder>> GetAll() =>
            _context.TShirtOrders.ToList();

        // GET by ID action
        [HttpGet("{id}")]
        public async Task<ActionResult<TShirtOrder>> GetById(long id)
        {
            var order = await _context.TShirtOrders.FindAsync(id);

            if (order == null)

            {
                return NotFound();
            }

            return order;
        }

        // POST action
        [HttpPost]
        public async Task<ActionResult<TShirtOrder>> Create(TShirtOrder[] orders)
        {
            foreach (var order in orders)
            {
                if(order.Status == false)
                {
                    _context.TShirtOrders.Add(order);
                    await _context.SaveChangesAsync();
                    order.Status = true;
                }
            }
            return Ok();
        }

        // PUT action
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, TShirtOrder order)
        {
            if (id != order.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }


        // DELETE action
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var order = await _context.TShirtOrders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            _context.TShirtOrders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}