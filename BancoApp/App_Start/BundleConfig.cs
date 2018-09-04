using System.Web;
using System.Web.Optimization;

namespace BancoApp
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Css").Include(
                        "~/Content/bootstrap/css/bootstrap.min.css",
                        "~/Content/dist/css/AdminLTE.min.css",
                        "~/Content/dist/css/skins/_all-skins.min.css")); 

            bundles.Add(new ScriptBundle("~/Js").Include(
                        "~/Content/plugins/jQuery/jquery-2.2.3.min.js",
                        "~/Content/bootstrap/js/bootstrap.min.js",
                        "~/Content/plugins/slimScroll/jquery.slimscroll.min.js",
                        "~/Content/plugins/fastclick/fastclick.js",
                        "~/Content/dist/js/app.min.js",
                        "~/Content/dist/js/demo.js"));

            BundleTable.EnableOptimizations = true;


            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            //// Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            //// para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));
        }
    }
}
