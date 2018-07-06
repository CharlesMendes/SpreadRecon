using System;
using System.Collections.Generic;
using System.Linq;
using starkdev.spreadrecon.model;
using starkdev.utils;

namespace starkdev.spreadrecon.data
{
    public class PerfilUsuarioTipoRelatorioDAL
    {
        private readonly _Contexto contexto;

        public PerfilUsuarioTipoRelatorioDAL()
        {
            contexto = new _Contexto();
        }

        public List<PerfilUsuarioTipoRelatorio> ListarTodos()
        {
            var retornoLista = new List<PerfilUsuarioTipoRelatorio>();
            var commandText = PerfilUsuarioTipoRelatorioSQL.Listar;

            var linhas = contexto.ExecutaComandoComRetorno(commandText);
            foreach (var row in linhas)
            {
                var retorno = new PerfilUsuarioTipoRelatorio
                {
                    id = row["id"].ToLong(),
                    idPerfilUsuario = row["idPerfilUsuario"].ToLong(),
                    idTipoRelatorio = row["idTipoRelatorio"].ToLong()
                };

                retornoLista.Add(retorno);
            }

            return retornoLista;
        }

        private long Inserir(PerfilUsuarioTipoRelatorio obj)
        {
            var commandText = PerfilUsuarioTipoRelatorioSQL.Inserir;

            var parametros = new Dictionary<string, object>
            {
                {"idPerfilUsuario", obj.idPerfilUsuario},
                {"idTipoRelatorio", obj.idTipoRelatorio}
            };

            return contexto.ExecutaComando(commandText, parametros);
        }

        private long Alterar(PerfilUsuarioTipoRelatorio obj)
        {
            var commandText = PerfilUsuarioTipoRelatorioSQL.Alterar;
            var parametros = new Dictionary<string, object>
            {
                {"id", obj.id},
                {"idPerfilUsuario", obj.idPerfilUsuario},
                {"idTipoRelatorio", obj.idTipoRelatorio}
            };

            return contexto.ExecutaComando(commandText, parametros);
        }

        public long Salvar(PerfilUsuarioTipoRelatorio obj)
        {
            if (obj.id > 0)
                Alterar(obj);
            else
                obj.id = Inserir(obj);

            return obj.id;
        }

        public long Excluir(int id)
        {
            var commandText = PerfilUsuarioTipoRelatorioSQL.Excluir;
            var parametros = new Dictionary<string, object>
            {
                {"id", id}
            };

            return contexto.ExecutaComando(commandText, parametros);
        }

        public PerfilUsuarioTipoRelatorio ListarPorId(long id)
        {
            var retorno = new List<PerfilUsuarioTipoRelatorio>();
            var commandText = PerfilUsuarioTipoRelatorioSQL.ListarPorId;

            var parametros = new Dictionary<string, object>
            {
                {"id", id}
            };

            var linhas = contexto.ExecutaComandoComRetorno(commandText, parametros);
            foreach (var row in linhas)
            {
                var tempPerfilUsuarioTipoRelatorio = new PerfilUsuarioTipoRelatorio
                {
                    id = row["id"].ToLong(),
                    idPerfilUsuario = row["idPerfilUsuario"].ToLong(),
                    idTipoRelatorio = row["idTipoRelatorio"].ToLong()
                };

                retorno.Add(tempPerfilUsuarioTipoRelatorio);
            }

            return retorno.FirstOrDefault();
        }
    }
}
