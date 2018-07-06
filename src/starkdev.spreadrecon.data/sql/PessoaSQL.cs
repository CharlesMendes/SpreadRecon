using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace starkdev.spreadrecon.data
{
    /// <summary>
    /// Pessoa
    /// Tabela Teste de CRUD
    /// </summary>
    public static class PessoaSQL
    {
        public static string Listar
        {
            get
            {
                return @"SELECT Id, Nome FROM Pessoa";
            }
        }

        public static string ListarPorId
        {
            get
            {
                return @"SELECT Id, Nome FROM Pessoa WHERE Id = @Id";
            }
        }

        public static string Inserir
        {
            get
            {
                return @"INSERT INTO Pessoa (Nome) VALUES (@Nome)";
            }
        }

        public static string Alterar
        {
            get
            {
                return @"UPDATE Pessoa SET Nome = @Nome WHERE Id = @Id";
            }
        }

        public static string Excluir
        {
            get
            {
                return @"DELETE FROM Pessoa WHERE Id = @Id";
            }
        }
    }
}
