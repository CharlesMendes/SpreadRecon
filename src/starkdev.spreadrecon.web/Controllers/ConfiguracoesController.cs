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
    public class ConfiguracoesController : BaseController
    {
        private ConfiguracoesBLL _bll;
        private ResultadoProcessamentoBLL _bllResultadoProcessamento;
        private ImportacaoPlanilhaBLL _bllImportacaoPlanilha;

        public ConfiguracoesController()
        {
            _bll = new ConfiguracoesBLL();
            _bllResultadoProcessamento = new ResultadoProcessamentoBLL();
            _bllImportacaoPlanilha = new ImportacaoPlanilhaBLL();
        }

        [PermissoesFiltro(Roles = "STARK, ADMIN")]
        public ActionResult Index()
        {
            return View();
        }

        [PermissoesFiltro(Roles = "STARK, ADMIN")]
        public ActionResult ZerarBase()
        {
            _bll.ZerarBase();
            return View("Index");
        }

        [PermissoesFiltro(Roles = "STARK, ADMIN")]
        public ActionResult Conciliar()
        {
            _bllResultadoProcessamento.Conciliar();
            return View("Index");
        }

        [PermissoesFiltro(Roles = "STARK, ADMIN")]
        public ActionResult Importar()
        {
            _bllImportacaoPlanilha.Importar();
            return View("Index");
        }
    }
}
