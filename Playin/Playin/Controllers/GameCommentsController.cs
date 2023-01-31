#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Playin.Data;
using Playin.Models;
using Playin.ViewModels;

namespace Playin.Controllers
{
    public class GameCommentsController : Controller
    {
        private readonly PlayinContext _context;

        public GameCommentsController(PlayinContext context)
        {
            _context = context;
        }

        // GET: GameComments
        public async Task<IActionResult> Index()
        {
            var playinContext = _context.GamesComments.Include(g => g.Games);
            return View(await playinContext.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(GameCommentViewModel vm)
        {
            var comment = vm.Comment;
            var gameId = vm.GamesId;
            var rating = vm.Rating;

            GameComment gmComment = new GameComment()
            {
                GamesId = gameId,
                Comments = comment,
                Rating = rating,
                PublishedDate = DateTime.Now
            };

            _context.GamesComments.Add(gmComment);
            _context.SaveChanges();

            return RedirectToAction("Details", "Games", new { id = gameId });
        }

        // GET: GameComments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameComment = await _context.GamesComments
                .Include(g => g.Games)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameComment == null)
            {
                return NotFound();
            }

            return View(gameComment);
        }

        // GET: GameComments/Create
        public IActionResult Create()
        {
            ViewData["GamesId"] = new SelectList(_context.Games, "Id", "Id");
            return View();
        }

        // POST: GameComments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Comments,PublishedDate,GamesId,Rating")] GameComment gameComment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gameComment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GamesId"] = new SelectList(_context.Games, "Id", "Id", gameComment.GamesId);
            return View(gameComment);
        }

        // GET: GameComments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameComment = await _context.GamesComments.FindAsync(id);
            if (gameComment == null)
            {
                return NotFound();
            }
            ViewData["GamesId"] = new SelectList(_context.Games, "Id", "Id", gameComment.GamesId);
            return View(gameComment);
        }

        // POST: GameComments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Comments,PublishedDate,GamesId,Rating")] GameComment gameComment)
        {
            if (id != gameComment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gameComment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameCommentExists(gameComment.Id))
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
            ViewData["GamesId"] = new SelectList(_context.Games, "Id", "Id", gameComment.GamesId);
            return View(gameComment);
        }

        // GET: GameComments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameComment = await _context.GamesComments
                .Include(g => g.Games)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameComment == null)
            {
                return NotFound();
            }

            return View(gameComment);
        }

        // POST: GameComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gameComment = await _context.GamesComments.FindAsync(id);
            _context.GamesComments.Remove(gameComment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameCommentExists(int id)
        {
            return _context.GamesComments.Any(e => e.Id == id);
        }
    }
}
