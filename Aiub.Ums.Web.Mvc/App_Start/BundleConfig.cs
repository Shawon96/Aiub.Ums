using System.Web.Optimization;

namespace Aiub.Ums.Web.Mvc
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            ScriptBundle scripts = new ScriptBundle("~/UmsBundledScripts");
            scripts.Include("~/Scripts/jquery.js");
            scripts.Include("~/Scripts/jquery.dataTables.js");
            scripts.Include("~/Scripts/bootstrap.js");
            scripts.Include("~/Scripts/dataTables.bootstrap.js");
            scripts.Include("~/Scripts/jquery-ui.js");
            scripts.Include("~/Scripts/adminlte.js");
            bundles.Add(scripts);

            StyleBundle styles = new StyleBundle("~/UmsBundledStyles");
            styles.Include("~/Content/css/bootstrap.css");
            styles.Include("~/Content/css/dataTables.bootstrap.css");
            styles.Include("~/Content/css/font-awesome.css");
            styles.Include("~/Content/css/ionicons.css");
            styles.Include("~/Content/css/AdminLTE.css");
            styles.Include("~/Content/css/skin-blue.css");
            styles.Include("~/Content/css/jquery-ui.css");
            styles.Include("~/Content/css/Ums.css");
            styles.Include("~/Content/css/google-font.css");
            bundles.Add(styles);
        }
    }
}
