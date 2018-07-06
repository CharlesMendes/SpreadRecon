using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace starkdev.spreadrecon.data
{
    /// <summary>
    /// TBN_VENDASVIVA
    /// TBN = Tabela de negocio
    /// </summary>
    public static class VendasVivaSQL
    {
        public static string Listar
        {
            get
            {
                return @"SELECT * FROM TBN_VENDASVIVA";
            }
        }

        public static string ListarLinhas
        {
            get
            {
                return @"SELECT v.*, s.nomeStatus, s.descricao
                        FROM TBN_VENDASVIVA v
                        INNER JOIN TBD_STATUS s
                        ON s.id = v.idStatus
                        WHERE idImportacaoPlanilha = @idImportacaoPlanilha";
            }
        }

        public static string ListarPorId
        {
            get
            {
                return @"SELECT * FROM TBN_VENDASVIVA WHERE id = @id";
            }
        }

        public static string Inserir
        {
            get
            {
                //SELECT last_insert_id();
                return @"INSERT INTO TBN_VENDASVIVA (dataVenda, numeroPDV, numeroLinha, nomeVendedor, nomePlano, nomePacoteDados, nomeTipo, nomeTitular, nomeDependente, dadosDependente, numeroOs, numeroICCD, numeroContrato, valorVenda, idImportacaoPlanilha) VALUES (@dataVenda, @numeroPDV, @numeroLinha, @nomeVendedor, @nomePlano, @nomePacoteDados, @nomeTipo, @nomeTitular, @nomeDependente, @dadosDependente, @numeroOs, @numeroICCD, @numeroContrato, @valorVenda, @idImportacaoPlanilha)";
            }
        }

        public static string Alterar
        {
            get
            {
                return @"UPDATE TBN_VENDASVIVA SET dataVenda = @dataVenda, numeroPDV = @numeroPDV, numeroLinha = @numeroLinha, nomeVendedor = @nomeVendedor, nomePlano = @nomePlano, nomePacoteDados = @nomePacoteDados, nomeTipo = @nomeTipo, nomeTitular = @nomeTitular, nomeDependente = @nomeDependente, dadosDependente = @dadosDependente, numeroOs = @numeroOs, numeroICCD = @numeroICCD, numeroContrato = @numeroContrato, valorVenda = @valorVenda, idImportacaoPlanilha = @idImportacaoPlanilha WHERE id = @id";
            }
        }

        public static string Excluir
        {
            get
            {
                return @"DELETE FROM TBN_VENDASVIVA WHERE id = @id";
            }
        }

        /// <summary>
        /// Atualiza o status para registros conciliados
        /// </summary>
        public static string AtualizarStatusConciliados
        {
            get
            {
                return @"UPDATE TBN_VENDASVIVA SET idStatus = @idStatus
                        WHERE id IN (
                                SELECT id FROM REL_GERARCONCILIADOS_VENDASVIVA
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
                return @"UPDATE TBN_VENDASVIVA SET idStatus = @idStatus
                        WHERE id IN (
                                SELECT id FROM REL_GERARNAOCONCILIADOS_VENDASVIVA
                            )";
            }
        }
    }
}
