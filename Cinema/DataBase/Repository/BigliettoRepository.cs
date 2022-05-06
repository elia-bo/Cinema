using Cinema.DataBase.Data;
using Cinema.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.DataBase.Repository
{
    public class BigliettoRepository
    {
        private readonly CinemaDbContext _context;

        public BigliettoRepository(CinemaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Biglietto>> GetAll()
        {
            IQueryable<Biglietto> query = _context.Biglietti;
            var list = await query.ToListAsync();
            return list;
        }

        public async Task<Biglietto> GetById(int id)
        {
            var entity = await _context.Biglietti.SingleOrDefaultAsync(b => b.Id == id);
            return entity;
        }

        public async Task<Biglietto> Create(Biglietto entity)
        {
            await _context.Biglietti.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Biglietto entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Biglietto entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
