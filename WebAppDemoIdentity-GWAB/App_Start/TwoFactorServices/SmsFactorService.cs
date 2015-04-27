using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HumanAPIClient.Model;
using HumanAPIClient.Service;
using Microsoft.AspNet.Identity;

namespace WebAppDemoIdentity_GWAB.App_Start.TwoFactorServices
{
    public class SmsFactorService : IIdentityMessageService
    {
        // Código para envio de Email usando Zenvia
        // Documentação: http://www.zenvia.com.br/desenvolvedores/tutoriais-e-biblioteca/integracao-net-para-envio-de-sms/
        public Task SendAsync(IdentityMessage message)
        {
            SimpleSending enviarSMS = new SimpleSending(ConfigurationManager.AppSettings["contaSMS"], ConfigurationManager.AppSettings["senhaContaSMS"]);

            SimpleMessage mensagem = new SimpleMessage();
            mensagem.To = message.Destination;
            mensagem.Message = message.Body;
            mensagem.Id = "DemoGWAB." + Guid.NewGuid().ToString("D").Substring(0, 10);

            List<string> resposta = enviarSMS.send(mensagem);
            string temp = "";
            foreach (var item in resposta)
            {
                temp = item;
            }

            return Task.FromResult(0);
        }
    }
}
