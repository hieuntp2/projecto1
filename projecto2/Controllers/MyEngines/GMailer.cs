using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using System;
using System.IO;
using RazorEngine.Templating;


namespace projecto2.MyEngines
{
    public class GMailer
    {
        public async Task Send(string fromemail, string password, string toemail, string subject, string useremail, string messagebody)
        {
            string mysj = "Inthef.vn: " + subject;
            string body = messagebody;

            var fromAddress = new MailAddress(fromemail, useremail);
            var toAddress = new MailAddress(toemail, useremail);
            string fromPassword = password;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = mysj,
                Body = body,
                IsBodyHtml = true
            })
            {
                await smtp.SendMailAsync(message);
            }
        }
    }

    public class UpdateOrderToUserModel
    {
        public string hoten { get; set; }
        public string email { get; set; }
        public string iddonhang { get; set; }
        public string tinhtrang { get; set; }
    }
}