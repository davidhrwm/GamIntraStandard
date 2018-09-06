using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamIntraStandard.Controllers
{
    public class TramitesController : Controller
    {
        // GET: Tramites
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Anticipos()
        {
            return PartialView();
        }

        public ActionResult ComunicadoTaller()
        {
            return PartialView();
        }
    }
}