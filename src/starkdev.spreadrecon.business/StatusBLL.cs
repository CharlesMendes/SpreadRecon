﻿using System;
using System.Collections.Generic;
using starkdev.spreadrecon.model;
using starkdev.spreadrecon.data;

namespace starkdev.spreadrecon.business
{
    public class StatusBLL : ICrud<Status>
    {
        private StatusDAL _dal;

        public StatusBLL()
        {
            _dal = new StatusDAL();
        }

        public void Excluir(int id)
        {
            _dal.Excluir(id);
        }

        public Status Detalhe(long id)
        {
            var retorno = _dal.ListarPorId(id);
            return retorno;
        }

        public List<Status> ListarTodos()
        {
            var lista = _dal.ListarTodos();
            return lista;
        }

        public long Salvar(Status obj)
        {
            return _dal.Salvar(obj);
        }
    }
}
