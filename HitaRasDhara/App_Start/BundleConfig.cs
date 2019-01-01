using System.Web;
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

            //css  
            bundles.Add(new StyleBundle("~/Content/cssjqryUi").Include(
                "~/Content/jquery-ui.css"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/sweetalert.js",
                      "~/Scripts/Myjs.js",
                      "~/Scripts/FileSaver.min.js",
                      "~/Scripts/jquery.binarytransport.js",
                      "~/Scripts/respond.js",
                      "~/js/jquery.dropdownPlain.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/MyCss.css",
                      "~/Content/intlTelInput.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Sunil/css").Include(
                "~/css/owl.carousel.css",
                "~/css/meanmenu.min.css",
                "~/css/font-awesome.min.css",
                "~/css/icon.css",
                "~/css/flaticon.css",
                "~/css/magnific.min.css",
                "~/css/venobox.css",
                "~/css/owl.transitions",
                "~/style.css",
                "~/css/responsive.css"));

            bundles.Add(new StyleBundle("~/Upcoming/resourcesUi").Include(
               "~/css/upcoming/normalize.css",
                "~/css/upcoming/geo_search.css",
                "~/css/upcoming/font-awesome.min.css",
                "~/css/upcoming/jquery.sidr.light.css",
                "~/css/upcoming/search_course.css",
                "~/css/upcoming/normalize-unity2.css",
                "~/css/upcoming/responsive-sidebars-unity2.css"));

            bundles.Add(new ScriptBundle("~/Upcoming/resourcesJs").Include(
                "~/js/Upcoming1.js",
                "~/js/Upcoming2.js",
                "~/js/Upcoming3.js",
                "~/js/Upcoming4.js"));

            bundles.Add(new ScriptBundle("~/Lower/js").Include(
                "~/js/bootstrap.min.js",
                "~/js/owl.carousel.min.js",
                "~/js/jquery.counterup.min.js",
                "~/js/waypoints.js",
                "~/js/isotope.pkgd.min.js",
                "~/js/jquery.stellar.min.js",
                "~/js/magnific.min.js",
                "~/js/venobox.min.js",
                "~/js/jquery.meanmenu.js",
                "~/js/form-validator.min.js",
                "~/Scripts/intlTelInput.min.js",
                "~/js/plugins.js",
                "~/js/main.js"
                ));
        }
    }
}
