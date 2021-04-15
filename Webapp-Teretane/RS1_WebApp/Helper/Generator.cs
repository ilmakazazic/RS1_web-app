using System;

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