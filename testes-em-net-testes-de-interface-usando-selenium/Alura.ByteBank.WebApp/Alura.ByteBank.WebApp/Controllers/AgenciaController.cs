using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ByteBank.WebApp.Controllers
{
    public class AgenciaController : Controller
    {
        // GET: AgenciaController
        private AgenciaRepositorio repositorio;
        public AgenciaController()
        {
            repositorio = new AgenciaRepositorio();
        }

        [Authorize]
        public ActionResult Index()
        {
            return View(repositorio.ObterTodos());
        }

        // GET: AgenciaController/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            var agencia = repositorio.ObterPorId(id);
            return View(agencia);
        }

        // GET: AgenciaController/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: AgenciaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind("Id,Identificador,Numero,Nome,Endereco")] Agencia agencia)
        {
            try
            {
                repositorio.Adicionar(agencia);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(agencia);
            }
        }

        // GET: AgenciaController/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var agencia = repositorio.ObterPorId(id);
            if (agencia == null)
            {
                return NotFound();
            }
            return View(agencia);
        }

        // POST: AgenciaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(int id, [Bind("Id,Identificador,Numero,Nome,Endereco")] Agencia agencia)
        {
          
            if (id != agencia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    repositorio.Atualizar(id, agencia);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgenciaExists(agencia.Id))
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
            return View(agencia);
        }

        // GET: AgenciaController/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
       
            var agencia = repositorio.ObterPorId(id);

            if (agencia == null)
            {
                return NotFound();
            }

            repositorio.Excluir(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: AgenciaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            var agencia = repositorio.ObterPorId(id);
            repositorio.Excluir(id);
            return RedirectToAction(nameof(Index));
        }

        private bool AgenciaExists(int id)
        {
            var agencia = repositorio.ObterPorId(id);
            return agencia == null ? true : false;
        }
    }
}
