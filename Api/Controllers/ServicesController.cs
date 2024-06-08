using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Models.Domain;
using Api.Models.DTO ; 
using AutoMapper ; 
using Api.Mapping ; 
using Api.Repositories ;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ServiceContext context;
        private readonly IServiceRepository serviceRepository;

        public ServicesController(ServiceContext context ,IMapper mapper , IServiceRepository serviceRepository)
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

            var serviceDomainModel = await serviceRepository.GetAllServices() ;

            var serviceDto = mapper.Map<List<ServiceDto>>(serviceDomainModel) ; 

            return Ok(serviceDto) ; 

        }

        // GET: api/Services/5
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetService([FromRoute] Guid id)
        {
            if (context.Services == null)
            {
                return NotFound();
            }

            var serviceDomainModel = await serviceRepository.GetService(id) ;

            if (serviceDomainModel == null)
            {
                return NotFound();
            }

            return Ok(serviceDomainModel) ;

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
        public async Task<IActionResult> AddService([FromBody]ServiceAddRequestDto ServiceAddRequestDto)
        {
            var serviceDomainModel = mapper.Map<Service>(ServiceAddRequestDto) ; 

            await serviceRepository.AddService(serviceDomainModel) ; 

            var serviceDto = mapper.Map<ServiceDto>(serviceDomainModel) ;

            return Ok(serviceDto) ; 

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
