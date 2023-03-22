/*
 * @fileoverview    {PoliciaController}
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
    public class PoliciaController : Controller
    {
        private readonly AutopistasContext _context;

        public PoliciaController(AutopistasContext context)
        {
            _context = context;
        }

        // GET: Policia
        public async Task<IActionResult> Index()
        {
            return View(await _context.Policia.ToListAsync());
        }

        // GET: Policia/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Policia == null)
            {
                return NotFound();
            }

            var policia = await _context.Policia
                .FirstOrDefaultAsync(m => m.IntIdPolicia == id);
            if (policia == null)
            {
                return NotFound();
            }

            return View(policia);
        }

        // GET: Policia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Policia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdPolicia,StrNombrePolicia,StrApellidoPolicia,StrTelefono")] Policia policia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(policia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(policia);
        }

        // GET: Policia/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Policia == null)
            {
                return NotFound();
            }

            var policia = await _context.Policia.FindAsync(id);
            if (policia == null)
            {
                return NotFound();
            }
            return View(policia);
        }

        // POST: Policia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdPolicia,StrNombrePolicia,StrApellidoPolicia,StrTelefono")] Policia policia)
        {
            if (id != policia.IntIdPolicia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(policia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PoliciaExists(policia.IntIdPolicia))
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
            return View(policia);
        }

        // GET: Policia/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Policia == null)
            {
                return NotFound();
            }

            var policia = await _context.Policia
                .FirstOrDefaultAsync(m => m.IntIdPolicia == id);
            if (policia == null)
            {
                return NotFound();
            }

            return View(policia);
        }

        // POST: Policia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            if (_context.Policia == null)
            {
                return Problem("Entity set 'AutopistasContext.Policia'  is null.");
            }
            var policia = await _context.Policia.FindAsync(id);
            if (policia != null)
            {
                _context.Policia.Remove(policia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PoliciaExists(long? id)
        {
            return _context.Policia.Any(e => e.IntIdPolicia == id);
        }
    }
}
