using System;
using System.Collections.Generic;

namespace Cinema.Domain
{
    public class Sala
    {
        public int Id { get; set; }
        public int MaxNumSpettatori { get; set; }
        public List<Spettatore> Spettatori { get; set; } = new List<Spettatore>();
        public Film FilmInCorso { get; set; }

        public Sala(int maxNumSpettatori)
        {
            MaxNumSpettatori = maxNumSpettatori;
        }

        public void SvuotaSala() => Spettatori.Clear();

        public void AggiungiSpettatore(Spettatore spettatore)
        {
            if (Spettatori.Count == MaxNumSpettatori)
            {
                throw new Exception("SalaAlCompleto");
            }
            if (spettatore.Eta < 14 && FilmInCorso.Genere == GenereFilm.Horror)
            {
                throw new Exception("FilmVietato");
            }
            else
            {
                Spettatori.Add(spettatore);
            }
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
