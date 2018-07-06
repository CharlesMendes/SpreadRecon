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
using starkdev.spreadrecon.model.Enum;

namespace starkdev.spreadrecon.web.Controllers
{
    public class RelatorioController : BaseController
    {
        private RelatorioBLL _bll;

        public RelatorioController()
        {
            _bll = new RelatorioBLL();
        }

        /// <summary>
        /// GET: Relatório 1: Exibir Terminais Achados
        /// </summary>
        /// <returns></returns>
        public ActionResult TerminaisAchadosPorCiclo(long idLoja, string ciclo)
        {
            var lista = _bll.ExibirTerminaisAchados(idLoja, ciclo);
            return View(lista);
        }

        public ActionResult TerminaisAchados()
        {
            long? idLojaUsuarioLogado = null;

            // Recupera o id da loja do franqueado
            if (User.IsInRole("FRANQUEADO"))
                idLojaUsuarioLogado = User.Identity.Name.Split('|')[1].Split(':')[1].ToLong();

            var lista = _bll.ListarRelatorio(idLojaUsuarioLogado, TipoRelatorioEnum.ExibirTerminaisAchados);
            return View(lista);
        }

        /// <summary>
        /// GET: Relatório 2: Exibir Terminais Pagos Sem Venda
        /// </summary>
        /// <returns></returns>
        public ActionResult TerminaisPagosSemVendaPorCiclo(long idLoja, string ciclo)
        {
            var lista = _bll.ExibirTerminaisPagosSemVenda(idLoja, ciclo);
            return View(lista);
        }

        public ActionResult TerminaisPagosSemVenda()
        {
            long? idLojaUsuarioLogado = null;

            // Recupera o id da loja do franqueado
            if (User.IsInRole("FRANQUEADO"))
                idLojaUsuarioLogado = User.Identity.Name.Split('|')[1].Split(':')[1].ToLong();

            var lista = _bll.ListarRelatorio(idLojaUsuarioLogado, TipoRelatorioEnum.ExibirTerminaisPagosSemVenda);
            return View(lista);
        }
    }
}
