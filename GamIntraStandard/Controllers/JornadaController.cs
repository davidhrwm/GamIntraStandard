using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamIntraStandard.Interfaces;
using GamIntraStandard.Clases;
using GamIntraStandard.Models;
using GamIntraStandard.Common;
using System.Globalization;

namespace GamIntraStandard.Controllers
{
    public class JornadaController : Controller
    {
        //Llamada a interfaz
        private IJornada _jornada;
        private List<HorarioJornada> _listaHorario;
        private QUA _extra;
        private Object jsonData;
        private IService _service;

        public GamIntraCustomerVerification.Clients verificacion = new GamIntraCustomerVerification.Clients();

        public JornadaController() : this(new CJornada(), new CService()){ }

        internal JornadaController(IJornada Jornada, IService Service)
        {
            _jornada = Jornada;
            _service = Service;
        }
        //Fin llamada a interfaz

        // GET: Jornada
        [Authorize]
        public ActionResult Index()
        {       

            return View();
        }

        public ActionResult CalendarioLaboral()
        {
            return PartialView();  
        }

        public ActionResult CalendarioLaboralEvents(string currentMonth, string fullYear)
        {

            int Month = Int32.Parse(currentMonth); //Pasa las variables string a int del mes actual
            int Year = Int32.Parse(fullYear); //Pasa las variables string a int del año actual

            try
            {
                _listaHorario = _jornada.HorarioQua(Month, Year);
            } catch(Exception Ex) {
                var source = Ex.Source;
                var message = Ex.Message;
            }

            return Json(_listaHorario, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Horarios(string dia)
        {
            var horarioDia = _jornada.HorariosCalendario(dia);

            return Json(horarioDia, JsonRequestBehavior.AllowGet);

        }

        public ActionResult CambioTurno()
        {
            var turno = new CambioTurno { usuario2 = GetAllUsers() };

            var cookieUser = System.Web.HttpContext.Current.Request.Cookies["User"];

            using (var ent = new gamEntities1()) {

                turno.usuario = ent.TRB.Where(x => x.CODI_TRB == cookieUser.Value ).Select(x => x.NOM.Trim()).FirstOrDefault();
            }

            return PartialView(turno);
        }

        public ActionResult HorasExtras()
        {

            return PartialView();
        }

        public ActionResult AddExtra(string date) {

            if(date != null) {

                try
                {
                   _extra = _jornada.AddHoraExtra(date);

                    if (_extra != null)
                    {
                        jsonData = new
                        {
                            InicioT = _extra.DATA_INICI,
                            InicioR = _extra.DATA_INICI_REAL, /*_extra.DATA_INICI_ORIGINAL,*/
                            FinalT = _extra.DATA_FINAL,
                            FinalR = _extra.DATA_FINAL_REAL,
                            Dia = _extra.DATA_INICI
                        };
                    }
                    else
                    {



                    }

                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
            }

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }


        private IEnumerable<SelectListItem> GetAllUsers()
        {

            List<SelectListItem> trabajador = new List<SelectListItem>();

            var usuario = System.Web.HttpContext.Current.Request.Cookies["User"];

            using (var ent = new gamEntities1())
            {
                trabajador = ent.TRB.Where(x => x.CODI_TRB != usuario.Value && x.ACTIU_SI_NO == 1).Select(d => new SelectListItem { Value = d.CODI_TRB, Text = d.NOM }).OrderBy(c => c.Text).ToList();
            }

            return new SelectList(trabajador, "Value", "Text");

        }


        [HttpPost]
        public ActionResult BtnCambiarTurno(CambioTurno turno) {

            int msgId = _jornada.CambiarTurno(turno);
            
            _service.EnviarCorreoEmail(msgId);

            return View("Index");
        }
    }
}