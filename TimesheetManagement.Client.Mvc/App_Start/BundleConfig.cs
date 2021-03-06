﻿using System.Web.Optimization;

namespace TimesheetManagement.Client.Mvc
{
	public class BundleConfig
	{
		// For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
				"~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery-ui-{version}.js",
                "~/Scripts/jquery.blockUI.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
				"~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/timesheets").Include(
                "~/Scripts/jquery.unobtrusive-ajax.js",
                "~/Scripts/utility.js",
                "~/Scripts/timesheets.js"));

            bundles.Add(new ScriptBundle("~/bundles/tasks").Include(
                "~/Scripts/tasks.js"));

            bundles.Add(new ScriptBundle("~/bundles/taskactivity").Include(
                "~/Scripts/taskactivity.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
				"~/Scripts/modernizr-*"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
				"~/Scripts/bootstrap.js",
				"~/Scripts/respond.js"));

			bundles.Add(new StyleBundle("~/Content/css").Include(
				"~/Content/bootstrap.css",
				"~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                "~/Content/themes/base/base.css"));

            bundles.Add(new StyleBundle("~/Content/tasks").Include(
                "~/Content/tasks.css"));
        }
	}
}
