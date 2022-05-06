using System.Collections.Generic;

namespace Cinema.Domain
{
    public class Sala
    {
        public int Id { get; set; }
        public int MaxNumSpettatori { get; set; }
        public List<Spettatore>? Spettatori { get; set; } = new List<Spettatore>();
        public Film? FilmInCorso { get; set; } = default;
        public int? IdFilmInCorso { get; set; } = default;
        public List<Assegnamento>? Assegnamenti { get; set; } = default;

        public Sala()
        {

        }



        public double CalcolaIncassoSala()
        {
            double result = 0;
            foreach (var item in Spettatori)
            {
                result += item.Biglietto.Prezzo;
            }
            return result;
        }
    }
}
