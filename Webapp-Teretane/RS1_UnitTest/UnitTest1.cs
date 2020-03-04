//using eUniverzitet.Web.Controllers;
//using eUniverzitet.Web.ViewModels;
using eUniverzitet.Web.Controllers;
using eUniverzitet.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RS1_Teretana.EF;
using RS1_WebApp.Areas.Clanovi.Controllers;
using RS1_WebApp.Areas.Clanovi.ViewModels;
using RS1_WebApp.Controllers;
using System;

namespace RS1_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
   
        [TestMethod]
        public void ObavijestiCount()
        {
           
            ObavijestiController controller = new ObavijestiController();
            int ocekivana = 5;
            int realna = controller.BrojObavijesti();
            Assert.AreEqual(ocekivana, realna);

        }
        [TestMethod]
        public void TipClanarineCount()
        {
         
            ClanarinaController controller = new ClanarinaController();
            int ocekivana = 3;
            int realna = controller.BrojTipova();
            Assert.AreEqual(ocekivana, realna);

        }

        [TestMethod]
        public void UrediProfilTest()
        {
            UrediProfilVM model = new UrediProfilVM();
            model.ClanID = 3;
            model.KorisnickoIme = "amina1";
            model.Lozinka = "123";

            //var optionsBuilder = new DbContextOptionsBuilder<MyContext>()
            //    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            //var _dbContext = new MyContext(optionsBuilder.Options);
            ProfilController controller = new ProfilController();
            int clanRezultat = controller.UrediSnimiTest(model);
            Assert.AreEqual(3, clanRezultat);


        }
        [TestMethod]
        public void OcjenjivanjeTest()
        {

            int ClanID = 2;
            int ocjena = 1;
            int teretanaID = 4;

            //var optionsBuilder = new DbContextOptionsBuilder<MyContext>()
            //    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            //var _dbContext = new MyContext(optionsBuilder.Options);
            ProfilController controller = new ProfilController();
            int ocjenaClana = controller.OcijeniTest(ClanID, ocjena, teretanaID);
            Assert.AreEqual(1, ocjenaClana);


        }

    }
}
