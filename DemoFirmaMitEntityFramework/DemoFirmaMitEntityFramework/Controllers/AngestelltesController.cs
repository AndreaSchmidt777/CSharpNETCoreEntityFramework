using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoFirmaMitEntityFramework.Data;
using DemoFirmaMitEntityFramework.Models;

namespace DemoFirmaMitEntityFramework.Controllers
{
    public class AngestelltesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AngestelltesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Angestelltes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mitarbeiter.ToListAsync());
        }

        // GET: Angestelltes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var angestellte = await _context.Mitarbeiter
                .FirstOrDefaultAsync(m => m.MitarbeiterID == id);
            if (angestellte == null)
            {
                return NotFound();
            }

            return View(angestellte);
        }

        // GET: Angestelltes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Angestelltes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MitarbeiterID,Vorname,Nachname")] Angestellte angestellte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(angestellte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(angestellte);
        }

        // GET: Angestelltes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var angestellte = await _context.Mitarbeiter.FindAsync(id);
            if (angestellte == null)
            {
                return NotFound();
            }
            return View(angestellte);
        }

        // POST: Angestelltes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MitarbeiterID,Vorname,Nachname")] Angestellte angestellte)
        {
            if (id != angestellte.MitarbeiterID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(angestellte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AngestellteExists(angestellte.MitarbeiterID))
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
            return View(angestellte);
        }

        // GET: Angestelltes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var angestellte = await _context.Mitarbeiter
                .FirstOrDefaultAsync(m => m.MitarbeiterID == id);
            if (angestellte == null)
            {
                return NotFound();
            }

            return View(angestellte);
        }

        // POST: Angestelltes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var angestellte = await _context.Mitarbeiter.FindAsync(id);
            _context.Mitarbeiter.Remove(angestellte);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AngestellteExists(int id)
        {
            return _context.Mitarbeiter.Any(e => e.MitarbeiterID == id);
        }
    }
}
