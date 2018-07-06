using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace starkdev.spreadrecon.data
{
    /// <summary>
    /// TBN_RESULTADOPROCESSAMENTO
    /// TBN = Tabela de negocio
    /// </summary>
    public static class ResultadoProcessamentoSQL
    {
        public static string Listar
        {
            get
            {
                return @"SELECT * FROM TBN_RESULTADOPROCESSAMENTO";
            }
        }

        public static string ListarTodosPagamentosConciliados
        {
            get
            {
                return @"SELECT * FROM REL_GERARPAGAMENTOSCONCILIADOS";
            }
        }

        public static string ListarPorId
        {
            get
            {
                return @"SELECT * FROM TBN_RESULTADOPROCESSAMENTO WHERE id = @id";
            }
        }

        public static string Inserir
        {
            get
            {
                return @"INSERT INTO TBN_RESULTADOPROCESSAMENTO (idImportacaoPlanilhaVendasViva, idImportacaoPlanilhaPagamentoOperadora, idStatus, dataResultadoProcessamento, nomeCicloPagamento) VALUES (@idImportacaoPlanilhaVendasViva, @idImportacaoPlanilhaPagamentoOperadora, @idStatus, @dataResultadoProcessamento, @nomeCicloPagamento)";
            }
        }

        public static string Alterar
        {
            get
            {
                return @"UPDATE TBN_RESULTADOPROCESSAMENTO SET idImportacaoPlanilhaVendasViva = @idImportacaoPlanilhaVendasViva, idImportacaoPlanilhaPagamentoOperadora = @idImportacaoPlanilhaPagamentoOperadora, idStatus = @idStatus, dataResultadoProcessamento = @dataResultadoProcessamento, nomeCicloPagamento = @nomeCicloPagamento WHERE id = @id";
            }
        }

        public static string Excluir
        {
            get
            {
                return @"DELETE FROM TBN_RESULTADOPROCESSAMENTO WHERE id = @id";
            }
        }

        public static string ExcluirPorVendasOperadora
        {
            get
            {
                return @"DELETE FROM TBN_RESULTADOPROCESSAMENTO WHERE idImportacaoPlanilhaVendasViva = @idImportacaoPlanilhaVendasViva AND idImportacaoPlanilhaPagamentoOperadora = @idImportacaoPlanilhaPagamentoOperadora";
            }
        }

        /// <summary>
        /// Busca todas as importacoes ja concluidas (status 1), tanto da vendas viva quanto
        /// pagamento operadora, e insere na tabela de TBN_RESULTADOPROCESSAMENTO com a data atual e status 6 NAO CONCILIADO
        /// ignora todas as conciliacoes de TBN_PAGAMENTOOPERADORA x TBN_VENDASVIVA ja realizadas, considerando apenas novas conciliacoes
        /// </summary>
        public static string Conciliar
        {
            get
            {
                return @"INSERT INTO TBN_RESULTADOPROCESSAMENTO
	                        (idImportacaoPlanilhaVendasViva,
	                        idVendasViva,
	                        idImportacaoPlanilhaPagamentoOperadora, 
	                        idPagamentoOperadora,
	                        dataResultadoProcessamento, 
	                        idStatus,
                            nomeCicloPagamento)
                        SELECT 
	                        idImportacaoPlanilhaVendasViva,
	                        idVendasViva,
	                        idImportacaoPlanilhaPagamentoOperadora, 
	                        idPagamentoOperadora,   
	                        dataResultadoProcessamento, 
	                        idStatus,
                            nomeCicloPagamento
                        FROM REL_GERARESULTADOPROCESSAMENTO";
            }
        }
    }
}
