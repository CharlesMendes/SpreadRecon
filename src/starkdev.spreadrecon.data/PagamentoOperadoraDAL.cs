using System;
using System.Collections.Generic;
using System.Linq;
using starkdev.spreadrecon.model;
using starkdev.utils;
using System.IO;
using OfficeOpenXml;

namespace starkdev.spreadrecon.data
{
    public class PagamentoOperadoraDAL
    {
        private readonly _Contexto contexto;

        public PagamentoOperadoraDAL()
        {
            contexto = new _Contexto();
        }

        public List<PagamentoOperadora> ListarTodos()
        {
            var retornoLista = new List<PagamentoOperadora>();
            var commandText = PagamentoOperadoraSQL.Listar;

            var linhas = contexto.ExecutaComandoComRetorno(commandText);
            foreach (var row in linhas)
            {
                var retorno = new PagamentoOperadora
                {
                    id = row["id"].ToLong(),
                    nomeCicloPagamento = row["nomeCicloPagamento"],
                    tipoIncentivo = row["tipoIncentivo"],
                    tipoEvento = row["tipoEvento"],
                    descricao = row["descricao"],
                    categoria = row["categoria"],
                    numeroPDV = row["numeroPDV"],
                    nomePDV = row["nomePDV"],
                    numeroSFIDPDVPagador = row["numeroSFIDPDVPagador"],
                    nomePDVPagador = row["nomePDVPagador"],
                    dataEvento = row["dataEvento"].ToDateTime(),
                    dataAtivacao = row["dataAtivacao"].ToDateTime(),
                    dataDesativacao = row["dataDesativacao"].ToDateTime(),
                    dataDocumento = row["dataDocumento"].ToDateTime(),
                    motivo = row["motivo"],
                    numeroContrato = row["numeroContrato"],
                    numeroMSISDN = row["numeroMSISDN"],
                    numeroIMEI = row["numeroIMEI"],
                    numeroICCID = row["numeroICCID"],
                    nomeAparelho = row["nomeAparelho"],
                    nomeCampanha = row["nomeCampanha"],
                    nomeCampanhaAnterior = row["nomeCampanhaAnterior"],
                    nomeOferta = row["nomeOferta"],
                    numeroIDBundle = row["numeroIDBundle"],
                    nomeBundle = row["nomeBundle"],
                    dataBundle = row["dataBundle"].ToDateTime(),
                    nomeRelacionamento = row["nomeRelacionamento"],
                    nomeRelacionamentoAnterior = row["nomeRelacionamentoAnterior"],
                    tipoOiTV = row["tipoOiTV"],
                    isCliente = row["isCliente"].ToBoolean(),
                    tipoMigracao = row["tipoMigracao"],
                    nomePlanoEvento = row["nomePlanoEvento"],
                    nomePlanoAnterior = row["nomePlanoAnterior"],
                    nomePlanoGrupo = row["nomePlanoGrupo"],
                    nomeGrupoPlanoContabil = row["nomeGrupoPlanoContabil"],
                    nomeServicoEvento = row["nomeServicoEvento"],
                    nomeServicoAnterior = row["nomeServicoAnterior"],
                    nomeServicoGrupo = row["nomeServicoGrupo"],
                    nomeGrupoServicoContabil = row["nomeGrupoServicoContabil"],
                    totalVoiceTerminal = row["totalVoiceTerminal"],
                    totalVoiceDias = row["totalVoiceDias"],
                    nomeCartaoCredito = row["nomeCartaoCredito"],
                    isPortabilidade = row["isPortabilidade"].ToBoolean(),
                    isOCT = row["isOCT"].ToBoolean(),
                    quantidade = row["quantidade"],
                    tipoPex = row["tipoPex"],
                    valor = row["valor"].ToDecimal(),
                    valorAnterior = row["valorAnterior"].ToDecimal(),
                    valorEvento = row["valorEvento"].ToDecimal(),
                    valorCalculado = row["valorCalculado"].ToDecimal(),
                    valorPago = row["valorPago"].ToDecimal(),
                    idImportacaoPlanilha = row["idImportacaoPlanilha"].ToLong()
                };

                retornoLista.Add(retorno);
            }

            return retornoLista;
        }

