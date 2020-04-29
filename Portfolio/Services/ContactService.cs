using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGeneration;
using Portfolio.Data;
using Portfolio.Models;
using Portfolio.ViewModels;

namespace Portfolio.Services
{
    public class ContactService
    {
        public bool SendMessage(ContactViewModel viewModel)
        {
            MailMessage msg = new MailMessage
            {
                From = new MailAddress(viewModel.Email), // Email which you are getting from contact us page 
                Subject = viewModel.Subject,
                Body = viewModel.Message
            };
            msg.To.Add("jonathanreynosa19@gmail.com"); // Where mail will be sent 

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential
            ("youremailid@gmail.com", "Password");
            smtp.EnableSsl = true;

            try
            {
                smtp.Send(msg);
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Sending mail", ex.Message);
                return false;
            }

            return true;
        }
    }
}
