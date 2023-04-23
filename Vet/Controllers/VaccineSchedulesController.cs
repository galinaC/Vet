using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vet.Data;

namespace Vet.Controllers
{
    public class VaccineSchedulesController : Controller
    {
        private readonly ClinicDbContext _context;

        public VaccineSchedulesController(ClinicDbContext context)
        {
            _context = context;
        }

        // GET: VaccineSchedules
        public async Task<IActionResult> Index()
        {
            var clinicDbContext = _context.VaccineSchedules.Include(v => v.Animal).Include(v => v.Vaccine);
            return View(await clinicDbContext.ToListAsync());
        }

        // GET: VaccineSchedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VaccineSchedules == null)
            {
                return NotFound();
            }

            var vaccineSchedule = await _context.VaccineSchedules
                .Include(v => v.Animal)
                .Include(v => v.Vaccine)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vaccineSchedule == null)
            {
                return NotFound();
            }

            return View(vaccineSchedule);
        }

        // GET: VaccineSchedules/Create
        public IActionResult Create()
        {
            ViewData["AnimalId"] = new SelectList(_context.Animals, "Id", "Id");
            ViewData["VaccineId"] = new SelectList(_context.Vaccines, "Id", "Id");
            return View();
        }

        // POST: VaccineSchedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,UserId,VaccineId,AnimalId")] VaccineSchedule vaccineSchedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vaccineSchedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnimalId"] = new SelectList(_context.Animals, "Id", "Id", vaccineSchedule.AnimalId);
            ViewData["VaccineId"] = new SelectList(_context.Vaccines, "Id", "Id", vaccineSchedule.VaccineId);
            return View(vaccineSchedule);
        }

        // GET: VaccineSchedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.VaccineSchedules == null)
            {
                return NotFound();
            }

            var vaccineSchedule = await _context.VaccineSchedules.FindAsync(id);
            if (vaccineSchedule == null)
            {
                return NotFound();
            }
            ViewData["AnimalId"] = new SelectList(_context.Animals, "Id", "Id", vaccineSchedule.AnimalId);
            ViewData["VaccineId"] = new SelectList(_context.Vaccines, "Id", "Id", vaccineSchedule.VaccineId);
            return View(vaccineSchedule);
        }

        // POST: VaccineSchedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,UserId,VaccineId,AnimalId")] VaccineSchedule vaccineSchedule)
        {
            if (id != vaccineSchedule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vaccineSchedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VaccineScheduleExists(vaccineSchedule.Id))
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
            ViewData["AnimalId"] = new SelectList(_context.Animals, "Id", "Id", vaccineSchedule.AnimalId);
            ViewData["VaccineId"] = new SelectList(_context.Vaccines, "Id", "Id", vaccineSchedule.VaccineId);
            return View(vaccineSchedule);
        }

        // GET: VaccineSchedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.VaccineSchedules == null)
            {
                return NotFound();
            }

            var vaccineSchedule = await _context.VaccineSchedules
                .Include(v => v.Animal)
                .Include(v => v.Vaccine)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vaccineSchedule == null)
            {
                return NotFound();
            }

            return View(vaccineSchedule);
        }

        // POST: VaccineSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.VaccineSchedules == null)
            {
                return Problem("Entity set 'ClinicDbContext.VaccineSchedules'  is null.");
            }
            var vaccineSchedule = await _context.VaccineSchedules.FindAsync(id);
            if (vaccineSchedule != null)
            {
                _context.VaccineSchedules.Remove(vaccineSchedule);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VaccineScheduleExists(int id)
        {
          return (_context.VaccineSchedules?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