        public List<PagamentoOperadora> ListarLinhas(long id)
        {
            var retornoLista = new List<PagamentoOperadora>();
            var commandText = PagamentoOperadoraSQL.ListarLinhas;

            var parametros = new Dictionary<string, object>
            {
                {"idImportacaoPlanilha", id}
            };

            var linhas = contexto.ExecutaComandoComRetorno(commandText, parametros);
            foreach (var row in linhas)
            {
                var retorno = new PagamentoOperadora
                {
                    id = row["id"].ToLong(),
                    nomeCicloPagamento = row["nomeCicloPagamento"],
                    tipoIncentivo = row["tipoIncentivo"],
                    tipoEvento = row["tipoEvento"],
                    descricao = row["descricao"],
                    categoria = row["categoria"],
                    numeroPDV = row["numeroPDV"],
                    nomePDV = row["nomePDV"],
                    numeroSFIDPDVPagador = row["numeroSFIDPDVPagador"],
                    nomePDVPagador = row["nomePDVPagador"],
                    dataEvento = row["dataEvento"].ToDateTime(),
                    dataAtivacao = row["dataAtivacao"].ToDateTime(),
                    dataDesativacao = row["dataDesativacao"].ToDateTime(),
                    dataDocumento = row["dataDocumento"].ToDateTime(),
                    motivo = row["motivo"],
                    numeroContrato = row["numeroContrato"],
                    numeroMSISDN = row["numeroMSISDN"],
                    numeroIMEI = row["numeroIMEI"],
                    numeroICCID = row["numeroICCID"],
                    nomeAparelho = row["nomeAparelho"],
                    nomeCampanha = row["nomeCampanha"],
                    nomeCampanhaAnterior = row["nomeCampanhaAnterior"],
                    nomeOferta = row["nomeOferta"],
                    numeroIDBundle = row["numeroIDBundle"],
                    nomeBundle = row["nomeBundle"],
                    dataBundle = row["dataBundle"].ToDateTime(),
                    nomeRelacionamento = row["nomeRelacionamento"],
                    nomeRelacionamentoAnterior = row["nomeRelacionamentoAnterior"],
                    tipoOiTV = row["tipoOiTV"],
                    isCliente = row["isCliente"].ToBoolean(),
                    tipoMigracao = row["tipoMigracao"],
                    nomePlanoEvento = row["nomePlanoEvento"],
                    nomePlanoAnterior = row["nomePlanoAnterior"],
                    nomePlanoGrupo = row["nomePlanoGrupo"],
                    nomeGrupoPlanoContabil = row["nomeGrupoPlanoContabil"],
                    nomeServicoEvento = row["nomeServicoEvento"],
                    nomeServicoAnterior = row["nomeServicoAnterior"],
                    nomeServicoGrupo = row["nomeServicoGrupo"],
                    nomeGrupoServicoContabil = row["nomeGrupoServicoContabil"],
                    totalVoiceTerminal = row["totalVoiceTerminal"],
                    totalVoiceDias = row["totalVoiceDias"],
                    nomeCartaoCredito = row["nomeCartaoCredito"],
                    isPortabilidade = row["isPortabilidade"].ToBoolean(),
                    isOCT = row["isOCT"].ToBoolean(),
                    quantidade = row["quantidade"],
                    tipoPex = row["tipoPex"],
                    valor = row["valor"].ToDecimal(),
                    valorAnterior = row["valorAnterior"].ToDecimal(),
                    valorEvento = row["valorEvento"].ToDecimal(),
                    valorCalculado = row["valorCalculado"].ToDecimal(),
                    valorPago = row["valorPago"].ToDecimal(),
                    idImportacaoPlanilha = row["idImportacaoPlanilha"].ToLong()
                };

                #region Status

                var retornoStatus = new Status
                {
                    id = row["idStatus"].ToLong(),
                    nomeStatus = row["nomeStatus"],
                    descricao = row["descricaoStatus"]
                };

                retorno.status = retornoStatus;

                #endregion  

                retornoLista.Add(retorno);
            }

            return retornoLista;
        }

