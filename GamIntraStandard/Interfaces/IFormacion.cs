using GamIntraStandard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamIntraStandard.Common;

namespace GamIntraStandard.Interfaces
{
    interface IFormacion
    {
        List<TRB_FOR> GetUserFor(string date);

        List<FOM> GetFormacion();

        FOM GetCursoInfo(string id);

        List<Archivos> GetDescargas();

    }
}
