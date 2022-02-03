using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace Suite.Models.Comunes
{
    public class Correo
    {
        public static void Email(LogErrores error)
        {
           
            var message = new MailMessage("Suite <error@epepc.cupet.cu>", "jgarcia@epepc.cupet.cu")
            {
                Subject = "Error del Sistema de Reportes Suite",
                Body = error.Accion + "   " + error.Error + "   " + error.Fecha
            };
            var smtpMail = new SmtpClient("pegasus");
            smtpMail.Send(message);

        }
    }
}