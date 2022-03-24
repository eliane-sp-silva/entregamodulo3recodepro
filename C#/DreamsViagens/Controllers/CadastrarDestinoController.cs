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
    public class CadastrarDestinoController : Controller
    {
        private readonly Context _context;

        public CadastrarDestinoController(Context context)
        {
            _context = context;
        }

        // GET: CadastrarDestino
        public async Task<IActionResult> Index()
        {
            return View(await _context.CadastrarDestinos.ToListAsync());
        }

        // GET: CadastrarDestino/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastrarDestino = await _context.CadastrarDestinos
                .FirstOrDefaultAsync(m => m.Id_Destino == id);
            if (cadastrarDestino == null)
            {
                return NotFound();
            }

            return View(cadastrarDestino);
        }

        // GET: CadastrarDestino/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CadastrarDestino/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Destino,Nome_Destino,Preco,Casal_Familia")] CadastrarDestino cadastrarDestino)
        {
           
                _context.Add(cadastrarDestino);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
        }

        // GET: CadastrarDestino/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastrarDestino = await _context.CadastrarDestinos.FindAsync(id);
            if (cadastrarDestino == null)
            {
                return NotFound();
            }
            return View(cadastrarDestino);
        }

        // POST: CadastrarDestino/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Destino,Nome_Destino,Preco,Casal_Familia")] CadastrarDestino cadastrarDestino)
        {
            if (id != cadastrarDestino.Id_Destino)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastrarDestino);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastrarDestinoExists(cadastrarDestino.Id_Destino))
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
            return View(cadastrarDestino);
        }

        // GET: CadastrarDestino/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastrarDestino = await _context.CadastrarDestinos
                .FirstOrDefaultAsync(m => m.Id_Destino == id);
            if (cadastrarDestino == null)
            {
                return NotFound();
            }

            return View(cadastrarDestino);
        }

        // POST: CadastrarDestino/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastrarDestino = await _context.CadastrarDestinos.FindAsync(id);
            _context.CadastrarDestinos.Remove(cadastrarDestino);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastrarDestinoExists(int id)
        {
            return _context.CadastrarDestinos.Any(e => e.Id_Destino == id);
        }
    }
}
