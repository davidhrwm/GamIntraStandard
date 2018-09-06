using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamIntraCustomerVerification
{
    public class Clients
    {
        private List<string> items;
        private List<string> subItems;
        private bool datosPersonales;

        public Module.Verification MainVerification(int cliente)
        {
            var _ = new Module.Verification();

            if (cliente == 91) { //EL 91 ES IVEMON

                _.CodigoEmpresa = 0;
                _.NombreEmpresa = "Ivemon";
                _.Color1 = "#FFFFFF";
                _.Color2 = "#FFFFFF";

                _.MenuJornada = true;
                _.MenuHome = true;
                _.SubJornadaCalendarioLaboral = true;
                _.SubJornadaCambioTurno = true;
                _.SubJornadaHorasExtras = false;

                _.AuthJornada = true;
            }
            if (cliente == 12) //EL 12 ES TOMAS
            {
                _.CodigoEmpresa = 12;
                _.NombreEmpresa = "Tomas";
                _.Color1 = "#FFFFFF";
                _.Color2 = "#FFFFFF";

                _.MenuHome = true;
                _.MenuJornada = true;
                _.MenuFormacion = true;
                _.MenuPerfil = true;
                _.MenuDocumentos = true;

                _.SubJornadaCalendarioLaboral = true;
                _.SubJornadaCambioTurno = true;
                _.SubJornadaHorasExtras = false;
                _.SubPerfilMisDocumentos = true;

                _.SubFormacionMisCursos = true;
                _.SubFormacionProximosCursos = true;

                _.AuthJornada = true;
            }
            if (cliente == 2) //Cliente OriginalSoft
            {
                _.CodigoEmpresa = 0;
                _.NombreEmpresa = "Demo Roma";
                _.Color1 = "#FFFFFF";
                _.Color2 = "#FFFFFF";

                _.MenuHome = true;
                _.MenuJornada = true;        
                _.MenuFormacion = true;
                _.MenuPerfil = true;
                _.MenuDocumentos = true;

                _.SubJornadaCalendarioLaboral = true;
                _.SubJornadaCambioTurno = true;
                _.SubJornadaHorasExtras = true;
                _.SubPerfilMisDocumentos = true;

                _.SubFormacionMisCursos = true;
                _.SubFormacionProximosCursos = true;

                _.AuthJornada = true;
            }
            if(cliente == 95) //EL 95 CUENCUA
            {
                _.CodigoEmpresa = 95;
                _.NombreEmpresa = "Demo Cuenca";
                _.Color1 = "#FFFFFF";
                _.Color2 = "#FFFFFF";

                _.MenuHome = true;
                _.MenuJornada = true;
                _.MenuFormacion = true;
                _.MenuPerfil = true;
                _.MenuDocumentos = true;

                _.SubJornadaCalendarioLaboral = true;
                _.SubJornadaCambioTurno = true;
                _.SubJornadaHorasExtras = true;
                _.SubPerfilMisDocumentos = true;

                _.SubFormacionMisCursos = true;
                _.SubFormacionProximosCursos = true;

                _.AuthJornada = true;
            }
            return _;
        }

#region OLd 


        public List<string> ConfigurationMenu(int ClientCode)
        {         
            switch (ClientCode) {

                case 91:

                    items = new List<string>
                    {
                         "Jornada",
                    };
                    break;

                case 95:

                    items = new List<string>
                    {
                        "Home", "Jornada" ,  "Formacion"
                    };
                    break;

                default:
                    items = new List<string>
                    {
                        "Home", "Jornada" ,  "Formacion"
                    };

                    break;

            }

            return items;
        }

        public List<string> ConfigurationJornada(int ClientCode) {

            switch (ClientCode)
            {
                case 91:

                    subItems = new List<string>
                    {
                        "Calendario Laboral", "Cambio de Turno"
                    };
                    break;
                    
                case 95:
                    subItems = new List<string>
                    {
                        "Calendario Laboral","Horas Extras","Cambio de Turno"
                    };

                    break;

                default:
                    subItems = new List<string>
                    {
                        "Calendario Laboral","Horas Extras","Cambio de Turno"
                    };

                    break;
            }

            return subItems;
        }

        public bool ConfigurationPersonal(int ClientCode) {

            switch (ClientCode)
            {
                case 91:

                    datosPersonales = false;
                    break;

                case 95:

                    datosPersonales = true;
                    break;

                default:
                    datosPersonales = true;
                    break;
            }

            return datosPersonales;
        }

        //METODO PARA PERSONALIZACION DE GAMINTRA
        public string[] ConfigClients(int ClientCode) {

            string[] itemMenu = null;

            switch (ClientCode)
            {
                case 91:
                    itemMenu = new string[] { "#39445C", "#D0D1D3" };
                   
                    break;

                case 95:
                    itemMenu = new string[] { "#39445C", "#D0D1D3" };

                    break;

                default:
                    itemMenu = new string[] { "#ffffff", "#98cbdf" };    
                    break;

            }

            return itemMenu;
        }

        public bool AuthController(int ClientCode, string Controller)
        {

            switch (ClientCode)
            {

                case 91:

                    switch (Controller)
                    {

                        case "Jornada":
                            return true;                         
                        case "Home":
                            return false;                                                
                        case "VerDatosPersonales":
                            return false;                          
                    }

                    break;

                case 73:

                    break;


                case 95:

                    switch (Controller)
                    {
                        
                        case "Jornada":
                            return true;
                        case "Home":
                            return true;
                        case "VerDatosPersonales":
                            return true;
                    }

                    break;


                default:

                    switch (Controller)
                    {

                        case "Formacion":
                            return true;
                        case "Home":
                            return true;
                        case "Jornada":
                            return true;
                        case "MiPerfil":
                            return true;
                        case "Service":
                            return true;
                        case "Tramites":
                            return true;
                    }

                    break;
            }




            return false;
        }


#endregion

    }
}
