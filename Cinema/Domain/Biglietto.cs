namespace Cinema.Domain
{
    public class Biglietto
    {
        public int Id { get; set; }
        public char Fila { get; set; }
        public int Posto { get; set; }
        public double Prezzo { get; set; }
        public int? IdSpettatore { get; set; } = default;
        public Spettatore? Spettatore { get; set; } = default;
        public int? IdFilm { get; set; } = default;
        public Film? Film { get; set; } = default;

        public Biglietto()
        {

        }

        public double ApplicaSconto(double sconto)
        {
            return Prezzo * (1 - (sconto / 100));
        }
    }
}
