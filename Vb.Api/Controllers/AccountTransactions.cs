using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vb.Data;
using Vb.Data.Entity;

namespace VbApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountTransactionsController : ControllerBase
    {
        private readonly VbDbContext _context;

        public AccountTransactionsController(VbDbContext context)
        {
            _context = context; // injects the database context
        }

        //get all account transactions
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var accountTransactions = await _context.AccountTransactions.ToListAsync();
            return Ok(accountTransactions); // returns 200 OK 
        }

        //get account transaction by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var accountTransaction = await _context.AccountTransactions.FindAsync(id);

            if (accountTransaction == null)
                return NotFound(); // returns 404 Not Found if not found

            return Ok(accountTransaction); // returns 200 OK 
        }

        // create account transaction
        [HttpPost]
        public async Task<IActionResult> PostAsync(AccountTransaction accountTransaction)
        {
            _context.AccountTransactions.Add(accountTransaction);

            return (await _context.SaveChangesAsync()) > 0
               ? CreatedAtAction(nameof(GetAsync), new { id = accountTransaction.Id }, accountTransaction)
               : BadRequest();
            // returns 201 Created if successful, 400 Bad Request if not
        }

        // update account transaction
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, AccountTransaction accountTransaction)
        {
            if (id != accountTransaction.Id)
                return BadRequest();
            // returns 400 Bad Request if account transaction id does not match with the id in the route

            var entityToUpdate = await _context.AccountTransactions.FindAsync(id);

            if (entityToUpdate == null)
                return NotFound(); // returns 404 Not Found if not found

            _context.AccountTransactions.Update(accountTransaction);

            return (await _context.SaveChangesAsync()) > 0
                ? NoContent()
                : BadRequest();
            // returns 204 No Content if successful, 400 Bad Request if not
        }

        // delete account transaction
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var entityToDelete = await _context.AccountTransactions.FindAsync(id);

            if (entityToDelete == null)
                return NotFound();

            _context.AccountTransactions.Remove(entityToDelete);

            return (await _context.SaveChangesAsync()) > 0
                ? NoContent()
                : BadRequest();
            // returns 204 No Content if successful, 400 Bad Request if not
        }
    }
}
