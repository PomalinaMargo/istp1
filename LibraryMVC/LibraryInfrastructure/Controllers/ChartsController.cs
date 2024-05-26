using LibraryDomain.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using Microsoft.EntityFrameworkCore;
namespace LibraryInfrastructure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartsController : ControllerBase

    {
        private record CountByGenreResponseItem(string Genre, int Count);
       
        private readonly LibraryContext context;
        public ChartsController(LibraryContext context)
        {
            this.context = context;
        }
        [HttpGet("countByGenre")]
        public async Task<IActionResult> GetCountByGenre()
        {
            var responseItems = await context.Books
                .GroupBy(book => book.Genre.GenreName)
                .Select(bookGroup => new CountByGenreResponseItem(bookGroup.Key.ToString(), bookGroup.Count()))
                .ToListAsync();

            return new JsonResult(responseItems);
           
        }
       
        
    }
}
