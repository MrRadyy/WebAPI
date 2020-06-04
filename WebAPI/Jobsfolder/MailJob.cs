using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Net.Mail;
using WebAPI.Models;

namespace WebAPI.Jobsfolder
{
    public class MailJob : IJob
    {
        MyContext MyContext = new MyContext();

        

        public Task Execute(IJobExecutionContext context)
        {
            foreach (var item in MyContext.Users)
            {
                Mail(item.Email, "123 TEST 123 TEST, ONO TO FUNGUJE :)");
            }
         
            return Task.CompletedTask;
        }


        public void Mail(string adressTo, string message)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("noreply.swombik@gmail.com");
            mail.To.Add(adressTo);
            mail.Subject = "Test - mailing"; /*PEEPOSAD*/
            mail.Body = message;

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("noreply.swombik@gmail.com", "A123456+");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

        }

    }
}