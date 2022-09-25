using Bootcamp.Modelo;
using Bootcamp.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly iPersonRepository _personRepository;

        public PersonController(iPersonRepository personRepository)
        {
            _personRepository =personRepository;
        }


        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Create([FromBody] Person person) 
        {
            var result = await _personRepository.Create(person);
            return Ok(result); 

        }
    }
}
