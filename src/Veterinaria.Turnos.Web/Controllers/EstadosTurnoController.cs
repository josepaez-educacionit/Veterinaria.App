using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Veterinaria.Turnos.Data.Data;
using Veterinaria.Turnos.Data.Entidades;

namespace Veterinaria.Turnos.Web.Controllers
{
    public class EstadosTurnoController : Controller
    {
        private readonly VeterinariaDbContext _context;

        public EstadosTurnoController(VeterinariaDbContext context)
        {
            _context = context;
        }

        // GET: EstadosTurno
        public async Task<IActionResult> Index()
        {
            return View(await _context.EstadosTurno.ToListAsync());
        }

        // GET: EstadosTurno/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoTurno = await _context.EstadosTurno.FirstOrDefaultAsync(m => m.Id == id);
            if (estadoTurno == null)
            {
                return NotFound();
            }

            return View(estadoTurno);
        }

        // GET: EstadosTurno/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstadosTurno/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] EstadoTurno estadoTurno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadoTurno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadoTurno);
        }

        // GET: EstadosTurno/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoTurno = await _context.EstadosTurno.FindAsync(id);
            if (estadoTurno == null)
            {
                return NotFound();
            }
            return View(estadoTurno);
        }

        // POST: EstadosTurno/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] EstadoTurno estadoTurno)
        {
            if (id != estadoTurno.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadoTurno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoTurnoExists(estadoTurno.Id))
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
            return View(estadoTurno);
        }

        // GET: EstadosTurno/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoTurno = await _context.EstadosTurno
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estadoTurno == null)
            {
                return NotFound();
            }

            return View(estadoTurno);
        }

        // POST: EstadosTurno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estadoTurno = await _context.EstadosTurno.FindAsync(id);
            if (estadoTurno != null)
            {
                _context.EstadosTurno.Remove(estadoTurno);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoTurnoExists(int id)
        {
            return _context.EstadosTurno.Any(e => e.Id == id);
        }
    }
}
