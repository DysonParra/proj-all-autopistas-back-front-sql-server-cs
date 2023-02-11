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
    public class VehiculoSobrepesoController : Controller
    {
        private readonly AutopistasContext _context;

        public VehiculoSobrepesoController(AutopistasContext context)
        {
            _context = context;
        }

        // GET: VehiculoSobrepeso
        public async Task<IActionResult> Index()
        {
            return View(await _context.VehiculoSobrepeso.ToListAsync());
        }

        // GET: VehiculoSobrepeso/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.VehiculoSobrepeso == null)
            {
                return NotFound();
            }

            var vehiculoSobrepeso = await _context.VehiculoSobrepeso
                .FirstOrDefaultAsync(m => m.IntIdRepeso == id);
            if (vehiculoSobrepeso == null)
            {
                return NotFound();
            }

            return View(vehiculoSobrepeso);
        }

        // GET: VehiculoSobrepeso/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehiculoSobrepeso/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdRepeso,IntPesoMaximo,IntDiferenciaPeso,StrPlacaVehiculo,BitBorrado,IntIdDinamica")] VehiculoSobrepeso vehiculoSobrepeso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehiculoSobrepeso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehiculoSobrepeso);
        }

        // GET: VehiculoSobrepeso/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.VehiculoSobrepeso == null)
            {
                return NotFound();
            }

            var vehiculoSobrepeso = await _context.VehiculoSobrepeso.FindAsync(id);
            if (vehiculoSobrepeso == null)
            {
                return NotFound();
            }
            return View(vehiculoSobrepeso);
        }

        // POST: VehiculoSobrepeso/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdRepeso,IntPesoMaximo,IntDiferenciaPeso,StrPlacaVehiculo,BitBorrado,IntIdDinamica")] VehiculoSobrepeso vehiculoSobrepeso)
        {
            if (id != vehiculoSobrepeso.IntIdRepeso)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehiculoSobrepeso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiculoSobrepesoExists(vehiculoSobrepeso.IntIdRepeso))
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
            return View(vehiculoSobrepeso);
        }

        // GET: VehiculoSobrepeso/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.VehiculoSobrepeso == null)
            {
                return NotFound();
            }

            var vehiculoSobrepeso = await _context.VehiculoSobrepeso
                .FirstOrDefaultAsync(m => m.IntIdRepeso == id);
            if (vehiculoSobrepeso == null)
            {
                return NotFound();
            }

            return View(vehiculoSobrepeso);
        }

        // POST: VehiculoSobrepeso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            if (_context.VehiculoSobrepeso == null)
            {
                return Problem("Entity set 'AutopistasContext.VehiculoSobrepeso'  is null.");
            }
            var vehiculoSobrepeso = await _context.VehiculoSobrepeso.FindAsync(id);
            if (vehiculoSobrepeso != null)
            {
                _context.VehiculoSobrepeso.Remove(vehiculoSobrepeso);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehiculoSobrepesoExists(long? id)
        {
            return _context.VehiculoSobrepeso.Any(e => e.IntIdRepeso == id);
        }
    }
}
