using System;
using System.Collections.Generic;
using starkdev.spreadrecon.model;
using starkdev.spreadrecon.data;
using starkdev.spreadrecon.model.Enum;

namespace starkdev.spreadrecon.business
{
    public class RelatorioBLL
    {
        private RelatorioDAL _dal;

        public RelatorioBLL()
        {
            _dal = new RelatorioDAL();
        }

        public Relatorio ListarRelatorio(long? idLoja, TipoRelatorioEnum tipoRelatorio)
        {
            return _dal.ListarRelatorio(idLoja, tipoRelatorio);
        }

        /// <summary>
        /// Relatório 1: Exibir Terminais Achados
        /// </summary>
        /// <returns></returns>
        public Relatorio ExibirTerminaisAchados(long idLoja, string ciclo)
        {
            return _dal.GerarRelatorio(TipoRelatorioEnum.ExibirTerminaisAchados, idLoja, ciclo);
        }

        /// <summary>
        /// Relatório 2: Exibir Terminais Pagos Sem Venda
        /// </summary>
        /// <returns></returns>
        public Relatorio ExibirTerminaisPagosSemVenda(long idLoja, string ciclo)
        {
            return _dal.GerarRelatorio(TipoRelatorioEnum.ExibirTerminaisPagosSemVenda, idLoja, ciclo);
        }
    }
}
