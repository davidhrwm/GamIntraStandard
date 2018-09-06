using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamIntraCustomerVerification.Module
{
    public class Verification
    {
        /*Datos GENERALES*/

        public int CodigoEmpresa = 0;
        public string NombreEmpresa = "Trial GamIntra Original Soft";
        public string Color1 = "#FFFFFF";
        public string Color2 = "#FFFFFF";

        /*Menu Principal*/

        public bool MenuHome = false;
        public bool MenuJornada = false;
        public bool MenuFormacion = false;
        public bool MenuPerfil = false;
        public bool MenuDocumentos = false;


        /*SubMenu*/

        public bool SubJornadaCalendarioLaboral = true;
        public bool SubJornadaHorasExtras = true;
        public bool SubJornadaCambioTurno = true;

        public bool SubFormacionMisCursos = true;
        public bool SubFormacionProximosCursos = true;

        public bool SubPerfilMisDocumentos = false;

        /*Auth Controller NO IMPLEMENTADO ACTUALMENTE*/ 

        public bool AuthHome = false;
        public bool AuthJornada = false;
        public bool AuthFormacion = false;
        public bool AuthPerfil = false;

    }
}
