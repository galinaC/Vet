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
    public class ConsultingServicesController : Controller
    {
        private readonly ClinicDbContext _context;

        public ConsultingServicesController(ClinicDbContext context)
        {
            _context = context;
        }

        // GET: ConsultingServices
        public async Task<IActionResult> Index()
        {
              return _context.ConsultingServices != null ? 
                          View(await _context.ConsultingServices.ToListAsync()) :
                          Problem("Entity set 'ClinicDbContext.ConsultingServices'  is null.");
        }

        // GET: ConsultingServices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ConsultingServices == null)
            {
                return NotFound();
            }

            var consultingService = await _context.ConsultingServices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consultingService == null)
            {
                return NotFound();
            }

            return View(consultingService);
        }

        // GET: ConsultingServices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ConsultingServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Date,UserId")] ConsultingService consultingService)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consultingService);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(consultingService);
        }

        // GET: ConsultingServices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ConsultingServices == null)
            {
                return NotFound();
            }

            var consultingService = await _context.ConsultingServices.FindAsync(id);
            if (consultingService == null)
            {
                return NotFound();
            }
            return View(consultingService);
        }

        // POST: ConsultingServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Date,UserId")] ConsultingService consultingService)
        {
            if (id != consultingService.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consultingService);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultingServiceExists(consultingService.Id))
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
            return View(consultingService);
        }

        // GET: ConsultingServices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ConsultingServices == null)
            {
                return NotFound();
            }

            var consultingService = await _context.ConsultingServices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consultingService == null)
            {
                return NotFound();
            }

            return View(consultingService);
        }

        // POST: ConsultingServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ConsultingServices == null)
            {
                return Problem("Entity set 'ClinicDbContext.ConsultingServices'  is null.");
            }
            var consultingService = await _context.ConsultingServices.FindAsync(id);
            if (consultingService != null)
            {
                _context.ConsultingServices.Remove(consultingService);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultingServiceExists(int id)
        {
          return (_context.ConsultingServices?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
