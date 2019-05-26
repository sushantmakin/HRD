using System.Web.Optimization;

namespace HitaRasDhara
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            //Create bundel for jQueryUI  
            //js  
            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new StyleBundle("~/bundles/ResourceCss").Include(
            "~/Resources/fonts/icomoon/style.css",
            "~/Resources/css/bootstrap.min.css",
            "~/Resources/css/magnific-popup.css",
            "~/Resources/css/jquery-ui.css",
            "~/Resources/css/owl.carousel.min.css",
            "~/Resources/css/owl.theme.default.min.css",
            "~/Resources/css/bootstrap-datepicker.css",
            "~/Resources/fonts/flaticon/font/flaticon.css",
            "~/Content/MyCss.css",
            "~/Content/intlTelInput.css",
            "~/Resources/css/font-awesome.min.css",
            "~/Resources/css/aos.css",
            "~/Resources/css/style.css"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/sweetalert.js",
                      "~/Scripts/Myjs.js",
                      "~/Scripts/FileSaver.min.js",
                      "~/Scripts/jquery.binarytransport.js",
                      "~/Scripts/respond.js",
                      "~/js/jquery.dropdownPlain.js"));

            bundles.Add(new StyleBundle("~/Upcoming/resourcesUi").Include(
                "~/Resources/css/upcoming/normalize.css",
                "~/Resources/css/upcoming/geo_search.css",
                "~/Resources/css/upcoming/font-awesome.min.css",
                "~/Resources/css/upcoming/jquery.sidr.light.css",
                "~/Resources/css/upcoming/search_course.css",
                "~/Resources/css/upcoming/normalize-unity2.css",
                "~/Resources/css/upcoming/responsive-sidebars-unity2.css"));
        }
    }
}
