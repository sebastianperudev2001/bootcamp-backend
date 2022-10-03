using Bootcamp.Modelo;
using Bootcamp.Repositorio;
using Bootcamp.Queries; 
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bootcamp.Queries.Person;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly iPersonRepository _personRepository;
        private readonly iPersonQueries _personQueries;


        public PersonController(iPersonRepository personRepository, iPersonQueries personQueries)
        {
            _personRepository =personRepository;
            _personQueries = personQueries;

        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var result = await _personQueries.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

      

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _personQueries.GetAll();
            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Bootcamp.Modelo.Person person)
        {
            var result = await _personRepository.Create(person);
            return Ok(result);

        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Bootcamp.Modelo.Person person)
        {
            var result = await _personRepository.Update(person);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var result = await _personRepository.Delete(id);
            return Ok(result);
        }
    }
}
