using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Quartz;
using RS1_Teretana.EF;
using RS1_Teretana.EntityModels;
using RS1_WebApp.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_WebApp.Areas.Clanovi.QuartzNetHelper
{
    public class ScheduledJob : IJob
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<ScheduledJob> logger;


        public ScheduledJob(MyContext context, IConfiguration configuration, ILogger<ScheduledJob> logger)
        {
            this.logger = logger;
            this.configuration = configuration;
        }

        public Task Execute(IJobExecutionContext context)
        {
            MyContext db = new MyContext();
            List<Clan> clanovi = db.Clan.ToList();

            for (int i = 0; i < clanovi.Count; i++)
            {
                DateTime zeroTime = new DateTime(1, 1, 1);
                List<PlacanjeClanarine> uplacene = db.PlacanjeClanarine.Where(x => x.ClanID == clanovi[i].ClanID)
                    .OrderByDescending(s => s.PlacanjeClanarineID)
                    .ToList();

                if (uplacene.Count == 0)
                {
                    clanovi[i].Aktivan = false;
                    continue;
                }

                DateTime datum = uplacene.Select(s => s.DatumUplate).FirstOrDefault();
                TimeSpan span = DateTime.Now - datum;

                int years = (zeroTime + span).Year - 1;
                if (years > 1)
                {
                    clanovi[i].Aktivan = false;
                }
            }
            db.SaveChanges();

            this.logger.LogWarning($"Hello from scheduled task {DateTime.Now.ToLongTimeString()}");

            return Task.CompletedTask;
        }
    }
}
