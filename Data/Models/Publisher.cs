using System.Collections.Generic;

namespace libreriaa_SLE.Data.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //PROPIEDADES DE NAVEGACION
        public List<Books> Books { get; set; }



    }
}