        private long Inserir(PagamentoOperadora obj)
        {
            var commandText = PagamentoOperadoraSQL.Inserir;

            var parametros = new Dictionary<string, object>
            {
                {"nomeCicloPagamento", obj.nomeCicloPagamento},
                {"tipoIncentivo", obj.tipoIncentivo},
                {"tipoEvento", obj.tipoEvento},
                {"descricao", obj.descricao},
                {"categoria", obj.categoria},
                {"numeroPDV", obj.numeroPDV},
                {"nomePDV", obj.nomePDV},
                {"numeroSFIDPDVPagador", obj.numeroSFIDPDVPagador},
                {"nomePDVPagador", obj.nomePDVPagador},
                {"dataEvento", obj.dataEvento},
                {"dataAtivacao", obj.dataAtivacao},
                {"dataDesativacao", obj.dataDesativacao},
                {"dataDocumento", obj.dataDocumento},
                {"motivo", obj.motivo},
                {"numeroContrato", obj.numeroContrato},
                {"numeroMSISDN", obj.numeroMSISDN},
                {"numeroIMEI", obj.numeroIMEI},
                {"numeroICCID", obj.numeroICCID},
                {"nomeAparelho", obj.nomeAparelho},
                {"nomeCampanha", obj.nomeCampanha},
                {"nomeCampanhaAnterior", obj.nomeCampanhaAnterior},
                {"nomeOferta", obj.nomeOferta},
                {"numeroIDBundle", obj.numeroIDBundle},
                {"nomeBundle", obj.nomeBundle},
                {"dataBundle", obj.dataBundle},
                {"nomeRelacionamento", obj.nomeRelacionamento},
                {"nomeRelacionamentoAnterior", obj.nomeRelacionamentoAnterior},
                {"tipoOiTV", obj.tipoOiTV},
                {"isCliente", obj.isCliente},
                {"tipoMigracao", obj.tipoMigracao},
                {"nomePlanoEvento", obj.nomePlanoEvento},
                {"nomePlanoAnterior", obj.nomePlanoAnterior},
                {"nomePlanoGrupo", obj.nomePlanoGrupo},
                {"nomeGrupoPlanoContabil", obj.nomeGrupoPlanoContabil},
                {"nomeServicoEvento", obj.nomeServicoEvento},
                {"nomeServicoAnterior", obj.nomeServicoAnterior},
                {"nomeServicoGrupo", obj.nomeServicoGrupo},
                {"nomeGrupoServicoContabil", obj.nomeGrupoServicoContabil},
                {"totalVoiceTerminal", obj.totalVoiceTerminal},
                {"totalVoiceDias", obj.totalVoiceDias},
                {"nomeCartaoCredito", obj.nomeCartaoCredito},
                {"isPortabilidade", obj.isPortabilidade},
                {"isOCT", obj.isOCT},
                {"quantidade", obj.quantidade},
                {"tipoPex", obj.tipoPex},
                {"valor", obj.valor},
                {"valorAnterior", obj.valorAnterior},
                {"valorEvento", obj.valorEvento},
                {"valorCalculado", obj.valorCalculado},
                {"valorPago", obj.valorPago},
                {"idImportacaoPlanilha", obj.idImportacaoPlanilha}
            };

            return contexto.ExecutaComando(commandText, parametros);
        }

