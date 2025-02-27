﻿/*
 * @fileoverview    {PerifericoController}
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
     * TODO: Description of {@code PerifericoController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class PerifericoController : Controller {
        private readonly AutopistasContext _context;

        /**
         * TODO: Description of method {@code PerifericoController}.
         *
         */
        public PerifericoController(AutopistasContext context) {
            _context = context;
        }

        /**
         * GET: Periferico
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.Periferico.ToListAsync());
        }

        /**
         * GET: Periferico/Details/5
         *
         */
        public async Task<IActionResult> Details(long? id) {
            if (id == null || _context.Periferico == null) {
                return NotFound();
            }

            var periferico = await _context.Periferico
                .FirstOrDefaultAsync(m => m.IntId == id);
            if (periferico == null) {
                return NotFound();
            }

            return View(periferico);
        }

        /**
         * GET: Periferico/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: Periferico/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntId,EnmTipoPeriferico,StrIp,IntPuerto,StrCodigo")] Periferico periferico) {
            if (ModelState.IsValid) {
                _context.Add(periferico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(periferico);
        }

        /**
         * GET: Periferico/Edit/5
         *
         */
        public async Task<IActionResult> Edit(long? id) {
            if (id == null || _context.Periferico == null) {
                return NotFound();
            }

            var periferico = await _context.Periferico.FindAsync(id);
            if (periferico == null) {
                return NotFound();
            }
            return View(periferico);
        }

        /**
         * POST: Periferico/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntId,EnmTipoPeriferico,StrIp,IntPuerto,StrCodigo")] Periferico periferico) {
            if (id != periferico.IntId) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(periferico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!PerifericoExists(periferico.IntId)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(periferico);
        }

        /**
         * GET: Periferico/Delete/5
         *
         */
        public async Task<IActionResult> Delete(long? id) {
            if (id == null || _context.Periferico == null) {
                return NotFound();
            }

            var periferico = await _context.Periferico
                .FirstOrDefaultAsync(m => m.IntId == id);
            if (periferico == null) {
                return NotFound();
            }

            return View(periferico);
        }

        /**
         * POST: Periferico/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id) {
            if (_context.Periferico == null) {
                return Problem("Entity set 'AutopistasContext.Periferico'  is null.");
            }
            var periferico = await _context.Periferico.FindAsync(id);
            if (periferico != null) {
                _context.Periferico.Remove(periferico);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code PerifericoExists}.
         *
         */
        private bool PerifericoExists(long? id) {
            return _context.Periferico.Any(e => e.IntId == id);
        }
    }
}
