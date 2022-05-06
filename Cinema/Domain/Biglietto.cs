namespace Cinema.Domain
{
    public class Biglietto
    {
        public int Id { get; set; }
        public char Fila { get; set; }
        public int Posto { get; set; }
        public double Prezzo { get; set; }
        public Spettatore Spettatore { get; set; } = default;

        public Biglietto(char fila, int posto, double prezzo)
        {
            Fila = fila;
            Posto = posto;
            Prezzo = prezzo;
        }

        public void ApplicaSconto(double sconto)
        {
            Prezzo = Prezzo * (1 - (sconto / 100));
        }
    }
}
