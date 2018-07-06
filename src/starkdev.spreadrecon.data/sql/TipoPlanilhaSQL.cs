using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace starkdev.spreadrecon.data
{
    /// <summary>
    /// TBD_TIPOPLANILHA
    /// TBD = Tabela de dominio
    /// </summary>
    public static class TipoPlanilhaSQL
    {
        public static string Listar
        {
            get
            {
                return @"SELECT * FROM TBD_TIPOPLANILHA";
            }
        }

        public static string ListarPorId
        {
            get
            {
                return @"SELECT * FROM TBD_TIPOPLANILHA WHERE id = @id";
            }
        }

        public static string Inserir
        {
            get
            {
                return @"INSERT INTO TBD_TIPOPLANILHA (nomeTipoPlanilha, descricao) VALUES (@nomeTipoPlanilha, @descricao)";
            }
        }

        public static string Alterar
        {
            get
            {
                return @"UPDATE TBD_TIPOPLANILHA SET nomeTipoPlanilha = @nomeTipoPlanilha, descricao = @descricao WHERE id = @id";
            }
        }

        public static string Excluir
        {
            get
            {
                return @"DELETE FROM TBD_TIPOPLANILHA WHERE id = @id";
            }
        }
    }
}
