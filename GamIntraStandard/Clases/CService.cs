using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GamIntraStandard.Interfaces;
using GamIntraStandard.Models;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;
using GamIntraStandard.Properties;

namespace GamIntraStandard.Clases
{
    public class CService : IService // Implementacion de interfaz
    {
        public List<INF_TRB> GetBuzon()
        {
            List<INF_TRB> buzon = new List<INF_TRB>();

            var cookieUser = HttpContext.Current.Request.Cookies["User"];

            using (var ent = new gamEntities1())
            {
                buzon = ent.INF_TRB.Where(x => x.CODI_TRB == cookieUser.Value && x.DATA_VIST == null && x.CODI_TRB_ORIGEN == null).ToList();

            }

            return buzon;
        }

        //[Authorize]
        public WEB_HIS GetCambioTurno()
        {
            WEB_HIS cambioTurno = new WEB_HIS();

            var cookieUser = HttpContext.Current.Request.Cookies["User"];

            using (var ent = new gamEntities1())
            {
                cambioTurno = ent.WEB_HIS.Where(x => x.CODI_TRB_DESTI == cookieUser.Value && DateTime.Now < x.DATA_PETICIO && x.ACCIO == "CANVI_TORN_PEN").FirstOrDefault();

            }

            return cambioTurno;
        }

        public List<INF> GetAvisos()
        {
            List<INF> avisos = new List<INF>();

            using (var ent = new gamEntities1())
            {
                avisos = ent.INF.Where(x => x.DATA_FINAL > DateTime.Now).ToList();

            }

            return avisos;
        }

        public List<INF_TRB> GetMensajeInterno()
        {

            List<INF_TRB> interno = new List<INF_TRB>();

            var cookieUser = HttpContext.Current.Request.Cookies["User"];

            using (var ent = new gamEntities1())
            {

                interno = ent.INF_TRB.Where(x => x.CODI_TRB == cookieUser.Value && x.DATA_VIST == null && x.CODI_TRB_ORIGEN != null).ToList();

            }

            return interno;
        }

        public INF_TRB GetMensaje(string id)
        {

            INF_TRB msg = new INF_TRB();

            //using (var ent = new gamEntities1())
            //{
            //    msg = ent.INF_TRB.FirstOrDefault(x=> x.SYS_215 == id);

            //}
            using (var ent = new gamEntities1())
            {
                msg = ent.INF_TRB.FirstOrDefault(x => x.SYS_215.Trim().ToUpper() == id.Trim().ToUpper());

            }

            return msg;
        }

        public void MarcarLeido(string id)
        {

            using (var ent = new gamEntities1())
            {
                var msg = ent.INF_TRB.FirstOrDefault(x => x.SYS_215.Trim().ToUpper() == id.Trim().ToUpper());
                msg.DATA_VIST = DateTime.Now;
                ent.SaveChanges();

            }

        }

        public INF GetAvisoModal(string id)
        {
            var aviso = new INF();

            using (var ent = new gamEntities1())
            {

                aviso = ent.INF.Where(x => x.SYS_215.Trim().ToUpper() == id.Trim().ToUpper()).FirstOrDefault();

            }

            return aviso;
        }

        public void AceptarCambioTurno(string id)
        {

            using (var ent = new gamEntities1())
            {
                var num = int.Parse(id);

                var webHisToUpdate = ent.WEB_HIS.Where(x => x.SYS_215 == num).FirstOrDefault();

                if (webHisToUpdate != null)
                {
                    try
                    {
                        webHisToUpdate.ACCIO = "CANVI_TORN_ACE";

                        INF_TRB confirmacion = new INF_TRB();

                        var cookieUser = HttpContext.Current.Request.Cookies["User"];

                        confirmacion.SYS_215 = Guid.NewGuid().ToString().ToUpper().Substring(0, 10);
                        confirmacion.TEXTE = "Su cambio de turno ha sido aceptado, un coordinador lo validará";
                        confirmacion.CODI_TRB_ORIGEN = cookieUser.Value;
                        confirmacion.CODI_TRB = webHisToUpdate.CODI_USU;
                        confirmacion.DATA = DateTime.Now;
                        confirmacion.DES = "Cambio de Turno";
                        confirmacion.APARTAT = "";
                        confirmacion.INACTIU_SI_NO = 0;
                        confirmacion.DESTI = "";
                        confirmacion.PATH_DOC = "";

                        ent.INF_TRB.Add(confirmacion);

                        ent.SaveChanges();

                    }
                    catch (Exception ex)
                    {
                        var msg = ex.Message;

                    }
                }
            }

        }

