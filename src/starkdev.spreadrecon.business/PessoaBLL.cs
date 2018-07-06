using System;
using System.Collections.Generic;
using starkdev.spreadrecon.model;
using starkdev.spreadrecon.data;

namespace starkdev.spreadrecon.business
{
    public class PessoaBLL : ICrud<Pessoa>
    {
        private PessoaDAL _dal;

        public PessoaBLL()
        {
            _dal = new PessoaDAL();
        }

        public void Excluir(int id)
        {
            _dal.Excluir(id);
        }

        public Pessoa Detalhe(long id)
        {
            var retorno = _dal.ListarPorId(id);
            return retorno;
        }

        public List<Pessoa> ListarTodos()
        {
            var lista = _dal.ListarTodos();
            return lista;
        }

        public void Salvar(Pessoa obj)
        {
            _dal.Salvar(obj);
        }

        long ICrud<Pessoa>.Salvar(Pessoa obj)
        {
            throw new NotImplementedException();
        }
    }
}
