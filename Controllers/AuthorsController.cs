using libreriaa_SLE.Data.Services;
using libreriaa_SLE.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace libreriaa_SLE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private AuthorService _authorsServices;

        public AuthorsController(AuthorService authorsServices)
        {
            _authorsServices = authorsServices;
        }


        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody] AuthorVM  author)
        {
            _authorsServices.AddAuthor(author);
            return Ok();
        }


        [HttpGet("get-author-with-books-by-id/{id}")]

        public IActionResult GetAuthorWithBooks(int id)
        {
            var response = _authorsServices.GetAuthorWithBooks(id);
            return Ok(response);
        }
    }
}
