/*
 * @fileoverview    {RegistroVehiculoController}
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
    public class RegistroVehiculoController : Controller
    {
        private readonly AutopistasContext _context;

        public RegistroVehiculoController(AutopistasContext context)
        {
            _context = context;
        }

        // GET: RegistroVehiculo
        public async Task<IActionResult> Index()
        {
            return View(await _context.RegistroVehiculo.ToListAsync());
        }

        // GET: RegistroVehiculo/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.RegistroVehiculo == null)
            {
                return NotFound();
            }

            var registroVehiculo = await _context.RegistroVehiculo
                .FirstOrDefaultAsync(m => m.IntTiqueteNro == id);
            if (registroVehiculo == null)
            {
                return NotFound();
            }

            return View(registroVehiculo);
        }

        // GET: RegistroVehiculo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RegistroVehiculo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntTiqueteNro,DtFechaHoraEstatica,IntPesoEstatica,IntSobrepeso,BitPesajeAutorizado,BitComparendo,IntCedulaConductor,IntCedulaUsuario,IntIdCategoria,IntIdMercancia,IntIdRepeso,StrPlacaVehiculo")] RegistroVehiculo registroVehiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registroVehiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registroVehiculo);
        }

        // GET: RegistroVehiculo/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.RegistroVehiculo == null)
            {
                return NotFound();
            }

            var registroVehiculo = await _context.RegistroVehiculo.FindAsync(id);
            if (registroVehiculo == null)
            {
                return NotFound();
            }
            return View(registroVehiculo);
        }

        // POST: RegistroVehiculo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntTiqueteNro,DtFechaHoraEstatica,IntPesoEstatica,IntSobrepeso,BitPesajeAutorizado,BitComparendo,IntCedulaConductor,IntCedulaUsuario,IntIdCategoria,IntIdMercancia,IntIdRepeso,StrPlacaVehiculo")] RegistroVehiculo registroVehiculo)
        {
            if (id != registroVehiculo.IntTiqueteNro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registroVehiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroVehiculoExists(registroVehiculo.IntTiqueteNro))
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
            return View(registroVehiculo);
        }

        // GET: RegistroVehiculo/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.RegistroVehiculo == null)
            {
                return NotFound();
            }

            var registroVehiculo = await _context.RegistroVehiculo
                .FirstOrDefaultAsync(m => m.IntTiqueteNro == id);
            if (registroVehiculo == null)
            {
                return NotFound();
            }

            return View(registroVehiculo);
        }

        // POST: RegistroVehiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            if (_context.RegistroVehiculo == null)
            {
                return Problem("Entity set 'AutopistasContext.RegistroVehiculo'  is null.");
            }
            var registroVehiculo = await _context.RegistroVehiculo.FindAsync(id);
            if (registroVehiculo != null)
            {
                _context.RegistroVehiculo.Remove(registroVehiculo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroVehiculoExists(long? id)
        {
            return _context.RegistroVehiculo.Any(e => e.IntTiqueteNro == id);
        }
    }
}
