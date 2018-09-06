using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GamIntraStandard.Common
{
    public class CambioTurno
    {
        
        public string codiTrb { get; set; }

        public string usuario { get; set; }
    
        public IEnumerable<SelectListItem> usuario2 { get; set; }
      
        public string obs { get; set; }
    
        public DateTime diaAfectat { get; set; }

        public DateTime diaSubs { get; set; }
    }
}