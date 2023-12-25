using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vb.Data;
using Vb.Data.Entity;

namespace VbApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EftTransactionsController : ControllerBase
    {
        private readonly VbDbContext _context;

        public EftTransactionsController(VbDbContext context)
        {
            _context = context; // injects the database context
        }

        //get all eftTransactions
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var eftTransactions = await _context.EftTransactions.ToListAsync();
            return Ok(eftTransactions); // returns 200 OK
        }

        // get eftTransaction by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var eftTransaction = await _context.EftTransactions.FindAsync(id);

            if (eftTransaction == null)
                return NotFound(); // returns 404 Not Found if not found

            return Ok(eftTransaction); // returns 200 OK
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(EftTransaction eftTransaction)
        {
            _context.EftTransactions.Add(eftTransaction);

            return (await _context.SaveChangesAsync()) > 0
               ? CreatedAtAction(nameof(GetAsync), new { id = eftTransaction.Id }, eftTransaction)
               : BadRequest();
            // returns 201 Created if successful, 400 Bad Request if not
        }

        // Update EftTransaction
        [HttpPut]
        public async Task<IActionResult> PutAsync(EftTransaction eftTransaction)
        {
            _context.EftTransactions.Update(eftTransaction);

            return (await _context.SaveChangesAsync()) > 0
                ? NoContent()
                : BadRequest();
            // returns 204 No Content if successful, 400 Bad Request if not
        }

        // delete EftTransaction
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var eftTransaction = await _context.EftTransactions.FindAsync(id);

            if (eftTransaction == null)
                return NotFound(); // returns 404 Not Found

            _context.EftTransactions.Remove(eftTransaction);

            return (await _context.SaveChangesAsync()) > 0
                ? NoContent()
                : BadRequest();
            // returns 204 No Content if successful, 400 Bad Request if not
        }
    }
}
