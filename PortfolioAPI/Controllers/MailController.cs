using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using portfolio.Models;

namespace portfolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        // POST api/Mail
        [HttpPost]
        public void Post([FromBody]MailModel model)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("tahjideshan@gmail.com", "eshan123456.");  // [4] Added this. Note, first parameter is NOT string.
            smtp.Host = "smtp.gmail.com";

            MailMessage mail = new MailMessage();
            mail.From = new System.Net.Mail.MailAddress("tahjideshan@gmail.com");
            mail.Priority = MailPriority.High;
            mail.Subject = "Mail From Portfolio Site";
            mail.ReplyToList.Add(new MailAddress("atahjid@gmail.com"));
            mail.To.Add(new MailAddress("atahjid@gmail.com"));
            mail.IsBodyHtml = true;
            mail.Body = $@"
                <html>
                <body>
                    <div style='padding:10px;background:#fff;'>
                    Someone sent a message from the portfolio site at {DateTime.UtcNow}
                        <p>
                            Name : {model.Name},
                            Email Address : {model.Email},
                            <br>
                            Phone : {model.Phone},
                        </p>
                        <p>
                            {model.Message}
                        </p>
                    </div>
                </body>
            </html>";
            smtp.Send(mail);

            MailMessage mailToUser = new MailMessage();
            mailToUser.From = new System.Net.Mail.MailAddress("tahjideshan@gmail.com");
            mailToUser.Priority = MailPriority.High;
            mailToUser.Subject = "Request recieved";
            mailToUser.ReplyToList.Add(new MailAddress("atahjid@gmail.com"));
            mailToUser.To.Add(new MailAddress(model.Email));
            mailToUser.IsBodyHtml = true;
            mailToUser.Body = $@"
                <html>
                <body>
                    <div style='padding:10px;background:#fff;'>
                    Dear {model.Name}, your message was recieved at {DateTime.UtcNow}
                    I will get back to you ASAP.

                    Thank you
                    Tahjid
                    </div>
                </body>
            </html>";
            smtp.Send(mailToUser);

        }
    }
}
