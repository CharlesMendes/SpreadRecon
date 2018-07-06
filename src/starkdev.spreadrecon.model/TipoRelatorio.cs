using System;
using System.ComponentModel.DataAnnotations;

namespace starkdev.spreadrecon.model
{
    public class TipoRelatorio
    {
        [Display(Name = "Cód.")]
        public long id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome do tipo de relatório é obrigatório")]
        public string nomeTipoRelatorio { get; set; }

        [Display(Name = "Versão")]
        [Required(ErrorMessage = "Versão do tipo de relatório é obrigatório")]
        public int versaoTipoRelatorio { get; set; }

        [Display(Name = "Descrição")]
        public string descricao { get; set; }
    }
}
