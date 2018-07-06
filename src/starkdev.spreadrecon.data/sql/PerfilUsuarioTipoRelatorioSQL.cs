using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace starkdev.spreadrecon.data
{
    /// <summary>
    /// TBR_PERFILUSUARIOTIPORELATORIO
    /// TBN = Tabela de negocio
    /// </summary>
    public static class PerfilUsuarioTipoRelatorioSQL
    {
        public static string Listar
        {
            get
            {
                return @"SELECT * FROM TBR_PERFILUSUARIOTIPORELATORIO";
            }
        }

        public static string ListarPorId
        {
            get
            {
                return @"SELECT * FROM TBR_PERFILUSUARIOTIPORELATORIO WHERE id = @id";
            }
        }

        public static string Inserir
        {
            get
            {
                return @"INSERT INTO TBR_PERFILUSUARIOTIPORELATORIO (idPerfilUsuario, idTipoRelatorio) VALUES (@idPerfilUsuario, @idTipoRelatorio)";
            }
        }

        public static string Alterar
        {
            get
            {
                return @"UPDATE TBR_PERFILUSUARIOTIPORELATORIO SET idPerfilUsuario = @idPerfilUsuario, idTipoRelatorio = @idTipoRelatorio WHERE id = @id";
            }
        }

        public static string Excluir
        {
            get
            {
                return @"DELETE FROM TBR_PERFILUSUARIOTIPORELATORIO WHERE id = @id";
            }
        }
    }
}
