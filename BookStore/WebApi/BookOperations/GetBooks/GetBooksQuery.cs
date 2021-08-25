using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Common;
using WebApi.DBOperations;
namespace WebApi.BookOperations.Getbooks

{
     public class GetBookQuery

     {
         private readonly BookStoreDbContext _dbcontext;

         public GetBookQuery(BookStoreDbContext dbContext)
         {
            _dbcontext=dbContext;

         }
         public List<BookViewModel> Handle()
         {
          var booklist=_dbcontext.Books.OrderBy(x=>x.Id).ToList<Book>();
          List<BookViewModel> vn= new List<BookViewModel>();
          foreach(var book in booklist)
          {
       
         vn.Add(new BookViewModel()
         {
             Title=book.Title,
             Genre=((GenreEnum)book.GenreId).ToString(),
             PublishDate=book.PublishDate.Date.ToString("dd/MM/yyyy"),
             PageCount=book.PageCount

         });
          }
           
          return vn;
         }
         
     }

     public class  BookViewModel
     {
       public string Title{get;set;}
       public string Genre{get;set;}  
       public int PageCount{get;set;}
       public string PublishDate {get;set;}
     }
}