using Cinema.DataBase.Data;
using Cinema.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Controllers
{
    public class BigliettoController : Controller
    {
        private readonly CinemaDbContext _context;

        public BigliettoController(CinemaDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Biglietti.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biglietto = await _context.Biglietti
                .FirstOrDefaultAsync(m => m.Id == id);
            if (biglietto == null)
            {
                return NotFound();
            }

            return View(biglietto);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fila,Posto,Prezzo")] Biglietto biglietto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(biglietto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(biglietto);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biglietto = await _context.Biglietti.FindAsync(id);
            if (biglietto == null)
            {
                return NotFound();
            }
            return View(biglietto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fila,Posto,Prezzo")] Biglietto biglietto)
        {
            if (id != biglietto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(biglietto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BigliettoExists(biglietto.Id))
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
            return View(biglietto);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biglietto = await _context.Biglietti
                .FirstOrDefaultAsync(m => m.Id == id);
            if (biglietto == null)
            {
                return NotFound();
            }

            return View(biglietto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var biglietto = await _context.Biglietti.FindAsync(id);
            _context.Biglietti.Remove(biglietto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BigliettoExists(int id)
        {
            return _context.Biglietti.Any(e => e.Id == id);
        }
    }
}
