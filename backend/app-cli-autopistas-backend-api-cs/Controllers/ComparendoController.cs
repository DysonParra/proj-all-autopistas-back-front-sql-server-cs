/*
 * @fileoverview    {ComparendoController}
 *
 * @version         2.0
 *
 * @author          Dyson Arley Parra Tilano <dysontilano@gmail.com>
 *
 * @copyright       Dyson Parra
 * @see             github.com/DysonParra
 *
 * History
 * @version 1.0     Implementation done.
 * @version 2.0     Documentation added.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Autopistas.Data;
using Project.Models;

namespace Autopistas.Controllers {

    /**
     * TODO: Description of {@code ComparendoController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class ComparendoController : Controller {
        private readonly AutopistasContext _context;

        public ComparendoController(AutopistasContext context) {
            _context = context;
        }

        // GET: Comparendo
        public async Task<IActionResult> Index() {
            return View(await _context.Comparendo.ToListAsync());
        }

        // GET: Comparendo/Details/5
        public async Task<IActionResult> Details(long? id) {
            if (id == null || _context.Comparendo == null) {
                return NotFound();
            }

            var comparendo = await _context.Comparendo
                .FirstOrDefaultAsync(m => m.IntIdComparendo == id);
            if (comparendo == null) {
                return NotFound();
            }

            return View(comparendo);
        }

        // GET: Comparendo/Create
        public IActionResult Create() {
            return View();
        }

        // POST: Comparendo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdComparendo,IntCodigoComparendo,StrObservaciones,EnmTipoInfractor,IntCedulaConductor,IntIdPolicia,StrPlacaVehiculo,IntTiqueteNro")] Comparendo comparendo) {
            if (ModelState.IsValid) {
                _context.Add(comparendo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comparendo);
        }

        // GET: Comparendo/Edit/5
        public async Task<IActionResult> Edit(long? id) {
            if (id == null || _context.Comparendo == null) {
                return NotFound();
            }

            var comparendo = await _context.Comparendo.FindAsync(id);
            if (comparendo == null) {
                return NotFound();
            }
            return View(comparendo);
        }

        // POST: Comparendo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdComparendo,IntCodigoComparendo,StrObservaciones,EnmTipoInfractor,IntCedulaConductor,IntIdPolicia,StrPlacaVehiculo,IntTiqueteNro")] Comparendo comparendo) {
            if (id != comparendo.IntIdComparendo) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(comparendo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!ComparendoExists(comparendo.IntIdComparendo)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(comparendo);
        }

        // GET: Comparendo/Delete/5
        public async Task<IActionResult> Delete(long? id) {
            if (id == null || _context.Comparendo == null) {
                return NotFound();
            }

            var comparendo = await _context.Comparendo
                .FirstOrDefaultAsync(m => m.IntIdComparendo == id);
            if (comparendo == null) {
                return NotFound();
            }

            return View(comparendo);
        }

        // POST: Comparendo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id) {
            if (_context.Comparendo == null) {
                return Problem("Entity set 'AutopistasContext.Comparendo'  is null.");
            }
            var comparendo = await _context.Comparendo.FindAsync(id);
            if (comparendo != null) {
                _context.Comparendo.Remove(comparendo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComparendoExists(long? id) {
            return _context.Comparendo.Any(e => e.IntIdComparendo == id);
        }
    }
}
