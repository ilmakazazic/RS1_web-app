//using eUniverzitet.Web.Controllers;
//using eUniverzitet.Web.ViewModels;
using eUniverzitet.Web.Controllers;
using eUniverzitet.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RS1_Teretana.EF;
using RS1_Teretana.Web.Helper;
using RS1_WebApp.Areas.Uposlenici.Controllers;
using RS1_WebApp.Areas.Uposlenici.ViewModels;
using RS1_WebApp.Controllers;
using System;

namespace RS1_UnitTest
{
    [TestClass]
    public class UnitTest_Uposlenik
    {
        private readonly MyContext db;

        [TestMethod]
        public void TreninziBroj()
        {
           
            TreningAjaxController controller = new TreningAjaxController(db);
            int ocekivana = 1;
            int realna = controller.BrojTreninga();
            Assert.IsTrue(ocekivana<realna);

        }
        [TestMethod]
        public void DrzaveBroj()
        {

            GradController controller = new GradController(db);
            int ocekivana = 4;
            int realna = controller.BrojDrzava();
            Assert.AreEqual(ocekivana, realna);

        }

        [TestMethod]
        public void Kupon_model_test()
        {
            KuponDodajVM model = new KuponDodajVM();
            model.Broj_Koristenja = 3;
            ClanarinaController controller = new ClanarinaController(db);
            int Rezultat = controller.ModelTest(model);
            Assert.AreEqual(3, Rezultat);

        }

        [TestMethod]
        public void DodavanjeKupon_test()
        {
            KuponDodajVM model = new KuponDodajVM()
            {
                KuponKod = Generator.KodPopusta(),
                Broj_Koristenja = 5,
                Aktivan = true,
                Postotak = 10,
                TeretanaID=5,
                Brojac_Koristenja = 0,
                PocetakDatum = DateTime.Now,
                KrajDatum = DateTime.Today.AddDays(5),
               

            };

            ClanarinaController controller = new ClanarinaController(db);
            string unos = controller.DodajKupon(model);
            Assert.AreEqual(model.KuponKod, unos);

        }

    }
}
