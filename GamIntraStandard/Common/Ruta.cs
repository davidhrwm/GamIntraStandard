using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamIntraStandard.Common
{
    public class Ruta
    {
        private static GamIntraStandard.Properties.Settings _route;
        
        public static string Path()
        {
            _route = new Properties.Settings();
            return _route.ruta + "Gamintra/";           
        }
        
    }
}