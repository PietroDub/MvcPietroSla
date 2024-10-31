using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcPietro.Data;
using MvcPietro.Models;

namespace MvcPietro.Controllers
{
    public class VendaProdutosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VendaProdutosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VendaProdutos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.VendaProduto.Include(v => v.Venda);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: VendaProdutos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendaProduto = await _context.VendaProduto
                .Include(v => v.Venda)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendaProduto == null)
            {
                return NotFound();
            }

            return View(vendaProduto);
        }

        // GET: VendaProdutos/Create
        public IActionResult Create()
        {
            ViewData["VendaId"] = new SelectList(_context.Venda, "Id", "Id");
            return View();
        }

        // POST: VendaProdutos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Quantidade,ProdutoId,VendaId")] VendaProduto vendaProduto)
        {
            if (ModelState.IsValid)
            {
                vendaProduto.Id = Guid.NewGuid();
                _context.Add(vendaProduto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VendaId"] = new SelectList(_context.Venda, "Id", "Id", vendaProduto.VendaId);
            return View(vendaProduto);
        }

        // GET: VendaProdutos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendaProduto = await _context.VendaProduto.FindAsync(id);
            if (vendaProduto == null)
            {
                return NotFound();
            }
            ViewData["VendaId"] = new SelectList(_context.Venda, "Id", "Id", vendaProduto.VendaId);
            return View(vendaProduto);
        }

        // POST: VendaProdutos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Quantidade,ProdutoId,VendaId")] VendaProduto vendaProduto)
        {
            if (id != vendaProduto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendaProduto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendaProdutoExists(vendaProduto.Id))
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
            ViewData["VendaId"] = new SelectList(_context.Venda, "Id", "Id", vendaProduto.VendaId);
            return View(vendaProduto);
        }

        // GET: VendaProdutos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendaProduto = await _context.VendaProduto
                .Include(v => v.Venda)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendaProduto == null)
            {
                return NotFound();
            }

            return View(vendaProduto);
        }

        // POST: VendaProdutos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var vendaProduto = await _context.VendaProduto.FindAsync(id);
            if (vendaProduto != null)
            {
                _context.VendaProduto.Remove(vendaProduto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendaProdutoExists(Guid id)
        {
            return _context.VendaProduto.Any(e => e.Id == id);
        }
    }
}
