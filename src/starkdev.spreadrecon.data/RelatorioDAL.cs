using System;
using System.Collections.Generic;
using System.Linq;
using starkdev.spreadrecon.model;
using starkdev.utils;
using System.IO;
using OfficeOpenXml;
using starkdev.spreadrecon.model.Enum;

namespace starkdev.spreadrecon.data
{
    public class RelatorioDAL
    {
        private readonly _Contexto contexto;

        public RelatorioDAL()
        {
            contexto = new _Contexto();
        }

        /// <summary>
        /// Exibe somatoria de todos os ciclos, para gerar o relatório
        /// </summary>
        /// <param name="tipoRelatorio"></param>
        /// <returns></returns>
        public Relatorio ListarRelatorio(long? idLoja, TipoRelatorioEnum tipoRelatorio)
        {
            var retornoLista = new List<RelatorioCabecalho>();
            var commandText = string.Empty;

            switch (tipoRelatorio)
            {
                case TipoRelatorioEnum.ExibirTerminaisAchados:
                    commandText = RelatorioSQL.ListarExibirTerminaisAchadosTotal;
                    break;

                case TipoRelatorioEnum.ExibirTerminaisPagosSemVenda:
                    commandText = RelatorioSQL.ListarExibirTerminaisPagosSemVendaTotal;
                    break;

                default:
                    break;
            }

            var parametros = new Dictionary<string, object>
            {
                {"idLoja", idLoja}
            };

            var linhas = contexto.ExecutaComandoComRetorno(commandText, parametros);
            foreach (var row in linhas)
            {
                var relatorio = new RelatorioCabecalho
                {
                    idLoja= row["idLoja"].ToLong(),
                    nomeLoja = row["nomeLoja"],
                    ciclo = row["ciclo"],
                    total = row["total"].ToDecimal(),
                    nomeStatus = row["nomeStatus"],
                };

                retornoLista.Add(relatorio);
            }

            var retornoRelatorio = new Relatorio();

            switch (tipoRelatorio)
            {
                case TipoRelatorioEnum.ExibirTerminaisAchados:
                    retornoRelatorio.ExibirTerminaisAchados = retornoLista;
                    break;

                case TipoRelatorioEnum.ExibirTerminaisPagosSemVenda:
                    retornoRelatorio.ExibirTerminaisPagosSemVenda = retornoLista;
                    break;

                default:
                    break;
            }

            return retornoRelatorio;
        }

        /// <summary>
        /// Gera os dados de cabeçalho e detalhes de um relatório, de forma genérica
        /// </summary>
        /// <param name="tipoRelatorio"></param>
        /// <returns></returns>
        public Relatorio GerarRelatorio(TipoRelatorioEnum tipoRelatorio, long idLoja, string ciclo)
        {
            var retorno = new Relatorio();
            var commandText = string.Empty;

            switch (tipoRelatorio)
            {
                case TipoRelatorioEnum.ExibirTerminaisAchados:
                    commandText = RelatorioSQL.ListarExibirTerminaisAchadosCabecalho;
                    break;

                case TipoRelatorioEnum.ExibirTerminaisPagosSemVenda:
                    commandText = RelatorioSQL.ListarExibirTerminaisPagosSemVendaCabecalho;
                    break;

                default:
                    break;
            }

            var parametros = new Dictionary<string, object>
            {
                {"idLoja", idLoja},
                {"ciclo", ciclo}
            };

            var linhasCabecalho = contexto.ExecutaComandoComRetorno(commandText, parametros);
            foreach (var row in linhasCabecalho)
            {
                var cabecalho = new RelatorioCabecalho
                {
                    ciclo = row["ciclo"],
                    telefone = row["telefone"],
                    total = row["total"].ToDecimal(),
                    idStatus = row["idStatus"].ToLong(),
                    nomeStatus = row["nomeStatus"],
                    idImportacaoPlanilha = row["idImportacaoPlanilha"].ToLong()
                };

                cabecalho.Detalhes = GerarRelatorioDetalhes(tipoRelatorio, cabecalho);

                switch (tipoRelatorio)
                {
                    case TipoRelatorioEnum.ExibirTerminaisAchados:
                        retorno.ExibirTerminaisAchados.Add(cabecalho);
                        break;

                    case TipoRelatorioEnum.ExibirTerminaisPagosSemVenda:
                        retorno.ExibirTerminaisPagosSemVenda.Add(cabecalho);
                        break;
                    default:
                        break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Gera os detalhes de um relatorio, de forma genérica
        /// </summary>
        /// <param name="tipoRelatorio"></param>
        /// <param name="cabecalho"></param>
        /// <returns></returns>
        private List<RelatorioDetalhe> GerarRelatorioDetalhes(TipoRelatorioEnum tipoRelatorio, RelatorioCabecalho cabecalho)
        {
            var retornoLista = new List<RelatorioDetalhe>();
            var commandText = string.Empty;
            var numeroLinha = 1;

            switch (tipoRelatorio)
            {
                case TipoRelatorioEnum.ExibirTerminaisAchados:
                    commandText = RelatorioSQL.ListarExibirTerminaisAchadosDetalhe;
                    break;

                case TipoRelatorioEnum.ExibirTerminaisPagosSemVenda:
                    commandText = RelatorioSQL.ListarExibirTerminaisPagosSemVendaDetalhe;
                    break;

                default:
                    break;
            }

            var parametros = new Dictionary<string, object>
            {
                {"ciclo", cabecalho.ciclo},
                {"telefone", cabecalho.telefone},
                {"idStatus", cabecalho.idStatus}
            };

            #region PrimeiraLinha

            //var primeiraLinha = new RelatorioDetalhe
            //{
            //    telefone = cabecalho.telefone,
            //    numeroLinha = numeroLinha++
            //};

            //retornoLista.Add(primeiraLinha);

            #endregion

            var linhasDetalhes = contexto.ExecutaComandoComRetorno(commandText, parametros);
            foreach (var row in linhasDetalhes)
            {
                var detalhe = new RelatorioDetalhe
                {
                    id = row["id"].ToLong(),
                    ciclo = row["ciclo"],
                    descricao = row["descricao"],
                    dataEvento = row["dataEvento"].ToDateTime(),
                    telefone = row["telefone"],
                    valorPago = row["valorPago"].ToDecimal(),
                    idStatus = row["idStatus"].ToLong(),
                    nomeStatus = row["nomeStatus"],
                    idImportacaoPlanilha = row["idImportacaoPlanilha"].ToLong(),
                    numeroLinha = numeroLinha++
                };

                retornoLista.Add(detalhe);
            }

            #region UltimaLinha

            var ultimaLinha = new RelatorioDetalhe
            {
                telefone = cabecalho.telefone,
                descricao = "Total",
                valorPago = cabecalho.total,
                numeroLinha = numeroLinha++
            };

            retornoLista.Add(ultimaLinha);

            #endregion

            return retornoLista.OrderBy(p => p.numeroLinha).ToList();
        }
    }
}
