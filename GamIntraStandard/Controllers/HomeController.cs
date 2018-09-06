using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamIntraStandard.Interfaces;
using GamIntraStandard.Clases;
using System.Configuration;
using GamIntraStandard.Properties;
using GamIntraStandard.Common;
using GamIntraCustomerVerification;

namespace GamIntraStandard.Controllers
{
    public class HomeController : Controller
    {
        /*Llamada a la interfaz*/
        private IHome _home;

        public HomeController() : this(new CHome()){ }

        internal HomeController(IHome home)
        {
            _home = home;
        }

        Clients auth = new Clients();

        public ActionResult Index()
        {           
            using(var ent = new GamIntraStandard.Models.gamEntities1())
            {

                //if(!auth.AuthController(Convert.ToInt32(ent.CFG.Select(x => x.CLIENT_OSOFT).FirstOrDefault()), "Home"))
                //{
                //    return RedirectToAction("Index", "Jornada");
                //}

            }

            var envi = _home.GetBuzon();

            return View(envi);
        }

        public void EnviarMensaje(MensajeTrabajadores msg) {


            _home.EnviarMensaje(msg);
        }


        public void CambiarDatos(MensajeTrabajadores msg)
        {

            _home.CambiarDatos(msg);

        }

        public void MarcarLeido(string msg) {
            _home.MarcarLeido(msg);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}