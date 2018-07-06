using System;
using System.ComponentModel.DataAnnotations;

namespace starkdev.spreadrecon.model
{
    public class ResultadoProcessamentoDetalhe
    {
        [Display(Name = "Cód.")]
        public long id { get; set; }

        public long idResultadoProcessamento { get; set; }

        public long idVendasViva { get; set; }

        public long idPagamentoOperadora { get; set; }

        public DateTime dataResultadoProcessamento { get; set; }

        #region relacionamentos

        public ResultadoProcessamento resultadoProcessamento { get; set; }

        public VendasViva vendasViva { get; set; }

        public PagamentoOperadora pagamentoOperadora { get; set; }

        #endregion
    }
}
