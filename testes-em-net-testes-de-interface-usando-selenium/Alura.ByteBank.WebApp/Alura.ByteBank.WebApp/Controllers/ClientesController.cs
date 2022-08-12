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
    
    public class ClientesController : Controller
    {
        private ClienteRepositorio _context;
        public ClientesController()
        {
            _context = new ClienteRepositorio();
        }

        // GET: Clientes
        [Authorize]
        public IActionResult Index()
        {
            return View( _context.ObterTodos());
        }

        // GET: Clientes/Details/5
        [Authorize]
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = _context.ObterPorId(id);
                
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]       
        public ActionResult Create([Bind("Id,Identificador,CPF,Nome,Profissao")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Adicionar(cliente);               
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = _context.ObterPorId(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(int id, [Bind("Id,Identificador,CPF,Nome,Profissao")] Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Atualizar(id,cliente);                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Id))
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
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = _context.ObterPorId(id);
              
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Excluir(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            var cliente = _context.ObterPorId(id);
            _context.Excluir(id);     
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id) {
            var cliente = _context.ObterPorId(id);
            return cliente == null ? true : false;
        }
    }
}
