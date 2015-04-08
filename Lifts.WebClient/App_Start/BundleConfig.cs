using System.Web;
using System.Web.Optimization;

namespace Lifts.WebClient
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/genius_v_1_0_4_html/assets/js/jquery-2.1.0.min.js",
                        "~/Content/genius_v_1_0_4_html/assets/js/jquery-ui-1.10.3.custom.min.js",
                        "~/Content/genius_v_1_0_4_html/assets/js/jquery.sparkline.min.js",
                        "~/Content/genius_v_1_0_4_html/assets/js/jquery.chosen.min.js",
                        "~/Content/genius_v_1_0_4_html/assets/js/jquery.cleditor.min.js",
                        "~/Content/genius_v_1_0_4_html/assets/js/jquery.autosize.min.js",
                        "~/Content/genius_v_1_0_4_html/assets/js/jquery.placeholder.min.js",
                        "~/Content/genius_v_1_0_4_html/assets/js/jquery.maskedinput.min.js",
                        "~/Content/genius_v_1_0_4_html/assets/js/jquery.inputlimiter.1.3.1.min.js",
                        "~/Content/genius_v_1_0_4_html/assets/js/bootstrap-datepicker.min.js",
                        "~/Content/genius_v_1_0_4_html/assets/js/bootstrap-timepicker.min.js",
                        "~/Content/genius_v_1_0_4_html/assets/js/daterangepicker.min.js",
                        "~/Content/genius_v_1_0_4_html/assets/js/jquery.hotkeys.min.js"));

                          bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                        "~/Scripts/knockout-*",
                        "~/Scripts/knockout.mapping-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/genius_v_1_0_4_html/assets/js/bootstrap.js",
                      "~/Content/genius_v_1_0_4_html/assets/js/bootstrap-datepicker.min.js",
                      //"~/Content/genius_v_1_0_4_html/assets/js/core.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/genius_v_1_0_4_html/assets/css/bootstrap.css",
                      "~/Content/genius_v_1_0_4_html/assets/css/style.css",
                      "~/Content/site.css"));
        }
    }
}
