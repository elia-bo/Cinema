using Cinema.DataBase.Data;
using Cinema.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.DataBase.Repository
{
    public class FilmRepository
    {
        private readonly CinemaDbContext _context;

        public FilmRepository(CinemaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Film>> GetAll()
        {
            IQueryable<Film> query = _context.Film;
            var list = await query.ToListAsync();
            return list;
        }

        public async Task<Film> GetById(int id)
        {
            var entity = await _context.Film.SingleOrDefaultAsync(b => b.Id == id);
            return entity;
        }

        public async Task<Film> Create(Film entity)
        {
            await _context.Film.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Film entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Film entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
