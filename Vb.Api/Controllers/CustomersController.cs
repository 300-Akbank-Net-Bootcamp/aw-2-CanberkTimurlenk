using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vb.Data;
using Vb.Data.Entity;

namespace VbApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly VbDbContext _context;

        public CustomersController(VbDbContext context)
        {
            _context = context; // injects the database context
        }

        //get all customers
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var customers = await _context.Customers.ToListAsync();
            return Ok(customers); // returns 200 OK 
        }

        //get customer by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
                return NotFound(); // returns 404 Not Found if not found

            return Ok(customer); // returns 200 OK 
        }

        // create customer
        [HttpPost]
        public async Task<IActionResult> PostAsync(Customer customer)
        {
            _context.Customers.Add(customer);

            return (await _context.SaveChangesAsync()) > 0
               ? CreatedAtAction(nameof(GetAsync), new { id = customer.Id }, customer)
               : BadRequest();
            // returns 201 Created if successful, 400 Bad Request if not
        }

        // update customer
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, Customer customer)
        {
            if (id != customer.Id)
                return BadRequest();
            // returns 400 Bad Request if customer id does not match with the id in the route

            var entityToUpdate = await _context.Customers.FindAsync(id);

            if (entityToUpdate == null)
                return NotFound(); // returns 404 Not Found if not found

            _context.Customers.Update(customer);

            return (await _context.SaveChangesAsync()) > 0
                ? NoContent()
                : BadRequest();
            // returns 204 No Content if successful, 400 Bad Request if not
        }

        // delete customer
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var entityToDelete = await _context.Customers.FindAsync(id);

            if (entityToDelete == null)
                return NotFound(); // returns 404 Not Found if not found

            _context.Customers.Remove(entityToDelete);

            return (await _context.SaveChangesAsync()) > 0
                ? NoContent()
                : BadRequest();
            // returns 204 No Content if successful, 400 Bad Request if not
        }
    }
}
