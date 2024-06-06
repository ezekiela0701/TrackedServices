using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Models.Domain;
using AutoMapper ; 
using Api.Mapping ; 

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ServiceContext context;
        private readonly ServiceRepository serviceRepository;

        public ServicesController(ServiceContext context ,IMapper mapper , ServiceRepository serviceRepository)
        {
            this.mapper             = mapper ; 
            this.context            = context ; 
            this.serviceRepository  = serviceRepository ; 
        }

        // GET: api/Services
        [HttpGet]
        public async Task<IActionResult> GetServices()
        {

            if(context.Services == null)
            {
                return NotFound() ;
            }

            var serviceDomainModel = await  ;

            var serviceDto = null ; 

        }

        // GET: api/Services/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> GetService(Guid id)
        {
            if (this.context.Services == null)
            {
                return NotFound();
            }

            var service = await this.context.Services.FindAsync(id);

            if (service == null)
            {
                return NotFound();
            }

            return service ;
        }

        // PUT: api/Services/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutService(Guid id, Service service)
        {
            if (id != service.Id)
            {
                return BadRequest();
            }

            this.context.Entry(service).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceExists(id))
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

        // POST: api/Services
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Service>> PostService(Service service)
        {
          if (this.context.Services == null)
          {
              return Problem("Entity set 'ServiceContext.Services'  is null.");
          }
            this.context.Services.Add(service);
            await this.context.SaveChangesAsync();

            return CreatedAtAction("GetService", new { id = service.Id }, service);
        }

        // DELETE: api/Services/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(Guid id)
        {
            if (this.context.Services == null)
            {
                return NotFound();
            }
            var service = await this.context.Services.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            this.context.Services.Remove(service);
            await this.context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceExists(Guid id)
        {
            // return (this.context.Services?.Any(e => e.Id == id)).GetValueOrDefault();
            return (this.context.Services?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
