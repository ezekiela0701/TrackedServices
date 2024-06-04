using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Models.Domain;
using Api.Models.DTO;
using Api.Repositories ; 
using Api.Mapping ; 
using AutoMapper ; 

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ServiceContext context;
        private readonly IClientRepository clientRepository;

        public ClientController(ServiceContext context , IClientRepository clientRepository , IMapper mapper )
        {
            this.mapper           = mapper;
            this.context          = context;
            this.clientRepository = clientRepository;
        }

        // GET: api/Client
        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            if (context.Clients == null)
            {
                return NotFound();
            }

            //Get data from client database
            // var clientsDomain =  await this.context.Clients.ToListAsync();
            var clientsDomain =  await clientRepository.GetAllClient();

            //mapping dommain models to DTO
            // var clientsDto = new List<ClientDto>() ;

            // foreach(var clientDomain in clientsDomain){

            //     clientsDto.Add(new ClientDto(){

            //         Id      = clientDomain.Id ,
            //         Name    = clientDomain.Name 

            //     }) ; 

            // }
            
            var clientsDto = mapper.Map<List<ClientDto>>(clientsDomain) ;

            return Ok(clientsDto) ; 
            // return Ok(clientsDomain) ; 

        }

        // GET: api/Client/5
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetClient([FromRoute] Guid id)
        {
          if (this.context.Clients == null)
          {
              return NotFound();
          }
            var client = await clientRepository.GetClientById(id);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        // PUT: api/Client/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> PutClient([FromRoute] Guid id , ClientUpdateRequestDto ClientUpdateRequestDto)
        {
            
            var clientDomainModel = mapper.Map<Client>(ClientUpdateRequestDto) ;

            if(clientDomainModel == null){

                return NotFound() ;

            }

            await clientRepository.UpdateClient(id , clientDomainModel) ;

            var clientDto = mapper.Map<ClientDto>(clientDomainModel) ;

            return Ok(clientDto) ;

        }

        // POST: api/Client
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostClient([FromBody] ClientAddRequestDto clientAddRequestDto)
        {
            
            //Map DTO to Domain Model
            var ClientDomainModel = mapper.Map<Client>(clientAddRequestDto) ;
            
            await clientRepository.AddClient(ClientDomainModel) ;

            //Map Domain to DTO
            var clientDto = mapper.Map<ClientDto>(ClientDomainModel) ; 

            return Ok(clientDto) ; 

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
                return NotFound() ;
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
