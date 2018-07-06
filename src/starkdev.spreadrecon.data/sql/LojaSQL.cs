using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace starkdev.spreadrecon.data
{
    /// <summary>
    /// TBN_LOJA
    /// TBN = Tabela de negocio
    /// </summary>
    public static class LojaSQL
    {
        public static string Listar
        {
            get
            {
                return @"SELECT * FROM TBN_LOJA";
            }
        }

        public static string ListarPorId
        {
            get
            {
                return @"SELECT * FROM TBN_LOJA WHERE id = @id";
            }
        }

        public static string Inserir
        {
            get
            {
                return @"INSERT INTO TBN_LOJA (nomeLoja, numeroPDV, isAtivo, numeroCNPJLoja) VALUES (@nomeLoja, @numeroPDV, @isAtivo, @numeroCNPJLoja)";
            }
        }

        public static string Alterar
        {
            get
            {
                return @"UPDATE TBN_LOJA SET nomeLoja = @nomeLoja, numeroPDV = @numeroPDV, isAtivo = @isAtivo, numeroCNPJLoja = @numeroCNPJLoja WHERE id = @id";
            }
        }

        public static string Excluir
        {
            get
            {
                return @"DELETE FROM TBN_LOJA WHERE id = @id";
            }
        }
    }
}
