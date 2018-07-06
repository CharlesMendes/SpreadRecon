using System;
using System.Collections.Generic;
using System.Linq;
using starkdev.spreadrecon.model;
using starkdev.utils;

namespace starkdev.spreadrecon.data
{
    public class TipoPlanilhaDAL
    {
        private readonly _Contexto contexto;

        public TipoPlanilhaDAL()
        {
            contexto = new _Contexto();
        }

        public List<TipoPlanilha> ListarTodos()
        {
            var retornoLista = new List<TipoPlanilha>();
            var commandText = TipoPlanilhaSQL.Listar;

            var linhas = contexto.ExecutaComandoComRetorno(commandText);
            foreach (var row in linhas)
            {
                var retorno = new TipoPlanilha
                {
                    id = row["id"].ToLong(),
                    nomeTipoPlanilha = row["nomeTipoPlanilha"],
                    descricao = row["descricao"]
                };

                retornoLista.Add(retorno);
            }

            return retornoLista;
        }

        private long Inserir(TipoPlanilha obj)
        {
            var commandText = TipoPlanilhaSQL.Inserir;

            var parametros = new Dictionary<string, object>
            {
                {"nomeTipoPlanilha", obj.nomeTipoPlanilha},
                {"descricao", obj.descricao}
            };

            return contexto.ExecutaComando(commandText, parametros);
        }

        private long Alterar(TipoPlanilha obj)
        {
            var commandText = TipoPlanilhaSQL.Alterar;
            var parametros = new Dictionary<string, object>
            {
                {"id", obj.id},
                {"nomeTipoPlanilha", obj.nomeTipoPlanilha},
                {"descricao", obj.descricao}
            };

            return contexto.ExecutaComando(commandText, parametros);
        }

        public long Salvar(TipoPlanilha obj)
        {
            if (obj.id > 0)
                Alterar(obj);
            else
                obj.id = Inserir(obj);

            return obj.id;
        }

        public long Excluir(int id)
        {
            var commandText = TipoPlanilhaSQL.Excluir;
            var parametros = new Dictionary<string, object>
            {
                {"id", id}
            };

            return contexto.ExecutaComando(commandText, parametros);
        }

        public TipoPlanilha ListarPorId(long id)
        {
            var retorno = new List<TipoPlanilha>();
            var commandText = TipoPlanilhaSQL.ListarPorId;

            var parametros = new Dictionary<string, object>
            {
                {"id", id}
            };

            var linhas = contexto.ExecutaComandoComRetorno(commandText, parametros);
            foreach (var row in linhas)
            {
                var tempTipoPlanilha = new TipoPlanilha
                {
                    id = row["id"].ToLong(),
                    nomeTipoPlanilha = row["nomeTipoPlanilha"],
                    descricao = row["descricao"]
                };

                retorno.Add(tempTipoPlanilha);
            }

            return retorno.FirstOrDefault();
        }
    }
}
