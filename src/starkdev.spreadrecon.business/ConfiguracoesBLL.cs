using System;
using System.Collections.Generic;
using starkdev.spreadrecon.model;
using starkdev.spreadrecon.data;

namespace starkdev.spreadrecon.business
{
    public class ConfiguracoesBLL
    {
        private ConfiguracoesDAL _dal;

        public ConfiguracoesBLL()
        {
            _dal = new ConfiguracoesDAL();
        }

        public void ZerarBase()
        {
            _dal.ZerarBase();
        }
    }
}
