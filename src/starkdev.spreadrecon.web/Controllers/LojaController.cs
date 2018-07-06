using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using starkdev.spreadrecon.business;
using starkdev.spreadrecon.model;
using starkdev.spreadrecon.business.security;

namespace starkdev.spreadrecon.web.Controllers
{
    public class LojaController : BaseController, IController<Loja>
    {
        private LojaBLL _bll;
        public LojaController()
        {
            _bll = new LojaBLL();
        }

        [PermissoesFiltro(Roles = "STARK, ADMIN")]
        public ActionResult BuscarPorId(int id)
        {
            var obj = _bll.Detalhe(id);

            if (obj == null)
                return HttpNotFound();

            return View(obj);
        }

        [PermissoesFiltro(Roles = "STARK, ADMIN")]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [PermissoesFiltro(Roles = "STARK, ADMIN")]
        public ActionResult Cadastrar(Loja obj)
        {
            return this.Salvar(obj);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ConfirmarExcluir(int id)
        {
            _bll.Excluir(id);
            return RedirectToAction("Index");
        }

        [PermissoesFiltro(Roles = "STARK, ADMIN")]
        public ActionResult Detalhe(int id)
        {
            return this.BuscarPorId(id);
        }

        [HttpPost]
        [PermissoesFiltro(Roles = "STARK, ADMIN")]
        public ActionResult Editar(Loja obj)
        {
            return this.Salvar(obj);
        }

        [PermissoesFiltro(Roles = "STARK, ADMIN")]
        public ActionResult Editar(int id)
        {
            return this.BuscarPorId(id);
        }

        [PermissoesFiltro(Roles = "STARK, ADMIN")]
        public ActionResult Excluir(int id)
        {
            return this.BuscarPorId(id);
        }

        [PermissoesFiltro(Roles = "STARK, ADMIN")]
        public ActionResult Index()
        {
            var lista = _bll.ListarTodos();
            return View(lista);
        }

        [PermissoesFiltro(Roles = "STARK, ADMIN")]
        public ActionResult Salvar(Loja obj)
        {
            if (ModelState.IsValid)
            {
                _bll.Salvar(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
