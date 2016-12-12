using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace BookATableMVC.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = true;
            bundles.Add(new StyleBundle("~/Content/book-a-table-style")
                .Include("~/Content/bootstrap.css")
               .Include(
                                "~/Content/jquery.datetimepicker.css")
                .Include("~/Content/bootstrap-theme.css"));

            bundles.Add(new ScriptBundle("~/Scripts/book-a-table-script")
                .Include("~/Scripts/jquery-3.1.1.js")
                .Include("~/Scripts/bootstrap.js")
                .Include("~/Scripts/jquery.validate.js")
                .Include(
                        "~/Scripts/jquery.datetimepicker.full.min.js")
                .Include(
                                "~/Scripts/DateTimePicker.js")
                .Include("~/Scripts/jquery-ui-1.12.1.js"));
        }
    }
}