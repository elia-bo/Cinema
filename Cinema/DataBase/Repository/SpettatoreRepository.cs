using Cinema.DataBase.Data;
using Cinema.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.DataBase.Repository
{
    public class SpettatoreRepository
    {
        private readonly CinemaDbContext _context;

        public SpettatoreRepository(CinemaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Spettatore>> GetAll()
        {
            IQueryable<Spettatore> query = _context.Spettatori;
            var list = await query.ToListAsync();
            return list;
        }

        public async Task<Spettatore> GetById(int id)
        {
            var entity = await _context.Spettatori.SingleOrDefaultAsync(b => b.Id == id);
            return entity;
        }

        public async Task<Spettatore> Create(Spettatore entity)
        {
            await _context.Spettatori.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Spettatore entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Spettatore entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
