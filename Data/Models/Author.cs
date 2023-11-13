using System.Collections.Generic;

namespace libreriaa_SLE.Data.Models
{
    public class Author
    {
        public int Id { get; set; } 
        public string FullName { get; set; }

        //PROPIEDADES DE NAVEGACION

        public List<Book_Author> Book_Authors { get; set; }
    }
}
