using System;
using System.Collections.Generic;

namespace PMovie.DAL.Entities
{
    public partial class Genero
    {
        public Genero()
        {
            Pelicula = new HashSet<Pelicula>();
        }

        public int IdGenero { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Pelicula> Pelicula { get; set; }
    }
}
