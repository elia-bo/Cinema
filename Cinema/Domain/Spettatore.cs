using System;

namespace Cinema.Domain
{
    public class Spettatore
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataNascita { get; set; }
        public Biglietto? Biglietto { get; set; } = default;
        public bool Maggiorenne { get; set; }
        public int Eta { get; set; }

        public Sala? Sala { get; set; } = default;
        public int? IdBiglietto { get; set; } = default;

        public Spettatore()
        {

        }

        public int CalcolaEta(Spettatore spettatore)
        {
            return DateTime.Now.Year - spettatore.DataNascita.Year;
        }
        public Biglietto ScontaBiglietto(Biglietto biglietto)
        {
            if (Eta >= 70)
            {
                biglietto.ApplicaSconto(10);
            }
            if (Eta <= 5)
            {
                biglietto.ApplicaSconto(50);
            }
            return biglietto;
        }

        public bool IsMaggiorenne(Spettatore spettatore)
        {
            return spettatore.DataNascita.AddYears(18) > DateTime.Now;
        }
    }
}
