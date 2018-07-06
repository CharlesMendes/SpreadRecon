using System;
using System.Collections.Generic;
using starkdev.spreadrecon.model;
using starkdev.spreadrecon.data;

namespace starkdev.spreadrecon.business
{
    public class PerfilUsuarioBLL : ICrud<PerfilUsuario>
    {
        private PerfilUsuarioDAL _dal;

        public PerfilUsuarioBLL()
        {
            _dal = new PerfilUsuarioDAL();
        }

        public void Excluir(int id)
        {
            _dal.Excluir(id);
        }

        public PerfilUsuario Detalhe(long id)
        {
            var retorno = _dal.ListarPorId(id);
            return retorno;
        }

        public List<PerfilUsuario> ListarTodos()
        {
            var lista = _dal.ListarTodos();
            return lista;
        }

        public long Salvar(PerfilUsuario obj)
        {
            return _dal.Salvar(obj);
        }
    }
}
