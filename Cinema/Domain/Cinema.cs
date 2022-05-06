using System.Collections.Generic;

namespace Cinema.Domain
{
    public class Cinema
    {
        public int Id { get; set; }
        public List<Sala> Sale { get; set; } = new List<Sala>();

        public Cinema()
        {

        }

        public double CalcolaIncassoCinema()
        {
            double result = 0;
            foreach (var item in Sale)
            {
                result += item.CalcolaIncassoSala();
            }
            return result;
        }
    }
}
