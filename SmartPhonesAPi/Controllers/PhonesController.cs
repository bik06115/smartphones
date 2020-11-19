﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartPhonesAPi.Models;

namespace SmartPhonesAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhonesController : ControllerBase
    {
        private readonly SmartPhonesAPiContext _context;

        public PhonesController(SmartPhonesAPiContext context)
        {
            _context = context;
        }

        // GET: api/Phones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Phone>>> GetPhone()
        {
            return await _context.Phone.ToListAsync();
        }

        // GET: api/Phones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Phone>> GetPhone(int id)
        {
            var phone = await _context.Phone.FindAsync(id);

            if (phone == null)
            {
                return NotFound();
            }

            return phone;
        }

        // PUT: api/Phones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhone(int id, Phone phone)
        {
            if (id != phone.Id)
            {
                return BadRequest();
            }

            _context.Entry(phone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhoneExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Phones
        [HttpPost]
        public async Task<ActionResult<Phone>> PostPhone(Phone phone)
        {
            _context.Phone.Add(phone);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhone", new { id = phone.Id }, phone);
        }

        // DELETE: api/Phones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Phone>> DeletePhone(int id)
        {
            var phone = await _context.Phone.FindAsync(id);
            if (phone == null)
            {
                return NotFound();
            }

            _context.Phone.Remove(phone);
            await _context.SaveChangesAsync();

            return phone;
        }

        private bool PhoneExists(int id)
        {
            return _context.Phone.Any(e => e.Id == id);
        }
    }
}