        private long Alterar(PagamentoOperadora obj)
        {
            var commandText = PagamentoOperadoraSQL.Alterar;
            var parametros = new Dictionary<string, object>
            {
                {"id", obj.id},
                {"nomeCicloPagamento", obj.nomeCicloPagamento},
                {"tipoIncentivo", obj.tipoIncentivo},
                {"tipoEvento", obj.tipoEvento},
                {"descricao", obj.descricao},
                {"categoria", obj.categoria},
                {"numeroPDV", obj.numeroPDV},
                {"nomePDV", obj.nomePDV},
                {"numeroSFIDPDVPagador", obj.numeroSFIDPDVPagador},
                {"nomePDVPagador", obj.nomePDVPagador},
                {"dataEvento", obj.dataEvento},
                {"dataAtivacao", obj.dataAtivacao},
                {"dataDesativacao", obj.dataDesativacao},
                {"dataDocumento", obj.dataDocumento},
                {"motivo", obj.motivo},
                {"numeroContrato", obj.numeroContrato},
                {"numeroMSISDN", obj.numeroMSISDN},
                {"numeroIMEI", obj.numeroIMEI},
                {"numeroICCID", obj.numeroICCID},
                {"nomeAparelho", obj.nomeAparelho},
                {"nomeCampanha", obj.nomeCampanha},
                {"nomeCampanhaAnterior", obj.nomeCampanhaAnterior},
                {"nomeOferta", obj.nomeOferta},
                {"numeroIDBundle", obj.numeroIDBundle},
                {"nomeBundle", obj.nomeBundle},
                {"dataBundle", obj.dataBundle},
                {"nomeRelacionamento", obj.nomeRelacionamento},
                {"nomeRelacionamentoAnterior", obj.nomeRelacionamentoAnterior},
                {"tipoOiTV", obj.tipoOiTV},
                {"isCliente", obj.isCliente},
                {"tipoMigracao", obj.tipoMigracao},
                {"nomePlanoEvento", obj.nomePlanoEvento},
                {"nomePlanoAnterior", obj.nomePlanoAnterior},
                {"nomePlanoGrupo", obj.nomePlanoGrupo},
                {"nomeGrupoPlanoContabil", obj.nomeGrupoPlanoContabil},
                {"nomeServicoEvento", obj.nomeServicoEvento},
                {"nomeServicoAnterior", obj.nomeServicoAnterior},
                {"nomeServicoGrupo", obj.nomeServicoGrupo},
                {"nomeGrupoServicoContabil", obj.nomeGrupoServicoContabil},
                {"totalVoiceTerminal", obj.totalVoiceTerminal},
                {"totalVoiceDias", obj.totalVoiceDias},
                {"nomeCartaoCredito", obj.nomeCartaoCredito},
                {"isPortabilidade", obj.isPortabilidade},
                {"isOCT", obj.isOCT},
                {"quantidade", obj.quantidade},
                {"tipoPex", obj.tipoPex},
                {"valor", obj.valor},
                {"valorAnterior", obj.valorAnterior},
                {"valorEvento", obj.valorEvento},
                {"valorCalculado", obj.valorCalculado},
                {"valorPago", obj.valorPago},
                {"idImportacaoPlanilha", obj.idImportacaoPlanilha}
            };

            return contexto.ExecutaComando(commandText, parametros);
        }

        public long Salvar(PagamentoOperadora obj)
        {
            if (obj.id > 0)
                Alterar(obj);
            else
                obj.id = Inserir(obj);

            return obj.id;
        }

        public long Excluir(int id)
        {
            var commandText = PagamentoOperadoraSQL.Excluir;
            var parametros = new Dictionary<string, object>
            {
                {"id", id}
            };

            return contexto.ExecutaComando(commandText, parametros);
        }

