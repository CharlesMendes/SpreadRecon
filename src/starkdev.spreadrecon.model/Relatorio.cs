using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace starkdev.spreadrecon.model
{
    public class Relatorio
    {
        public Relatorio()
        {
            ExibirTerminaisAchados = new List<RelatorioCabecalho>();
            ExibirTerminaisPagosSemVenda = new List<RelatorioCabecalho>();
        }

        /// <summary>
        /// Relatório 1: Exibir Terminais Achados
        /// </summary>
        public List<RelatorioCabecalho> ExibirTerminaisAchados { get; set; }

        /// <summary>
        /// Relatório 2: Exibir Terminais Pagos Sem Venda
        /// </summary>
        public List<RelatorioCabecalho> ExibirTerminaisPagosSemVenda { get; set; }
    }

    public class RelatorioCabecalho
    {
        public long idLoja { get; set; }

        [Display(Name = "Loja")]
        public string nomeLoja { get; set; }

        [Display(Name = "Ciclo")]
        public string ciclo { get; set; }

        [Display(Name = "Linha")]
        public string telefone { get; set; }

        [Display(Name = "Total")]
        [DataType(DataType.Currency)]
        public decimal total { get; set; }

        [Display(Name = "Cód. Status")]
        public long idStatus { get; set; }

        [Display(Name = "Status")]
        public string nomeStatus { get; set; }

        [Display(Name = "Cód. Importação")]
        public long idImportacaoPlanilha { get; set; }

        public List<RelatorioDetalhe> Detalhes { get; set; }
    }

    public class RelatorioDetalhe
    {
        [Display(Name = "Cód.")]
        public long id { get; set; }

        [Display(Name = "Ciclo")]
        public string ciclo { get; set; }

        [Display(Name = "Descrição")]
        public string descricao { get; set; }

        [Display(Name = "Data")]
        public DateTime dataEvento { get; set; }

        [Display(Name = "Linha")]
        public string telefone { get; set; }

        [Display(Name = "Valor")]
        [DataType(DataType.Currency)]
        public decimal valorPago { get; set; }

        [Display(Name = "Cód. Status")]
        public long idStatus { get; set; }

        [Display(Name = "Status")]
        public string nomeStatus { get; set; }

        [Display(Name = "Cód. Importação")]
        public long idImportacaoPlanilha { get; set; }

        #region Campo Auxiliar

        /// <summary>
        /// Sequencia da linha a ser exibida
        /// </summary>
        public int numeroLinha { get; set; }

        #endregion
    }
}
