/*
 * @overview        {MenuController}
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
     * TODO: Description of {@code MenuController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class MenuController : Controller {
        private readonly AutopistasContext _context;

        /**
         * TODO: Description of method {@code MenuController}.
         *
         */
        public MenuController(AutopistasContext context) {
            _context = context;
        }

        /**
         * GET: Menu
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.Menu.ToListAsync());
        }

        /**
         * GET: Menu/Details/5
         *
         */
        public async Task<IActionResult> Details(string id) {
            if (id == null || _context.Menu == null) {
                return NotFound();
            }

            var menu = await _context.Menu
                .FirstOrDefaultAsync(m => m.StrId == id);
            if (menu == null) {
                return NotFound();
            }

            return View(menu);
        }

        /**
         * GET: Menu/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: Menu/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StrId,StrTitle,StrSubtitle,StrType,StrIcon,StrLink,BitExactMatch,BitActive,BitDisabled,StrBadge,StrFather")] Menu menu) {
            if (ModelState.IsValid) {
                _context.Add(menu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(menu);
        }

        /**
         * GET: Menu/Edit/5
         *
         */
        public async Task<IActionResult> Edit(string id) {
            if (id == null || _context.Menu == null) {
                return NotFound();
            }

            var menu = await _context.Menu.FindAsync(id);
            if (menu == null) {
                return NotFound();
            }
            return View(menu);
        }

        /**
         * POST: Menu/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StrId,StrTitle,StrSubtitle,StrType,StrIcon,StrLink,BitExactMatch,BitActive,BitDisabled,StrBadge,StrFather")] Menu menu) {
            if (id != menu.StrId) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(menu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!MenuExists(menu.StrId)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(menu);
        }

        /**
         * GET: Menu/Delete/5
         *
         */
        public async Task<IActionResult> Delete(string id) {
            if (id == null || _context.Menu == null) {
                return NotFound();
            }

            var menu = await _context.Menu
                .FirstOrDefaultAsync(m => m.StrId == id);
            if (menu == null) {
                return NotFound();
            }

            return View(menu);
        }

        /**
         * POST: Menu/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id) {
            if (_context.Menu == null) {
                return Problem("Entity set 'AutopistasContext.Menu'  is null.");
            }
            var menu = await _context.Menu.FindAsync(id);
            if (menu != null) {
                _context.Menu.Remove(menu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code MenuExists}.
         *
         */
        private bool MenuExists(string id) {
            return _context.Menu.Any(e => e.StrId == id);
        }
    }
}
