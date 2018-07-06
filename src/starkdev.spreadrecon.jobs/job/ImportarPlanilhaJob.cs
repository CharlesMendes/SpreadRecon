using Quartz;
using starkdev.spreadrecon.business;
using starkdev.spreadrecon.model;
using starkdev.utils;
using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace starkdev.spreadrecon.jobs
{
    public class ImportarPlanilhaJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            //Verifica no web.config se esta ativo para enviar o job
            var appSettings = ConfigurationManager.AppSettings;
            var ativarJob = appSettings["AtivarJobs"].ToBoolean();

            if (ativarJob)
            {
                ImportacaoPlanilhaBLL _bllImportacaoPlanilha = new ImportacaoPlanilhaBLL();
                _bllImportacaoPlanilha.Importar();
            }
        }
    }
}