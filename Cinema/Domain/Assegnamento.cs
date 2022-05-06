namespace Cinema.Domain
{
    public class Assegnamento
    {
        public int Id { get; set; }
        public int IdSala { get; set; }
        public int IdSpettatore { get; set; }
        public Sala? Sala { get; set; }
        public Spettatore? Spettatore { get; set; }

        public Assegnamento()
        {

        }
    }
}
