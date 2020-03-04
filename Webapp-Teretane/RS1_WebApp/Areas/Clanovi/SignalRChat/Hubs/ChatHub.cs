using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using RS1_Teretana.EF;
using RS1_WebApp.EntityModels;

namespace RS1_WebApp.Areas.Clanovi.SignalRChat.Hubs
{
    public class ChatHub:Hub
    {
        private readonly MyContext db;

        public ChatHub(MyContext context)
        {
            db = context;
        }
        public async Task SendMessage(string user, string message)
        {

            if (user != "" && message != "")
            {
                ChatClanovi msg = new ChatClanovi
                {
                    KorisnickoIme = user,
                    Poruka = message,
                    DatumVrijeme = DateTime.Now

                };
                db.ChatClanovi.Add(msg);
                db.SaveChanges();
            }
   
           
            List<string> niz = db.ChatClanovi.Select(c=>c.DatumVrijeme.ToString("dddd, dd MMMM yyyy HH:mm") + " " +c.KorisnickoIme + ": " + c.Poruka).ToList();
            await Clients.All.SendAsync("ReceiveMessage", user, message, niz);
        }
    }
}
