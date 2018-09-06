using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using GamIntraStandard.Interfaces;
using GamIntraStandard.Models;
using GamIntraStandard.Common;
using System.Web.Mvc;
using System.IO;
using GamIntraStandard.Properties;
using System.Net.Mail;
using System.Net;
using System.Data.Entity.Validation;

namespace GamIntraStandard.Clases
{
    public class CMiPerfil : IMiPerfil
    {
        public TRB RecogerDatos()
        {
            TRB trb = new TRB();

            var cookieUser = HttpContext.Current.Request.Cookies["User"];
                   
            using (var ent = new gamEntities1())
            {

                trb = ent.TRB.FirstOrDefault(x => x.CODI_TRB == cookieUser.Value);
            }

            return trb;
        }


        public void CambiarContrasenya(CambioPass data)
        {
            var cookieUser = HttpContext.Current.Request.Cookies["User"];

            using (var ent = new gamEntities1())
            {
                var trbToUpdate = ent.TRB.FirstOrDefault(x => x.CODI_TRB == cookieUser.Value);
                trbToUpdate.PWD_WEB = data.RepetirPasswd;


                try
                {
                    ent.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }


                
            }
        }

        public bool CambiarDatos(string texto) {

            Settings sett = new Settings();

            var cookieUser = HttpContext.Current.Request.Cookies["User"];

            string nomTrb = "";

            using (var ent = new gamEntities1())
            {

                var model = ent.TRB.Where(x => x.CODI_TRB == cookieUser.Value).FirstOrDefault();
                nomTrb = model.NOM.ToString().TrimEnd();

            }
            try
            {
                MailMessage mail = new MailMessage();
                NetworkCredential userInfo = new NetworkCredential();

                mail.From = new MailAddress(sett.from);

                mail.To.Add(new MailAddress(sett.emailCntrl)); //HAY QUE CAMBIAR EL VALOR DE sett.destinoFijo POR UN CORREO

                mail.Body = "Cambio de datos personales a: " + nomTrb + " :\n\r";

                mail.Body += texto;


                mail.Subject = nomTrb + " - Solicitud Cambio Datos Personales";
                mail.IsBodyHtml = false;

                SmtpClient client = new SmtpClient
                {
                    Host = sett.host,
                    Port = 25,
                    Credentials = new NetworkCredential(sett.from, sett.password)
                };

                client.Send(mail);
                mail.Dispose();
                client.Dispose();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

            return false;
        }

        public List<Archivos> Nomina(string year)
        {

            var cookieUser = HttpContext.Current.Request.Cookies["User"];
            //string trb = "";

            //using (var ent = new gamEntities1())
            //{
            //    trb = ent.TRB.First(x => x.CODI_TRB == cookieUser.Value).NOM;

            //}

            //var ruta = cookieUser.Value + " - " + trb;

            List<Archivos> lstFiles = new List<Archivos>();
            Settings sett = new Settings();

            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(sett.ruta + "Gam_SQL/GamIntra/Empleados/" + cookieUser.Value + "/Nominas/" + year +"/");

                int i = 0;

                foreach (var item in dirInfo.GetFiles())
                {
                    lstFiles.Add(new Archivos()
                    {
                        id = i + 1,
                        FileName = item.Name,
                        FilePath = dirInfo.FullName
                    });

                    i = i + 1;

                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex.InnerException);

            }

            return lstFiles;
        }

        public List<Directorio> GetDirectorio()
        {

            var cookieUser = HttpContext.Current.Request.Cookies["User"];
            List<Directorio> lstFiles = new List<Directorio>();

            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(@"C:/Gam/Gam_SQL/GamIntra/Empleados/" + cookieUser.Value + "/Nominas/");

                int i = 0;


                foreach (var item in dirInfo.GetDirectories())
                {
                    lstFiles.Add(new Directorio()
                    {
                        id = i + 1,
                        DirName = item.Name,
                    });

                    i = i + 1;

                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex.InnerException);

            }

            return lstFiles;
        }

        public string GetM145() {
            var cookieUser = HttpContext.Current.Request.Cookies["User"];
            string file = @"C:/Gam/Gam_SQL/GamIntra/Empleados/" + cookieUser.Value + "/M145/Modelo145.pdf";
            return file;
        }

        public List<Archivos> DocumentosPersonales() {
            var cookieUser = HttpContext.Current.Request.Cookies["User"];

            List<Archivos> lstFiles = new List<Archivos>();

            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(@"C:/Gam/Gam_SQL/GamIntra/Empleados/" + cookieUser.Value + "/DocumentosPersonales/");

                int i = 0;

                foreach (var item in dirInfo.GetFiles())
                {
                    lstFiles.Add(new Archivos()
                    {
                        id = i + 1,
                        FileName = item.Name,
                        FilePath = dirInfo.FullName
                    });

                    i = i + 1;

                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex.InnerException);

            }

            return lstFiles;
        }

        public List<Archivos> DocumentosGenerales()
        {
            var cookieUser = HttpContext.Current.Request.Cookies["User"];

            List<Archivos> lstFiles = new List<Archivos>();

            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(@"C:/Gam/Gam_SQL/GamIntra/Documentos/");

                int i = 0;

                foreach (var item in dirInfo.GetFiles())
                {
                    lstFiles.Add(new Archivos()
                    {
                        id = i + 1,
                        FileName = item.Name,
                        FilePath = dirInfo.FullName
                    });

                    i = i + 1;

                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex.InnerException);

            }

            return lstFiles;
        }


    }
}