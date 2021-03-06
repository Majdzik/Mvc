﻿using System.Web;
using System.Web.Optimization;

namespace MajdzikMvc
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"
            //          //,"~/Scripts/respond.js"
            //          ));
            bundles.Add(new StyleBundle("~/Content/bootstrap", "//cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.4/css/bootstrap.min.css").Include("~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/s/a", "//cdnjs.cloudflare.com/ajax/libs/angular.js/1.3.15/angular.js").Include("~/Scripts/angular.js", "~/Scripts/angular-mocks.js"));

            bundles.Add(new ScriptBundle("~/bundles/s/ui", "//cdnjs.cloudflare.com/ajax/libs/angular-ui-bootstrap/0.12.1/ui-bootstrap.js").Include("~/Scripts/angular-ui/ui-bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/s/tp", "//cdnjs.cloudflare.com/ajax/libs/angular-ui-bootstrap/0.12.1/ui-bootstrap-tpls.js").Include("~/Scripts/angular-ui/ui-bootstrap-tpls.js"));

            bundles.Add(new ScriptBundle("~/bundles/s").Include("~/Scripts/main.js"));

        }
    }
}
