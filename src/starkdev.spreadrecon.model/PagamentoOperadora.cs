using System;
using System.ComponentModel.DataAnnotations;

namespace starkdev.spreadrecon.model
{
    public class PagamentoOperadora
    {
        [Display(Name = "Cód.")]
        public long id { get; set; }

        [Required(ErrorMessage = "Nome do ciclo de pagamento do pagamento operadora do pagamento operadora é obrigatório")]
        [Display(Name = "Ciclo")]
        public string nomeCicloPagamento { get; set; }

        [Required(ErrorMessage = "Tipo incentivo do pagamento operadora é obrigatório")]
        public string tipoIncentivo { get; set; }

        [Required(ErrorMessage = "Tipo de evento do pagamento operadora é obrigatório")]
        public string tipoEvento { get; set; }

        [Display(Name = "Descrição")]
        public string descricao { get; set; }

        public string categoria { get; set; }

        [Required(ErrorMessage = "Número do PDV do pagamento operadora é obrigatório")]
        [Display(Name = "PDV")]
        public string numeroPDV { get; set; }

        [Required(ErrorMessage = "Nome do PDV do pagamento operadora é obrigatório")]
        public string nomePDV { get; set; }

        [Required(ErrorMessage = "Número SFID do PDV pagador do pagamento operadora é obrigatório")]
        public string numeroSFIDPDVPagador { get; set; }

        [Required(ErrorMessage = "Nome do PDV pagador do pagamento operadora é obrigatório")]
        public string nomePDVPagador { get; set; }

        [Required(ErrorMessage = "Data do evento do pagamento operadora é obrigatório")]
        public DateTime dataEvento { get; set; }

        [Required(ErrorMessage = "Data de ativação do pagamento operadora é obrigatório")]
        public DateTime dataAtivacao { get; set; }

        public DateTime dataDesativacao { get; set; }

        public DateTime dataDocumento { get; set; }

        public string motivo { get; set; }

        [Required(ErrorMessage = "Número do contrato do pagamento operadora é obrigatório")]
        public string numeroContrato { get; set; }

        [Required(ErrorMessage = "Número MISDN do pagamento operadora é obrigatório")]
        [Display(Name = "Linha")]
        public string numeroMSISDN { get; set; }

        public string numeroIMEI { get; set; }

        public string numeroICCID { get; set; }

        public string nomeAparelho { get; set; }

        public string nomeCampanha { get; set; }

        [Required(ErrorMessage = "Nome da campanha anterior do pagamento operadora é obrigatório")]
        public string nomeCampanhaAnterior { get; set; }

        [Required(ErrorMessage = "Nome da oferta do pagamento operadora é obrigatório")]
        public string nomeOferta { get; set; }

        [Required(ErrorMessage = "Id bundle do pagamento operadora é obrigatório")]
        public string numeroIDBundle { get; set; }

        [Required(ErrorMessage = "Nome do bundle do pagamento operadora é obrigatório")]
        public string nomeBundle { get; set; }

        public DateTime dataBundle { get; set; }

        [Required(ErrorMessage = "Nome relacionamento do pagamento operadora é obrigatório")]
        public string nomeRelacionamento { get; set; }

        [Required(ErrorMessage = "Nome relacionamento anterior  do pagamento operadora é obrigatório")]
        public string nomeRelacionamentoAnterior { get; set; }

        public string tipoOiTV { get; set; }

        public bool isCliente { get; set; }

        //aux para importacao planilha excel
        private string _isCliente_string;
        public string isCliente_string
        {
            get { return _isCliente_string; }
            set
            {
                _isCliente_string = value;

                if (value.Equals("S"))
                    isCliente = true;
                else
                    isCliente = false;
            }
        }

        [Required(ErrorMessage = "Tipo de migração do pagamento operadora é obrigatório")]
        public string tipoMigracao { get; set; }

        [Required(ErrorMessage = "Nome do plano evento do pagamento operadora é obrigatório")]
        public string nomePlanoEvento { get; set; }

        public string nomePlanoAnterior { get; set; }

        public string nomePlanoGrupo { get; set; }

        public string nomeGrupoPlanoContabil { get; set; }

        public string nomeServicoEvento { get; set; }

        public string nomeServicoAnterior { get; set; }

        public string nomeServicoGrupo { get; set; }

        public string nomeGrupoServicoContabil { get; set; }

        public string totalVoiceTerminal { get; set; }

        public string totalVoiceDias { get; set; }

        public string nomeCartaoCredito { get; set; }

        public bool isPortabilidade { get; set; }

        //aux para importacao planilha excel
        private string _isPortabilidade_string;
        public string isPortabilidade_string
        {
            get { return _isPortabilidade_string; }
            set
            {
                _isPortabilidade_string = value;

                if (value.Equals("S"))
                    isPortabilidade = true;
                else
                    isPortabilidade = false;
            }
        }

        public bool isOCT { get; set; }

        //aux para importacao planilha excel
        private string _isOCT_string;
        public string isOCT_string
        {
            get { return _isOCT_string; }
            set
            {
                _isOCT_string = value;

                if (value.Equals("S"))
                    isOCT = true;
                else
                    isOCT = false;
            }
        }

        public string quantidade { get; set; }

        public string tipoPex { get; set; }

        public decimal valor { get; set; }

        public decimal valorAnterior { get; set; }

        public decimal valorEvento { get; set; }

        [Required(ErrorMessage = "Valor calculado do pagamento operadora é obrigatório")]
        public decimal valorCalculado { get; set; }

        [Required(ErrorMessage = "Valor pago do pagamento operadora é obrigatório")]
        [Display(Name = "Valor Pago")]
        [DataType(DataType.Currency)]
        public decimal valorPago { get; set; }

        [Required(ErrorMessage = "Importação da planilha do pagamento operadora é obrigatório")]
        public long idImportacaoPlanilha { get; set; }

        public long idStatus { get; set; }

        #region relacionamentos

        public ImportacaoPlanilha importacaoPlanilha { get; set; }

        public Status status { get; set; }

        #endregion
    }
}
