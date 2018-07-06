using System;
using System.ComponentModel.DataAnnotations;

namespace starkdev.spreadrecon.model
{
    public class Loja
    {
        [Display(Name = "Cód.")]
        public long id { get; set; }

        [Display(Name = "Loja")]
        [Required(ErrorMessage = "Nome da loja é obrigatório")]
        public string nomeLoja { get; set; }

        [Display(Name = "Número PDV")]
        [Required(ErrorMessage = "Número do PDV da loja é obrigatório")]
        public int numeroPDV { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "Status da loja é obrigatório")]
        public bool isAtivo { get; set; }

        [Display(Name = "CNPJ")]
        [Required(ErrorMessage = "CNPJ da loja é obrigatório")]
        public string numeroCNPJLoja { get; set; }
    }
}
