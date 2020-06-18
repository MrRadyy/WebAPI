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

        public string Report ()
        {

            string Report = "Dnešní provedené backupy"  + Environment.NewLine;
            List <Backup> temp =MyContext.Backup.ToList();
            foreach (var item in temp)
            {
                Report += item.Name + " " + item.Job + " "+ item.Succesful + Environment.NewLine; 
              
            }

            return Report; 
        }

        public Task Execute(IJobExecutionContext context)
        {
            List<User> users = MyContext.Users.ToList();
            foreach (var item in users)
            {
                Mail(item.Email,Report());
            }
         
            return Task.CompletedTask;
        }


        public void Mail(string adressTo, string message)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("noreply.swombik@gmail.com");
            mail.To.Add(adressTo);
            mail.Subject = "Report" + DateTime.Now; ; /*PEEPOHAPPY*/
            mail.Body = message;

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("noreply.swombik@gmail.com", "A123456+");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

        }

    }
}