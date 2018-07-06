using System;
using System.ComponentModel.DataAnnotations;

namespace starkdev.spreadrecon.model
{
    public class ImportacaoPlanilha
    {
        [Display(Name = "Cód.")]
        public long id { get; set; }

        [Required(ErrorMessage = "Tipo da planilha da importação é obrigatório")]
        public long idTipoPlanilha { get; set; }

        [Required(ErrorMessage = "Usuário da importação é obrigatório")]
        public long idUsuarioImportacao { get; set; }

        [Display(Name = "Início")]
        [Required(ErrorMessage = "Data/hora início do processamento da importação é obrigatório")]
        public DateTime dataInicioProcessamento { get; set; }

        [Display(Name = "Fim")]
        public DateTime? dataFimProcessamento { get; set; }

        [Required(ErrorMessage = "Status da importação é obrigatório")]
        public long idStatus { get; set; }

        [Display(Name = "Sucesso")]
        public int qtdImportacaoSucesso { get; set; }

        [Display(Name = "Erros")]
        public int qtdImportacaoIgnorada { get; set; }

        [Required(ErrorMessage = "Loja da importação é obrigatório")]
        public long idLoja { get; set; }

        [Display(Name = "Arquivo")]
        public string nomeArquivoOriginal { get; set; }

        public string nomeArquivoProcessado { get; set; }

        public string nomeArquivoErro { get; set; }

        #region relacionamentos

        public TipoPlanilha tipoPlanilha { get; set; }

        public Usuario usuarioImportacao { get; set; }

        public Loja loja { get; set; }

        public Status status { get; set; }

        #endregion

        #region Campos Auxiliares

        public string _diretorioPendente { get; set; }

        public string _diretorioProcessado { get; set; }

        public string _diretorioLog { get; set; }

        #endregion
    }
}
