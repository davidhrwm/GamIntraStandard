using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamIntraStandard.Interfaces;
using GamIntraStandard.Clases;
using GamIntraStandard.Models;
using GamIntraStandard.Properties;
using System.IO;

namespace GamIntraStandard.Controllers
{

    public class FormacionController : Controller
    {
        private IFormacion _formacion;
        private List<TRB_FOR> TrbFor;
        private List<Common.MisCursos> cursos;

        public FormacionController() : this(new CFormacion()) { }

        internal FormacionController(IFormacion Formacion)
        {
            _formacion = Formacion;
        }

        // GET: Formacion
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MisCursos(string date)
        {
            var model = _formacion.GetUserFor(date);
          
            cursos = new List<Common.MisCursos>();

            foreach(var item in model)
            {
                cursos.Add(new Common.MisCursos { Inicio = item.DATA_INICI, Final = item.DATA_FINAL, Titulo = item.TITOL, Horas = item.HORES });
            }

            return PartialView(cursos);
        }

        public ActionResult ProximosCursos()
        {

          

           return PartialView();
        }

        public ActionResult GetAllCursos()
        {
            var model = _formacion.GetFormacion();

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult InfoCurso(string cursoId)
        {
             var model = _formacion.GetCursoInfo(cursoId);

            return Json(model,JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult Descargas()
        {
            var model = _formacion.GetDescargas();

            return PartialView(model);
        }

        public ActionResult DescargarArchivo(int id, string FileName, string FilePath)
        {
            //string file = _miPerfil.GetM145();
            string contentType = "application/pdf";
            //Verificado, también puede enviar .txt
            return File(FilePath, contentType, FileName);
        }

        public string PassLastYear(string year)
        {
            return year;
        }
    }
}