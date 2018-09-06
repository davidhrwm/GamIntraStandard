using GamIntraStandard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GamIntraStandard.Interfaces;
using GamIntraStandard.Clases;
using GamIntraStandard.Common;

namespace GamIntraStandard.Interfaces
{
    interface IHome
    {
        List<INF_TRB> GetBuzon();

        List<TRB> GetAllUsers();

        void EnviarMensaje(MensajeTrabajadores msg);

        bool CambiarDatos(MensajeTrabajadores msg);

        void MarcarLeido(string id);
    }
}