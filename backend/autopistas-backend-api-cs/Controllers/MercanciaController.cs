/*
 * @fileoverview    {MercanciaController}
 *
 * @version         2.0
 *
 * @author          Dyson Arley Parra Tilano <dysontilano@gmail.com>
 *
 * @copyright       Dyson Parra
 * @see             github.com/DysonParra
 *
 * History
 * @version 1.0     Implementación realizada.
 * @version 2.0     Documentación agregada.
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

namespace Autopistas.Controllers
{
    public class MercanciaController : Controller
    {
        private readonly AutopistasContext _context;

        public MercanciaController(AutopistasContext context)
        {
            _context = context;
        }

        // GET: Mercancia
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mercancia.ToListAsync());
        }

        // GET: Mercancia/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Mercancia == null)
            {
                return NotFound();
            }

            var mercancia = await _context.Mercancia
                .FirstOrDefaultAsync(m => m.IntIdMercancia == id);
            if (mercancia == null)
            {
                return NotFound();
            }

            return View(mercancia);
        }

        // GET: Mercancia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mercancia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdMercancia,StrNombreMercancia,StrDescripcionMercancia")] Mercancia mercancia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mercancia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mercancia);
        }

        // GET: Mercancia/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Mercancia == null)
            {
                return NotFound();
            }

            var mercancia = await _context.Mercancia.FindAsync(id);
            if (mercancia == null)
            {
                return NotFound();
            }
            return View(mercancia);
        }

        // POST: Mercancia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdMercancia,StrNombreMercancia,StrDescripcionMercancia")] Mercancia mercancia)
        {
            if (id != mercancia.IntIdMercancia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mercancia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MercanciaExists(mercancia.IntIdMercancia))
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
            return View(mercancia);
        }

        // GET: Mercancia/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Mercancia == null)
            {
                return NotFound();
            }

            var mercancia = await _context.Mercancia
                .FirstOrDefaultAsync(m => m.IntIdMercancia == id);
            if (mercancia == null)
            {
                return NotFound();
            }

            return View(mercancia);
        }

        // POST: Mercancia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            if (_context.Mercancia == null)
            {
                return Problem("Entity set 'AutopistasContext.Mercancia'  is null.");
            }
            var mercancia = await _context.Mercancia.FindAsync(id);
            if (mercancia != null)
            {
                _context.Mercancia.Remove(mercancia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MercanciaExists(long? id)
        {
            return _context.Mercancia.Any(e => e.IntIdMercancia == id);
        }
    }
}
