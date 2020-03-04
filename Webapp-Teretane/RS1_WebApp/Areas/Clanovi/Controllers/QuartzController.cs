using Microsoft.AspNetCore.Mvc;
using RS1_WebApp.Areas.Clanovi.QuartzNetHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_WebApp.Areas.Clanovi.Controllers
{
    public class QuartzController:Controller
    {

        [HttpGet]
        public void Get()
        {
            //QuartzHostedService.StartTestJob();
            //String x = "";
        }
    }
}
