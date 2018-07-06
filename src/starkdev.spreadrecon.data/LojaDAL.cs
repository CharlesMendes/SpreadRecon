using System;
using System.Collections.Generic;
using System.Linq;
using starkdev.spreadrecon.model;
using starkdev.utils;

namespace starkdev.spreadrecon.data
{
    public class LojaDAL
    {
        private readonly _Contexto contexto;

        public LojaDAL()
        {
            contexto = new _Contexto();
        }

        public List<Loja> ListarTodos()
        {
            var retornoLista = new List<Loja>();
            var commandText = LojaSQL.Listar;

            var linhas = contexto.ExecutaComandoComRetorno(commandText);
            foreach (var row in linhas)
            {
                var retorno = new Loja
                {
                    id = row["id"].ToLong(),
                    nomeLoja = row["nomeLoja"],
                    numeroCNPJLoja = row["numeroCNPJLoja"],
                    numeroPDV = row["numeroPDV"].ToInt32(),
                    isAtivo = row["isAtivo"].ToBoolean()
                };

                retornoLista.Add(retorno);
            }

            return retornoLista;
        }

        private long Inserir(Loja obj)
        {
            var commandText = LojaSQL.Inserir;

            var parametros = new Dictionary<string, object>
            {
                {"nomeLoja", obj.nomeLoja},
                {"numeroCNPJLoja", obj.numeroCNPJLoja},
                {"numeroPDV", obj.numeroPDV},
                {"isAtivo", obj.isAtivo}
            };

            return contexto.ExecutaComando(commandText, parametros);
        }

        private long Alterar(Loja obj)
        {
            var commandText = LojaSQL.Alterar;
            var parametros = new Dictionary<string, object>
            {
                {"id", obj.id},
                {"nomeLoja", obj.nomeLoja},
                {"numeroCNPJLoja", obj.numeroCNPJLoja},
                {"numeroPDV", obj.numeroPDV},
                {"isAtivo", obj.isAtivo}
            };

            return contexto.ExecutaComando(commandText, parametros);
        }

        public long Salvar(Loja obj)
        {
            if (obj.id > 0)
                Alterar(obj);
            else
                obj.id = Inserir(obj);

            return obj.id;
        }

        public long Excluir(int id)
        {
            var commandText = LojaSQL.Excluir;
            var parametros = new Dictionary<string, object>
            {
                {"id", id}
            };

            return contexto.ExecutaComando(commandText, parametros);
        }

        public Loja ListarPorId(long id)
        {
            var retorno = new List<Loja>();
            var commandText = LojaSQL.ListarPorId;

            var parametros = new Dictionary<string, object>
            {
                {"id", id}
            };

            var linhas = contexto.ExecutaComandoComRetorno(commandText, parametros);
            foreach (var row in linhas)
            {
                var tempLoja = new Loja
                {
                    id = row["id"].ToLong(),
                    nomeLoja = row["nomeLoja"],
                    numeroCNPJLoja = row["numeroCNPJLoja"],
                    numeroPDV = row["numeroPDV"].ToInt32(),
                    isAtivo = row["isAtivo"].ToBoolean()
                };

                retorno.Add(tempLoja);
            }

            return retorno.FirstOrDefault();
        }
    }
}
