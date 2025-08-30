using Entityframeworklearning.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Entityframeworklearning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly AppDbContext appDbContext;

        public CurrencyController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext; 
        }
        [HttpGet("Currecies")]
        public async Task<IActionResult> getallcurrencies()
        {
            var result = await appDbContext.CurrencyTypes.ToListAsync();

            if (result.Any())
            {
                return Ok(result);
            }
            else
            {
                return NotFound("Not Found");
            }
            
        }
        [HttpGet("Language")]
        public IActionResult getallLanguage()
        {
            var result = appDbContext.Language.ToList();
            return Ok(result);
        }

        [HttpGet("Books")]
        public IActionResult getallBooks()
        {
            var result = appDbContext.Books.ToList();
            return Ok(result);
        }

        [HttpGet("Price")]
        public IActionResult getallPrice()
        {
            var result = appDbContext.BookPrices.ToList();
            return Ok(result);
        }

        [HttpGet("Books/{id}")]
        public IActionResult get(int id)
        {
            var result = appDbContext.Books.Where(x=>x.Id == id).ToList();
            return Ok(result);
        }

        [HttpPost("AddBooks")]
        public async Task<IActionResult> AddBook([FromBody]AddBook AddBook)
        {
            var book = new Book()
            {
                Id=AddBook.Id,
                Title=AddBook.Title,
                Description=AddBook.Description,
                NumberOfPage=AddBook.NumberOfPage,
                IsActive=AddBook.IsActive,  
                CreatedTime=AddBook.CreatedTime,
                LanguageId=AddBook.LanguageId

            };
            var result = await appDbContext.Books.AddAsync(book);
            await appDbContext.SaveChangesAsync();
            return Ok(book);
        }

        [HttpPut("UpdateBooks/{BookId}")]
        public async Task<IActionResult> UpdateBook(int BookId, [FromBody]AddBook AddBook)
        {
            try
            {
                var result = await appDbContext.Books.FindAsync(BookId);
                if (result != null)
                {
                    result.Title = AddBook.Title;
                    result.Description = AddBook.Description;
                    result.NumberOfPage = AddBook.NumberOfPage;
                    result.IsActive = AddBook.IsActive;
                    result.CreatedTime = AddBook.CreatedTime;
                    result.LanguageId = AddBook.LanguageId;
                    await appDbContext.SaveChangesAsync();
                    return Ok(result);
                }
                else {
                    return BadRequest();
                }


                
            }
            catch(Exception ex)
            {
                return StatusCode(500, new
                {
                    Message = "An error occurred while processing your request.",
                    Error = ex.Message,               // short message
                    StackTrace = ex.StackTrace        // full stack trace (for debugging)
                });
            }
            

            }
        [HttpDelete("deletebook/{BookId}")]

        public async Task<IActionResult> DeleteBook(int BookId)
        {
            var result =await appDbContext.Books.FindAsync(BookId);
            if (result != null)
            {
                appDbContext.Books.Remove(result);
                await appDbContext.SaveChangesAsync();
                return Ok(new { status = 200,Message="Deleted Succesfully"});
            }
            else
            {
                return BadRequest();
            }
        }
    }
    
}
