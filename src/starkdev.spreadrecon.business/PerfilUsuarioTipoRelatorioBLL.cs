using System;
using System.Collections.Generic;
using starkdev.spreadrecon.model;
using starkdev.spreadrecon.data;

namespace starkdev.spreadrecon.business
{
    public class PerfilUsuarioTipoRelatorioBLL : ICrud<PerfilUsuarioTipoRelatorio>
    {
        private PerfilUsuarioTipoRelatorioDAL _dal;

        public PerfilUsuarioTipoRelatorioBLL()
        {
            _dal = new PerfilUsuarioTipoRelatorioDAL();
        }

        public void Excluir(int id)
        {
            _dal.Excluir(id);
        }

        public PerfilUsuarioTipoRelatorio Detalhe(long id)
        {
            var retorno = _dal.ListarPorId(id);
            return retorno;
        }

        public List<PerfilUsuarioTipoRelatorio> ListarTodos()
        {
            var lista = _dal.ListarTodos();
            return lista;
        }

        public long Salvar(PerfilUsuarioTipoRelatorio obj)
        {
            return _dal.Salvar(obj);
        }
    }
}
