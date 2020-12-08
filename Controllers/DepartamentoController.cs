using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteVisitantes.Models;

namespace TesteVisitantes.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly DataContext _context;

        public DepartamentoController(DataContext context)
        {
            _context = context;
        }
        
        // GET: DepartamentoController
        [HttpGet]//Desenvolvido pelo Scaffolding e EF core
        public async Task<IActionResult> Index()
        {
            return View(await _context.Departamentos.ToListAsync());
        }

        // INDEX - Desenvolvido a  mão, funciona perfeitamente - Eric Figueiredo.
        /* public async Task<ActionResult<List<Departamento>>> Index([FromServices] DataContext scontext)
        {
            var deptos = await scontext.Departamentos.ToListAsync();
            return View(new List<Departamento>(deptos));
        } */


        // GET: DepartamentoController/Details/5
        [HttpGet]//Desenvolvido pelo Scaffolding e EF core
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamento = await _context.Departamentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }

        // DETAILS - Desenvolvido a  mão, funciona perfeitamente - Eric Figueiredo.
        /* public async Task<ActionResult<Departamento>> Details([FromServices] DataContext scontext, int id)
        {
            var deptos = await scontext.Departamentos
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return View(deptos);
        } */

        // GET: DepartamentoController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DepartamentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Depto")] Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departamento);
        }

        // CREATE - Desenvolvido a  mão, funciona perfeitamente - Eric Figueiredo.
        /* public ActionResult Create(Departamento departamento)
        {
            try
            {
                _context.Add(departamento);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        } */

        // GET: DepartamentoController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamento = await _context.Departamentos.FindAsync(id);
            if (departamento == null)
            {
                return NotFound();
            }
            return View(departamento);
        }

        // POST: DepartamentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Depto")] Departamento departamento)
        {
            if (id != departamento.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartamentoExists(departamento.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(departamento);
        }

        // EDIT - Desenvolvido a  mão, funciona perfeitamente - Eric Figueiredo.
        /* public ActionResult Edit(int id, Departamento departamento)
        {
            try
            {
                if (id != departamento.Id)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    _context.Update(departamento);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return View(departamento);
            }
            catch
            {
                return View();
            }
        }  */

        // GET: DepartamentoController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamento = await _context.Departamentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }

        // POST: DepartamentoController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departamento = await _context.Departamentos.FindAsync(id);
            _context.Departamentos.Remove(departamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // DELETE - Desenvolvido a  mão, funciona perfeitamente - Eric Figueiredo.
        /*public ActionResult Delete(int id, Departamento departamento)
        {
            try
            {
                if (id != departamento.Id)
                {
                    return NotFound();
                }
                else
                {
                    _context.Remove(departamento);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View();
            }
        }*/

        private bool DepartamentoExists(int id)
        {
            return _context.Departamentos.Any(e => e.Id == id);
        }
}
}
