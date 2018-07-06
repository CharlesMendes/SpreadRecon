using System;
using System.Collections.Generic;
using System.Linq;
using starkdev.spreadrecon.model;
using starkdev.spreadrecon.data;

namespace starkdev.spreadrecon.business
{
    public class ResultadoProcessamentoBLL : ICrud<ResultadoProcessamento>
    {
        private ResultadoProcessamentoDAL _dal;

        //relacionamentos
        private ImportacaoPlanilhaBLL _bllImportacaoPlanilha;
        private UsuarioBLL _bllUsuario;
        private StatusBLL _bllStatus;

        public ResultadoProcessamentoBLL()
        {
            _dal = new ResultadoProcessamentoDAL();
            _bllImportacaoPlanilha = new ImportacaoPlanilhaBLL();
            _bllUsuario = new UsuarioBLL();
            _bllStatus = new StatusBLL();
        }

        public void Excluir(int id)
        {
            _dal.Excluir(id);
        }

        public void ExcluirPorVendasOperadora(long idVendas, long idOperadora)
        {
            _dal.ExcluirPorVendasOperadora(idVendas, idOperadora);
        }

        public ResultadoProcessamento Detalhe(long id)
        {
            var retorno = _dal.ListarPorId(id);

            //relacionamentos
            retorno.importacaoPlanilhaVendasViva = _bllImportacaoPlanilha.Detalhe(retorno.idImportacaoPlanilhaVendasViva);
            retorno.importacaoPlanilhaPagamentoOperadora = _bllImportacaoPlanilha.Detalhe(retorno.idImportacaoPlanilhaPagamentoOperadora);
            retorno.status = _bllStatus.Detalhe(retorno.idStatus);

            return retorno;
        }