        public void CancelarCambioTurno(string id)
        {

            using (var ent = new gamEntities1())
            {

                var num = int.Parse(id);

                var webHisToUpdate = ent.WEB_HIS.Where(x => x.SYS_215 == num).FirstOrDefault();

                try
                {

                    webHisToUpdate.ACCIO = "CANVI_TORN_CAN";

                    INF_TRB confirmacion = new INF_TRB();

                    var cookieUser = HttpContext.Current.Request.Cookies["User"];

                    confirmacion.SYS_215 = Guid.NewGuid().ToString().ToUpper().Substring(0, 10);
                    confirmacion.TEXTE = "El usuario no ha aceptado su cambio de turno";
                    confirmacion.CODI_TRB_ORIGEN = cookieUser.Value;
                    confirmacion.CODI_TRB = webHisToUpdate.CODI_USU;
                    confirmacion.DATA = DateTime.Now;
                    confirmacion.DES = "Cambio de Turno Cancelado";
                    confirmacion.APARTAT = "";
                    confirmacion.INACTIU_SI_NO = 1;
                    confirmacion.DESTI = "";
                    confirmacion.PATH_DOC = "";

                    ent.INF_TRB.Add(confirmacion);

                    ent.SaveChanges();

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);

                }
            }

        }


        public void EnviarCorreoEmail(int msgId)
        {

            using (var ent = new gamEntities1())
            {
                /****OBJETOS DEL EMAIL****/
                Settings sett = new Settings(); //crea el objeto de tipo settings, Tambien recibe datos del AppSettings

                //EL HOST QUE ENVIA EL CORREO (ORIGEN)
                MailAddress from = new MailAddress(sett.from, "GamIntra");

                //OBJETO MAIL
                MailMessage mail = new MailMessage();

                //AÑADE AL OBJETO MAIL EL ORIGEN O HOST
                mail.From = from;

                //PERMITE HTML EN EL CUERPO DEL EMAIL
                mail.IsBodyHtml = true;

                //DIRECCION DE CONTROL DE ERRORES (toD)
                MailAddress toD = new MailAddress(sett.emailCntrl, "David");

                //CONFIGURA EL CLIENTE CON EL ORIGEN Y EL PUERTO
                SmtpClient client = new SmtpClient
                {
                    Host = sett.host,
                    Port = sett.port,
                    //credenciales del host
                    Credentials = new NetworkCredential(sett.from, sett.password) 
                };

                //CREA OBJETO TURNO
                WEB_HIS newTurno = new WEB_HIS();

                //DATOS DEL USUARIO CONECTADO
                var cookieUser = HttpContext.Current.Request.Cookies["User"];

                //BUSCA EL WEBHIS A TRAVES DE LA ID
                var webhis = ent.WEB_HIS.Where(x => x.SYS_215 == msgId).FirstOrDefault();

                //RECOGE EL INDEX DONDE EMPIEZA EL CHAR DE LAS OBSERVACIONES ":" 
                int startIndex = webhis.DADES.IndexOf(":");

                //RECOGE LA CANTIDAD DE CHARS QUE HAY DESDE EL INDEX HASTA LA MARCA "."
                int length = webhis.DADES.IndexOf(".", startIndex) - startIndex;

                //FINALMENTE TROCEA LA STRING PARA RECOGER EL VALOR DE LAS OBS
                string output = webhis.DADES.Substring(startIndex, length).Trim();

                //RECOGE EL TRABAJADOR 1
                var emisor = ent.TRB.Where(x => x.CODI_TRB == webhis.CODI_USU).FirstOrDefault();

                //RECOGE EL TRABAJADOR 2
                var destinatario = ent.TRB.Where(x => x.CODI_TRB == webhis.CODI_TRB_DESTI).FirstOrDefault();
                
                MailAddress to1 = new MailAddress(emisor.E_MAIL, emisor.NOM.TrimEnd());
                
                MailAddress to2 = new MailAddress(destinatario.E_MAIL, destinatario.NOM.TrimEnd());

                if (emisor == null || destinatario == null){
                    mail.To.Add(toD);
                    mail.Body = "Se ha dado el caso de que uno de los TRB es NULL";
                    mail.Subject = "ERROR GAMINTRA";
                    client.Send(mail);
                }else if (string.IsNullOrWhiteSpace(emisor.E_MAIL) || string.IsNullOrWhiteSpace(destinatario.E_MAIL)){
                    mail.To.Add(toD);
                    mail.Body = "En este TRB (" + emisor.CODI_TRB + ") o en estre otro (" + destinatario.CODI_TRB + ") falta el E_MAIL";
                    mail.Subject = "ERROR GAMINTRA";
                    client.Send(mail);
                }

                switch (webhis.ACCIO)
                {
                    case "CANVI_TORN_PEN":
                        mail.To.Add(to1);
                        mail.To.Add(to2);
                        mail.Body = "El usuario <strong>" + emisor.NOM.TrimEnd() + "</strong> ha solicitado un cambio de turno a <strong>" + destinatario.NOM.TrimEnd() + "</strong><br/>Fecha de la Solicitud: <strong>" + webhis.DATA_ALTA + "</strong> <br/>Fecha de Retorno: <strong>" + webhis.DATA_PETICIO + "</strong><br/> Observaciones" + output + " <br/> Por favor visita <a href='" + sett.url + "'>GamIntra</a>";
                        mail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
                        mail.BodyTransferEncoding = System.Net.Mime.TransferEncoding.EightBit;
                        mail.Subject = emisor.NOM.TrimEnd() + " - Ha solicitado un cambio de turno.";
                        mail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");

                        client.Send(mail); //se envia el correo
                        break;
                    case "CANVI_TORN_CAN":
                        mail.To.Add(to1);
                        mail.To.Add(to2);
                        mail.Body = "El usuario <strong>" + destinatario.NOM.TrimEnd() + "</strong> ha cancelado el cambio de turno de <strong>" + emisor.NOM.TrimEnd() + "</strong><br/>Fecha de la Solicitud: <strong>" + webhis.DATA_ALTA + "</strong> <br/>Fecha de Retorno: <strong>" + webhis.DATA_PETICIO + "</strong>";
                        mail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
                        mail.Subject = destinatario.NOM.TrimEnd() + " - Ha cancelado el cambio de turno.";
                        mail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
                        client.Send(mail); //se envia el correo
                        break;
                    case "CANVI_TORN_ACE":
                        var qua = ent.QUA.Where(x => x.CODI_TRB == destinatario.CODI_TRB).ToList().LastOrDefault();
                        var qua2 = ent.QUA.Where(x => x.CODI_TRB == emisor.CODI_TRB).ToList().LastOrDefault();

                        if (qua != null || qua2 != null)
                        {

                            if (!string.IsNullOrWhiteSpace(qua.CODI_BAS) || !string.IsNullOrWhiteSpace(qua2.CODI_BAS))
                            {

                                if (!string.IsNullOrWhiteSpace(qua.CODI_RCU) || !string.IsNullOrWhiteSpace(qua2.CODI_RCU))
                                {

                                    var rcu = ent.RCU.Where(x => x.CODI_RCU == qua.CODI_RCU).FirstOrDefault();
                                    var rcu2 = ent.RCU.Where(x => x.CODI_RCU == qua2.CODI_RCU).FirstOrDefault();

                                    if (rcu != null || rcu2 != null)
                                    {

                                        if (!string.IsNullOrWhiteSpace(rcu.CODI_BAS) || !string.IsNullOrWhiteSpace(rcu2.CODI_BAS))
                                        {

                                            if (!string.IsNullOrWhiteSpace(rcu.CODI_RCU) || !string.IsNullOrWhiteSpace(rcu2.CODI_RCU))
                                            {
                                                var bas = ent.BAS.Where(x => x.CODI_BAS == rcu.CODI_BAS).FirstOrDefault();
                                                var bas2 = ent.BAS.Where(x => x.CODI_BAS == rcu2.CODI_BAS).FirstOrDefault();

                                                if (bas != null || bas2 != null)
                                                {

                                                    if (!string.IsNullOrWhiteSpace(bas.CODI_BAS) || !string.IsNullOrWhiteSpace(bas2.CODI_BAS))
                                                    {

                                                        if (!string.IsNullOrWhiteSpace(bas.E_MAIL) || !string.IsNullOrWhiteSpace(bas2.E_MAIL))
                                                        {

                                                            MailAddress to3 = new MailAddress(bas.E_MAIL, bas.DES.TrimEnd()); //RRHH del DESTINATARIO
                                                            MailAddress to4 = new MailAddress(bas2.E_MAIL, bas2.DES.TrimEnd()); //RRHH del EMISOR

                                                            mail.To.Add(to1);
                                                            mail.To.Add(to2);
                                                            mail.To.Add(to3);
                                                            mail.To.Add(to4);

                                                            mail.Body = "El usuario <strong>" + destinatario.NOM.TrimEnd() + "</strong> ha aceptado el cambio de turno de <strong>" + emisor.NOM.TrimEnd() + "</strong>. <br/>Fecha de la Solicitud: <strong>" + webhis.DATA_ALTA + "</strong> <br/>Fecha de Retorno: <strong>" + webhis.DATA_PETICIO + "</strong><br/> Observaciones" + output + " <br/> Por favor visita <a href='"+ sett.url +"'>GamIntra</a>";
                                                            mail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
                                                            //mail.BodyTransferEncoding = System.Net.Mime.TransferEncoding.EightBit;
                                                            mail.Subject = destinatario.NOM.TrimEnd() + " - Ha aceptado el cambio de turno.";
                                                            mail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
                                                            client.Send(mail); //se envia el correo

                                                        } else { //FALTA UN BAS.E_MAIL
                                                            mail.To.Add(toD);
                                                            mail.Body = "En este BAS (" + bas.CODI_BAS + ") o en estre otro (" + bas2.CODI_BAS + ") falta el EMAIL ";
                                                            mail.Subject = "ERROR GAMINTRA";
                                                            client.Send(mail); }

                                                    } else { //FALTA UN BAS.CODI_BAS
                                                        mail.To.Add(toD);
                                                        mail.Body = "En este BAS (" + bas.DES + ") o en estre otro (" + bas2.DES + ") falta el CODI_BAS ";
                                                        mail.Subject = "ERROR GAMINTRA";
                                                        client.Send(mail); }

                                                } else { //UN BAS ES NULL
                                                    mail.To.Add(toD);
                                                    mail.Body = "Se ha dado la ocasión de que un BAS es NULL";
                                                    mail.Subject = "ERROR GAMINTRA";
                                                    client.Send(mail); }
                                                
                                            } else { //UN RCU.CODI_RCU ES NULL O NO TIENE VALOR
                                                mail.To.Add(toD);
                                                mail.Body = "En este RCU (" + rcu.DES + ") o en estre otro (" + rcu2.DES + ") falta el CODI_RCU";
                                                mail.Subject = "ERROR GAMINTRA";
                                                client.Send(mail); }

                                        } else { //UN RCU.CODI_BAS ES NULL O NO TIENE VALOR
                                            mail.To.Add(toD);
                                            mail.Body = "En este RCU (" + rcu.DES + ") o en estre otro (" + rcu2.DES + ") falta el CODI_BAS";
                                            mail.Subject = "ERROR GAMINTRA";
                                            client.Send(mail); }

                                    } else { //UN BAS ES NULL
                                        mail.To.Add(toD);
                                        mail.Body = "Se ha dado la ocasión de que un RCU es NULL";
                                        mail.Subject = "ERROR GAMINTRA";
                                        client.Send(mail); }

                                } else { //UN QUA.CODI_RCU ES NULL O NO TIENE VALOR
                                    mail.To.Add(toD);
                                    mail.Body = "En este QUA id(" + qua.SYS_215 + ") o en estre otro id2(" + qua2.SYS_215 + ") falta el CODI_RCU";
                                    mail.Subject = "ERROR GAMINTRA";
                                    client.Send(mail); }

                            } else { //UN QUA.CODI_BAS ES NULL O NO TIENE VALOR
                                mail.To.Add(toD);
                                mail.Body = "En este QUA id(" + qua.SYS_215 + ") o en estre otro id2(" + qua2.SYS_215 + ") falta el CODI_BAS";
                                mail.Subject = "ERROR GAMINTRA";
                                //client.Send(mail); 
                            }

                        } else { //UN QUA ES NULL
                            mail.To.Add(toD);
                            mail.Body = "Se ha dado la ocasión de que un QUA es NULL";
                            mail.Subject = "ERROR GAMINTRA";
                            client.Send(mail); }
                        
                        break;

                } //SE CIERRA EL SWITCH

                mail.Dispose(); //se limpia la var mail
                client.Dispose(); //se limpia la var client
            }
        }
    }
}