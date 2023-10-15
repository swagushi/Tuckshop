using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tuckshop.Areas.Identity.Data;
using Tuckshop.Models;

namespace Tuckshop.Views
{
    public class RequestsController : Controller
    {
        private readonly TuckshopContext _context;

        public RequestsController(TuckshopContext context)
        {
            _context = context;
        }

        // GET: Requests
        public async Task<IActionResult> Index()
        {
            var tuckshopContext = _context.Request.Include(r => r.Food).Include(r => r.Student);
            return View(await tuckshopContext.ToListAsync());
        }

        public async Task<ActionResult> RedirectToWebsite()
        {
            await _context.SaveChangesAsync();
            return Redirect("https://www.youtube.com");


        }

        [HttpPost]
    
        // GET: Requests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Request == null)
            {
                return NotFound();
            }

            var request = await _context.Request
                .Include(r => r.Food)
                .Include(r => r.Student)
                .FirstOrDefaultAsync(m => m.RequestID == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // GET: Requests/Create
        public IActionResult Create()
        {
            ViewData["FoodID"] = new SelectList(_context.Food, "FoodID", "FoodID");
            ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "FirstName");
            return View();
        }

        // POST: Requests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RequestID,OrderNumber,DateOrdered,FoodID,StudentID")] Request request)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(request);
                await _context.SaveChangesAsync();
                return Redirect("https://www.youtube.com");
            }
            ViewData["FoodID"] = new SelectList(_context.Food, "FoodID", "FoodID", request.FoodID);
            ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "FirstName", request.StudentID);
            return View(request);
        }

        // GET: Requests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Request == null)
            {
                return NotFound();
            }

            var request = await _context.Request.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }
            ViewData["FoodID"] = new SelectList(_context.Food, "FoodID", "FoodID", request.FoodID);
            ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "FirstName", request.StudentID);
            return View(request);
        }

        // POST: Requests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RequestID,OrderNumber,DateOrdered,FoodID,StudentID")] Request request)
        {
            if (id != request.RequestID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(request);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestExists(request.RequestID))
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
            ViewData["FoodID"] = new SelectList(_context.Food, "FoodID", "FoodID", request.FoodID);
            ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "FirstName", request.StudentID);
            return View(request);
        }

        // GET: Requests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Request == null)
            {
                return NotFound();
            }

            var request = await _context.Request
                .Include(r => r.Food)
                .Include(r => r.Student)
                .FirstOrDefaultAsync(m => m.RequestID == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // POST: Requests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Request == null)
            {
                return Problem("Entity set 'TuckshopContext.Request'  is null.");
            }
            var request = await _context.Request.FindAsync(id);
            if (request != null)
            {
                _context.Request.Remove(request);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestExists(int id)
        {
          return (_context.Request?.Any(e => e.RequestID == id)).GetValueOrDefault();
        }
    }
}
