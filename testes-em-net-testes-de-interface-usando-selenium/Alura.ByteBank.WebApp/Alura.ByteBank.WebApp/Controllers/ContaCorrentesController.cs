using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Alura.ByteBank.Dados.Contexto;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dados.Repositorio;
using Microsoft.AspNetCore.Authorization;

namespace Alura.ByteBank.WebApp.Controllers
{
    
    public class ContaCorrentesController : Controller
    {
        private ContaCorrenteRepositorio _context;

        public ContaCorrentesController()
        {
            _context = new ContaCorrenteRepositorio();
        }
        [Authorize]
        // GET: ContaCorrentes
        public ActionResult Index()
        {
            return View( _context.ObterTodos());
        }

        [Authorize]
        // GET: ContaCorrentes/Details/5
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contaCorrente =  _context.ObterPorId(id);
                
            if (contaCorrente == null)
            {
                return NotFound();
            }

            return View(contaCorrente);
        }

        [Authorize]
        // GET: ContaCorrentes/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Numero,Identificador,Saldo,PixConta")] ContaCorrente contaCorrente)
        {
            if (ModelState.IsValid)
            {
                _context.Adicionar(contaCorrente);                
                return RedirectToAction(nameof(Index));
            }
            return View(contaCorrente);
        }

        // GET: ContaCorrentes/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contaCorrente = _context.ObterPorId(id); ;
            if (contaCorrente == null)
            {
                return NotFound();
            }
            return View(contaCorrente);
        }

        // POST: ContaCorrentes/Edit/5
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,Numero,Identificador,Saldo,PixConta")] ContaCorrente contaCorrente)
        {
            if (id != contaCorrente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Atualizar(id,contaCorrente);                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContaCorrenteExists(contaCorrente.Id))
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
            return View(contaCorrente);
        }

        // GET: ContaCorrentes/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contaCorrente = _context.ObterPorId(id);                
            if (contaCorrente == null)
            {
                return NotFound();
            }

            _context.Excluir(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: ContaCorrentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var contaCorrente = _context.ObterPorId(id);
            _context.Excluir(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ContaCorrenteExists(int id)
        {
            var contaCorrente = _context.ObterPorId(id);
            return contaCorrente == null ? true : false;
        }
    }
}
