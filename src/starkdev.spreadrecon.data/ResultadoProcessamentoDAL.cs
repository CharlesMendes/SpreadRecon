using System;
using System.Collections.Generic;
using System.Linq;
using starkdev.spreadrecon.model;
using starkdev.utils;

namespace starkdev.spreadrecon.data
{
    public class ResultadoProcessamentoDAL
    {
        private readonly _Contexto contexto;

        public ResultadoProcessamentoDAL()
        {
            contexto = new _Contexto();
        }

        public List<ResultadoProcessamento> ListarTodos()
        {
            var retornoLista = new List<ResultadoProcessamento>();
            var commandText = ResultadoProcessamentoSQL.Listar;

            var linhas = contexto.ExecutaComandoComRetorno(commandText);
            foreach (var row in linhas)
            {
                var retorno = new ResultadoProcessamento
                {
                    id = row["id"].ToLong(),
                    idImportacaoPlanilhaVendasViva = row["idImportacaoPlanilhaVendasViva"].ToLong(),
                    idImportacaoPlanilhaPagamentoOperadora = row["idImportacaoPlanilhaPagamentoOperadora"].ToLong(),
                    idStatus = row["idStatus"].ToLong(),
                    dataResultadoProcessamento = row["dataResultadoProcessamento"].ToDateTime(),
                    nomeCicloPagamento = row["nomeCicloPagamento"]
                };

                retornoLista.Add(retorno);
            }

            return retornoLista;
        }

        public List<ResultadoProcessamento> ListarTodosPagamentosConciliados()
        {
            var retornoLista = new List<ResultadoProcessamento>();
            var commandText = ResultadoProcessamentoSQL.ListarTodosPagamentosConciliados;

            var linhas = contexto.ExecutaComandoComRetorno(commandText);
            foreach (var row in linhas)
            {
                var retorno = new ResultadoProcessamento
                {
                    id = row["id"].ToLong(),
                    nomeCicloPagamento = row["nomeCicloPagamento"],
                    idImportacaoPlanilhaVendasViva = row["idImportacaoPlanilhaVendasViva"].ToLong(),
                    nomeArquivoOriginalVendasViva = row["nomeArquivoOriginalVendasViva"],
                    totalVendasViva =row["totalVendasViva"].ToInt32(),
                    idImportacaoPlanilhaPagamentoOperadora = row["idImportacaoPlanilhaPagamentoOperadora"].ToLong(),
                    nomeArquivoOriginalPagamentoOperadora = row["nomeArquivoOriginalPagamentoOperadora"],
                    totalPagamentoOperadora = row["totalPagamentoOperadora"].ToInt32(),
                    dataResultadoProcessamento = row["dataResultadoProcessamento"].ToDateTime(),
                    idStatus = row["idStatus"].ToLong()
                };

                retornoLista.Add(retorno);
            }

            return retornoLista;
        }

        private long Inserir(ResultadoProcessamento obj)
        {
            var commandText = ResultadoProcessamentoSQL.Inserir;

            var parametros = new Dictionary<string, object>
            {
                {"idImportacaoPlanilhaVendasViva", obj.idImportacaoPlanilhaVendasViva},
                {"idImportacaoPlanilhaPagamentoOperadora", obj.idImportacaoPlanilhaPagamentoOperadora},
                {"idStatus", obj.idStatus},
                {"dataResultadoProcessamento", obj.dataResultadoProcessamento},
                {"nomeCicloPagamento", obj.nomeCicloPagamento}
            };

            return contexto.ExecutaComando(commandText, parametros);
        }

        private long Alterar(ResultadoProcessamento obj)
        {
            var commandText = ResultadoProcessamentoSQL.Alterar;
            var parametros = new Dictionary<string, object>
            {
                {"id", obj.id},
                {"idImportacaoPlanilhaVendasViva", obj.idImportacaoPlanilhaVendasViva},
                {"idImportacaoPlanilhaPagamentoOperadora", obj.idImportacaoPlanilhaPagamentoOperadora},
                {"idStatus", obj.idStatus},
                {"dataResultadoProcessamento", obj.dataResultadoProcessamento},
                {"nomeCicloPagamento", obj.nomeCicloPagamento}
            };

            return contexto.ExecutaComando(commandText, parametros);
        }

        public long Salvar(ResultadoProcessamento obj)
        {
            if (obj.id > 0)
                Alterar(obj);
            else
                obj.id = Inserir(obj);

            return obj.id;
        }

        public long Excluir(int id)
        {
            var commandText = ResultadoProcessamentoSQL.Excluir;
            var parametros = new Dictionary<string, object>
            {
                {"id", id}
            };

            return contexto.ExecutaComando(commandText, parametros);
        }

        public long ExcluirPorVendasOperadora(long idVendas, long idOperadora)
        {
            var commandText = ResultadoProcessamentoSQL.ExcluirPorVendasOperadora;
            var parametros = new Dictionary<string, object>
            {
                {"idImportacaoPlanilhaVendasViva", idVendas},
                {"idImportacaoPlanilhaPagamentoOperadora", idOperadora}
            };

            return contexto.ExecutaComando(commandText, parametros);
        }

        /// <summary>
        /// Busca todas as importacoes ja concluidas (status 1), tanto da vendas viva quanto
        /// pagamento operadora, e insere na tabela de TBN_RESULTADOPROCESSAMENTO com a data atual e status 6 NAO CONCILIADO
        /// ignora todas as conciliacoes de TBN_PAGAMENTOOPERADORA x TBN_VENDASVIVA ja realizadas, considerando apenas novas conciliacoes
        /// </summary>
        /// <returns></returns>
        public bool Conciliar()
        {
            try
            {
                var commandText = ResultadoProcessamentoSQL.Conciliar;
                contexto.ExecutaComando(commandText, null);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ResultadoProcessamento ListarPorId(long id)
        {
            var retorno = new List<ResultadoProcessamento>();
            var commandText = ResultadoProcessamentoSQL.ListarPorId;

            var parametros = new Dictionary<string, object>
            {
                {"id", id}
            };

            var linhas = contexto.ExecutaComandoComRetorno(commandText, parametros);
            foreach (var row in linhas)
            {
                var tempResultadoProcessamento = new ResultadoProcessamento
                {
                    id = row["id"].ToLong(),
                    idImportacaoPlanilhaVendasViva = row["idImportacaoPlanilhaVendasViva"].ToLong(),
                    idImportacaoPlanilhaPagamentoOperadora = row["idImportacaoPlanilhaPagamentoOperadora"].ToLong(),
                    idStatus = row["idStatus"].ToLong(),
                    dataResultadoProcessamento = row["dataResultadoProcessamento"].ToDateTime(),
                    nomeCicloPagamento = row["nomeCicloPagamento"]
                };

                retorno.Add(tempResultadoProcessamento);
            }

            return retorno.FirstOrDefault();
        }
    }
}
