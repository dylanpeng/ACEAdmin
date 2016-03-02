using System.Web;
using System.Web.Optimization;

namespace Pengdylan.ACE
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            #region assets(ACE)
            bundles.Add(new StyleBundle("~/assets/css").Include(
                      "~/assets/css/bootstrap.min.css",
                      "~/assets/css/font-awesome.min.css",
                      "~/assets/css/ace.min.css",
                      "~/assets/css/ace-rtl.min.css",
                      "~/assets/css/ace-skins.min.css"
                      ));

            bundles.Add(new ScriptBundle("~/assets/JS").Include(
                      "~/assets/js/bootstrap.min.js",
                      "~/assets/js/typeahead-bs2.min.js",
                      "~/assets/js/jquery-ui-1.10.3.custom.min.js",
                      "~/assets/js/jquery.ui.touch-punch.min.js",
                      "~/assets/js/jquery.slimscroll.min.js",
                      "~/assets/js/jquery.easy-pie-chart.min.js",
                      "~/assets/js/jquery.sparkline.min.js",
                      "~/assets/js/flot/jquery.flot.min.js",
                      "~/assets/js/flot/jquery.flot.pie.min.js",
                      "~/assets/js/flot/jquery.flot.resize.min.js",
                      "~/assets/js/ace-elements.min.js",
                      "~/assets/js/ace.min.js"));

            #endregion
        }
    }
}
