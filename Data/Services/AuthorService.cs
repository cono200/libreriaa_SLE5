using libreriaa_SLE.Data.Models;
using libreriaa_SLE.Data.ViewModels;
using System;
using System.Linq;

namespace libreriaa_SLE.Data.Services
{
    public class AuthorService
    {
        private AppDbContext _context;
        public AuthorService(AppDbContext context)
        {

            _context = context;

        }

        //METODO QUE NOS PERMITE AGREGAR UN NUEVO AUTOR EN LA BD


        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                FullName = author.FullName
            };

            _context.Authors .Add(_author);
            _context.SaveChanges();
        }


        public AuthorWithBooksVM GetAuthorWithBooks(int authorId)
        {
            var _author = _context.Authors.Where(n => n.Id == authorId).Select(n => new AuthorWithBooksVM()
            {
                FullName = n.FullName,
                BookTitles = n.Book_Authors.Select(n => n.Book.Titulo).ToList()
            }).FirstOrDefault();
            return _author;
        }

    }
}
