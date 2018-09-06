using System.Web;
using System.Web.Optimization;

namespace GamIntraStandard
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {


            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            //preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                     "~/assets/js/velocity.min.js",
                     "~/assets/js/main.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/assets/bootstrap/css/bootstrap.css",
                   "~/assets/style.css"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/assets/js/jquery.min.js"));

            bundles.Add(new StyleBundle("~/Content/fullcalendarcss").Include(
              "~/Content/themes/jquery.ui.all.css",
              "~/Content/fullcalendar.css"));

            bundles.Add(new ScriptBundle("~/bundles/fullcalendarjs").Include(
                "~/Scripts/jquery-ui-{version}.min.js",
                "~/Scripts/moment.min.js",
               
                "~/Scripts/fullcalendar.min.js"));




        }
    }
}
