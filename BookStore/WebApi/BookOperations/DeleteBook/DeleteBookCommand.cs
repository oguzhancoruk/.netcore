using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Common;
using WebApi.DBOperations;
namespace WebApi.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public int BookId{get;set;}
        public DeleteBookCommand(BookStoreDbContext dbContext)
        {
          _dbContext=dbContext;
        }
        public void Handle()
        {
           var book =_dbContext.Books.SingleOrDefault(x=>x.Id==BookId);

          if(book is null)
          throw new InvalidOperationException("silinecek kitap bulunamadı");
          _dbContext.Books.Remove(book);
          _dbContext.SaveChanges(); 
        }
    }
}