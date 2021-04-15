using System;
using System.Linq;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using RS1_Teretana.EF;
using RS1_Teretana.EntityModels;
using RS1_WebApp.Areas.Uposlenici.ViewModels;
using RS1_WebApp.Web.Helper;

namespace RS1_WebApp.Controllers
{
    [Area("Uposlenici")]
    public class EmailController : Controller
    {
        private readonly MyContext db;

        public EmailController(MyContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult SendEmail(int ClanID, int TeretanaID)
        {
            Clan clan = db.Clan.Where(c => c.ClanID == ClanID).FirstOrDefault();
            EmailVM vm = new EmailVM()
            {
                Ime = clan.Ime,
                Email = clan.Email,
                Naslov = "Napomena",
                TeretanaID=TeretanaID
            };
            return PartialView(vm);
        }

        [HttpPost]
        public IActionResult SendEmail(EmailVM vm)
        {
            var imeUposlenika =  HttpContext.GetLogiraniKorisnik();
            var Korisnik = db.Korisnik.Where(b => b.KorisnickiNalogID == imeUposlenika.Id).FirstOrDefault();
            if (ModelState.IsValid)
            {
                try
                {
                    var message = new MimeMessage();
                    message.To.Add(new MailboxAddress(vm.Ime, vm.Email));
                    message.From.Add(new MailboxAddress(Korisnik.Ime + " " + Korisnik.Prezime, Korisnik.Email));
                    message.Subject = vm.Naslov;
                    message.Body = new TextPart(TextFormat.Html)
                    {
                        Text = vm.Poruka + " Poruka je poslana od: " + vm.Ime + " E-mail: " + vm.Email
                    };

                    using (var emailClient = new SmtpClient())
                    {
                        emailClient.Connect("smtp.gmail.com", 587, false);
                        emailClient.Authenticate("test@gmail.com", "password");
                        emailClient.Send(message);
                        emailClient.Disconnect(true);
                    }
                }
                catch (Exception ex)
                {
                    ModelState.Clear();
                    ViewBag.Message = $" Nije u funkciji {ex.Message}";
                }
            }
            TempData["Poruka-email"] = "Uspjesno ste poslali mail korisniku " + vm.Ime;
            return Redirect("/Uposlenici/Clan?TeretanaID="+vm.TeretanaID);
        }
    }
}