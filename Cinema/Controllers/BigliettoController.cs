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
    public class BigliettoController : Controller
    {
        private readonly CinemaDbContext _context;

        public BigliettoController(CinemaDbContext context)
        {
            _context = context;
        }

        // GET: Biglietto
        public async Task<IActionResult> Index()
        {
            return View(await _context.Biglietti.ToListAsync());
        }

        // GET: Biglietto/Details/5
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

        // GET: Biglietto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Biglietto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Biglietto/Edit/5
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

        // POST: Biglietto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Biglietto/Delete/5
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

        // POST: Biglietto/Delete/5
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
