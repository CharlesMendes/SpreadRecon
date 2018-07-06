using System;
using System.Collections.Generic;
using starkdev.spreadrecon.model;
using starkdev.spreadrecon.data;

namespace starkdev.spreadrecon.business
{
    public class TipoRelatorioBLL : ICrud<TipoRelatorio>
    {
        private TipoRelatorioDAL _dal;

        public TipoRelatorioBLL()
        {
            _dal = new TipoRelatorioDAL();
        }

        public void Excluir(int id)
        {
            _dal.Excluir(id);
        }

        public TipoRelatorio Detalhe(long id)
        {
            var retorno = _dal.ListarPorId(id);
            return retorno;
        }

        public List<TipoRelatorio> ListarTodos()
        {
            var lista = _dal.ListarTodos();
            return lista;
        }

        public long Salvar(TipoRelatorio obj)
        {
            return _dal.Salvar(obj);
        }
    }
}
