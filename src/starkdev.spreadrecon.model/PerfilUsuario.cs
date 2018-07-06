using System;
using System.ComponentModel.DataAnnotations;

namespace starkdev.spreadrecon.model
{
    public class PerfilUsuario
    {
        [Display(Name = "Cód.")]
        public long id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome do perfil é obrigatório")]
        public string nomePerfil { get; set; }

        [Display(Name = "Descrição")]
        public string descricao { get; set; }
    }
}
