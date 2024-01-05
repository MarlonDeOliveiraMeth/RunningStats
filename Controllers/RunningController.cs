using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RunningStats.Data;
using RunningStats.Models;

namespace RunningStats.Controllers
{
    public class RunningController : Controller
    {
        private readonly RunningStatsContext _context;

        public RunningController(RunningStatsContext context)
        {
            _context = context;
        }

        // GET: Running
        public async Task<IActionResult> Index()
        {
            var runningData = _context.RunningModel
                .OrderBy(entry => entry.Date.Year)
                .ThenBy(entry => entry.Date.Month)
                .ThenBy(entry => entry.Date.Day)
                .ToListAsync();

            return View(await runningData);
        }

        // GET: Running/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var runningModel = await _context.RunningModel
                .FirstOrDefaultAsync(m => m.RunningId == id);
            if (runningModel == null)
            {
                return NotFound();
            }

            return View(runningModel);
        }

        // GET: Running/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Running/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RunningId,Meters,Minutes,Date")] RunningModel runningModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(runningModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(runningModel);
        }

        // GET: Running/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var runningModel = await _context.RunningModel.FindAsync(id);
            if (runningModel == null)
            {
                return NotFound();
            }
            return View(runningModel);
        }

        // POST: Running/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RunningId,Meters,Minutes,Date")] RunningModel runningModel)
        {
            if (id != runningModel.RunningId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(runningModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RunningModelExists(runningModel.RunningId))
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
            return View(runningModel);
        }

        // GET: Running/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var runningModel = await _context.RunningModel
                .FirstOrDefaultAsync(m => m.RunningId == id);
            if (runningModel == null)
            {
                return NotFound();
            }

            return View(runningModel);
        }

        // POST: Running/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var runningModel = await _context.RunningModel.FindAsync(id);
            if (runningModel != null)
            {
                _context.RunningModel.Remove(runningModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RunningModelExists(int id)
        {
            return _context.RunningModel.Any(e => e.RunningId == id);
        }
    }
}
