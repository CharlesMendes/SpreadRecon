using System;
using System.Collections.Generic;
using System.Linq;
using starkdev.spreadrecon.model;
using starkdev.utils;

namespace starkdev.spreadrecon.data
{
    public class ImportacaoPlanilhaDAL
    {
        private readonly _Contexto contexto;

        public ImportacaoPlanilhaDAL()
        {
            contexto = new _Contexto();
        }

        public List<ImportacaoPlanilha> ListarTodos(int? tipoPlanilha)
        {
            var retornoLista = new List<ImportacaoPlanilha>();
            var commandText = ImportacaoPlanilhaSQL.Listar;

            var linhas = contexto.ExecutaComandoComRetorno(commandText);
            foreach (var row in linhas)
            {
                var retorno = new ImportacaoPlanilha
                {
                    id = row["id"].ToLong(),
                    idTipoPlanilha = row["idTipoPlanilha"].ToLong(),
                    idUsuarioImportacao = row["idUsuarioImportacao"].ToLong(),
                    idLoja = row["idLoja"].ToLong(),
                    dataInicioProcessamento = row["dataInicioProcessamento"].ToDateTime(),
                    dataFimProcessamento = row["dataFimProcessamento"].ToDateTime(),
                    idStatus = row["idStatus"].ToLong(),
                    qtdImportacaoSucesso = row["qtdImportacaoSucesso"].ToInt32(),
                    qtdImportacaoIgnorada = row["qtdImportacaoIgnorada"].ToInt32(),
                    nomeArquivoOriginal = row["nomeArquivoOriginal"],
                    nomeArquivoProcessado = row["nomeArquivoProcessado"],
                    nomeArquivoErro = row["nomeArquivoErro"]
                };

                retornoLista.Add(retorno);
            }

            if (tipoPlanilha.HasValue)
                return retornoLista.Where(w => w.idTipoPlanilha.Equals(tipoPlanilha.Value)).ToList();
            else
                return retornoLista;
        }

        public List<ImportacaoPlanilha> ListaImportacoesConcluidasPorLoja()
        {
            var retornoLista = new List<ImportacaoPlanilha>();
            var commandText = ImportacaoPlanilhaSQL.ListaImportacoesConcluidasPorLoja;

            var linhas = contexto.ExecutaComandoComRetorno(commandText);
            foreach (var row in linhas)
            {
                var retorno = new ImportacaoPlanilha
                {
                    id = row["id"].ToLong(),
                    idTipoPlanilha = row["idTipoPlanilha"].ToLong(),
                    idUsuarioImportacao = row["idUsuarioImportacao"].ToLong(),
                    idLoja = row["idLoja"].ToLong(),
                    dataInicioProcessamento = row["dataInicioProcessamento"].ToDateTime(),
                    dataFimProcessamento = row["dataFimProcessamento"].ToDateTime(),
                    idStatus = row["idStatus"].ToLong(),
                    qtdImportacaoSucesso = row["qtdImportacaoSucesso"].ToInt32(),
                    qtdImportacaoIgnorada = row["qtdImportacaoIgnorada"].ToInt32(),
                    nomeArquivoOriginal = row["nomeArquivoOriginal"],
                    nomeArquivoProcessado = row["nomeArquivoProcessado"],
                    nomeArquivoErro = row["nomeArquivoErro"]
                };

                retornoLista.Add(retorno);
            }

            return retornoLista;
        }

        private long Inserir(ImportacaoPlanilha obj)
        {
            var commandText = ImportacaoPlanilhaSQL.Inserir;

            var parametros = new Dictionary<string, object>
            {
                {"idTipoPlanilha", obj.idTipoPlanilha},
                {"idUsuarioImportacao", obj.idUsuarioImportacao},
                {"idLoja", obj.idLoja},
                {"dataInicioProcessamento", obj.dataInicioProcessamento},
                {"dataFimProcessamento", obj.dataFimProcessamento},
                {"idStatus", obj.idStatus},
                {"qtdImportacaoSucesso", obj.qtdImportacaoSucesso},
                {"qtdImportacaoIgnorada", obj.qtdImportacaoIgnorada},
                {"nomeArquivoOriginal", obj.nomeArquivoOriginal},
                {"nomeArquivoProcessado", obj.nomeArquivoProcessado},
                {"nomeArquivoErro", obj.nomeArquivoErro}
            };

            return contexto.ExecutaComando(commandText, parametros);
        }

