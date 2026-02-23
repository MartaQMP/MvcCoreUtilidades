using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace MvcCoreUtilidades.Controllers
{
    public class MailsController : Controller
    {
        private IConfiguration configuration;

        public MailsController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMail(string to, string asunto, string mensaje)
        {
            string user = this.configuration.GetValue<string>("MailSettings:Credentials:User");
            // OBJETO PARA LA INFORMACION DEL MAIL
            var mail = new MailMessage();
            mail.From = new MailAddress(user);
            mail.To.Add(to);
            mail.Subject = asunto;
            mail.Body = mensaje;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.Normal;
            // RECUPERAMOS LOS DATOS PARA EL OBJETO QUE MANDA EL PROPIO MAIL
            string password = this.configuration.GetValue<string>("MailSettings:Credentials:Password");
            string host = this.configuration.GetValue<string>("MailSettings:Server:Host");
            int port = this.configuration.GetValue<int>("MailSettings:Server:Port");
            bool ssl = this.configuration.GetValue<bool>("MailSettings:Server:Ssl");
            bool defaultCredentials = this.configuration.GetValue<bool>("MailSettings:Server:DefaultCrendentials");
            SmtpClient client = new SmtpClient
            {
                Host = host,
                Port = port,
                EnableSsl = ssl,
                UseDefaultCredentials = defaultCredentials
            };
            NetworkCredential credential = new NetworkCredential(user, password);
            client.Credentials = credential;
            await client.SendMailAsync(mail);

            ViewBag.Mensaje = "Mensaje enviado correctamente";
            return View();
        }
    }
}
