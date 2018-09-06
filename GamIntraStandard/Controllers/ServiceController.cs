using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamIntraStandard.Interfaces;
using GamIntraStandard.Clases;
using GamIntraStandard.Models;
using GamIntraStandard.Common;
using System.Web.Security;
using Microsoft.Owin.Security;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using System.Net;
using GamIntraStandard.Properties;

namespace GamIntraStandard.Controllers
{
    public class ServiceController : Controller
    {
        private IService _service;

        public ServiceController() : this(new CService()){ }

        internal ServiceController(IService Jornada)
        {
            _service = Jornada;
        }
        // GET: Service

        public ActionResult CambioTurnosPendientes()
        {
            var turno = _service.GetCambioTurno();
            return Json(turno, JsonRequestBehavior.AllowGet);
        }

        public void CancelarCambio(string msgId)
        {
            _service.CancelarCambioTurno(msgId);

            _service.EnviarCorreoEmail(Convert.ToInt32(msgId));

        }

        public void AceptarCambio(string msgId)
        {

            _service.AceptarCambioTurno(msgId);
            
            _service.EnviarCorreoEmail(Convert.ToInt32(msgId));

        }

        public ActionResult salir()
        {
            try
            {
                // string callbackUrl = Url.Action("Menu", "Home");               
                Request.GetOwinContext().Authentication.SignOut(new AuthenticationProperties { RedirectUri = "Url.Action('Index', 'Login')" });
                //var cookieUser = HttpContext.Current.Request.Cookies["User"];       
            }
            catch
            {

            }

            return RedirectToAction("Index","Login");
        }

        public ActionResult Update() {
            return View();
        }
    }
}