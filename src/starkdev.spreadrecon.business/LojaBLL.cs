using System;
using System.Collections.Generic;
using starkdev.spreadrecon.model;
using starkdev.spreadrecon.data;

namespace starkdev.spreadrecon.business
{
    public class LojaBLL : ICrud<Loja>
    {
        private LojaDAL _dal;

        public LojaBLL()
        {
            _dal = new LojaDAL();
        }

        public void Excluir(int id)
        {
            _dal.Excluir(id);
        }

        public Loja Detalhe(long id)
        {
            var retorno = _dal.ListarPorId(id);
            return retorno;
        }

        public List<Loja> ListarTodos()
        {
            var lista = _dal.ListarTodos();
            return lista;
        }

        public long Salvar(Loja obj)
        {
            return _dal.Salvar(obj);
        }
    }
}
