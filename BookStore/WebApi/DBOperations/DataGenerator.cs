using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
namespace WebApi.DBOperations
{
    public class DataGenerator

    {
       public static void Initialize(IServiceProvider serviceProvider)
       {
           using (var context=new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
           {
               if(context.Books.Any())
               {
                   return;
               }
               context.Books.AddRange(new Book {
       //Id=1,
       Title="Lean Startup",
       GenreId=1,//personal Growth
       PageCount=200,
       PublishDate= new DateTime(2001,06,12)

    },
     new Book{
     //  Id=2,
       Title="Herland",
       GenreId=2,//science Fiction
       PageCount=258,
       PublishDate= new DateTime(2010,05,23)

    },
     new Book{
       //Id=3,
       Title="Dune",
       GenreId=2,//science Fiction
       PageCount=540,
       PublishDate= new DateTime(2001,12,21)

    }
    );
    context.SaveChanges();
           }
       }
    }
}