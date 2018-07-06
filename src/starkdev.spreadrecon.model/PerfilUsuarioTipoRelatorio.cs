using System;
using System.ComponentModel.DataAnnotations;

namespace starkdev.spreadrecon.model
{
    public class PerfilUsuarioTipoRelatorio
    {
        [Display(Name = "Cód.")]
        public long id { get; set; }

        [Required(ErrorMessage = "Perfil do usuario é obrigatório")]
        public long idPerfilUsuario { get; set; }

        [Required(ErrorMessage = "Tipo de relatório é obrigatório")]
        public long idTipoRelatorio { get; set; }

        #region relacionamentos

        public PerfilUsuario perfilUsuario { get; set; }

        public TipoRelatorio tipoRelatorio { get; set; }

        #endregion
    }
}
