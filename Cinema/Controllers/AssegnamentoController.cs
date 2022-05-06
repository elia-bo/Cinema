using Cinema.DataBase.Data;
using Cinema.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Controllers
{
    public class AssegnamentoController : Controller
    {
        private readonly CinemaDbContext _context;

        public AssegnamentoController(CinemaDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var cinemaDbContext = _context.Assegnamento.Include(a => a.Sala).Include(a => a.Spettatore);
            return View(await cinemaDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assegnamento = await _context.Assegnamento
                .Include(a => a.Sala)
                .Include(a => a.Spettatore)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assegnamento == null)
            {
                return NotFound();
            }

            return View(assegnamento);
        }

        public IActionResult Create()
        {
            ViewData["IdSala"] = new SelectList(_context.Sale, "Id", "Id");
            ViewData["IdSpettatore"] = new SelectList(_context.Spettatori, "Id", "Cognome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdSala,IdSpettatore")] Assegnamento assegnamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assegnamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdSala"] = new SelectList(_context.Sale, "Id", "Id", assegnamento.IdSala);
            ViewData["IdSpettatore"] = new SelectList(_context.Spettatori, "Id", "Cognome", assegnamento.IdSpettatore);
            return View(assegnamento);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assegnamento = await _context.Assegnamento.FindAsync(id);
            if (assegnamento == null)
            {
                return NotFound();
            }
            ViewData["IdSala"] = new SelectList(_context.Sale, "Id", "Id", assegnamento.IdSala);
            ViewData["IdSpettatore"] = new SelectList(_context.Spettatori, "Id", "Cognome", assegnamento.IdSpettatore);
            return View(assegnamento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdSala,IdSpettatore")] Assegnamento assegnamento)
        {
            if (id != assegnamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assegnamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssegnamentoExists(assegnamento.Id))
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
            ViewData["IdSala"] = new SelectList(_context.Sale, "Id", "Id", assegnamento.IdSala);
            ViewData["IdSpettatore"] = new SelectList(_context.Spettatori, "Id", "Cognome", assegnamento.IdSpettatore);
            return View(assegnamento);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assegnamento = await _context.Assegnamento
                .Include(a => a.Sala)
                .Include(a => a.Spettatore)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assegnamento == null)
            {
                return NotFound();
            }

            return View(assegnamento);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assegnamento = await _context.Assegnamento.FindAsync(id);
            _context.Assegnamento.Remove(assegnamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> SvuotaSala(int id)
        {
            var assegnamenti = await _context.Assegnamento.Include(a => a.Sala).Include(a => a.Spettatore).ToListAsync();
            var sale = assegnamenti.Where(a => a.IdSala == id);
            foreach (var item in sale)
            {
                _context.Assegnamento.Remove(item);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssegnamentoExists(int id)
        {
            return _context.Assegnamento.Any(e => e.Id == id);
        }
    }
}
