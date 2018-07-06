using System;
using System.Collections.Generic;
using System.Linq;
using starkdev.spreadrecon.model;
using starkdev.utils;
using System.IO;
using OfficeOpenXml;

namespace starkdev.spreadrecon.data
{
    public class VendasVivaDAL
    {
        private readonly _Contexto contexto;

        public VendasVivaDAL()
        {
            contexto = new _Contexto();
        }

        public List<VendasViva> ListarTodos()
        {
            var retornoLista = new List<VendasViva>();
            var commandText = VendasVivaSQL.Listar;

            var linhas = contexto.ExecutaComandoComRetorno(commandText);
            foreach (var row in linhas)
            {
                var retorno = new VendasViva
                {
                    id = row["id"].ToLong(),
                    dataVenda = row["dataVenda"].ToDateTime(),
                    numeroPDV = row["numeroPDV"],
                    numeroLinha = row["numeroLinha"],
                    nomeVendedor = row["nomeVendedor"],
                    nomePlano = row["nomePlano"],
                    nomePacoteDados = row["nomePacoteDados"],
                    nomeTipo = row["nomeTipo"],
                    nomeTitular = row["nomeTitular"],
                    nomeDependente = row["nomeDependente"],
                    dadosDependente = row["dadosDependente"],
                    numeroOs = row["numeroOs"],
                    numeroICCD = row["numeroICCD"],
                    numeroContrato = row["numeroContrato"],
                    valorVenda = row["valorVenda"].ToDecimal(),
                    idImportacaoPlanilha = row["idImportacaoPlanilha"].ToLong()
                };

                retornoLista.Add(retorno);
            }

            return retornoLista;
        }

        public List<VendasViva> ListarLinhas(long id)
        {
            var retornoLista = new List<VendasViva>();
            var commandText = VendasVivaSQL.ListarLinhas;

            var parametros = new Dictionary<string, object>
            {
                {"idImportacaoPlanilha", id}
            };

            var linhas = contexto.ExecutaComandoComRetorno(commandText, parametros);
            foreach (var row in linhas)
            {
                var retorno = new VendasViva
                {
                    id = row["id"].ToLong(),
                    dataVenda = row["dataVenda"].ToDateTime(),
                    numeroPDV = row["numeroPDV"],
                    numeroLinha = row["numeroLinha"],
                    nomeVendedor = row["nomeVendedor"],
                    nomePlano = row["nomePlano"],
                    nomePacoteDados = row["nomePacoteDados"],
                    nomeTipo = row["nomeTipo"],
                    nomeTitular = row["nomeTitular"],
                    nomeDependente = row["nomeDependente"],
                    dadosDependente = row["dadosDependente"],
                    numeroOs = row["numeroOs"],
                    numeroICCD = row["numeroICCD"],
                    numeroContrato = row["numeroContrato"],
                    valorVenda = row["valorVenda"].ToDecimal(),
                    idImportacaoPlanilha = row["idImportacaoPlanilha"].ToLong()
                };

                #region Status

                var retornoStatus = new Status
                {
                    id = row["idStatus"].ToLong(),
                    nomeStatus = row["nomeStatus"],
                    descricao = row["descricao"]
                };

                retorno.status = retornoStatus;

                #endregion  

                retornoLista.Add(retorno);
            }

            return retornoLista;
        }

        private long Inserir(VendasViva obj)
        {
            var commandText = VendasVivaSQL.Inserir;

            var parametros = new Dictionary<string, object>
            {
                {"dataVenda", obj.dataVenda},
                {"numeroPDV", obj.numeroPDV},
                {"numeroLinha", obj.numeroLinha},
                {"nomeVendedor", obj.nomeVendedor},
                {"nomePlano", obj.nomePlano},
                {"nomePacoteDados", obj.nomePacoteDados},
                {"nomeTipo", obj.nomeTipo},
                {"nomeTitular", obj.nomeTitular},
                {"nomeDependente", obj.nomeDependente},
                {"dadosDependente", obj.dadosDependente},
                {"numeroOs", obj.numeroOs},
                {"numeroICCD", obj.numeroICCD},
                {"numeroContrato", obj.numeroContrato},
                {"valorVenda", obj.valorVenda},
                {"idImportacaoPlanilha", obj.idImportacaoPlanilha}
            };

            return contexto.ExecutaComando(commandText, parametros);
        }