        public PagamentoOperadora ListarPorId(long id)
        {
            var retorno = new List<PagamentoOperadora>();
            var commandText = PagamentoOperadoraSQL.ListarPorId;

            var parametros = new Dictionary<string, object>
            {
                {"id", id}
            };

            var linhas = contexto.ExecutaComandoComRetorno(commandText, parametros);
            foreach (var row in linhas)
            {
                var tempPagamentoOperadora = new PagamentoOperadora
                {
                    id = row["id"].ToLong(),
                    nomeCicloPagamento = row["nomeCicloPagamento"],
                    tipoIncentivo = row["tipoIncentivo"],
                    tipoEvento = row["tipoEvento"],
                    descricao = row["descricao"],
                    categoria = row["categoria"],
                    numeroPDV = row["numeroPDV"],
                    nomePDV = row["nomePDV"],
                    numeroSFIDPDVPagador = row["numeroSFIDPDVPagador"],
                    nomePDVPagador = row["nomePDVPagador"],
                    dataEvento = row["dataEvento"].ToDateTime(),
                    dataAtivacao = row["dataAtivacao"].ToDateTime(),
                    dataDesativacao = row["dataDesativacao"].ToDateTime(),
                    dataDocumento = row["dataDocumento"].ToDateTime(),
                    motivo = row["motivo"],
                    numeroContrato = row["numeroContrato"],
                    numeroMSISDN = row["numeroMSISDN"],
                    numeroIMEI = row["numeroIMEI"],
                    numeroICCID = row["numeroICCID"],
                    nomeAparelho = row["nomeAparelho"],
                    nomeCampanha = row["nomeCampanha"],
                    nomeCampanhaAnterior = row["nomeCampanhaAnterior"],
                    nomeOferta = row["nomeOferta"],
                    numeroIDBundle = row["numeroIDBundle"],
                    nomeBundle = row["nomeBundle"],
                    dataBundle = row["dataBundle"].ToDateTime(),
                    nomeRelacionamento = row["nomeRelacionamento"],
                    nomeRelacionamentoAnterior = row["nomeRelacionamentoAnterior"],
                    tipoOiTV = row["tipoOiTV"],
                    isCliente = row["isCliente"].ToBoolean(),
                    tipoMigracao = row["tipoMigracao"],
                    nomePlanoEvento = row["nomePlanoEvento"],
                    nomePlanoAnterior = row["nomePlanoAnterior"],
                    nomePlanoGrupo = row["nomePlanoGrupo"],
                    nomeGrupoPlanoContabil = row["nomeGrupoPlanoContabil"],
                    nomeServicoEvento = row["nomeServicoEvento"],
                    nomeServicoAnterior = row["nomeServicoAnterior"],
                    nomeServicoGrupo = row["nomeServicoGrupo"],
                    nomeGrupoServicoContabil = row["nomeGrupoServicoContabil"],
                    totalVoiceTerminal = row["totalVoiceTerminal"],
                    totalVoiceDias = row["totalVoiceDias"],
                    nomeCartaoCredito = row["nomeCartaoCredito"],
                    isPortabilidade = row["isPortabilidade"].ToBoolean(),
                    isOCT = row["isOCT"].ToBoolean(),
                    quantidade = row["quantidade"],
                    tipoPex = row["tipoPex"],
                    valor = row["valor"].ToDecimal(),
                    valorAnterior = row["valorAnterior"].ToDecimal(),
                    valorEvento = row["valorEvento"].ToDecimal(),
                    valorCalculado = row["valorCalculado"].ToDecimal(),
                    valorPago = row["valorPago"].ToDecimal(),
                    idImportacaoPlanilha = row["idImportacaoPlanilha"].ToLong()
                };

                retorno.Add(tempPagamentoOperadora);
            }

            return retorno.FirstOrDefault();
        }

