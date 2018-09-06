using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamIntraStandard.Interfaces;
using GamIntraStandard.Clases;
using GamIntraStandard.Models;
using GamIntraStandard.Common;

namespace GamIntraStandard.Interfaces
{
    interface IJornada
    {
        List<HorarioJornada> HorarioQua(int Month, int Year);

        InfoHorarioJornada HorariosCalendario(string dia);

        int CambiarTurno(CambioTurno turno);

        QUA AddHoraExtra(string date);
    }
}
