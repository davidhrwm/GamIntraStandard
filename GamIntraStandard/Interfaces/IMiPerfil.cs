using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamIntraStandard.Models;
using GamIntraStandard.Common;
using System.Web.Mvc;

namespace GamIntraStandard.Interfaces
{
    interface IMiPerfil
    {
        TRB RecogerDatos();
       
        void CambiarContrasenya(CambioPass data);

        bool CambiarDatos(string texto);

        List<Archivos> Nomina(string year);

        string GetM145();

        List<Archivos> DocumentosGenerales();
    }
}
