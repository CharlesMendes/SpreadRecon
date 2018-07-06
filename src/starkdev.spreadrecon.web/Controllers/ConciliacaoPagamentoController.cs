using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using starkdev.spreadrecon.business;
using starkdev.spreadrecon.model;
using starkdev.utils;
using starkdev.spreadrecon.business.security;

namespace starkdev.spreadrecon.web.Controllers
{
    public class ConciliacaoPagamentoController : BaseController, IController<ResultadoProcessamento>
    {
        private ResultadoProcessamentoBLL _bll;
        private ImportacaoPlanilhaBLL _bllImportacaoPlanilha;

        public ConciliacaoPagamentoController()
        {
            _bll = new ResultadoProcessamentoBLL();
            _bllImportacaoPlanilha = new ImportacaoPlanilhaBLL();
        }

        public ActionResult BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Cadastrar()
        {
            throw new NotImplementedException();
        }

        public ActionResult Cadastrar(ResultadoProcessamento obj)
        {
            throw new NotImplementedException();
        }

        public ActionResult ConfirmarExcluir(int id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Detalhe(int id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Editar(ResultadoProcessamento obj)
        {
            throw new NotImplementedException();
        }

        public ActionResult Editar(int id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Excluir(int id)
        {
            throw new NotImplementedException();
        }

        [PermissoesFiltro(Roles = "STARK, ADMIN, FRANQUEADO")]
        public ActionResult Index()
        {
            //Dados do usuario logado
            var usuarioLogado = User.Identity.Name;
            //var idPerfilUsuarioLogado = usuarioLogado.Split('|')[1].Split(':')[5].ToLong();

            long idLojaUsuarioLogado = 0;

            //Se usuario é 3-FRANQUEADO, apenas ira acessar listagem de sua loja, 
            //caso contrario mantem 0 para listar todas as lojas
            if (User.IsInRole("FRANQUEADO"))
                idLojaUsuarioLogado = usuarioLogado.Split('|')[1].Split(':')[1].ToLong();

            var lista = _bll.ListarTodosPagamentosConciliados(idLojaUsuarioLogado);
            return View(lista);
        }

        public ActionResult Salvar(ResultadoProcessamento obj)
        {
            throw new NotImplementedException();
        }

        public ActionResult ExcluirProcessamento(long idVendas, long idOperadora)
        {
            _bll.ExcluirPorVendasOperadora(idVendas, idOperadora);
            _bllImportacaoPlanilha.Excluir(idVendas.ToInt32());
            _bllImportacaoPlanilha.Excluir(idOperadora.ToInt32());

            return RedirectToAction("Index");
        }
    }
}