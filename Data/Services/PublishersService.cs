using libreriaa_SLE.Data.Models;
using libreriaa_SLE.Data.ViewModels;
using libreriaa_SLE.Exceptions;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace libreriaa_SLE.Data.Services
{
    public class PublishersService
    {
        private AppDbContext _context;
        public PublishersService(AppDbContext context)
        {

            _context = context;

        }

        //METODO QUE NOS PERMITE AGREGAR UNA NUEVA EDITORA EN LA BD


        public Publisher AddPublisher(PublisherVM publisher)
        {
            if (StringStartsWithNumber(publisher.Name)) throw new PublisherNameException("El nombre empieza con un numero",
                publisher.Name);




            var _publisher = new Publisher()
            {
                Name = publisher.Name
            };

            _context.Publisher.Add(_publisher);
            _context.SaveChanges();

            return _publisher;

        }


        public Publisher GetPublisherByID(int id ) => _context.Publisher.FirstOrDefault(n => n.Id == id);


        public PublisherWithBooksAndAuthorsVM GetPublisherData(int publisherId)
        {
            var _publisherData = _context.Publisher.Where(n => n.Id == publisherId)
                .Select(n => new PublisherWithBooksAndAuthorsVM()
                {
                    Name = n.Name,
                    BookAuthors = n.Books.Select(n => new BookAuthorVM()
                    {
                        BookName = n.Titulo,
                        BookAuthors = n.Book_Authors.Select(n => n.Author.FullName).ToList()
                    }).ToList()
                }).FirstOrDefault();
            return _publisherData;
        }

        internal void DeletePublisherById(int id)
        {
            var _publisher = _context.Publisher.FirstOrDefault(n => n.Id == id);
            if (_publisher != null)
            {
                _context.Publisher.Remove(_publisher);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"La editora con ese id {id} no existe!");
            }
        }

        private bool StringStartsWithNumber(string name)
        {
            if (Regex.IsMatch(name,@"^\d")) return true;
            return false;
        }

    }
}
