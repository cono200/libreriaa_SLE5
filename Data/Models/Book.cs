using System;
using System.Collections.Generic;

namespace libreriaa_SLE.Data.Models
{
    public class Books
    {
        public int id {  get; set; }
        public string Titulo { get; set; }
        public string Descripcion {  get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public string Genero { get; set; }
        public string CoverUrl { get; set; }
        public DateTime DateAdded { get; set; }

        //PROPIEDADES DE NAVEGACION (EN ESTA PARTE ES DONDE "MAPEAMOS")
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public List<Book_Author> Book_Authors { get; set; }

    }
}
