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
    public class ProductoCategoriasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductoCategoriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductoCategorias
        public async Task<IActionResult> Index()
        {
              return View(await _context.ProductoCategoria.ToListAsync());
        }

        // GET: ProductoCategorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductoCategoria == null)
            {
                return NotFound();
            }

            var productoCategoria = await _context.ProductoCategoria
                .FirstOrDefaultAsync(m => m.CategoriaId == id);
            if (productoCategoria == null)
            {
                return NotFound();
            }

            return View(productoCategoria);
        }

        // GET: ProductoCategorias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductoCategorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoriaId,NombreCategoria")] ProductoCategoria productoCategoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productoCategoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productoCategoria);
        }

        // GET: ProductoCategorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductoCategoria == null)
            {
                return NotFound();
            }

            var productoCategoria = await _context.ProductoCategoria.FindAsync(id);
            if (productoCategoria == null)
            {
                return NotFound();
            }
            return View(productoCategoria);
        }

        // POST: ProductoCategorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoriaId,NombreCategoria")] ProductoCategoria productoCategoria)
        {
            if (id != productoCategoria.CategoriaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productoCategoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoCategoriaExists(productoCategoria.CategoriaId))
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
            return View(productoCategoria);
        }

        // GET: ProductoCategorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductoCategoria == null)
            {
                return NotFound();
            }

            var productoCategoria = await _context.ProductoCategoria
                .FirstOrDefaultAsync(m => m.CategoriaId == id);
            if (productoCategoria == null)
            {
                return NotFound();
            }

            return View(productoCategoria);
        }

        // POST: ProductoCategorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductoCategoria == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ProductoCategoria'  is null.");
            }
            var productoCategoria = await _context.ProductoCategoria.FindAsync(id);
            if (productoCategoria != null)
            {
                _context.ProductoCategoria.Remove(productoCategoria);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoCategoriaExists(int id)
        {
          return _context.ProductoCategoria.Any(e => e.CategoriaId == id);
        }
    }
}
