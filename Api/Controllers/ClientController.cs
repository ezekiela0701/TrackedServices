using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Models.Domain;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ServiceContext context;

        public ClientController(ServiceContext context)
        {
            this.context = context;
        }

        // GET: api/Client
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            if (this.context.Clients == null)
            {
                return NotFound();
            }

            //Get data from client database
            var clients =  await this.context.Clients.ToListAsync();

            //mapping dommain models to DTO
            

            return clients ; 
        }

        // GET: api/Client/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(Guid id)
        {
          if (this.context.Clients == null)
          {
              return NotFound();
          }
            var client = await this.context.Clients.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        // PUT: api/Client/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(Guid id, Client client)
        {
            if (id != client.Id)
            {
                return BadRequest();
            }

            this.context.Entry(client).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        // POST: api/Client
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(Client client)
        {
          if (this.context.Clients == null)
          {
              return Problem("Entity set 'ServiceContext.Clients'  is null.");
          }
            this.context.Clients.Add(client);
            await this.context.SaveChangesAsync();

            return CreatedAtAction("GetClient", new { id = client.Id }, client);
        }

        // DELETE: api/Client/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(Guid id)
        {
            if (this.context.Clients == null)
            {
                return NotFound();
            }
            var client = await this.context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            this.context.Clients.Remove(client);
            await this.context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientExists(Guid id)
        {
            return (this.context.Clients?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
