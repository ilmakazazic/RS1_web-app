using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ispit.Web.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design.Internal;
using Microsoft.Extensions.DependencyInjection;
using RS1_Teretana.EF;
using RS1_WebApp.EntityModels;

namespace RS1_Teretana.Web.Helper
{
    public static class Generator
    {
        private const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static string KodPopusta ()
        {
            Random Generator = new Random();
            int Gen = Generator.Next(0, 99999); 
            Random ranAlpha = new Random();

            string alpha = alphabet[ranAlpha.Next(0, 25)].ToString();
            return Gen.ToString("###" + alpha + "##" + alpha + alpha + "##");

        }

    }
}