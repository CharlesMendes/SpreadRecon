using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace starkdev.spreadrecon.data
{
    /// <summary>
    /// TBN_USUARIO
    /// TBN = Tabela de negocio
    /// </summary>
    public static class UsuarioSQL
    {
        public static string Listar
        {
            get
            {
                return @"SELECT * FROM TBN_USUARIO";
            }
        }

        public static string ListarPorId
        {
            get
            {
                return @"SELECT * FROM TBN_USUARIO WHERE id = @id";
            }
        }

        public static string BuscarPorLogin
        {
            get
            {
                return @"SELECT * FROM TBN_USUARIO WHERE login = @login";
            }
        }

        public static string AutenticarUsuario
        {
            get
            {
                return @"SELECT * FROM TBN_USUARIO WHERE login = @login AND senha = @senha";
            }
        }

        public static string Inserir
        {
            get
            {
                return @"INSERT INTO TBN_USUARIO (nome, login, senha, dataUltimoLogin, idPerfilUsuario, isAtivo, idLoja, email) VALUES (@nome, @login, @senha, @dataUltimoLogin, @idPerfilUsuario, @isAtivo, @idLoja, @email)";
            }
        }

        public static string Alterar
        {
            get
            {
                return @"UPDATE TBN_USUARIO SET nome = @nome, login = @login, senha = @senha, dataUltimoLogin = @dataUltimoLogin, idPerfilUsuario = @idPerfilUsuario, isAtivo = @isAtivo, idLoja = @idLoja, email = @email WHERE id = @id";
            }
        }

        public static string Excluir
        {
            get
            {
                return @"DELETE FROM TBN_USUARIO WHERE id = @id";
            }
        }

        public static string AlterarSemSenha
        {
            get
            {
                return @"UPDATE TBN_USUARIO SET nome = @nome, login = @login, dataUltimoLogin = @dataUltimoLogin, idPerfilUsuario = @idPerfilUsuario, isAtivo = @isAtivo, idLoja = @idLoja, email = @email WHERE id = @id";
            }
        }

        public static string AlterarSenha
        {
            get
            {
                return @"UPDATE TBN_USUARIO SET senha = @senha WHERE id = @id";
            }
        }
    }
}
