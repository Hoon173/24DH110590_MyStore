using System.Web;
using System.Web.Optimization;

namespace _24DH110590_MyStore
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));  // jQuery - phải có file này từ NuGet

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            // Use non-minified bootstrap bundle so the ASP.NET bundler/minifier doesn't re-parse a .min.js it can't handle
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.bundle.js"));  // Use bootstrap.bundle.js (not bootstrap.bundle.min.js)

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/bootstrap.min.css",  // BS5 CSS
                        "~/Content/site.css"));
        }
    }
}