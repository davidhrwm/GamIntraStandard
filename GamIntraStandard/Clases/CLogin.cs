using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GamIntraStandard.Interfaces;
using GamIntraStandard.Models;


namespace GamIntraStandard.Clases
{
    public class CLogin : ILogin
    {
        public bool VerifyLogin(string usuario, string passwd)
        {
            bool verificacion = false;

            using (var ent = new gamEntities1())
            {
                var result = ent.TRB.Where(x => x.CODI_TRB == usuario && x.PWD == passwd).FirstOrDefault();

                if (result == null)
                {
                    verificacion = false;
                }
                else
                {
                    verificacion = true;
                }
            }

            return verificacion;
        }
        public void SetCookie(string userName)
        {
            HttpCookie galleta = new HttpCookie("User");
            galleta.Expires.AddMonths(12);
            galleta.Value = userName;
            HttpContext.Current.Response.Cookies.Set(galleta);
        }
    }
}