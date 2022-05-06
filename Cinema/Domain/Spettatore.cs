using System;

namespace Cinema.Domain
{
    public class Spettatore
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataNascita { get; set; }
        public Biglietto Biglietto { get; set; }
        public bool Maggiorenne { get; init; }
        public int Eta { get; set; }
        public Sala Sala { get; set; }

        public Spettatore(string nome, string cognome, DateTime dataNascita, Biglietto biglietto)
        {
            Nome = nome;
            Cognome = cognome;
            DataNascita = dataNascita;
            Biglietto = biglietto;
            Maggiorenne = IsMaggiorenne(dataNascita);
            Eta = DateTime.Now.Year - dataNascita.Year;
            ScontaBiglietto(Biglietto);
        }

        private void ScontaBiglietto(Biglietto biglietto)
        {
            if (Eta >= 70)
            {
                biglietto.ApplicaSconto(10);
            }
            if (Eta <= 5)
            {
                Biglietto.ApplicaSconto(50);
            }
        }

        private static bool IsMaggiorenne(DateTime dataNascita) => dataNascita.AddYears(18) > DateTime.Now;
    }
}
