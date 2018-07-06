using System;
using System.ComponentModel.DataAnnotations;

namespace starkdev.spreadrecon.model
{
    public class ResultadoProcessamento
    {
        [Display(Name = "Cód.")]
        public long id { get; set; }

        [Required(ErrorMessage = "Vendas Viva do processamento é obrigatório")]
        [Display(Name = "Id")]
        public long idImportacaoPlanilhaVendasViva { get; set; }

        [Display(Name = "Id")]
        public long idImportacaoPlanilhaPagamentoOperadora { get; set; }

        [Required(ErrorMessage = "Status do processamento é obrigatório")]
        public long idStatus { get; set; }

        [Display(Name = "Processado em")]
        public DateTime dataResultadoProcessamento { get; set; }

        [Display(Name = "Ciclo")]
        public string nomeCicloPagamento { get; set; }

        #region relacionamentos

        public Status status { get; set; }

        public ImportacaoPlanilha importacaoPlanilhaVendasViva { get; set; }

        public ImportacaoPlanilha importacaoPlanilhaPagamentoOperadora { get; set; }

        #endregion

        #region Campos Auxiliar

        [Display(Name = "Vendas Loja")]
        public string nomeArquivoOriginalVendasViva { get; set; }

        [Display(Name = "Pagamento Operadora")]
        public string nomeArquivoOriginalPagamentoOperadora { get; set; }

        [Display(Name = "Total")]
        public int totalVendasViva { get; set; }

        [Display(Name = "Total")]
        public int totalPagamentoOperadora { get; set; }

        #endregion
    }
}
