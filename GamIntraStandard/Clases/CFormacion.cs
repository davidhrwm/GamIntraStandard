using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using GamIntraStandard.Interfaces;
using GamIntraStandard.Models;
using GamIntraStandard.Properties;
using GamIntraStandard.Common;
using System.Resources;

namespace GamIntraStandard.Clases
{
    public class CFormacion : IFormacion
    {
        private Settings sett = new Settings(); //Es para utilizar el objeto sett.

        public List<TRB_FOR> GetUserFor(string date)
        {
            List<TRB_FOR> formacion = new List<TRB_FOR>();

            var cookieUser = HttpContext.Current.Request.Cookies["User"];

            try
            {
                using (var ent = new gamEntities1())
                {
                    var year = Convert.ToInt32(date);

                    formacion = ent.TRB_FOR.Where(x => x.CODI_TRB == cookieUser.Value && x.DATA_INICI.Value.Year == year).ToList();
                }
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
                var iner = ex.InnerException;

            }

            return formacion;
        }

        public List<FOM> GetFormacion()
        {
            List<FOM> formacion = new List<FOM>();

            using (var ent = new gamEntities1())
            {
               formacion = ent.FOM.Where(x => x.DATA_INICI.Value >= DateTime.Now).ToList();
            }

            return formacion;
        }

        public FOM GetCursoInfo(string id)
        {
            FOM curso = new FOM();

            using (var ent = new gamEntities1())
            {
                curso = ent.FOM.Where(x => x.CODI_FOR.Trim() == id.Trim()).FirstOrDefault();
            }


            return curso;
        }

        public List<Archivos> GetDescargas()
        {
            List<Archivos> formacion = new List<Archivos>();

            //recoge el numero de usuario (ejemplo: 00004)
            var cookieUser = System.Web.HttpContext.Current.Request.Cookies["User"];

            //concatena rutas para crear la ruta final
            var route = sett.ruta + "Gam_SQL/GamIntra/Empleados/" + cookieUser.Value + "/Formacion/";
            string[] rutaNombres = new string[20]; //array ara guardar los nombres de los ficheros encontrados
            var i = 0; //contador

            DirectoryInfo di = new DirectoryInfo(route); //guarda la ruta en un objeto de tipo directory

            foreach (var fi in di.GetFiles())//busca todos los archivos dentro de un directorio
            {
                //rutaNombres[i] = route += fi.Name;
                //i++;
                formacion.Add(new Archivos{
                    id = 1,
                    FileName = fi.Name,
                    FilePath = fi.FullName,
                    RelativePath = fi.FullName.Substring(20)
            });
                
            }

            return formacion;
        }
    }
}