using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamIntraStandard.Common
{
    public class Buzon
    {
        public string UsuarioDestino { get; set; }

        public string Asunto { get; set; }

        public string Mensaje { get; set; }

        public DateTime Fecha { get; set; }

        public DateTime Visto { get; set; }

        public string UsuarioOrigen { get; set; }
    }
}