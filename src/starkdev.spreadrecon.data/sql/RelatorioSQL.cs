using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace starkdev.spreadrecon.data
{
    /// <summary>
    /// Queries para busca de relatórios por melo de Views
    /// REL = Views de Relatórios
    /// </summary>
    public static class RelatorioSQL
    {
        #region "Relatório 1: Terminais Achados"

        public static string ListarExibirTerminaisAchadosTotal
        {
            get
            {
                return @"SELECT idLoja, nomeLoja, ciclo, SUM(total) as total, nomeStatus 
                        FROM REL_EXIBIRTERMINAISACHADOS_TOTAL 
                        WHERE idLoja = IFNULL(@idLoja, idLoja) 
                        GROUP BY idLoja, ciclo, nomeStatus order by nomeLoja, ciclo";
            }
        }

        public static string ListarExibirTerminaisAchadosCabecalho
        {
            get
            {
                return @"SELECT * FROM REL_EXIBIRTERMINAISACHADOS_TOTAL 
                        WHERE ciclo = @ciclo AND idLoja = @idLoja";
            }
        }

        public static string ListarExibirTerminaisAchadosDetalhe
        {
            get
            {
                return @"SELECT * FROM REL_EXIBIRTERMINAISACHADOS 
                        WHERE ciclo = @ciclo AND telefone = @telefone AND idStatus = @idStatus";
            }
        }

        #endregion

        #region "Relatório 2: Terminais Pagos Sem Venda"

        public static string ListarExibirTerminaisPagosSemVendaTotal
        {
            get
            {
                return @"SELECT idLoja, nomeLoja, ciclo, SUM(total) as total, nomeStatus 
                        FROM REL_EXIBIRTERMINAISPAGOSSEMVENDA_TOTAL 
                        WHERE idLoja = IFNULL(@idLoja, idLoja) 
                        GROUP BY idLoja, ciclo, nomeStatus order by nomeLoja, ciclo";
            }
        }

        public static string ListarExibirTerminaisPagosSemVendaCabecalho
        {
            get
            {
                return @"SELECT * FROM REL_EXIBIRTERMINAISPAGOSSEMVENDA_TOTAL 
                        WHERE ciclo = @ciclo AND idLoja = @idLoja";
            }
        }

        public static string ListarExibirTerminaisPagosSemVendaDetalhe
        {
            get
            {
                return @"SELECT * FROM REL_EXIBIRTERMINAISPAGOSSEMVENDA 
                        WHERE ciclo = @ciclo AND telefone = @telefone AND idStatus = @idStatus";
            }
        }

        #endregion
    }
}
