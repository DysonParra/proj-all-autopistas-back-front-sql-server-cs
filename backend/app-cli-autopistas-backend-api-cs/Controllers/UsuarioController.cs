/*
 * @overview        {UsuarioController}
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
     * TODO: Description of {@code UsuarioController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class UsuarioController : Controller {
        private readonly AutopistasContext _context;

        /**
         * TODO: Description of method {@code UsuarioController}.
         *
         */
        public UsuarioController(AutopistasContext context) {
            _context = context;
        }

        /**
         * GET: Usuario
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.Usuario.ToListAsync());
        }

        /**
         * GET: Usuario/Details/5
         *
         */
        public async Task<IActionResult> Details(long? id) {
            if (id == null || _context.Usuario == null) {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(m => m.IntCedulaUsuario == id);
            if (usuario == null) {
                return NotFound();
            }

            return View(usuario);
        }

        /**
         * GET: Usuario/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: Usuario/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntCedulaUsuario,StrNombreUsuario,StrApellidoUsuario,StrSeudonimo,EnmTipoUsuario,StrContrasena,StrCargoUsuario")] Usuario usuario) {
            if (ModelState.IsValid) {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        /**
         * GET: Usuario/Edit/5
         *
         */
        public async Task<IActionResult> Edit(long? id) {
            if (id == null || _context.Usuario == null) {
                return NotFound();
            }

            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null) {
                return NotFound();
            }
            return View(usuario);
        }

        /**
         * POST: Usuario/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntCedulaUsuario,StrNombreUsuario,StrApellidoUsuario,StrSeudonimo,EnmTipoUsuario,StrContrasena,StrCargoUsuario")] Usuario usuario) {
            if (id != usuario.IntCedulaUsuario) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!UsuarioExists(usuario.IntCedulaUsuario)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        /**
         * GET: Usuario/Delete/5
         *
         */
        public async Task<IActionResult> Delete(long? id) {
            if (id == null || _context.Usuario == null) {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(m => m.IntCedulaUsuario == id);
            if (usuario == null) {
                return NotFound();
            }

            return View(usuario);
        }

        /**
         * POST: Usuario/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id) {
            if (_context.Usuario == null) {
                return Problem("Entity set 'AutopistasContext.Usuario'  is null.");
            }
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario != null) {
                _context.Usuario.Remove(usuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code UsuarioExists}.
         *
         */
        private bool UsuarioExists(long? id) {
            return _context.Usuario.Any(e => e.IntCedulaUsuario == id);
        }
    }
}
