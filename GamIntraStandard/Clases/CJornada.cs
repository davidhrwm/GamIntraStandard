using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GamIntraStandard.Interfaces;
using GamIntraStandard.Clases;
using GamIntraStandard.Models;
using GamIntraStandard.Common;
using System.Net.Mail;
using System.Net;
using GamIntraStandard.Properties;
using System.Drawing;
using System.Globalization;

namespace GamIntraStandard.Clases
{
    public class CJornada : IJornada //IMPLEMENTACION DE UNTERFAZ
    {
        private IQueryable<QUA> _horarios;
        private QUA _data;
        private InfoHorarioJornada _info;

        public List<HorarioJornada> HorarioQua(int Month, int Year)
        {
            //Month contiene el mes actual, se le suma 1 porque va de 0 a 11 meses.
            Month = Month + 1;

            List<HorarioJornada> lista = new List<HorarioJornada>();

            using (var ent = new gamEntities1())
            {
                var cookieUser = HttpContext.Current.Request.Cookies["User"];

                _horarios = ent.QUA.Where(x => x.CODI_TRB == cookieUser.Value && x.DATA_INICI.Value.Month == Month && x.DATA_INICI.Value.Year == Year); //CARGA SOLO EL MES

                foreach (var item in _horarios)
                {
                    HorarioJornada qua = new HorarioJornada();

                    //var decimalNumber = string.Format("#{0:X6}", Convert.ToInt32(ent.TJO.First(x => x.CODI_TJO == item.CODI_TJO).COLOR));
                    //int number = int.Parse(decimalNumber);
                    //string hex = number.ToString("x");
                    //var color = hex.ToString();

                    var decimalNumber = 16711680;

                    qua.color = "rgb(" + 255 + "," + 0 + "," + 0 + ")";
                    try
                    {
                        decimalNumber = Convert.ToInt32(ent.TJO.First(x => x.CODI_TJO == item.CODI_TJO).COLOR);
                        
                        var R = decimalNumber % 256;
                        var num2 = decimalNumber / 256;
                        var G = num2 % 256;
                        var num3 = num2 / 256;
                        var B = num3 % 256;
                        qua.color = "rgb(" + R + "," + G + "," + B + ")";

                    }
                    catch(Exception Ex)
                    {
                        throw;
                    }

                    //myRgbColor = Color.FromArgb(R, G, B);

                    //byte[] bytes = BitConverter.GetBytes(Convert.ToInt32(decimalNumber));
                    //System.Drawing.Color color = System.Drawing.Color.FromArgb(Convert.ToInt32(decimalNumber));//bytes[2], bytes[1], bytes[0]);
                    //"rgb(155, 102, 102)";//R+","+G+","+B/*"#" + myRgbColor*/;
                    //qua.color = "rgb(color.R,color.G,color.B)";
                    //qua.color = "#" + color.R.ToString("x") + color.G.ToString("x") + color.B.ToString("x");
                    //qua.color = "#" + decimalNumber;


                    //VUELVE A RECOGER LA DES correcta PORQUE EL GAM CUANDO HACEN CAMBIOS NE EL QUA, CAMBIA EL CODI_TJO PERO LA DES NO CAMBIA
                    var realDesTjo = ent.TJO.Where(x => x.CODI_TJO == item.CODI_TJO).Select(x => x.DES).FirstOrDefault();

                    qua.sys_215 = item.SYS_215 == null ? "" : item.SYS_215;
                    qua.CODI_TJO = item.CODI_TJO == null ? "" : item.CODI_TJO;
                    qua.codi_trb = item.CODI_TRB == null ? "" : item.CODI_TRB;
                    qua.data_inici = item.DATA_INICI == null ? "" : item.DATA_INICI.Value.Date.ToString("M/d/yyyy");
                    qua.data_final = item.DATA_FINAL == null ? "" : item.DATA_FINAL.ToString();
                    qua.des_tjo = realDesTjo == null ? "" : realDesTjo; //TJO => Tipos de Jornada
                    qua.CODI_TJO = item.CODI_TJO == null ? "" : item.CODI_TJO;
                    qua.DATA_INICI_REAL = item.DATA_INICI_REAL == null ? "" : item.DATA_INICI_REAL.ToString();
                    qua.DATA_FINAL_REAL = item.DATA_FINAL_REAL == null ? "" : item.DATA_FINAL_REAL.ToString();
                    qua.data_inici_original = item.DATA_INICI_ORIGINAL == null ? "" : item.DATA_INICI_ORIGINAL.ToString();
                    qua.data_final_original = item.DATA_FINAL_ORIGINAL == null ? "" : item.DATA_FINAL_ORIGINAL.ToString();

                    lista.Add(qua);
                }
            }

            return lista;

        }

