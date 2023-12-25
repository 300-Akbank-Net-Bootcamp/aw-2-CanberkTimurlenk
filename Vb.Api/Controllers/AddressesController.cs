using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vb.Data;
using Vb.Data.Entity;

namespace VbApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly VbDbContext _context; 

        public AddressesController(VbDbContext context)
        {
            _context = context; // injects the database context
        }

        //get all addresses
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var addresses = await _context.Addresses.ToListAsync();
            return Ok(addresses); // returns 200 OK 
        }

        //get address by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var address = await _context.Addresses.FindAsync(id);

            if (address == null)
                return NotFound(); // returns 404 Not Found if not found

            return Ok(address); // returns 200 OK 
        }

        // create address
        [HttpPost]
        public async Task<IActionResult> PostAsync(Address address)
        {
            _context.Addresses.Add(address);

            return (await _context.SaveChangesAsync()) > 0
               ? CreatedAtAction(nameof(GetAsync), new { id = address.Id }, address)
               : BadRequest();
            // returns 201 Created if successful, 400 Bad Request if not
        }

        // update address
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, Address address)
        {
            // To follow the common conventions, I added the id to the route even though it is in the request body
            // Request/Response Model could be used to overcome that, In that case account no more include the id

            if (id != address.Id)
                return BadRequest();
            // returns 400 Bad Request if Address id does not match with the id in the route

            var entityExists = (await _context.Addresses.AnyAsync(a => a.Id.Equals(id)));
            // Since request/response models were not used, I checked if the entity exists manually.

            if (!entityExists)
                return NotFound(); // returns 404 Not Found if not found

            _context.Addresses.Update(address);

            return (await _context.SaveChangesAsync()) > 0
                ? NoContent()
                : BadRequest();
            // returns 204 No Content if successful, 400 Bad Request if not
        }

        // delete address
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var entityToDelete = await _context.Addresses.FindAsync(id);

            if (entityToDelete == null)
                return NotFound(); // returns 404 Not Found if not found

            _context.Addresses.Remove(entityToDelete);

            return (await _context.SaveChangesAsync()) > 0
                ? NoContent()
                : BadRequest();
            // returns 204 No Content if successful, 400 Bad Request if not
        }
    }
}
