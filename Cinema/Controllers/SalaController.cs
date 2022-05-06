using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cinema.DataBase.Data;
using Cinema.Domain;

namespace Cinema.Controllers
{
    public class SalaController : Controller
    {
        private readonly CinemaDbContext _context;

        public SalaController(CinemaDbContext context)
        {
            _context = context;
        }

        // GET: Sala
        public async Task<IActionResult> Index()
        {
            var cinemaDbContext = _context.Sale.Include(s => s.FilmInCorso);
            return View(await cinemaDbContext.ToListAsync());
        }

        // GET: Sala/Details/5
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

        // GET: Sala/Create
        public IActionResult Create()
        {
            ViewData["IdFilmInCorso"] = new SelectList(_context.Film, "Id", "TitoloFilm");
            return View();
        }

        // POST: Sala/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Sala/Edit/5
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

        // POST: Sala/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Sala/Delete/5
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

        // POST: Sala/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sala = await _context.Sale.FindAsync(id);
            _context.Sale.Remove(sala);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalaExists(int id)
        {
            return _context.Sale.Any(e => e.Id == id);
        }
    }
}