        public List<ResultadoProcessamento> ListarTodos()
        {
            var lista = new List<ResultadoProcessamento>();

            //relacionamentos
            foreach (var item in _dal.ListarTodos())
            {
                item.importacaoPlanilhaVendasViva = _bllImportacaoPlanilha.Detalhe(item.idImportacaoPlanilhaVendasViva);
                item.importacaoPlanilhaPagamentoOperadora = _bllImportacaoPlanilha.Detalhe(item.idImportacaoPlanilhaPagamentoOperadora);
                item.status = _bllStatus.Detalhe(item.idStatus);

                lista.Add(item);
            }

            return lista;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idLojaUsuarioLogado">Lista o ID da loja do usuario, se for 0 lista todas lojas</param>
        /// <returns></returns>
        public List<ResultadoProcessamento> ListarTodosPagamentosConciliados(long idLojaUsuarioLogado)
        {
            var lista = new List<ResultadoProcessamento>();

            //relacionamentos
            foreach (var item in _dal.ListarTodosPagamentosConciliados())
            {
                item.importacaoPlanilhaVendasViva = _bllImportacaoPlanilha.Detalhe(item.idImportacaoPlanilhaVendasViva);
                item.importacaoPlanilhaPagamentoOperadora = _bllImportacaoPlanilha.Detalhe(item.idImportacaoPlanilhaPagamentoOperadora);
                item.status = _bllStatus.Detalhe(item.idStatus);

                //Busca os dados do usuario que realizou importacao da Vendas Loja
                var usuarioImportacao = _bllUsuario.Detalhe(item.importacaoPlanilhaVendasViva.idUsuarioImportacao);

                //Se a loja usuario = 0, entao lista tudo, ou se nao for zero 
                //mas for de usuario de uma loja especifica, lista apenas do usuario logado franqueado
                if (idLojaUsuarioLogado.Equals(0) || usuarioImportacao.idLoja.Equals(idLojaUsuarioLogado))
                    lista.Add(item);
            }

            return lista;
        }

        public long Salvar(ResultadoProcessamento obj)
        {
            return _dal.Salvar(obj);
        }

        public List<ResultadoProcessamento> ListarTodosPorStatus(int idStatus)
        {
            var lista = ListarTodos().Where(p => p.idStatus == idStatus).ToList();
            return lista;
        }

        /// <summary>
        /// Busca todas as importacoes ja concluidas (status 1), tanto da vendas viva quanto
        /// pagamento operadora, e insere na tabela de TBN_RESULTADOPROCESSAMENTO com a data atual e status 6 NAO CONCILIADO
        /// ignora todas as conciliacoes de TBN_PAGAMENTOOPERADORA x TBN_VENDASVIVA ja realizadas, considerando apenas novas conciliacoes
        /// </summary>
        public void Conciliar()
        {
            ImportacaoPlanilhaBLL _bllImportacaoPlanilha = new ImportacaoPlanilhaBLL();
            VendasVivaBLL _bllVendasViva = new VendasVivaBLL();
            PagamentoOperadoraBLL _bllPagamentoOperadora = new PagamentoOperadoraBLL();
            bool isProsseguir = false;

            // 1) Busca apenas importações concluídas que tiveram planilhas de loja e operadora 
            // ja importadas
            var listaImportacoesConcluidasPorLoja = _bllImportacaoPlanilha.ListaImportacoesConcluidasPorLoja();
            isProsseguir = listaImportacoesConcluidasPorLoja.Count > 0;

            // 2) Busca as lojas que ja tiveram planilhas importadas
            if (isProsseguir)
            {
                var idLojas = listaImportacoesConcluidasPorLoja.GroupBy(p => new { p.idLoja }).Select(x => x.First());
                foreach (var item in idLojas)
                {
                    // 3) Verifica se cada importação concluída possui tipo planilha 1 e 2 concluídas
                    var tipoPlanilha_1 = listaImportacoesConcluidasPorLoja.FindAll(p => p.idLoja == item.idLoja && p.idTipoPlanilha == 1);
                    var tipoPlanilha_2 = listaImportacoesConcluidasPorLoja.FindAll(p => p.idLoja == item.idLoja && p.idTipoPlanilha == 2);

                    // 4) Caso nao exista tipo planilha 1 ou 2, deve desconsiderar a loja na conciliação
                    if (tipoPlanilha_1.Count.Equals(0) || tipoPlanilha_2.Count.Equals(0))
                    {
                        // recupera a lista de lojas para excluir da conciliação, pois nao tem planilha dos 2 tipos ja importadas
                        var listaImportacaoExcluir = listaImportacoesConcluidasPorLoja.FindAll(p => p.idLoja == item.idLoja);
                        foreach (var itemExcluir in listaImportacaoExcluir)
                        {
                            listaImportacoesConcluidasPorLoja.Remove(itemExcluir);
                        }
                    }
                }
            }

            // 5) Verifica se sobrou alguma importação de loja para seguir com a conciliação
            isProsseguir = listaImportacoesConcluidasPorLoja.Count > 0;

            // 6) Reserva todas as importações com status 1 Concluído importação, 
            // e trava com status 5 Em processamento
            if (isProsseguir)
                foreach (var item in listaImportacoesConcluidasPorLoja)
                {
                    isProsseguir = _bllImportacaoPlanilha.AtualizarStatusImportacao(item.id, 1, 5);
                }

            // 7) Cria registro de processamento para as importações com status 5
            if (isProsseguir)
                isProsseguir = _dal.Conciliar();

            // 8) Atualizar todos os ID`s da VendasViva processados para 
            // status 7 CONCILIADO
            if (isProsseguir)
                isProsseguir = _bllVendasViva.AtualizarStatus(7, "C");

            // 9) Atualizar todos os ID`s da PagamentoOperadora processados 
            // para status 7 CONCILIADO
            if (isProsseguir)
                isProsseguir = _bllPagamentoOperadora.AtualizarStatus(7, "C");

            // 10) Atualizar todos os ID`s da VendasViva em processamento mas 
            // que nao puderam ser conciliados, para status 6 NAO CONCILIADO
            if (isProsseguir)
                isProsseguir = _bllVendasViva.AtualizarStatus(6, "N");

            // 11) Atualizar todos os ID`s da PagamentoOperadora em processamento 
            // mas que nao puderam ser conciliados, para status 6 NAO CONCILIADO
            if (isProsseguir)
                isProsseguir = _bllPagamentoOperadora.AtualizarStatus(6, "N");

            // 12) Pega todas as importações com status 5 Em processamento
            // e libera com status 7 CONCILIADO
            if (isProsseguir)
                isProsseguir = _bllImportacaoPlanilha.AtualizarStatusImportacao(5, 7);
        }
    }
}
