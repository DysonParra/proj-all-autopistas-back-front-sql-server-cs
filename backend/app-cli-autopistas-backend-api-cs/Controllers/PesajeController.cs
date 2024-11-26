/*
 * @fileoverview    {PesajeController}
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

namespace Autopistas.Controllers
{
    public class PesajeController : Controller
    {
        private readonly AutopistasContext _context;

        public PesajeController(AutopistasContext context)
        {
            _context = context;
        }

        // GET: Pesaje
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pesaje.ToListAsync());
        }

        // GET: Pesaje/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Pesaje == null)
            {
                return NotFound();
            }

            var pesaje = await _context.Pesaje
                .FirstOrDefaultAsync(m => m.IntId == id);
            if (pesaje == null)
            {
                return NotFound();
            }

            return View(pesaje);
        }

        // GET: Pesaje/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pesaje/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntId,IntTiqueteNumero,StrPlaca,StrCodigo,IntNumeroInterno,StrTipoVehiculo,StrConductor,StrCedula,StrProducto,StrPlanta,StrCliente,StrTransportadora,DtFechaHoraPesoVacio,DtFechaHoraPesoLleno,StrCiv,StrDireccion,StrEntregadoPor,StrRecibidoPor,StrShipment,StrSello,StrR,StrContenedor,StrObservacion,EnmTipoIngreso")] Pesaje pesaje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pesaje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pesaje);
        }

        // GET: Pesaje/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Pesaje == null)
            {
                return NotFound();
            }

            var pesaje = await _context.Pesaje.FindAsync(id);
            if (pesaje == null)
            {
                return NotFound();
            }
            return View(pesaje);
        }

        // POST: Pesaje/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntId,IntTiqueteNumero,StrPlaca,StrCodigo,IntNumeroInterno,StrTipoVehiculo,StrConductor,StrCedula,StrProducto,StrPlanta,StrCliente,StrTransportadora,DtFechaHoraPesoVacio,DtFechaHoraPesoLleno,StrCiv,StrDireccion,StrEntregadoPor,StrRecibidoPor,StrShipment,StrSello,StrR,StrContenedor,StrObservacion,EnmTipoIngreso")] Pesaje pesaje)
        {
            if (id != pesaje.IntId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pesaje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PesajeExists(pesaje.IntId))
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
            return View(pesaje);
        }

        // GET: Pesaje/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Pesaje == null)
            {
                return NotFound();
            }

            var pesaje = await _context.Pesaje
                .FirstOrDefaultAsync(m => m.IntId == id);
            if (pesaje == null)
            {
                return NotFound();
            }

            return View(pesaje);
        }

        // POST: Pesaje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            if (_context.Pesaje == null)
            {
                return Problem("Entity set 'AutopistasContext.Pesaje'  is null.");
            }
            var pesaje = await _context.Pesaje.FindAsync(id);
            if (pesaje != null)
            {
                _context.Pesaje.Remove(pesaje);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PesajeExists(long? id)
        {
            return _context.Pesaje.Any(e => e.IntId == id);
        }
    }
}
