using libreriaa_SLE.Data.ViewModels;
using libreriaa_SLE.Data.Models;
using libreriaa_SLE.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace libreriaa_SLE.Data.Services
{
    public class BooksServicecs
    {
        private AppDbContext _context;
        public BooksServicecs(AppDbContext context)
        {

            _context = context;

        }


        //METODO QUE NOS PERMITE AGREGAR UN NUEVO LIBRO EN LA BD


        public void AddBookWithAuthors(BookVM book)
        {
            var _book = new Books()
            {
                Titulo = book.Titulo,
                Descripcion = book.Descripcion,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.Rate,
                Genero = book.Genero,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now,
                PublisherId = book.PublisherID
            };

            _context.Books.Add(_book);
            _context.SaveChanges();


            foreach (var id in book.AutorIDs)
            {
                var _book_author = new Book_Author()
                {
                    BookId = _book.id,
                    AuthorId = id
                };
                _context.Book_Authors.Add(_book_author);
                _context.SaveChanges(); 
            }
        }
        //METODO QUE NOS PERMITE OBTENER UNA LISTA DE TODOS LOS  LIBRO EN LA BD


        public List<Books> GetAllBks() => _context.Books.ToList();
        //METODO QUE NOS PERMITE OBTENER EL LIBRO QUE ESTAMOS PIDIDIENDO EN LA BASE DE DATOS
        public BookWithAuthorsVM GetBooksById(int bookid)
        {
            var _bookWithAuthors = _context.Books.Where(n => n.id == bookid).Select(book => new BookWithAuthorsVM()
            {
                Titulo = book.Titulo,
                Descripcion = book.Descripcion,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.Rate,
                Genero = book.Genero,
                CoverUrl = book.CoverUrl,
                PublisherName = book.Publisher.Name,
                AutorNames = book.Book_Authors.Select(n => n.Author.FullName).ToList()

            }).FirstOrDefault();
            return _bookWithAuthors;
            
        }
        //METODO QUE NOS PERMITE  MODIFICAR UNA LIBRO QUE SE ENCUENTRA EN LA BASE DE DATOS


        public Books UpdateBookByID(int bookid, BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(n =>n.id == bookid);
            if (_book != null)
            {
                _book.Titulo = book.Titulo;
                _book.Descripcion = book.Descripcion;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.DateRead;
                _book.Rate = book.Rate;
                _book.Genero = book.Genero;
                _book.CoverUrl = book.CoverUrl;


                _context.SaveChanges();
            }
            return _book;
        }


        public void DeleteBookById(int bookid)
        {
            var _book = _context.Books.FirstOrDefault(n => n.id == bookid);
            if (_book != null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }



        }



    }
}
