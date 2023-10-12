﻿using System;
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
    public class RequestsController : Controller
    {
        private readonly TuckshopContext _context;

        public RequestsController(TuckshopContext context)
        {
            _context = context;
        }

        // GET: Requests
        //sort order feature for requests, sorting by ordername 
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

            var requests = from s in _context.Request
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                requests = requests.Where(s => s.OrderName.Contains(searchString));
                                       
            }

            switch (sortOrder)
            {
                case "name_desc":
                    requests = requests.OrderByDescending(s => s.OrderName);
                    break;
                case "Date":
                    requests = requests.OrderBy(s => s.DateOrdered);
                    break;
                case "date_desc":
                    requests = requests.OrderByDescending(s => s.OrderName);
                    break;
                default:
                    requests = requests.OrderBy(s => s.DateOrdered);
                    break;
            }

            int pageSize = 5;
            return View(await PaginatedList<Request>.CreateAsync(requests.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Requests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Request == null)
            {
                return NotFound();
            }

            var request = await _context.Request
                .Include(r => r.Food)
                .Include(r => r.Payment)
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
            ViewData["FoodID"] = new SelectList(_context.Food, "FoodID", "DrinkName");
            ViewData["PaymentID"] = new SelectList(_context.Payment, "PaymentID", "PaymentName");
            ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "FirstName");
            return View();
        }

        // POST: Requests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RequestID,OrderName,OrderNumber,DateOrdered,FoodID,StudentID,PaymentID")] Request request)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(request);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FoodID"] = new SelectList(_context.Food, "FoodID", "DrinkName", request.FoodID);
            ViewData["PaymentID"] = new SelectList(_context.Payment, "PaymentID", "PaymentName", request.PaymentID);
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
            ViewData["FoodID"] = new SelectList(_context.Food, "FoodID", "DrinkName", request.FoodID);
            ViewData["PaymentID"] = new SelectList(_context.Payment, "PaymentID", "PaymentName", request.PaymentID);
            ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "FirstName", request.StudentID);
            return View(request);
        }

        // POST: Requests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RequestID,OrderName,OrderNumber,DateOrdered,FoodID,StudentID,PaymentID")] Request request)
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
            ViewData["FoodID"] = new SelectList(_context.Food, "FoodID", "DrinkName", request.FoodID);
            ViewData["PaymentID"] = new SelectList(_context.Payment, "PaymentID", "PaymentName", request.PaymentID);
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
                .Include(r => r.Payment)
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
