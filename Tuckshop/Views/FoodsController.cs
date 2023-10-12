using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tuckshop.Areas.Identity.Data;
using Tuckshop.Models;

namespace Tuckshop.Views
{
    [Authorize(Roles = "Admin, Teacher, Student")]
    public class FoodsController : Controller
    {
        private readonly TuckshopContext _context;

        public FoodsController(TuckshopContext context)
        {
            _context = context;
        }

        // GET: Foods
        public async Task<IActionResult> Index(
         string sortOrder,
         string currentFilter,
         string searchString,
         int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var foods = from s in _context.Food
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                foods = foods.Where(s => s.FoodName.Contains(searchString));

            }
            switch (sortOrder)
            {
                case "name_desc":
                    foods = foods.OrderByDescending(s => s.FoodName);
                    break;
                case "Date":
                    foods = foods.OrderBy(s => s.DrinkName);
                    break;
                case "date_desc":
                    foods = foods.OrderByDescending(s => s.FoodName);
                    break;
                default:
                    foods = foods.OrderBy(s => s.DrinkName);
                    break;
            }

            int pageSize = 5;
            return View(await PaginatedList<Food>.CreateAsync(foods.AsNoTracking(), pageNumber ?? 1 , pageSize));
        }

        // GET: Foods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Food == null)
            {
                return NotFound();
            }

            var food = await _context.Food
                .FirstOrDefaultAsync(m => m.FoodID == id);
            if (food == null)
            {
                return NotFound();
            }

            return View(food);
        }

        // GET: Foods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Foods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FoodID,FoodName,DrinkName,Amount")] Food food)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(food);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(food);
        }

        // GET: Foods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Food == null)
            {
                return NotFound();
            }

            var food = await _context.Food.FindAsync(id);
            if (food == null)
            {
                return NotFound();
            }
            return View(food);
        }

        // POST: Foods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FoodID,FoodName,DrinkName,Amount")] Food food)
        {
            if (id != food.FoodID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(food);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodExists(food.FoodID))
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
            return View(food);
        }

        // GET: Foods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Food == null)
            {
                return NotFound();
            }

            var food = await _context.Food
                .FirstOrDefaultAsync(m => m.FoodID == id);
            if (food == null)
            {
                return NotFound();
            }

            return View(food);
        }

        // POST: Foods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Food == null)
            {
                return Problem("Entity set 'TuckshopContext.Food'  is null.");
            }
            var food = await _context.Food.FindAsync(id);
            if (food != null)
            {
                _context.Food.Remove(food);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodExists(int id)
        {
          return (_context.Food?.Any(e => e.FoodID == id)).GetValueOrDefault();
        }
    }
}

//enum which lets the user see options when they order the food
public enum Foods
{
    Hamburger = 0,
    Salad = 1,
    Wrap = 2,
}

public enum Drinks
{
    Water = 0,
    Coke = 1,
    Sprite = 2,
    Milk = 3,
}
