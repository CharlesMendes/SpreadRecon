using System;
using System.ComponentModel.DataAnnotations;

namespace starkdev.spreadrecon.model
{
    public class TipoPlanilha
    {
        [Display(Name = "Cód.")]
        public long id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome do tipo de planilha é obrigatório")]
        public string nomeTipoPlanilha { get; set; }

        [Display(Name = "Descrição")]
        public string descricao { get; set; }
    }
}
