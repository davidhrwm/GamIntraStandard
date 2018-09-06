using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamIntraStandard.Common
{
    public class HorasExtras
    {

        public DateTime? InicioOriginal { get; set; }

        public DateTime? InicioReal { get; set; }

        public DateTime? FinalOriginal { get; set; }

        public DateTime? FinalReal { get; set; }

        public string Observaciones { get; set; }

        public TimeSpan? HExtra { get; set; }


    }
}