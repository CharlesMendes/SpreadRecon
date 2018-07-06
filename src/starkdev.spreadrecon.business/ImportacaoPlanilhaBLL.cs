using System;
using System.Collections.Generic;
using System.Linq;
using starkdev.spreadrecon.model;
using starkdev.spreadrecon.data;
using System.Configuration;

namespace starkdev.spreadrecon.business
{
    public class ImportacaoPlanilhaBLL : ICrud<ImportacaoPlanilha>
    {
        private ImportacaoPlanilhaDAL _dal;

        //relacionamentos
        private TipoPlanilhaBLL _bllTipoPlanilha;
        private UsuarioBLL _bllUsuario;
        private StatusBLL _bllStatus;
        private LojaBLL _bllLoja;

        public ImportacaoPlanilhaBLL()
        {
            _dal = new ImportacaoPlanilhaDAL();
            _bllTipoPlanilha = new TipoPlanilhaBLL();
            _bllUsuario = new UsuarioBLL();
            _bllStatus = new StatusBLL();
            _bllLoja = new LojaBLL();
        }

        public void Excluir(int id)
        {
            _dal.Excluir(id);
        }

        public ImportacaoPlanilha Detalhe(long id)
        {
            var retorno = _dal.ListarPorId(id);

            //relacionamentos
            retorno.tipoPlanilha = _bllTipoPlanilha.Detalhe(retorno.idTipoPlanilha);
            retorno.status = _bllStatus.Detalhe(retorno.idStatus);
            retorno.usuarioImportacao = _bllUsuario.Detalhe(retorno.idUsuarioImportacao);
            retorno.loja = _bllLoja.Detalhe(retorno.idLoja);

            return retorno;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipoPlanilha"></param>
        /// <param name="idLojaUsuarioLogado">Lista o ID da loja do usuario, se for 0 lista todas lojas</param>
        /// <returns></returns>
        public List<ImportacaoPlanilha> ListarTodos(int? tipoPlanilha, long idLojaUsuarioLogado)
        {
            var lista = new List<ImportacaoPlanilha>();

            //relacionamentos
            foreach (var item in _dal.ListarTodos(tipoPlanilha))
            {
                item.tipoPlanilha = _bllTipoPlanilha.Detalhe(item.idTipoPlanilha);
                item.status = _bllStatus.Detalhe(item.idStatus);
                item.usuarioImportacao = _bllUsuario.Detalhe(item.idUsuarioImportacao);
                item.loja = _bllLoja.Detalhe(item.idLoja);

                if (item.dataFimProcessamento.Equals(DateTime.MinValue))
                    item.dataFimProcessamento = null;

                //Se a loja usuario = 0, entao lista tudo, ou se nao for zero 
                //mas for de usuario de uma loja especifica, lista apenas do usuario logado franqueado
                if (idLojaUsuarioLogado.Equals(0) || item.usuarioImportacao.idLoja.Equals(idLojaUsuarioLogado))
                    lista.Add(item);
            }

            return lista;
        }

        public long Salvar(ImportacaoPlanilha obj)
        {
            return _dal.Salvar(obj);
        }

        public List<ImportacaoPlanilha> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public List<ImportacaoPlanilha> ListarTodosPorStatus(int? tipoPlanilha, long idStatus)
        {
            var listaImportacoesPendentes_VendasViva = ListarTodos(tipoPlanilha, 0).Where(p => p.idStatus == idStatus).ToList();

            return listaImportacoesPendentes_VendasViva;
        }

        public List<ImportacaoPlanilha> ListaImportacoesConcluidasPorLoja()
        {
            var lista = new List<ImportacaoPlanilha>();

            //relacionamentos
            foreach (var item in _dal.ListaImportacoesConcluidasPorLoja())
            {
                item.tipoPlanilha = _bllTipoPlanilha.Detalhe(item.idTipoPlanilha);
                item.status = _bllStatus.Detalhe(item.idStatus);
                item.usuarioImportacao = _bllUsuario.Detalhe(item.idUsuarioImportacao);
                item.loja = _bllLoja.Detalhe(item.idLoja);

                lista.Add(item);
            }

            return lista;
        }

        public void Importar()
        {
            VendasVivaBLL _bllVendasViva = new VendasVivaBLL();
            PagamentoOperadoraBLL _bllPagamentoOperadora = new PagamentoOperadoraBLL();
            bool isProsseguir = false;

            // 1) Verifica se existe alguma importação com status 4 Pendente importação
            isProsseguir = ListarTodosPorStatus(null, 4).Count > 0;

            // 2) Reserva todas as importações com status 4 Pendente importação, 
            // e trava com status 2 Importando
            if (isProsseguir)
                isProsseguir = AtualizarStatusImportacao(4, 2);

            // 3) Recupera a listagem de importações com status 2 Importando
            var lista = new List<ImportacaoPlanilha>();
            if (isProsseguir)
            {
                try
                {
                    lista = ListarTodosPorStatus(null, 2);
                }
                catch (Exception)
                {
                    isProsseguir = false;
                }
            }

            // 4) Inicia varredura de arquivos para a Importação dos registros com status 2 Importando
            if (isProsseguir)
                foreach (var item in lista)
                {
                    //Seta diretorios
                    var appSettings = ConfigurationManager.AppSettings;
                    var _diretorioPadrao = appSettings["DiretorioImportacao"];

                    string _diretorioPendente = appSettings["_diretorioPendente"];
                    string _diretorioProcessado = appSettings["_diretorioProcessado"];
                    string _diretorioLog = appSettings["_diretorioLog"];

                    item._diretorioPendente = string.Format("{0}{1}", _diretorioPadrao, _diretorioPendente);
                    item._diretorioProcessado = string.Format("{0}{1}", _diretorioPadrao, _diretorioProcessado);
                    item._diretorioLog = string.Format("{0}{1}", _diretorioPadrao, _diretorioLog);

                    // 5) Realiza a importação
                    switch (item.idTipoPlanilha)
                    {
                        case 1:
                            // 6) Importa VendasViva - Lista todas planilhas 1-VendasViva (pendentes)
                            _bllVendasViva.Importar(item);
                            break;

                        case 2:
                            // 7) Importa PagamentoOperadora - Lista todas planilhas 2-PagamentoOperadora (pendentes)
                            _bllPagamentoOperadora.Importar(item);
                            break;

                        default:
                            break;
                    }
                }
        }

        public bool AtualizarStatusImportacao(long idStatusAtual, long idStatusNovo)
        {
            return _dal.AtualizarStatusImportacao(idStatusAtual, idStatusNovo);
        }

        public bool AtualizarStatusImportacao(long idImportacao, long idStatusAtual, long idStatusNovo)
        {
            return _dal.AtualizarStatusImportacao(idImportacao, idStatusAtual, idStatusNovo);
        }
    }
}
