using HotelProject.WUI.Models.Mail;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Net.Mail;

namespace HotelProject.WUI.Controllers
{
    public class AdminMailController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AdminMailViewModel model)
        {//KİMDEN GÖNDERİYORUZ
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("HotelierAdmin","aydemirfurkan1372@gmail.com");

            //KİME GÖNDERİYORUZ
            mimeMessage.From.Add(mailboxAddressFrom);
            MailboxAddress mailboxAddress= new MailboxAddress("User", model.ReceiverMail);

            mimeMessage.To.Add(mailboxAddress);

            var bodyBuilder = new BodyBuilder();
            //İÇERİK
            bodyBuilder.TextBody = model.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = model.Subject;
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                client.Authenticate("aydemirfurkan1372@gmail.com", "jmkd iyyk bpqj llby"); 

                client.Send(mimeMessage);
                client.Disconnect(true);
            }
            //Gönderilen Mailin veri tabanına kaydedilmesi.

            return View();
        }
    }
}
