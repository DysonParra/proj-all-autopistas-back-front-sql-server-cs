/*
 * @fileoverview    {TransitoDinamicaController}
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
    public class TransitoDinamicaController : Controller
    {
        private readonly AutopistasContext _context;

        public TransitoDinamicaController(AutopistasContext context)
        {
            _context = context;
        }

        // GET: TransitoDinamica
        public async Task<IActionResult> Index()
        {
            return View(await _context.TransitoDinamica.ToListAsync());
        }

        // GET: TransitoDinamica/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.TransitoDinamica == null)
            {
                return NotFound();
            }

            var transitoDinamica = await _context.TransitoDinamica
                .FirstOrDefaultAsync(m => m.IntIdDinamica == id);
            if (transitoDinamica == null)
            {
                return NotFound();
            }

            return View(transitoDinamica);
        }

        // GET: TransitoDinamica/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TransitoDinamica/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdDinamica,IntIdCategoria,StrPlacaVehiculo,DtFechaHoraTransito,IntPesoGeneral,StrPesoEjes,FltVelocidad,TxtBase64Placa")] TransitoDinamica transitoDinamica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transitoDinamica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transitoDinamica);
        }

        // GET: TransitoDinamica/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.TransitoDinamica == null)
            {
                return NotFound();
            }

            var transitoDinamica = await _context.TransitoDinamica.FindAsync(id);
            if (transitoDinamica == null)
            {
                return NotFound();
            }
            return View(transitoDinamica);
        }

        // POST: TransitoDinamica/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdDinamica,IntIdCategoria,StrPlacaVehiculo,DtFechaHoraTransito,IntPesoGeneral,StrPesoEjes,FltVelocidad,TxtBase64Placa")] TransitoDinamica transitoDinamica)
        {
            if (id != transitoDinamica.IntIdDinamica)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transitoDinamica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransitoDinamicaExists(transitoDinamica.IntIdDinamica))
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
            return View(transitoDinamica);
        }

        // GET: TransitoDinamica/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.TransitoDinamica == null)
            {
                return NotFound();
            }

            var transitoDinamica = await _context.TransitoDinamica
                .FirstOrDefaultAsync(m => m.IntIdDinamica == id);
            if (transitoDinamica == null)
            {
                return NotFound();
            }

            return View(transitoDinamica);
        }

        // POST: TransitoDinamica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            if (_context.TransitoDinamica == null)
            {
                return Problem("Entity set 'AutopistasContext.TransitoDinamica'  is null.");
            }
            var transitoDinamica = await _context.TransitoDinamica.FindAsync(id);
            if (transitoDinamica != null)
            {
                _context.TransitoDinamica.Remove(transitoDinamica);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransitoDinamicaExists(long? id)
        {
            return _context.TransitoDinamica.Any(e => e.IntIdDinamica == id);
        }
    }
}
