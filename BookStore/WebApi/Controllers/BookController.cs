using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.DeleteBook;
using WebApi.BookOperations.Getbooks;
using WebApi.BookOperations.GetbooksDetail;
using WebApi.BookOperations.UpdateBook;
using WebApi.DBOperations;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;
using static WebApi.BookOperations.GetbooksDetail.GetbooksDetailQuery;

namespace WebApi.AddControllers{
[ApiController]
[Route("[controller]s")]
public class BookController:ControllerBase
{
    private readonly BookStoreDbContext _context;
   public BookController(BookStoreDbContext context)
   {
     _context=context;
   }

[HttpGet]
public IActionResult GetBooks()
{
  GetBookQuery query=new GetBookQuery(_context);
  var result=query.Handle();
  return Ok(result);
  
} 
[HttpGet("{id}")]
public IActionResult GetById(int id)
{
        BookDetailViewModel result;
        try
        {
            GetbooksDetailQuery query=new GetbooksDetailQuery(_context);
        query.BookId=id;
        result= query.Handle();
        }
        catch (Exception ex)  
        {
            
            return BadRequest(ex.Message);
        }

        return Ok(result);
        
} 
//[HttpGet]
//public Book Get([FromQuery] string id)
//{
  //  var book=BookList.Where(book=>book.Id==Convert.ToInt32(id)).SingleOrDefault();
    //return book;
//} 
//POST
[HttpPost]
public IActionResult AddBook([FromBody] CreateBookModel newBook)
{ 
  CreateBookCommand command=new CreateBookCommand(_context);
  try
{
command.Model=newBook;
  command.Handle();

}
catch(Exception ex)
{

return BadRequest(ex.Message);
}
  
  
return Ok();

}
//put
[HttpPut("{id}")]
public IActionResult UpdateBook(int id,[FromBody] UpdateBookModel updateBook)
{

  try
  {
      UpdateBookCommand command=new UpdateBookCommand(_context);
   _context.SaveChanges();
   command.BookId=id;
   command.Model=updateBook;
   command.Handle();
  }
  catch (Exception ex)
  {
      
      return BadRequest(ex.Message);
  }
  

  return Ok();
}
//delete
[HttpDelete("{id}")]
public IActionResult DeleteBook(int id)
{
  
  try
  {
      DeleteBookCommand command=new DeleteBookCommand(_context);
      command.BookId=id;
      command.Handle();
  }
  catch (Exception ex)
  {
      
      return BadRequest(ex.Message);
  }
  return Ok();
}
}

} 