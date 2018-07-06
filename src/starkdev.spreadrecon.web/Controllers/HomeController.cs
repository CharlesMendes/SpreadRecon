using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using starkdev.spreadrecon.business;
using starkdev.spreadrecon.model;

namespace starkdev.spreadrecon.web.Controllers
{
    public class HomeController : Controller
    {
        private PessoaBLL _bll;
        public HomeController()
        {
            _bll = new PessoaBLL();
        }

        #region Metodos Comum
        private ActionResult BuscarPorId(int id)
        {
            var obj = _bll.Detalhe(id);

            if (obj == null)
                return HttpNotFound();

            return View(obj);
        }

        private ActionResult Salvar(Pessoa obj)
        {
            if (ModelState.IsValid)
            {
                _bll.Salvar(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        #endregion

        public ActionResult Index()
        {
            var lista = _bll.ListarTodos();
            return View(lista);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Pessoa obj)
        {
            return this.Salvar(obj);
        }

        public ActionResult Editar(int id)
        {
            return this.BuscarPorId(id);
        }

        [HttpPost]
        public ActionResult Editar(Pessoa obj)
        {
            return this.Salvar(obj);
        }

        public ActionResult Detalhe(int id)
        {
            return this.BuscarPorId(id);
        }

        public ActionResult Excluir(int id)
        {
            return this.BuscarPorId(id);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ConfirmarExcluir(int id)
        {
            _bll.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}
