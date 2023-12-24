using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vb.Data;
using Vb.Data.Entity;

namespace VbApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly VbDbContext _context;

        public AccountsController(VbDbContext context)
        {
            _context = context; // injects the database context
        }


        //get all accounts
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var accounts = await _context.Accounts.ToListAsync();
            return Ok(accounts); // returns 200 OK 
        }

        //get account by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var account = await _context.Accounts.FindAsync(id);

            if (account == null)
                return NotFound(); // returns 404 Not Found if not found

            return Ok(account); // returns 200 OK 
        }

        // create account
        [HttpPost]
        public async Task<IActionResult> PostAsync(Account account)
        {
            _context.Accounts.Add(account);

            return (await _context.SaveChangesAsync()) > 0
               ? CreatedAtAction(nameof(GetAsync), new { id = account.Id }, account)
               : BadRequest();
            // returns 201 Created if successful, 400 Bad Request if not
        }

        // update account
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, Account account)
        {
            if (id != account.Id)
                return BadRequest();
            // returns 400 Bad Request if account id does not match with the id in the route

            var entityToUpdate = await _context.Accounts.FindAsync(id);

            if (entityToUpdate == null)
                return NotFound(); // returns 404 Not Found if not found

            _context.Accounts.Update(account);

            return (await _context.SaveChangesAsync()) > 0
                ? NoContent()
                : BadRequest();
            // returns 204 No Content if successful, 400 Bad Request if not
        }

        // delete account
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var account = await _context.Accounts.FindAsync(id);

            if (account == null)
                return NotFound(); // returns 404 Not Found if not found

            _context.Accounts.Remove(account);

            return (await _context.SaveChangesAsync()) > 0
                ? NoContent()
                : BadRequest();
            // returns 204 No Content if successful, 400 Bad Request if not
        }
    }
}
