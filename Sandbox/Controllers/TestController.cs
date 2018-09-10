using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace Sandbox.Controllers
{
    [Route("test/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public async Task Test()
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("Sandbox", "sandbox@sandbox.com"));
            message.To.Add(new MailboxAddress("", "test@fake.com"));
            message.Subject = "Test Data";

            message.Body = new TextPart("plain")
            {
                Text = string.Join(Environment.NewLine, new string[] { "Test", "One", "Two", "Three" })
            };

            using (var mailClient = new SmtpClient())
            {
                await mailClient.ConnectAsync("mail", 1025, SecureSocketOptions.None);
                await mailClient.SendAsync(message);
                await mailClient.DisconnectAsync(true);
            }

        }
    }
}