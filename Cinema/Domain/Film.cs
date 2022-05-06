using System.Collections.Generic;

namespace Cinema.Domain
{
    public class Film
    {
        public int Id { get; set; }
        public string TitoloFilm { get; set; }
        public string Autore { get; set; }
        public string Produttore { get; set; }
        public GenereFilm Genere { get; set; }
        public int Durata { get; set; }
        public Sala? Sala { get; set; } = default;
        public List<Biglietto>? Biglietti { get; set; } = default;

        public Film()
        {

        }
    }
}