        private long Alterar(ImportacaoPlanilha obj)
        {
            var commandText = ImportacaoPlanilhaSQL.Alterar;
            var parametros = new Dictionary<string, object>
            {
                {"id", obj.id},
                {"idTipoPlanilha", obj.idTipoPlanilha},
                {"idUsuarioImportacao", obj.idUsuarioImportacao},
                {"idLoja", obj.idLoja},
                {"dataInicioProcessamento", obj.dataInicioProcessamento},
                {"dataFimProcessamento", obj.dataFimProcessamento},
                {"idStatus", obj.idStatus},
                {"qtdImportacaoSucesso", obj.qtdImportacaoSucesso},
                {"qtdImportacaoIgnorada", obj.qtdImportacaoIgnorada},
                {"nomeArquivoOriginal", obj.nomeArquivoOriginal},
                {"nomeArquivoProcessado", obj.nomeArquivoProcessado},
                {"nomeArquivoErro", obj.nomeArquivoErro}
            };

            return contexto.ExecutaComando(commandText, parametros);
        }

        public long Salvar(ImportacaoPlanilha obj)
        {
            if (obj.id > 0)
                Alterar(obj);
            else
                obj.id = Inserir(obj);

            return obj.id;
        }

        public long Excluir(int id)
        {
            var commandText = ImportacaoPlanilhaSQL.Excluir;
            var parametros = new Dictionary<string, object>
            {
                {"id", id}
            };

            return contexto.ExecutaComando(commandText, parametros);
        }

        public ImportacaoPlanilha ListarPorId(long id)
        {
            var retorno = new List<ImportacaoPlanilha>();
            var commandText = ImportacaoPlanilhaSQL.ListarPorId;

            var parametros = new Dictionary<string, object>
            {
                {"id", id}
            };

            var linhas = contexto.ExecutaComandoComRetorno(commandText, parametros);
            foreach (var row in linhas)
            {
                var tempImportacaoPlanilha = new ImportacaoPlanilha
                {
                    id = row["id"].ToLong(),
                    idTipoPlanilha = row["idTipoPlanilha"].ToLong(),
                    idUsuarioImportacao = row["idUsuarioImportacao"].ToLong(),
                    idLoja = row["idLoja"].ToLong(),
                    dataInicioProcessamento = row["dataInicioProcessamento"].ToDateTime(),
                    dataFimProcessamento = row["dataFimProcessamento"].ToDateTime(),
                    idStatus = row["idStatus"].ToLong(),
                    qtdImportacaoSucesso = row["qtdImportacaoSucesso"].ToInt32(),
                    qtdImportacaoIgnorada = row["qtdImportacaoIgnorada"].ToInt32(),
                    nomeArquivoOriginal = row["nomeArquivoOriginal"],
                    nomeArquivoProcessado = row["nomeArquivoProcessado"],
                    nomeArquivoErro = row["nomeArquivoErro"]
                };

                retorno.Add(tempImportacaoPlanilha);
            }

            return retorno.FirstOrDefault();
        }

        public bool AtualizarStatusImportacao(long idStatusAtual, long idStatusNovo)
        {
            try
            {
                var commandText = ImportacaoPlanilhaSQL.AtualizarStatusImportacao;
                var parametros = new Dictionary<string, object>
                {
                    { "idStatusAtual", idStatusAtual },
                    { "idStatusNovo", idStatusNovo }
                };

                contexto.ExecutaComando(commandText, parametros);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AtualizarStatusImportacao(long idImportacao, long idStatusAtual, long idStatusNovo)
        {
            try
            {
                var commandText = ImportacaoPlanilhaSQL.AtualizarStatusImportacaoPorId;
                var parametros = new Dictionary<string, object>
                {
                    { "idImportacao", idImportacao },
                    { "idStatusAtual", idStatusAtual },
                    { "idStatusNovo", idStatusNovo }
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
