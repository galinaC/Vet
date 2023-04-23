﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vet.Data;

namespace Vet.Controllers
{
    public class VetsController : Controller
    {
        private readonly ClinicDbContext _context;

        public int Id { get; private set; }

        public VetsController(ClinicDbContext context)
        {
            _context = context;
        }

        // GET: Vets
        public async Task<IActionResult> Index()
        {
              return _context.Vets != null ? 
                          View(await _context.Vets.ToListAsync()) :
                          Problem("Entity set 'ClinicDbContext.Vets'  is null.");
        }

        // GET: Vets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vets == null)
            {
                return NotFound();
            }

            var vet = await _context.Vets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vet == null)
            {
                return NotFound();
            }

            return View(vet);
        }

        // GET: Vets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email")] DriveType vet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vet);
        }

        // GET: Vets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vets == null)
            {
                return NotFound();
            }

            var vet = await _context.Vets.FindAsync(id);
            if (vet == null)
            {
                return NotFound();
            }
            return View(vet);
        }

        // POST: Vets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email")] VetsController vet)
        {
           if (id != vet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VetExists(vet.Id))
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
            return View(vet);
        }

        // GET: Vets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vets == null)
            {
                return NotFound();
            }

            var vet = await _context.Vets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vet == null)
            {
                return NotFound();
            }

            return View(vet);
        }

        // POST: Vets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vets == null)
            {
                return Problem("Entity set 'ClinicDbContext.Vets'  is null.");
            }
            var vet = await _context.Vets.FindAsync(id);
            if (vet != null)
            {
                _context.Vets.Remove(vet);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VetExists(int id)
        {
          return (_context.Vets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
