using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GamIntraStandard.Interfaces;
using GamIntraStandard.Clases;
using GamIntraStandard.Models;
using GamIntraStandard.Common;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.IO;
using GamIntraStandard.Properties;
using System.Net.Mail;
using System.Net;


namespace GamIntraStandard.Clases
{
    public class CHome : IHome
    {

        public List<INF_TRB> GetBuzon()
        {

            var cookieUser = HttpContext.Current.Request.Cookies["User"];

            List<INF_TRB> buzon = new List<INF_TRB>();
            if(cookieUser != null)
            {
                using (var ent = new gamEntities1())
                {

                    buzon = ent.INF_TRB.Where(x => x.CODI_TRB == cookieUser.Value && x.DATA_VIST == null).ToList();
                }
            }

            return buzon;
        }

        public List<TRB> GetAllUsers()
        {

            List<TRB> trabajador = new List<TRB>();

            var usuario = System.Web.HttpContext.Current.Request.Cookies["User"];

            using (var ent = new gamEntities1())
            {
                trabajador = ent.TRB.Where(x => x.CODI_TRB != usuario.Value && x.ACTIU_SI_NO == 1).OrderBy(c => c.NOM).ToList();
            }

            return trabajador;

        }

        public void EnviarMensaje(MensajeTrabajadores msg)
        {

            var cookieUser = HttpContext.Current.Request.Cookies["User"];

            string[] getCodi = msg.codiTrb.Split('|');


            using (var ent = new gamEntities1())
            {

                
                var msgToInsert = new INF_TRB
                {
                    SYS_215 = Guid.NewGuid().ToString().Substring(0, 10).ToUpper(),
                    CODI_TRB = getCodi[1].Trim(),
                    DATA = DateTime.Now,
                    DES = msg.asunto,
                    TEXTE = msg.mensaje,
                    CODI_TRB_ORIGEN = cookieUser.Value,
                    INACTIU_SI_NO = 0,
                    PATH_DOC = "",
                    APARTAT = "",
                    DESTI = "T",

                };

            ent.INF_TRB.Add(msgToInsert);
            ent.SaveChanges();                       
                    
                    
              
            }
        }

        public bool CambiarDatos(MensajeTrabajadores msg)
        {

            Settings sett = new Settings();
            

            var cookieUser = HttpContext.Current.Request.Cookies["User"];
            string nomTrb = "";

            using (var ent = new gamEntities1())
            {

                var model = ent.TRB.Where(x => x.CODI_TRB == cookieUser.Value).FirstOrDefault();
                nomTrb = model.NOM.ToString().TrimEnd();


                var qua = ent.QUA.Where(x => x.CODI_TRB == model.CODI_TRB).FirstOrDefault();

                var bas = ent.BAS.Where(x => x.CODI_BAS == qua.CODI_BAS).FirstOrDefault();
           
            try
            {
                    if(bas.E_MAIL != null)
                    {

                        MailMessage mail = new MailMessage();
                        NetworkCredential userInfo = new NetworkCredential();

                        mail.From = new MailAddress(sett.from);

                        if (bas.E_MAIL != null)
                        {
                            mail.Body = "Nuevo mensaje:\n\r";
                            var texto = "- DE: " + nomTrb + "\n\r" + "- Asunto: " + msg.asunto + "\n\r" + "- Mansaje: " + msg.mensaje + "\n\r";
                            mail.Body += texto;
                            mail.To.Add(new MailAddress(bas.E_MAIL));
                        }
                        else
                        {
                            mail.Body = "Nuevo mensaje:\n\r";
                            var texto = "- DE: " + nomTrb + " Está intentando enviar un correo a la administración +";
                            mail.Body += texto;
                            mail.To.Add(new MailAddress("david.hernandez@original-soft.com"));
                        }
                        
                        mail.Subject = "GamIntra - Nuevo mensaje de: " + nomTrb;
                        mail.IsBodyHtml = false;

                        SmtpClient client = new SmtpClient
                        {
                            Host = sett.host,
                            Port = sett.port,
                            Credentials = new NetworkCredential(sett.from, sett.password)
                        };

                        client.Send(mail);
                        mail.Dispose();
                        client.Dispose();

                    }



                }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            }
            return false;
        }

        public void MarcarLeido(string id)
        {

            using (var ent = new gamEntities1())
            {
                try
                {
                    var msg = ent.INF_TRB.FirstOrDefault(x => x.SYS_215.Trim().ToUpper() == id.Trim().ToUpper());
                    msg.DATA_VIST = DateTime.Now;
                    ent.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
            }

        }


    }
}