        public bool Importar(ImportacaoPlanilha importacao)
        {
            string sheetName = "importar";
            //var connectionString = "";
            var pathArquivoPendente = string.Format("{0}{1}", importacao._diretorioPendente, importacao.nomeArquivoProcessado);
            var pathArquivoProcessado = string.Format("{0}{1}", importacao._diretorioProcessado, importacao.nomeArquivoProcessado);
            var pathArquivoLog = string.Format("{0}{1}", importacao._diretorioLog, importacao.nomeArquivoErro);

            try
            {
                FileInfo file = new FileInfo(pathArquivoPendente);
                using (var package = new ExcelPackage(file))
                {
                    var currentSheet = package.Workbook.Worksheets;
                    var workSheet = currentSheet.First(p => p.Name.ToLower() == sheetName.ToLower()); //abre a planilha chamada "importar"
                    var totalColuna = workSheet.Dimension.End.Column;
                    var totalLinha = workSheet.Dimension.End.Row;

                    //Importar conteúdo da planilha
                    int totalErros = 0;
                    int totalSucesso = 0;
                    int numeroLinha = 1;

                    //ignora primeira linha cabeçalho
                    for (int rowIterator = 2; rowIterator <= totalLinha; rowIterator++)
                    {
                        //user.FirstName = workSheet.Cells[rowIterator, 1].Value.ToString();
                        numeroLinha++;
                        int columnIterator = 0;

                        try
                        {
                            var numeroMSISDN = string.Empty;
                            var descricao = string.Empty;

                            if (workSheet.Cells[rowIterator, 16].Value != null)
                                numeroMSISDN = workSheet.Cells[rowIterator, 16].Value.ToString();

                            if (workSheet.Cells[rowIterator, 4].Value != null)
                            {
                                descricao = workSheet.Cells[rowIterator, 4].Value.ToString();

                                //caso no arquivo nao venha preenchido o MSISDN, pega o numero do telefone da coluna de Descrição
                                if (string.IsNullOrEmpty(numeroMSISDN))
                                {
                                    //Se no campo descrição contem a palavra MSISDN, então captura o numero telefone
                                    if (descricao.Contains("MSISDN"))
                                    {
                                        //Captura as ultimas 11 posicoes, que correspondem ao telefone
                                        numeroMSISDN = descricao.Trim().Substring(descricao.Trim().IndexOf("MSISDN") + 7, 11);
                                    }
                                }
                            }

                            //Prossegue apenas se existir (coluna P) numero do terminal ou se a (coluna D) Descrição esta preenchida
                            if (!string.IsNullOrEmpty(descricao) || !string.IsNullOrEmpty(numeroMSISDN))
                            {
                                PagamentoOperadora obj = new PagamentoOperadora();

                                #region Mapeamento das colunas excel

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.nomeCicloPagamento = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.tipoIncentivo = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.tipoEvento = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                columnIterator++;
                                obj.descricao = descricao;
                                //if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                //    obj.descricao = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.categoria = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.numeroPDV = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.nomePDV = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.numeroSFIDPDVPagador = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.nomePDVPagador = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.dataEvento = workSheet.Cells[rowIterator, columnIterator].Value.ToDateTime();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.dataAtivacao = workSheet.Cells[rowIterator, columnIterator].Value.ToDateTime();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.dataDesativacao = workSheet.Cells[rowIterator, columnIterator].Value.ToDateTime();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.dataDocumento = workSheet.Cells[rowIterator, columnIterator].Value.ToDateTime();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.motivo = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.numeroContrato = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                columnIterator++;
                                obj.numeroMSISDN = numeroMSISDN;
                                //if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                //    obj.numeroMSISDN = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.numeroIMEI = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.numeroICCID = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.nomeAparelho = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.nomeCampanha = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.nomeCampanhaAnterior = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.nomeOferta = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.numeroIDBundle = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.nomeBundle = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.dataBundle = workSheet.Cells[rowIterator, columnIterator].Value.ToDateTime();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.nomeRelacionamento = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.nomeRelacionamentoAnterior = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.tipoOiTV = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.isCliente_string = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.tipoMigracao = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.nomePlanoEvento = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.nomePlanoAnterior = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.nomePlanoGrupo = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.nomeGrupoPlanoContabil = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.nomeServicoEvento = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.nomeServicoAnterior = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.nomeServicoGrupo = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.nomeGrupoServicoContabil = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.totalVoiceTerminal = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.totalVoiceDias = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.nomeCartaoCredito = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.isPortabilidade_string = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.isOCT_string = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.quantidade = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.tipoPex = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.valor = workSheet.Cells[rowIterator, columnIterator].Value.ToDecimal();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.valorAnterior = workSheet.Cells[rowIterator, columnIterator].Value.ToDecimal();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.valorEvento = workSheet.Cells[rowIterator, columnIterator].Value.ToDecimal();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.valorCalculado = workSheet.Cells[rowIterator, columnIterator].Value.ToDecimal();

                                columnIterator++;
                                if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                    obj.valorPago = workSheet.Cells[rowIterator, columnIterator].Value.ToDecimal();

                                #endregion

                                //Atualizar importacao
                                obj.importacaoPlanilha = importacao;
                                obj.idImportacaoPlanilha = importacao.id;

                                //Inserir no banco
                                this.Salvar(obj);
                                totalSucesso++;
                            }
                            else
                            {
                                totalErros++;

                                var log = string.Format("Linha: {0} - {1}", numeroLinha, "Campo 'Descrição' ou 'MSISDN/Terminal' não podem ser vazios");
                                this.GerarArquivoLogErro(pathArquivoLog, log);
                            }
                        }
                        catch (Exception ex)
                        {
                            totalErros++;

                            var log = string.Format("Linha: {0} - {1}", numeroLinha, ex.Message);
                            this.GerarArquivoLogErro(pathArquivoLog, log);
                        }
                    }

                    importacao.dataFimProcessamento = DateTime.Now;
                    importacao.qtdImportacaoSucesso = totalSucesso;
                    importacao.qtdImportacaoIgnorada = totalErros;
                    importacao.idStatus = 1;

                    ImportacaoPlanilhaDAL _dalImportacaoPlanilhaDAL = new ImportacaoPlanilhaDAL();
                    _dalImportacaoPlanilhaDAL.Salvar(importacao);

                    //remover os arquivos temporarios
                    if ((File.Exists(pathArquivoPendente)))
                    {
                        File.Move(pathArquivoPendente, pathArquivoProcessado);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                var mensagemErro = ex.Message;

                if (mensagemErro.ToUpper().Contains("SEQUENCE CONTAINS NO MATCHING ELEMENT"))
                    mensagemErro = "Não foi encontrada nenhuma planilha com nome 'importar', favor verificar no EXCEL";

                var log = string.Format("Arquivo: {0} - Erro: {1}", pathArquivoPendente, mensagemErro);
                this.GerarArquivoLogErro(pathArquivoLog, log);

                //Cancelar processamento
                importacao.dataFimProcessamento = DateTime.Now;
                importacao.idStatus = 3;

                ImportacaoPlanilhaDAL _dalImportacaoPlanilhaDAL = new ImportacaoPlanilhaDAL();
                _dalImportacaoPlanilhaDAL.Salvar(importacao);

                //remover os arquivos temporarios
                if ((File.Exists(pathArquivoPendente)))
                {
                    File.Move(pathArquivoPendente, pathArquivoProcessado);
                }
                return false;
            }
        }

        private void GerarArquivoLogErro(string filePath, string log)
        {
            var line = string.Format("[ERRO]\t{1}\t{0}", log, DateTime.Now.ToString("[dd/MM/yyyy HH:mm:ss]"));
            using (FileStream aFile = new FileStream(filePath, FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(aFile))
            {
                sw.WriteLine(line);
            }
        }

        public bool AtualizarStatus(long idStatus, string tipo)
        {
            try
            {
                var commandText = string.Empty;

                switch (tipo.ToUpper())
                {
                    case "C":
                        commandText = PagamentoOperadoraSQL.AtualizarStatusConciliados;
                        break;

                    case "N":
                        commandText = PagamentoOperadoraSQL.AtualizarStatusNaoConciliados;
                        break;

                    default:
                        break;
                }
                var parametros = new Dictionary<string, object>
                {
                    {"idStatus", idStatus}
                };

                contexto.ExecutaComando(commandText, parametros);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
