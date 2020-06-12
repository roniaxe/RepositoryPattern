using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API.Models;
using Web_API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        // GET: api/<TicketController>
        [HttpGet]
        public IActionResult GetAllTickets()
        {
            try
            {
                return Ok(_ticketService.GetAll());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        // GET api/<TicketController>/5
        [HttpGet("{id}")]
        public IActionResult GetTicket(int id)
        {
            try
            {
                var ticketResponse = _ticketService.GetById(id);
                if (ticketResponse == null)
                {
                    return NotFound();
                }

                return Ok(ticketResponse);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        // POST api/<TicketController>
        [HttpPost]
        public IActionResult Post([FromBody] Ticket ticket)
        {
            try
            {
                var createdTicket = _ticketService.Create(ticket);
                return CreatedAtAction(nameof(GetTicket), new { id = ticket.Id }, ticket);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        // PUT api/<TicketController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return BadRequest();
            }

            var foundTicket = _ticketService.GetById(id);
            if (foundTicket == null) return NotFound();

            try
            {
                _ticketService.Update(ticket);
            }
            catch (DbUpdateConcurrencyException) when (!TicketExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE api/<TicketController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var foundTicket = _ticketService.GetById(id);
                if (foundTicket == null) return NotFound();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return NoContent();
        }

        private bool TicketExists(int id) => _ticketService.GetAll().Any(t => t.Id == id);
    }
}
