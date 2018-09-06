using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using GamIntraStandard.Clases;
using GamIntraStandard.Models;
namespace GamIntraStandard.Interfaces
{
    interface IService
    {

        List<INF_TRB> GetBuzon();

        List<INF> GetAvisos();

        INF_TRB GetMensaje(string id);

        void MarcarLeido(string id);

        List<INF_TRB> GetMensajeInterno();

        INF GetAvisoModal(string id);

        WEB_HIS GetCambioTurno();

        void AceptarCambioTurno(string id);

        void CancelarCambioTurno(string id);

        void EnviarCorreoEmail(int msgId);
    }
}
