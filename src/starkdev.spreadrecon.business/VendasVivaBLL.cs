using System;
using System.Collections.Generic;
using starkdev.spreadrecon.model;
using starkdev.spreadrecon.data;

namespace starkdev.spreadrecon.business
{
    public class VendasVivaBLL : ICrud<VendasViva>, IImportacao<ImportacaoPlanilha>
    {
        private VendasVivaDAL _dal;

        //relacionamentos
        private ImportacaoPlanilhaBLL _bllImportacaoPlanilha;
        private StatusBLL _bllStatus;

        public VendasVivaBLL()
        {
            _dal = new VendasVivaDAL();
            _bllImportacaoPlanilha = new ImportacaoPlanilhaBLL();
            _bllStatus = new StatusBLL();
        }

        public void Excluir(int id)
        {
            _dal.Excluir(id);
        }

        public VendasViva Detalhe(long id)
        {
            var retorno = _dal.ListarPorId(id);

            //relacionamentos
            retorno.importacaoPlanilha = _bllImportacaoPlanilha.Detalhe(retorno.idImportacaoPlanilha);
            retorno.status = _bllStatus.Detalhe(retorno.idStatus);

            return retorno;
        }

        public List<VendasViva> ListarLinhas(long id)
        {
            return _dal.ListarLinhas(id);
        }

        public List<VendasViva> ListarTodos()
        {
            var lista = new List<VendasViva>();

            //relacionamentos
            foreach (var item in _dal.ListarTodos())
            {
                item.importacaoPlanilha = _bllImportacaoPlanilha.Detalhe(item.idImportacaoPlanilha);
                item.status = _bllStatus.Detalhe(item.idStatus);

                lista.Add(item);
            }

            return lista;
        }

        public long Salvar(VendasViva obj)
        {
            return _dal.Salvar(obj);
        }

        public bool Importar(ImportacaoPlanilha importacao)
        {
            return _dal.Importar(importacao);
        }

        public bool SalvarImportacaoPendente(ImportacaoPlanilha importacao)
        {
            importacao.id = _bllImportacaoPlanilha.Salvar(importacao);
            return importacao.id > 0;
        }

        /// <summary>
        /// Atualiza o status do registro de acordo com o resultado da conciliação
        /// </summary>
        /// <param name="idStatus">Novo status</param>
        /// <param name="tipo">C = apenas conciliados / N = apenas não conciliados</param>
        public bool AtualizarStatus(long idStatus, string tipo)
        {
            return _dal.AtualizarStatus(idStatus, tipo);
        }
    }
}
