#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DreamsViagens.Models;

namespace DreamsViagens.Controllers
{
    public class ComprarController : Controller
    {
        private readonly Context _context;

        public ComprarController(Context context)
        {
            _context = context;
        }

        // GET: Comprar
        public async Task<IActionResult> Index()
        {
            return View(await _context.compras.ToListAsync());
        }

        // GET: Comprar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comprar = await _context.compras
                .FirstOrDefaultAsync(m => m.IdCompra == id);
            if (comprar == null)
            {
                return NotFound();
            }

            return View(comprar);
        }

        // GET: Comprar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Comprar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCompra,Email,Id_Destino,Id_CadastrarCarro")] Comprar comprar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comprar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comprar);
        }

        // GET: Comprar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comprar = await _context.compras.FindAsync(id);
            if (comprar == null)
            {
                return NotFound();
            }
            return View(comprar);
        }

        // POST: Comprar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCompra,Email,Id_Destino,Id_CadastrarCarro")] Comprar comprar)
        {
            if (id != comprar.IdCompra)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comprar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComprarExists(comprar.IdCompra))
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
            return View(comprar);
        }

        // GET: Comprar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comprar = await _context.compras
                .FirstOrDefaultAsync(m => m.IdCompra == id);
            if (comprar == null)
            {
                return NotFound();
            }

            return View(comprar);
        }

        // POST: Comprar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comprar = await _context.compras.FindAsync(id);
            _context.compras.Remove(comprar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComprarExists(int id)
        {
            return _context.compras.Any(e => e.IdCompra == id);
        }
    }
}
