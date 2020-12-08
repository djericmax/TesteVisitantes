﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TesteVisitantes.Models;

namespace TesteVisitantes.Controllers
{
    public class VisitantesController : Controller
    {
        private readonly DataContext _context;

        public VisitantesController(DataContext context)
        {
            _context = context;
        }

        // GET: Visitantes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Visitantes.ToListAsync());
        }

        // GET: Visitantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitante = await _context.Visitantes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visitante == null)
            {
                return NotFound();
            }

            return View(visitante);
        }

        // GET: Visitantes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Visitantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Empresa,HoraChegada,HoraSaida,Data,Nome,DepartamentoId")] Visitante visitante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(visitante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(visitante);
        }

        // GET: Visitantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitante = await _context.Visitantes.FindAsync(id);
            if (visitante == null)
            {
                return NotFound();
            }
            return View(visitante);
        }

        // POST: Visitantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Empresa,HoraChegada,HoraSaida,Data,Nome,DepartamentoId")] Visitante visitante)
        {
            if (id != visitante.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visitante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitanteExists(visitante.Id))
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
            return View(visitante);
        }

        // GET: Visitantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitante = await _context.Visitantes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visitante == null)
            {
                return NotFound();
            }

            return View(visitante);
        }

        // POST: Visitantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var visitante = await _context.Visitantes.FindAsync(id);
            _context.Visitantes.Remove(visitante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisitanteExists(int id)
        {
            return _context.Visitantes.Any(e => e.Id == id);
        }
    }
}