        private long Alterar(VendasViva obj)
        {
            var commandText = VendasVivaSQL.Alterar;
            var parametros = new Dictionary<string, object>
            {
                {"id", obj.id},
                {"dataVenda", obj.dataVenda},
                {"numeroPDV", obj.numeroPDV},
                {"numeroLinha", obj.numeroLinha},
                {"nomeVendedor", obj.nomeVendedor},
                {"nomePlano", obj.nomePlano},
                {"nomePacoteDados", obj.nomePacoteDados},
                {"nomeTipo", obj.nomeTipo},
                {"nomeTitular", obj.nomeTitular},
                {"nomeDependente", obj.nomeDependente},
                {"dadosDependente", obj.dadosDependente},
                {"numeroOs", obj.numeroOs},
                {"numeroICCD", obj.numeroICCD},
                {"numeroContrato", obj.numeroContrato},
                {"valorVenda", obj.valorVenda},
                {"idImportacaoPlanilha", obj.idImportacaoPlanilha}
            };

            return contexto.ExecutaComando(commandText, parametros);
        }

        public long Salvar(VendasViva obj)
        {
            if (obj.id > 0)
                Alterar(obj);
            else
                obj.id = Inserir(obj);

            return obj.id;
        }

        public long Excluir(int id)
        {
            var commandText = VendasVivaSQL.Excluir;
            var parametros = new Dictionary<string, object>
            {
                {"id", id}
            };

            return contexto.ExecutaComando(commandText, parametros);
        }

        public VendasViva ListarPorId(long id)
        {
            var retorno = new List<VendasViva>();
            var commandText = VendasVivaSQL.ListarPorId;

            var parametros = new Dictionary<string, object>
            {
                {"id", id}
            };

            var linhas = contexto.ExecutaComandoComRetorno(commandText, parametros);
            foreach (var row in linhas)
            {
                var tempVendasViva = new VendasViva
                {
                    id = row["id"].ToLong(),
                    dataVenda = row["dataVenda"].ToDateTime(),
                    numeroPDV = row["numeroPDV"],
                    numeroLinha = row["numeroLinha"],
                    nomeVendedor = row["nomeVendedor"],
                    nomePlano = row["nomePlano"],
                    nomePacoteDados = row["nomePacoteDados"],
                    nomeTipo = row["nomeTipo"],
                    nomeTitular = row["nomeTitular"],
                    nomeDependente = row["nomeDependente"],
                    dadosDependente = row["dadosDependente"],
                    numeroOs = row["numeroOs"],
                    numeroICCD = row["numeroICCD"],
                    numeroContrato = row["numeroContrato"],
                    valorVenda = row["valorVenda"].ToDecimal(),
                    idImportacaoPlanilha = row["idImportacaoPlanilha"].ToLong()
                };

                retorno.Add(tempVendasViva);
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
                            //Prossegue apenas se existir numero do terminal
                            if (workSheet.Cells[rowIterator, 3].Value != null)
                                if (!string.IsNullOrEmpty(workSheet.Cells[rowIterator, 3].Value.ToString()))
                                {
                                    VendasViva obj = new VendasViva();

                                    #region Mapeamento das colunas excel

                                    columnIterator++;
                                    if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                        obj.dataVenda = workSheet.Cells[rowIterator, columnIterator].Value.ToDateTime();

                                    columnIterator++;
                                    if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                        obj.numeroPDV = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                    columnIterator++;
                                    if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                        obj.numeroLinha = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                    columnIterator++;
                                    if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                        obj.nomeVendedor = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                    columnIterator++;
                                    if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                        obj.nomePlano = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                    columnIterator++;
                                    if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                        obj.nomePacoteDados = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                    columnIterator++;
                                    if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                        obj.nomeTipo = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                    columnIterator++;
                                    if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                        obj.nomeTitular = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                    columnIterator++;
                                    if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                        obj.nomeDependente = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                    columnIterator++;
                                    if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                        obj.dadosDependente = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                    columnIterator++;
                                    if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                        obj.numeroOs = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                    columnIterator++;
                                    if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                        obj.numeroICCD = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                    columnIterator++;
                                    if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                        obj.numeroContrato = workSheet.Cells[rowIterator, columnIterator].Value.ToString();

                                    columnIterator++;
                                    if (workSheet.Cells[rowIterator, columnIterator].Value != null)
                                        obj.valorVenda = workSheet.Cells[rowIterator, columnIterator].Value.ToDecimal();

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

                                    var log = string.Format("Linha: {0} - {1}", numeroLinha, "LINHA/TERMINAL não pode ser vazio");
                                    this.GerarArquivoLogErro(pathArquivoLog, log);
                                }
                            else
                            {
                                totalErros++;

                                var log = string.Format("Linha: {0} - {1}", numeroLinha, "LINHA/TERMINAL não pode ser vazio");
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
                        commandText = VendasVivaSQL.AtualizarStatusConciliados;
                        break;

                    case "N":
                        commandText = VendasVivaSQL.AtualizarStatusNaoConciliados;
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
