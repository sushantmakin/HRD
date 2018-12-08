﻿using System.Web;
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
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/MyCss.css",
                      "~/Content/intlTelInput.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Sunil/css").Include(
                "~/Content/owl.carousel.css",
                "~/Content/meanmenu.min.css",
                "~/Content/font-awesome.min.css",
                "~/Content/icon.css",
                "~/Content/flaticon.css",
                "~/Content/magnific.min.css",
                "~/Content/venobox.css",
                "~/Content/icon.css",
                "~/Content/style2.css",
                "~/Content/owl.transitions"));

            bundles.Add(new StyleBundle("~/Upcoming/resourcesUi").Include(
               "~/css/upcoming/normalize.css",
                "~/css/upcoming/geo_search.css",
                "~/css/upcoming/font-awesome.min.css",
                "~/css/upcoming/jquery.sidr.light.css",
                "~/css/upcoming/search_course.css",
                "~/css/upcoming/normalize-unity2.css",
                "~/css/upcoming/responsive-sidebars-unity2.css"));

            bundles.Add(new StyleBundle("~/Upcoming/resourcesJs").Include(
                "~/js/Upcoming1.js",
                "~/js/Upcoming2.js",
                "~/js/Upcoming3.js",
                "~/js/Upcoming4.js"));
        }
    }
}
