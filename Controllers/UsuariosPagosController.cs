using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Donde_Compro.Datos;
using Donde_Compro.Models;

namespace Donde_Compro.Controllers
{
    public class UsuariosPagosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsuariosPagosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UsuariosPagos
        public async Task<IActionResult> Index()
        {
              return View(await _context.UsuarioPago.ToListAsync());
        }

        // GET: UsuariosPagos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UsuarioPago == null)
            {
                return NotFound();
            }

            var usuarioPago = await _context.UsuarioPago
                .FirstOrDefaultAsync(m => m.UsuarioPagoId == id);
            if (usuarioPago == null)
            {
                return NotFound();
            }

            return View(usuarioPago);
        }

        // GET: UsuariosPagos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UsuariosPagos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuarioPagoId,TipoDePago")] UsuarioPago usuarioPago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuarioPago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuarioPago);
        }

        // GET: UsuariosPagos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UsuarioPago == null)
            {
                return NotFound();
            }

            var usuarioPago = await _context.UsuarioPago.FindAsync(id);
            if (usuarioPago == null)
            {
                return NotFound();
            }
            return View(usuarioPago);
        }

        // POST: UsuariosPagos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsuarioPagoId,TipoDePago")] UsuarioPago usuarioPago)
        {
            if (id != usuarioPago.UsuarioPagoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarioPago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioPagoExists(usuarioPago.UsuarioPagoId))
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
            return View(usuarioPago);
        }

        // GET: UsuariosPagos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UsuarioPago == null)
            {
                return NotFound();
            }

            var usuarioPago = await _context.UsuarioPago
                .FirstOrDefaultAsync(m => m.UsuarioPagoId == id);
            if (usuarioPago == null)
            {
                return NotFound();
            }

            return View(usuarioPago);
        }

        // POST: UsuariosPagos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UsuarioPago == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UsuarioPago'  is null.");
            }
            var usuarioPago = await _context.UsuarioPago.FindAsync(id);
            if (usuarioPago != null)
            {
                _context.UsuarioPago.Remove(usuarioPago);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioPagoExists(int id)
        {
          return _context.UsuarioPago.Any(e => e.UsuarioPagoId == id);
        }
    }
}
