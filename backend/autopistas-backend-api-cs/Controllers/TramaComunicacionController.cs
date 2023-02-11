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
    public class TramaComunicacionController : Controller
    {
        private readonly AutopistasContext _context;

        public TramaComunicacionController(AutopistasContext context)
        {
            _context = context;
        }

        // GET: TramaComunicacion
        public async Task<IActionResult> Index()
        {
            return View(await _context.TramaComunicacion.ToListAsync());
        }

        // GET: TramaComunicacion/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.TramaComunicacion == null)
            {
                return NotFound();
            }

            var tramaComunicacion = await _context.TramaComunicacion
                .FirstOrDefaultAsync(m => m.IntIdTrama == id);
            if (tramaComunicacion == null)
            {
                return NotFound();
            }

            return View(tramaComunicacion);
        }

        // GET: TramaComunicacion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TramaComunicacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdTrama,StrNombreTrama,IntPosicionInicial,IntTotalDatosPeso,CrCaracterFin,CrCaracterInicio")] TramaComunicacion tramaComunicacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tramaComunicacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tramaComunicacion);
        }

        // GET: TramaComunicacion/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.TramaComunicacion == null)
            {
                return NotFound();
            }

            var tramaComunicacion = await _context.TramaComunicacion.FindAsync(id);
            if (tramaComunicacion == null)
            {
                return NotFound();
            }
            return View(tramaComunicacion);
        }

        // POST: TramaComunicacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdTrama,StrNombreTrama,IntPosicionInicial,IntTotalDatosPeso,CrCaracterFin,CrCaracterInicio")] TramaComunicacion tramaComunicacion)
        {
            if (id != tramaComunicacion.IntIdTrama)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tramaComunicacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TramaComunicacionExists(tramaComunicacion.IntIdTrama))
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
            return View(tramaComunicacion);
        }

        // GET: TramaComunicacion/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.TramaComunicacion == null)
            {
                return NotFound();
            }

            var tramaComunicacion = await _context.TramaComunicacion
                .FirstOrDefaultAsync(m => m.IntIdTrama == id);
            if (tramaComunicacion == null)
            {
                return NotFound();
            }

            return View(tramaComunicacion);
        }

        // POST: TramaComunicacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            if (_context.TramaComunicacion == null)
            {
                return Problem("Entity set 'AutopistasContext.TramaComunicacion'  is null.");
            }
            var tramaComunicacion = await _context.TramaComunicacion.FindAsync(id);
            if (tramaComunicacion != null)
            {
                _context.TramaComunicacion.Remove(tramaComunicacion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TramaComunicacionExists(long? id)
        {
            return _context.TramaComunicacion.Any(e => e.IntIdTrama == id);
        }
    }
}
