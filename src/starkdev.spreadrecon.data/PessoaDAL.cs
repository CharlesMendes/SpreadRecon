using System.Collections.Generic;
using System.Linq;
using starkdev.spreadrecon.model;

namespace starkdev.spreadrecon.data
{
    public class PessoaDAL
    {
        private readonly _Contexto contexto;

        public PessoaDAL()
        {
            contexto = new _Contexto();
        }

        public List<Pessoa> ListarTodos()
        {
            var retornoLista = new List<Pessoa>();
            var commandText = PessoaSQL.Listar;

            var linhas = contexto.ExecutaComandoComRetorno(commandText);
            foreach (var row in linhas)
            {
                var retorno = new Pessoa
                {
                    Id = int.Parse(!string.IsNullOrEmpty(row["Id"]) ? row["Id"] : "0"),
                    Nome = row["Nome"]
                };

                retornoLista.Add(retorno);
            }

            return retornoLista;
        }

        private long Inserir(Pessoa obj)
        {
            var commandText = PessoaSQL.Inserir;

            var parametros = new Dictionary<string, object>
            {
                {"Nome", obj.Nome}
            };

            return contexto.ExecutaComando(commandText, parametros);
        }

        private long Alterar(Pessoa obj)
        {
            var commandText = PessoaSQL.Alterar;
            var parametros = new Dictionary<string, object>
            {
                {"Id", obj.Id},
                {"Nome", obj.Nome}
            };

            return contexto.ExecutaComando(commandText, parametros);
        }

        public void Salvar(Pessoa obj)
        {
            if (obj.Id > 0)
                Alterar(obj);
            else
                Inserir(obj);
        }

        public long Excluir(int id)
        {
           var commandText = PessoaSQL.Excluir;
            var parametros = new Dictionary<string, object>
            {
                {"Id", id}
            };

            return contexto.ExecutaComando(commandText, parametros);
        }

        public Pessoa ListarPorId(long id)
        {
            var retorno = new List<Pessoa>();
            var commandText = PessoaSQL.ListarPorId;

            var parametros = new Dictionary<string, object>
            {
                {"Id", id}
            };

            var linhas = contexto.ExecutaComandoComRetorno(commandText, parametros);
            foreach (var row in linhas)
            {
                var tempPessoa = new Pessoa
                {
                    Id = int.Parse(!string.IsNullOrEmpty(row["Id"]) ? row["Id"] : "0"),
                    Nome = row["Nome"]
                };

                retorno.Add(tempPessoa);
            }

            return retorno.FirstOrDefault();
        }
    }
}
