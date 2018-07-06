using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace starkdev.spreadrecon.data
{
    /// <summary>
    /// TBR_IMPORTACAOPLANILHA
    /// TBR = Tabela de relacionamento
    /// </summary>
    public static class ImportacaoPlanilhaSQL
    {
        public static string Listar
        {
            get
            {
                return @"SELECT * FROM TBR_IMPORTACAOPLANILHA";
            }
        }

        public static string ListarPorId
        {
            get
            {
                return @"SELECT * FROM TBR_IMPORTACAOPLANILHA WHERE id = @id";
            }
        }

        public static string Inserir
        {
            get
            {
                return @"INSERT INTO TBR_IMPORTACAOPLANILHA (idTipoPlanilha, idUsuarioImportacao, dataInicioProcessamento, dataFimProcessamento, idStatus, qtdImportacaoSucesso, qtdImportacaoIgnorada, nomeArquivoOriginal, nomeArquivoProcessado, nomeArquivoErro, idLoja) VALUES (@idTipoPlanilha, @idUsuarioImportacao, @dataInicioProcessamento, @dataFimProcessamento, @idStatus, @qtdImportacaoSucesso, @qtdImportacaoIgnorada, @nomeArquivoOriginal, @nomeArquivoProcessado, @nomeArquivoErro, @idLoja)";
            }
        }

        public static string Alterar
        {
            get
            {
                return @"UPDATE TBR_IMPORTACAOPLANILHA SET idTipoPlanilha = @idTipoPlanilha, idUsuarioImportacao = @idUsuarioImportacao, dataInicioProcessamento = @dataInicioProcessamento, dataFimProcessamento = @dataFimProcessamento, idStatus = @idStatus, qtdImportacaoSucesso = @qtdImportacaoSucesso, qtdImportacaoIgnorada = @qtdImportacaoIgnorada, nomeArquivoOriginal = @nomeArquivoOriginal, nomeArquivoProcessado = @nomeArquivoProcessado, nomeArquivoErro = @nomeArquivoErro, idLoja = @idLoja WHERE id = @id";
            }
        }

        public static string Excluir
        {
            get
            {
                return @"DELETE FROM TBR_IMPORTACAOPLANILHA WHERE id = @id";
            }
        }

        /// <summary>
        /// Atualiza o status da importação
        /// </summary>
        public static string AtualizarStatusImportacao
        {
            get
            {
                return @"UPDATE TBR_IMPORTACAOPLANILHA SET idStatus = @idStatusNovo WHERE idStatus= @idStatusAtual";
            }
        }

        public static string AtualizarStatusImportacaoPorId
        {
            get
            {
                return @"UPDATE TBR_IMPORTACAOPLANILHA SET idStatus = @idStatusNovo WHERE id = @idImportacao AND idStatus = @idStatusAtual";
            }
        }

        public static string ListaImportacoesConcluidasPorLoja
        {
            get
            {
                return @"SELECT * FROM TBR_IMPORTACAOPLANILHA 
                        WHERE idLoja IN (SELECT DISTINCT idLoja FROM TBR_IMPORTACAOPLANILHA WHERE idStatus = 1)
                        ORDER BY idLoja, id
                        ";
            }
        }
    }
}
