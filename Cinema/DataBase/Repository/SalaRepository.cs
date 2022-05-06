using Cinema.DataBase.Data;
using Cinema.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.DataBase.Repository
{
    public class SalaRepository
    {
        private readonly CinemaDbContext _context;

        public SalaRepository(CinemaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sala>> GetAll()
        {
            IQueryable<Sala> query = _context.Sale;
            var list = await query.ToListAsync();
            return list;
        }

        public async Task<Sala> GetById(int id)
        {
            var entity = await _context.Sale.SingleOrDefaultAsync(b => b.Id == id);
            return entity;
        }

        public async Task<Sala> Create(Sala entity)
        {
            await _context.Sale.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Sala entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Sala entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
