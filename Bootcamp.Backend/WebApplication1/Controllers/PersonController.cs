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

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _personRepository.GetAll();
            return Ok(result);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult> Update([FromBody] Person person)
        {
            var result = await _personRepository.Update(person);
            return Ok(result);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult> Delete([FromBody] int id)
        {
            var result = await _personRepository.Delete(id);
            return Ok(result);
        }
    }
}
