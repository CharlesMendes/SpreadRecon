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
using System.Configuration;

namespace starkdev.spreadrecon.web.Controllers
{
    public class PagamentoOperadoraController : BaseController, IController<PagamentoOperadora>
    {
        private PagamentoOperadoraBLL _bll;
        private ImportacaoPlanilhaBLL _bllImportacaoPlanilha;

        public PagamentoOperadoraController()
        {
            _bll = new PagamentoOperadoraBLL();
            _bllImportacaoPlanilha = new ImportacaoPlanilhaBLL();
        }

        [PermissoesFiltro(Roles = "STARK, ADMIN, FRANQUEADO")]
        public ActionResult BuscarPorId(int id)
        {
            var obj = _bll.Detalhe(id);

            if (obj == null)
                return HttpNotFound();

            return View(obj);
        }

        public ActionResult Cadastrar()
        {
            throw new NotImplementedException();
        }

        public ActionResult Cadastrar(PagamentoOperadora obj)
        {
            throw new NotImplementedException();
        }

        public ActionResult ConfirmarExcluir(int id)
        {
            throw new NotImplementedException();
        }

        [PermissoesFiltro(Roles = "STARK, ADMIN, FRANQUEADO")]
        public ActionResult Detalhe(int id)
        {
            return this.BuscarPorId(id);
        }

        [PermissoesFiltro(Roles = "STARK, ADMIN, FRANQUEADO")]
        public ActionResult Linhas(int id)
        {
            var obj = _bll.ListarLinhas(id);

            if (obj == null)
                return HttpNotFound();

            return View(obj);
        }

        public ActionResult Editar(PagamentoOperadora obj)
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

            //Busca todas as importacoes de pagamento operadora (tipo: ciclo pagamento)
            var lista = _bllImportacaoPlanilha.ListarTodos(2, idLojaUsuarioLogado);
            //var listaRetorno = new List<ImportacaoPlanilha>();

            //Gera url para dowload do arquivo .log
            //var urlBase = Request.Url.Authority;
            //var appSettings = ConfigurationManager.AppSettings;
            //string _diretorioLog = appSettings["_diretorioLog"];

            //foreach (var item in lista)
            //{
            //    item._diretorioLog = string.Format("{0}/{1}{2}", urlBase, _diretorioLog, item.nomeArquivoErro);
            //    listaRetorno.Add(item);
            //}

            return View(lista);
        }

        public ActionResult Salvar(PagamentoOperadora obj)
        {
            throw new NotImplementedException();
        }

        [PermissoesFiltro(Roles = "STARK, FRANQUEADO")]
        public ActionResult Upload(FormCollection formCollection)
        {
            if (Request != null)
            {
                var appSettings = ConfigurationManager.AppSettings;
                string _diretorioPendente = string.Format("{0}{1}", "~/", appSettings["_diretorioPendente"]);
                string _diretorioProcessado = string.Format("{0}{1}", "~/", appSettings["_diretorioProcessado"]);
                string _diretorioLog = string.Format("{0}{1}", "~/", appSettings["_diretorioLog"]);

                HttpPostedFileBase file = Request.Files["uploadArquivo"];
                if (file != null)
                    if (file.ContentType == "application/vnd.ms-excel" || file.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                    {
                        //Importa arquivo
                        ImportacaoPlanilha importacao = new ImportacaoPlanilha();
                        importacao.idStatus = 4;
                        importacao.idTipoPlanilha = 2;
                        importacao.idUsuarioImportacao = User.Identity.Name.Split('|')[0].Split(':')[1].ToInt32();
                        importacao.idLoja = User.Identity.Name.Split('|')[1].Split(':')[1].ToLong();
                        importacao._diretorioPendente = Server.MapPath(_diretorioPendente);
                        importacao._diretorioProcessado = Server.MapPath(_diretorioProcessado);
                        importacao._diretorioLog = Server.MapPath(_diretorioLog);
                        importacao.dataInicioProcessamento = DateTime.Now;

                        //realiza copia do arquivo importado
                        importacao.nomeArquivoOriginal = file.FileName;
                        importacao.nomeArquivoProcessado = file.FileName.GerarNomeUnico();
                        importacao.nomeArquivoErro = string.Format("ERRO_{0}.log", importacao.nomeArquivoProcessado);

                        file.SaveAs(string.Format("{0}{1}", importacao._diretorioPendente, importacao.nomeArquivoProcessado));

                        //loga no servidor que o arquivo foi copiado
                        _bll.SalvarImportacaoPendente(importacao);
                    }
            }

            return RedirectToAction("Index");
        }

        [PermissoesFiltro(Roles = "STARK, FRANQUEADO")]
        public ActionResult Download(string fileName)
        {
            var appSettings = ConfigurationManager.AppSettings;
            string _diretorioLog = appSettings["_diretorioLog"];

            string filepath = string.Format("{0}{1}{2}", AppDomain.CurrentDomain.BaseDirectory, _diretorioLog, fileName);

            if (System.IO.File.Exists(filepath))
            {
                byte[] filedata = System.IO.File.ReadAllBytes(filepath);
                string contentType = MimeMapping.GetMimeMapping(filepath);

                var cd = new System.Net.Mime.ContentDisposition
                {
                    FileName = fileName,
                    Inline = true,
                };

                Response.AppendHeader("Content-Disposition", cd.ToString());
                return File(filedata, contentType);
            }
            else
                return RedirectToAction("Index");
        }

        public ActionResult ExcluirImportacao(long idImportacao)
        {
            _bllImportacaoPlanilha.Excluir(idImportacao.ToInt32());
            return RedirectToAction("Index");
        }
    }
}