        public InfoHorarioJornada HorariosCalendario(string dia)
        {
            var cookieUser = HttpContext.Current.Request.Cookies["User"];

            _info = new InfoHorarioJornada();

            using (var ent = new gamEntities1())
            {

                _data = ent.QUA.Where(x => x.SYS_215 == dia && x.CODI_TRB == cookieUser.Value).FirstOrDefault();

                if (_data != null)
                {

                    /*"d/M/yyyy HH:mm"*/

                    var ci = CultureInfo.InvariantCulture;

                    _info.data_inici_original = _data.DATA_INICI == null ? "" : _data.DATA_INICI.Value.ToString("d/M/yyyy HH:mm");
                    _info.data_final_original = _data.DATA_FINAL == null ? "" : _data.DATA_FINAL.Value.ToString("d/M/yyyy HH:mm");
                    _info.DATA_INICI_REAL = _data.DATA_FINAL_REAL == null ? "Sin Datos" : _data.DATA_INICI_REAL.Value.ToString("d/M/yyyy HH:mm", ci);
                    _info.DATA_FINAL_REAL = _data.DATA_INICI_REAL == null ? "Sin Datos" : _data.DATA_FINAL_REAL.Value.ToString("d/M/yyyy HH:mm", ci);

                }
            }


           
            return _info;
        }

        public int CambiarTurno(CambioTurno turno)
        {
            var cookieUser = HttpContext.Current.Request.Cookies["User"]; //Usuario conectado

            using (var ent = new gamEntities1())
            {
                int msgId; //se inicializa la variable para luego guardar la ID
                var nombre = ent.TRB.Where(x => x.CODI_TRB == cookieUser.Value).FirstOrDefault();
                
                try
                {
                    WEB_HIS newTurno = new WEB_HIS();

                    newTurno.CODI_USU = cookieUser.Value; //El codigo de usuario
                    newTurno.ACCIO = "CANVI_TORN_PEN"; //El estado es PENDIENTE
                    newTurno.DADES = "El usuario " + nombre.NOM.TrimEnd() + " solicita un cambio de turno, Observaciones: " + turno.obs + ".";
                    int caca = newTurno.DADES.Length;
                    newTurno.DATA_ALTA = turno.diaAfectat.Date; //añade la fecha de alta del cambio de turno
                    newTurno.DATA_PETICIO = turno.diaSubs.Date; //añade la fecha de peticion del cambio de turno
                    newTurno.APP = "GAMINTRA";
                    newTurno.CODI_TRB_DESTI = turno.codiTrb;
                    ent.WEB_HIS.Add(newTurno);
                    ent.SaveChanges(); //Actualiza en la BD
                    msgId = newTurno.SYS_215;

                    return msgId;

                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    var ie = ex.InnerException;
                    throw new Exception(ex.Message, ex.InnerException);
                }
            }
        }

        public QUA AddHoraExtra(string date)
        {
            var cookieUser = HttpContext.Current.Request.Cookies["User"];

            try {

                using (var ent = new gamEntities1())
                {    
                    var extraDay =  Convert.ToDateTime(date);

                    if (extraDay != null)
                    {
                        _data = ent.QUA.Where(x => x.DATA_INICI.Value.Day == extraDay.Day && x.DATA_INICI.Value.Month == extraDay.Month && x.DATA_INICI.Value.Year == extraDay.Year &&  x.CODI_TRB == cookieUser.Value).FirstOrDefault();
                    }
                }

            } catch {

            }

            return _data;
        }
    }
}