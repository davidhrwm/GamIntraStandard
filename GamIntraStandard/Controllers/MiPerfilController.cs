using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamIntraStandard.Models;
using GamIntraStandard.Interfaces;
using GamIntraStandard.Clases;
using GamIntraStandard.Common;
using System.ComponentModel.DataAnnotations;
using GamIntraStandard.Properties;
using System.Net.Mail;
using System.Net;

namespace GamIntraStandard.Controllers
{
    public class MiPerfilController : Controller
    {
        private IMiPerfil _miPerfil;

        public MiPerfilController() : this(new CMiPerfil()){}

        internal MiPerfilController(IMiPerfil miPerfil)
        {
            _miPerfil = miPerfil;
        }

        // GET: MiPerfil      
        public ActionResult VerDatosPersonales()
        {
            var model = _miPerfil.RecogerDatos();
            return View(model);
        }

        public ActionResult CambiarPass()
        {
            return View();
        }

        public JsonResult PassCambioData(CambioPass data)
        {
            var cPass = true;

            try
            {
                _miPerfil.CambiarContrasenya(data);
            }
            catch (Exception ex)
            {
                cPass = false;
            }
            
            return Json(cPass);
        }

        public void CambioDatosPersonales(string text)
        {

            _miPerfil.CambiarDatos(text);

        }

        public ActionResult MisDocumentos() {

            return View();
        }

        public ActionResult DatosPersonales()
        {


            return PartialView();
        }

        public ActionResult Nominas() {
            

            return PartialView();
        }

        public FileResult Modelo145()
        {
            var name = "Modelo145.pdf";
            string contentType = "application/pdf";

            string url = _miPerfil.GetM145();

            return File(url, contentType, name);

        }

        public ActionResult GetYearFile(string yr)
        {

            var contenido = _miPerfil.Nomina(yr);

            //var envio = "";
            //foreach (var item in contenido) {
            //    //envio += item.FileName; 
            //    //envio += "<a href='/MiPerfil/DownloadFile/?url=" + item.FilePath + item.FileName + "&name=" + item.FileName + "><li>POCOYP" + item.FileName + "</li></a>";
            //    envio += "<li class='archivoLista'><a href='/MiPerfil/DownloadFile/?url="+ item.FilePath + item.FileName + "&name=" + item.FileName + "'><span class='titleFile'>" + item.FileName.Split('.').First() + "</span><br/><span class='biggerIcons glyphicon glyphicon-file'></span></a></li>";
            //    //envio += "<a href='/MiPerfil/DownloadFile/?url="+ item.FilePath + item.FileName + "&name=" + item.FileName +"><li>POCOYP" + item.FileName + "</li></a>";
            //}
            //return Content(envio);

            var nominas = "";
            foreach (var item in contenido)
            {
                var url = Url.Action("DownloadNomina", "MiPerfil", new { @carpeta = item.FilePath, @name = item.FileName, @id = item.id, @year = yr });

                nominas += "<li class='archivoLista'><a href = '"+ url +"' ><span class='titleFile'>"+ item.FileName.Split('.').First() +"</span><br /><span class='biggerIcons glyphicon glyphicon-file'></span></a></li>";
            }
            return Content(nominas);
        }

        public FileResult DownloadFile(string url, string name, int id)
        {
            //string file = url;
            string contentType = "application/pdf";
            //return File(file, contentType, "GamIntraSTD-" + name);

            CMiPerfil hola = new CMiPerfil();

            var filesCol = hola.DocumentosGenerales();

            var fileToDownload = filesCol.Where(x => x.id == id).First();

            var currentFilePath = fileToDownload.FilePath + "//" + fileToDownload.FileName;

            if (currentFilePath.Contains(".pdf"))
            {
                contentType = "application/pdf";
            }
            return File(currentFilePath, contentType, fileToDownload.FileName);
        }


        public FileResult DownloadFile2(string url, string name, int id)
        {
            //string file = url;
            string contentType = "application/pdf";
            //return File(file, contentType, "GamIntraSTD-" + name);

            CMiPerfil hola = new CMiPerfil();

            var filesCol = hola.DocumentosPersonales();

            var fileToDownload = filesCol.Where(x => x.id == id).First();

            var currentFilePath = fileToDownload.FilePath + "//" + fileToDownload.FileName;

            if (currentFilePath.Contains(".pdf"))
            {
                contentType = "application/pdf";
            }
            return File(currentFilePath, contentType, fileToDownload.FileName);
        }


        public FileResult DownloadNomina(string url, string name, int id, string year)
        {
            //string file = url;
            string contentType = "application/pdf";
            //return File(file, contentType, "GamIntraSTD-" + name);

            CMiPerfil hola = new CMiPerfil();

            var filesCol = hola.Nomina(year);

            var fileToDownload = filesCol.Where(x => x.id == id).First();

            var currentFilePath = fileToDownload.FilePath + "//" + fileToDownload.FileName;

            if (currentFilePath.Contains(".pdf"))
            {
                contentType = "application/pdf";
            }
            return File(currentFilePath, contentType, fileToDownload.FileName);
        }

        public FileResult DownloadM145(string url, string name)
        {
            //string file = url;
            string contentType = "application/pdf";
            //return File(file, contentType, "GamIntraSTD-" + name);

            CMiPerfil hola = new CMiPerfil();

            var urlm = hola.GetM145();

            if (urlm.Contains(".pdf"))
            {
                contentType = "application/pdf";
            }
            return File(urlm, contentType, "Modelo145.pdf");
        }

        public ActionResult GeneralDocumentos() {

            return View();
        }

    }
}