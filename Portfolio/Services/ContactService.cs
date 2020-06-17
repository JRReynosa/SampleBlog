using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using Portfolio.ViewModels;

namespace Portfolio.Services
{
    public class ContactService
    {
        public bool SendMessage(ContactViewModel viewModel)
        {
            var msg = new MimeMessage
            {
                From = { new MailboxAddress(viewModel.Email) },
                Subject = viewModel.Subject,
                Body = new TextPart("plain") { Text = viewModel.Message },
                To = { new MailboxAddress("jonathanreynosa19@gmail.com") }
            };

            var smtp = new SmtpClient();

            try
            {
                smtp.Connect("smtp.gmail.com", 587, false);
                smtp.Authenticate("jonathanreynosa19@gmail.com", "852797John");
                smtp.Send(msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending mail:" + ex.Message);
                return false;
            }

            smtp.Disconnect(true);
            return true;
        }
    }
}
