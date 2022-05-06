using Cinema.DataBase.Data;
using Cinema.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Controllers
{
    public class SalaController : Controller
    {
        private readonly CinemaDbContext _context;

        public SalaController(CinemaDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var cinemaDbContext = _context.Sale.Include(s => s.FilmInCorso);
            return View(await cinemaDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sala = await _context.Sale
                .Include(s => s.FilmInCorso)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sala == null)
            {
                return NotFound();
            }

            return View(sala);
        }

        public IActionResult Create()
        {
            ViewData["IdFilmInCorso"] = new SelectList(_context.Film, "Id", "TitoloFilm");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaxNumSpettatori,IdFilmInCorso")] Sala sala)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sala);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdFilmInCorso"] = new SelectList(_context.Film, "Id", "TitoloFilm", sala.IdFilmInCorso);
            return View(sala);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sala = await _context.Sale.FindAsync(id);
            if (sala == null)
            {
                return NotFound();
            }
            ViewData["IdFilmInCorso"] = new SelectList(_context.Film, "Id", "TitoloFilm", sala.IdFilmInCorso);
            return View(sala);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaxNumSpettatori,IdFilmInCorso")] Sala sala)
        {
            if (id != sala.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sala);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalaExists(sala.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdFilmInCorso"] = new SelectList(_context.Film, "Id", "TitoloFilm", sala.IdFilmInCorso);
            return View(sala);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sala = await _context.Sale
                .Include(s => s.FilmInCorso)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sala == null)
            {
                return NotFound();
            }

            return View(sala);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sala = await _context.Sale.FindAsync(id);
            _context.Sale.Remove(sala);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> CalcolaIncassoSala(int id)
        {
            var sala = await _context.Sale.FindAsync(id);
            var incasso = sala.CalcolaIncassoSala();
            return View(incasso);
        }

        private bool SalaExists(int id)
        {
            return _context.Sale.Any(e => e.Id == id);
        }
    }
}
