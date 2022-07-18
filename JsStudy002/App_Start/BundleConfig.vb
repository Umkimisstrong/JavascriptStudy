Imports System.Web
Imports System.Web.Optimization

Public Module BundleConfig
    ' 묶음에 대한 자세한 내용은 https://go.microsoft.com/fwlink/?LinkId=301862를 참조하세요.
    Public Sub RegisterBundles(bundles As BundleCollection)
        bundles.Add(New ScriptBundle("~/bundles/jquery").Include(
            "~/Scripts/jquery-{version}.js"))

        bundles.Add(New ScriptBundle("~/bundles/jqueryval").Include(
            "~/Scripts/jquery.unobtrusive*",
            "~/Scripts/jquery.validate*"))

        bundles.Add(New ScriptBundle("~/bundles/knockout").Include(
            "~/Scripts/knockout-{version}.js",
            "~/Scripts/knockout.validation.js"))

        bundles.Add(New ScriptBundle("~/bundles/app").Include(
            "~/Scripts/sammy-{version}.js",
            "~/Scripts/app/common.js",
            "~/Scripts/app/app.datamodel.js",
            "~/Scripts/app/app.viewmodel.js",
            "~/Scripts/app/home.viewmodel.js",
            "~/Scripts/app/_run.js"))

        ' Modernizr의 개발 버전을 사용하여 개발하고 배우십시오. 그런 다음
        ' 프로덕션에 사용할 준비를 하고 https://modernizr.com의 빌드 도구를 사용하여 필요한 테스트만 선택하세요.
        bundles.Add(New ScriptBundle("~/bundles/modernizr").Include(
            "~/Scripts/modernizr-*"))

        bundles.Add(New ScriptBundle("~/bundles/bootstrap").Include(
            "~/Scripts/bootstrap.js"))

        bundles.Add(New StyleBundle("~/Content/css").Include(
            "~/Content/bootstrap.css",
            "~/Content/Site.css"))
    End Sub
End Module
