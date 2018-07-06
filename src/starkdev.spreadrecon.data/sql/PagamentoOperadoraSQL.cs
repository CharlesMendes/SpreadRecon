using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace starkdev.spreadrecon.data
{
    /// <summary>
    /// TBN_PAGAMENTOOPERADORA
    /// TBN = Tabela de negocio
    /// </summary>
    public static class PagamentoOperadoraSQL
    {
        public static string Listar
        {
            get
            {
                return @"SELECT * FROM TBN_PAGAMENTOOPERADORA";
            }
        }

        public static string ListarLinhas
        {
            get
            {
                return @"SELECT p.*, s.nomeStatus, s.descricao as descricaoStatus
                        FROM TBN_PAGAMENTOOPERADORA p
                        INNER JOIN TBD_STATUS s
                        ON s.id = p.idStatus
                        WHERE idImportacaoPlanilha = @idImportacaoPlanilha";
            }
        }

        public static string ListarPorId
        {
            get
            {
                return @"SELECT * FROM TBN_PAGAMENTOOPERADORA WHERE id = @id";
            }
        }

        public static string Inserir
        {
            get
            {
                return @"INSERT INTO TBN_PAGAMENTOOPERADORA (nomeCicloPagamento, tipoIncentivo, tipoEvento, descricao, categoria, numeroPDV, nomePDV, numeroSFIDPDVPagador, nomePDVPagador, dataEvento, dataAtivacao, dataDesativacao, dataDocumento, motivo, numeroContrato, numeroMSISDN, numeroIMEI, numeroICCID, nomeAparelho, nomeCampanha, nomeCampanhaAnterior, nomeOferta, numeroIDBundle, nomeBundle, dataBundle, nomeRelacionamento, nomeRelacionamentoAnterior, tipoOiTV, isCliente, tipoMigracao, nomePlanoEvento, nomePlanoAnterior, nomePlanoGrupo, nomeGrupoPlanoContabil, nomeServicoEvento, nomeServicoAnterior, nomeServicoGrupo, nomeGrupoServicoContabil, totalVoiceTerminal, totalVoiceDias, nomeCartaoCredito, isPortabilidade, isOCT, quantidade, tipoPex, valor, valorAnterior, valorEvento, valorCalculado, valorPago, idImportacaoPlanilha) VALUES (@nomeCicloPagamento, @tipoIncentivo, @tipoEvento, @descricao, @categoria, @numeroPDV, @nomePDV, @numeroSFIDPDVPagador, @nomePDVPagador, @dataEvento, @dataAtivacao, @dataDesativacao, @dataDocumento, @motivo, @numeroContrato, @numeroMSISDN, @numeroIMEI, @numeroICCID, @nomeAparelho, @nomeCampanha, @nomeCampanhaAnterior, @nomeOferta, @numeroIDBundle, @nomeBundle, @dataBundle, @nomeRelacionamento, @nomeRelacionamentoAnterior, @tipoOiTV, @isCliente, @tipoMigracao, @nomePlanoEvento, @nomePlanoAnterior, @nomePlanoGrupo, @nomeGrupoPlanoContabil, @nomeServicoEvento, @nomeServicoAnterior, @nomeServicoGrupo, @nomeGrupoServicoContabil, @totalVoiceTerminal, @totalVoiceDias, @nomeCartaoCredito, @isPortabilidade, @isOCT, @quantidade, @tipoPex, @valor, @valorAnterior, @valorEvento, @valorCalculado, @valorPago, @idImportacaoPlanilha)";
            }
        }

        public static string Alterar
        {
            get
            {
                return @"UPDATE TBN_PAGAMENTOOPERADORA SET nomeCicloPagamento = @nomeCicloPagamento, tipoIncentivo = @tipoIncentivo, tipoEvento = @tipoEvento, descricao = @descricao, categoria = @categoria, numeroPDV = @numeroPDV, nomePDV = @nomePDV, numeroSFIDPDVPagador = @numeroSFIDPDVPagador, nomePDVPagador = @nomePDVPagador, dataEvento = @dataEvento, dataAtivacao = @dataAtivacao, dataDesativacao = @dataDesativacao, dataDocumento = @dataDocumento, motivo = @motivo, numeroContrato = @numeroContrato, numeroMSISDN = @numeroMSISDN, numeroIMEI = @numeroIMEI, numeroICCID = @numeroICCID, nomeAparelho = @nomeAparelho, nomeCampanha = @nomeCampanha, nomeCampanhaAnterior = @nomeCampanhaAnterior, nomeOferta = @nomeOferta, numeroIDBundle = @numeroIDBundle, nomeBundle = @nomeBundle, dataBundle = @dataBundle, nomeRelacionamento = @nomeRelacionamento, nomeRelacionamentoAnterior = @nomeRelacionamentoAnterior, tipoOiTV = @tipoOiTV, isCliente = @isCliente, tipoMigracao = @tipoMigracao, nomePlanoEvento = @nomePlanoEvento, nomePlanoAnterior = @nomePlanoAnterior, nomePlanoGrupo = @nomePlanoGrupo, nomeGrupoPlanoContabil = @nomeGrupoPlanoContabil, nomeServicoEvento = @nomeServicoEvento, nomeServicoAnterior = @nomeServicoAnterior, nomeServicoGrupo = @nomeServicoGrupo, nomeGrupoServicoContabil = @nomeGrupoServicoContabil, totalVoiceTerminal = @totalVoiceTerminal, totalVoiceDias = @totalVoiceDias, nomeCartaoCredito = @nomeCartaoCredito, isPortabilidade = @isPortabilidade, isOCT = @isOCT, quantidade = @quantidade, tipoPex = @tipoPex, valor = @valor, valorAnterior = @valorAnterior, valorEvento = @valorEvento, valorCalculado = @valorCalculado, valorPago = @valorPago, idImportacaoPlanilha = @idImportacaoPlanilha WHERE id = @id";
            }
        }

        public static string Excluir
        {
            get
            {
                return @"DELETE FROM TBN_PAGAMENTOOPERADORA WHERE id = @id";
            }
        }

        /// <summary>
        /// Atualiza o status para registros conciliados
        /// </summary>
        public static string AtualizarStatusConciliados
        {
            get
            {
                return @"UPDATE TBN_PAGAMENTOOPERADORA SET idStatus = @idStatus
                        WHERE id IN (
                                SELECT id FROM REL_GERARCONCILIADOS_PAGAMENTOOPERADORA
                            )";
            }
        }

        /// <summary>
        /// Atualiza o status para registros não conciliados
        /// </summary>
        public static string AtualizarStatusNaoConciliados
        {
            get
            {
                return @"UPDATE TBN_PAGAMENTOOPERADORA SET idStatus = @idStatus
                        WHERE id IN (
                                SELECT id FROM REL_GERARNAOCONCILIADOS_PAGAMENTOOPERADORA
                            )";
            }
        }
    }
}
