﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Vb.Data;
using Vb.Data.Entity;

namespace VbApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly VbDbContext _context;

        public ContactsController(VbDbContext context)
        {
            _context = context; // injects the database context
        }

        //get all contacts
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var contacts = await _context.Contacts.ToListAsync();
            return Ok(contacts); // returns 200 OK 
        }

        //get contact by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);

            if (contact == null)
                return NotFound(); // returns 404 Not Found if not found

            return Ok(contact); // returns 200 OK 
        }

        // create contact
        [HttpPost]
        public async Task<IActionResult> PostAsync(Contact contact)
        {
            _context.Contacts.Add(contact);

            return (await _context.SaveChangesAsync()) > 0
              ? CreatedAtAction(nameof(GetAsync), new { id = contact.Id }, contact)
              : BadRequest();
            // returns 201 Created if successful, 400 Bad Request if not
        }

        // update contact
        [HttpPut]
        public async Task<IActionResult> PutAsync(Contact contact)
        {
            _context.Contacts.Update(contact);

            return (await _context.SaveChangesAsync()) > 0
                ? NoContent()
                : BadRequest();
            // returns 204 No Content if successful, 400 Bad Request if not
        }

        // delete contact
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var entityToDelete = await _context.Contacts.FindAsync(id);

            if (entityToDelete == null)
                return NotFound();

            _context.Contacts.Remove(entityToDelete);

            return (await _context.SaveChangesAsync()) > 0
                            ? NoContent()
                            : BadRequest();
            // returns 204 No Content if successful, 400 Bad Request if not
        }
    }
}
