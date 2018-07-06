using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace starkdev.spreadrecon.model
{
    public class VendasViva
    {
        [Display(Name = "Cód.")]
        public long id { get; set; }

        [Required(ErrorMessage = "Data da venda da vendas viva é obrigatório")]
        [Display(Name = "")]
        public DateTime dataVenda { get; set; }

        [Required(ErrorMessage = "Número do PDV da vendas viva é obrigatório")]
        public string numeroPDV { get; set; }

        [Required(ErrorMessage = "Número da linha da vendas viva é obrigatório")]
        [Display(Name = "Linha")]
        public string numeroLinha { get; set; }

        [Display(Name = "Vendedor")]
        public string nomeVendedor { get; set; }

        [Display(Name = "Plano")]
        public string nomePlano { get; set; }

        public string nomePacoteDados { get; set; }

        public string nomeTipo { get; set; }

        [Display(Name = "Titular")]
        public string nomeTitular { get; set; }

        public string nomeDependente { get; set; }

        public string dadosDependente { get; set; }

        public string numeroOs { get; set; }

        public string numeroICCD { get; set; }

        public string numeroContrato { get; set; }

        [Required(ErrorMessage = "Valor da venda da vendas viva é obrigatório")]
        [Display(Name = "Venda")]
        [DataType(DataType.Currency)]
        public decimal valorVenda { get; set; }

        [Required(ErrorMessage = "Importação da planilha da vendas viva é obrigatório")]
        public long idImportacaoPlanilha { get; set; }

        public long idStatus { get; set; }

        #region relacionamentos

        public ImportacaoPlanilha importacaoPlanilha { get; set; }

        public Status status { get; set; }

        #endregion
    }
}
