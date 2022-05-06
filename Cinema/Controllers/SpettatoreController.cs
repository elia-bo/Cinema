using Cinema.DataBase.Data;
using Cinema.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Controllers
{
    public class SpettatoreController : Controller
    {
        private readonly CinemaDbContext _context;

        public SpettatoreController(CinemaDbContext context)
        {
            _context = context;
        }

        // GET: Spettatore
        public async Task<IActionResult> Index()
        {
            var cinemaDbContext = _context.Spettatori.Include(s => s.Biglietto);
            return View(await cinemaDbContext.ToListAsync());
        }

        // GET: Spettatore/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spettatore = await _context.Spettatori
                .Include(s => s.Biglietto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spettatore == null)
            {
                return NotFound();
            }

            return View(spettatore);
        }

        // GET: Spettatore/Create
        public IActionResult Create()
        {
            ViewData["IdBiglietto"] = new SelectList(_context.Biglietti, "Id", "Id");
            return View();
        }

        // POST: Spettatore/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Cognome,DataNascita,IdBiglietto")] Spettatore spettatore)
        {
            spettatore.Eta = spettatore.CalcolaEta(spettatore);
            spettatore.Maggiorenne = spettatore.IsMaggiorenne(spettatore);
            if (ModelState.IsValid)
            {
                _context.Add(spettatore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdBiglietto"] = new SelectList(_context.Biglietti, "Id", "Id", spettatore.IdBiglietto);
            return View(spettatore);
        }

        // GET: Spettatore/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spettatore = await _context.Spettatori.FindAsync(id);
            if (spettatore == null)
            {
                return NotFound();
            }
            ViewData["IdBiglietto"] = new SelectList(_context.Biglietti, "Id", "Id", spettatore.IdBiglietto);
            return View(spettatore);
        }

        // POST: Spettatore/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Cognome,DataNascita,Maggiorenne,Eta,IdBiglietto")] Spettatore spettatore)
        {
            if (id != spettatore.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spettatore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpettatoreExists(spettatore.Id))
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
            ViewData["IdBiglietto"] = new SelectList(_context.Biglietti, "Id", "Id", spettatore.IdBiglietto);
            return View(spettatore);
        }

        // GET: Spettatore/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spettatore = await _context.Spettatori
                .Include(s => s.Biglietto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spettatore == null)
            {
                return NotFound();
            }

            return View(spettatore);
        }

        // POST: Spettatore/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var spettatore = await _context.Spettatori.FindAsync(id);
            _context.Spettatori.Remove(spettatore);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpettatoreExists(int id)
        {
            return _context.Spettatori.Any(e => e.Id == id);
        }
    }
}
