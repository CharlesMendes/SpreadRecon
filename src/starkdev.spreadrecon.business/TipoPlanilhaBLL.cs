using System;
using System.Collections.Generic;
using starkdev.spreadrecon.model;
using starkdev.spreadrecon.data;

namespace starkdev.spreadrecon.business
{
    public class TipoPlanilhaBLL : ICrud<TipoPlanilha>
    {
        private TipoPlanilhaDAL _dal;

        public TipoPlanilhaBLL()
        {
            _dal = new TipoPlanilhaDAL();
        }

        public void Excluir(int id)
        {
            _dal.Excluir(id);
        }

        public TipoPlanilha Detalhe(long id)
        {
            var retorno = _dal.ListarPorId(id);
            return retorno;
        }

        public List<TipoPlanilha> ListarTodos()
        {
            var lista = _dal.ListarTodos();
            return lista;
        }

        public long Salvar(TipoPlanilha obj)
        {
            return _dal.Salvar(obj);
        }
    }
}
