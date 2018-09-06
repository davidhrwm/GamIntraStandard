using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GamIntraStandard.Common
{
    public class CambioPass
    {
        [Required]
        public string NewPasswd { get; set; }

        [Required]
        public string RepetirPasswd { get; set; }
    }
}