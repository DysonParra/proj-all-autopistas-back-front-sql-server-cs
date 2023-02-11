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
    public class BadgeController : Controller
    {
        private readonly AutopistasContext _context;

        public BadgeController(AutopistasContext context)
        {
            _context = context;
        }

        // GET: Badge
        public async Task<IActionResult> Index()
        {
            return View(await _context.Badge.ToListAsync());
        }

        // GET: Badge/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Badge == null)
            {
                return NotFound();
            }

            var badge = await _context.Badge
                .FirstOrDefaultAsync(m => m.StrTitle == id);
            if (badge == null)
            {
                return NotFound();
            }

            return View(badge);
        }

        // GET: Badge/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Badge/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StrTitle,StrClasses")] Badge badge)
        {
            if (ModelState.IsValid)
            {
                _context.Add(badge);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(badge);
        }

        // GET: Badge/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Badge == null)
            {
                return NotFound();
            }

            var badge = await _context.Badge.FindAsync(id);
            if (badge == null)
            {
                return NotFound();
            }
            return View(badge);
        }

        // POST: Badge/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StrTitle,StrClasses")] Badge badge)
        {
            if (id != badge.StrTitle)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(badge);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BadgeExists(badge.StrTitle))
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
            return View(badge);
        }

        // GET: Badge/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Badge == null)
            {
                return NotFound();
            }

            var badge = await _context.Badge
                .FirstOrDefaultAsync(m => m.StrTitle == id);
            if (badge == null)
            {
                return NotFound();
            }

            return View(badge);
        }

        // POST: Badge/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Badge == null)
            {
                return Problem("Entity set 'AutopistasContext.Badge'  is null.");
            }
            var badge = await _context.Badge.FindAsync(id);
            if (badge != null)
            {
                _context.Badge.Remove(badge);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BadgeExists(string id)
        {
            return _context.Badge.Any(e => e.StrTitle == id);
        }
    }
}
