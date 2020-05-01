using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGeneration;
using MimeKit;
using Portfolio.Data;
using Portfolio.Models;
using Portfolio.ViewModels;

namespace Portfolio.Services
{
    public class ContactService
    {
        public bool SendMessage(ContactViewModel viewModel)
        {
            var msg = new MimeMessage();
            msg.From.Add(new MailboxAddress(viewModel.Email)); // Email which you are getting from contact us page 
            msg.Subject = viewModel.Subject;
            msg.Body = new TextPart("plain")
            {
                Text = viewModel.Message
            };

            msg.To.Add(new MailboxAddress("jonathanreynosa19@gmail.com")); // Where mail will be sent 

            var smtp = new SmtpClient();

            try
            {
                smtp.Connect("smtp.gmail.com", 587, false);
                smtp.Authenticate("jonathanreynosa19@gmail.com", "852797John");
                smtp.Send(msg);
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Sending mail", ex.Message);
                return false;
            }

            smtp.Disconnect(true);
            return true;
        }
    }
}
