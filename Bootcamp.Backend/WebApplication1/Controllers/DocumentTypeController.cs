using Bootcamp.Queries.DocumentType;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class DocumentTypeController : ControllerBase
    {
        private readonly iDocumentTypeQueries _documentTypeQueries;

        public DocumentTypeController(iDocumentTypeQueries documentTypeQueries) 
        {
            _documentTypeQueries = documentTypeQueries; 
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult> GetAll() 
        {
            var result = await _documentTypeQueries.GetAll();
            return Ok(result);
        }

        
    }
}
