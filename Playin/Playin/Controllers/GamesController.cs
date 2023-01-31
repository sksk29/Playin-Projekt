#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Playin.Data;
using Playin.Models;
using Playin.ViewModels;

namespace Playin.Controllers
{
    public class GamesController : Controller
    {
        private readonly PlayinContext _context;

        public GamesController(PlayinContext context)
        {
            _context = context;
        }

        // GET: Games
        public ViewResult Index(string searchString, string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.GenreSortParm = String.IsNullOrEmpty(sortOrder) ? "genre_desc" : "Genre";

            var games = from g in _context.Games
                        select g;

            if (!String.IsNullOrEmpty(searchString))
            {
                games = games.Where(g => g.Name!.Contains(searchString));
            }


            switch(sortOrder)
            {
                case "name_desc":
                    games = games.OrderByDescending(s => s.Name);
                    break;
                case "Date":
                    games = games.OrderBy(s => s.ReleaseDate);
                    break;
                case "date_desc":
                    games = games.OrderByDescending(s => s.ReleaseDate);
                    break;
                case "genre_desc":
                    games = games.OrderByDescending(s => s.Genre);
                    break;
                case "Genre":
                    games = games.OrderBy(s => s.Genre);
                    break;
                default:
                    games = games.OrderBy(s => s.Name);
                    break;

            }
            return View(games.ToList());
        }

            [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }
        // GET: Games/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Game game = _context.Games.Find(id);
            GameCommentViewModel vm = new GameCommentViewModel();

            if (game == null)
            {
                return NotFound();
            }
            vm.GamesId = id.Value;
            vm.Title = game.Name;
            var Comments = _context.GamesComments.Where(d => d.GamesId.Equals(id.Value)).ToList();
            vm.ListOfComments = Comments;

            var ratings = _context.GamesComments.Where(d => d.GamesId.Equals(id.Value)).ToList();
            if (ratings.Count() > 0)
            {
                var ratingSum = ratings.Sum(d => d.Rating);
                ViewBag.RatingSum = ratingSum;
                var ratingCount = ratings.Count();
                ViewBag.RatingCount = ratingCount;
            }
            else
            {
                ViewBag.RatingSum = 0;
                ViewBag.RatingCount = 0;
            }
            return View(vm);
        }

        // GET: Games/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ReleaseDate,Genre")] Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Add(game);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Games/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ReleaseDate,Genre")] Game game)
        {
            if (id != game.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(game);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(game.Id))
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
            return View(game);
        }

        // GET: Games/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // POST: Games/Delete/5
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var game = await _context.Games.FindAsync(id);
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameExists(int id)
        {
            return _context.Games.Any(e => e.Id == id);
        }
    }
}
