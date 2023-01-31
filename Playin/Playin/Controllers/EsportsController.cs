using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Playin.Data;
using Playin.Models;

namespace Playin.Controllers
{
    public class EsportsController : Controller
    {
        private readonly PlayinContext _context;

        public EsportsController(PlayinContext context)
        {
            _context = context;
        }

        // GET: Esports
        public async Task<IActionResult> Index()
        {
            return View(await _context.Esport.ToListAsync());
        }

        // GET: Esports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var esport = await _context.Esport
                .FirstOrDefaultAsync(m => m.Id == id);
            if (esport == null)
            {
                return NotFound();
            }

            return View(esport);
        }

        // GET: Esports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Esports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Text,PublishedDate")] Esport esport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(esport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(esport);
        }

        // GET: Esports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var esport = await _context.Esport.FindAsync(id);
            if (esport == null)
            {
                return NotFound();
            }
            return View(esport);
        }

        // POST: Esports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Text,PublishedDate")] Esport esport)
        {
            if (id != esport.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(esport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EsportExists(esport.Id))
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
            return View(esport);
        }

        // GET: Esports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var esport = await _context.Esport
                .FirstOrDefaultAsync(m => m.Id == id);
            if (esport == null)
            {
                return NotFound();
            }

            return View(esport);
        }

        // POST: Esports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var esport = await _context.Esport.FindAsync(id);
            _context.Esport.Remove(esport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EsportExists(int id)
        {
            return _context.Esport.Any(e => e.Id == id);
        }
    }
}
