Imports System.Net.Http
Imports System.Web.Http
Imports Microsoft.Owin.Security.OAuth
Imports Newtonsoft.Json.Serialization

Public Module WebApiConfig
    Public Sub Register(config As HttpConfiguration)
        ' Web API 구성 및 서비스
        ' 전달자 토큰 인증만 사용하도록 Web API를 구성합니다.
        config.SuppressDefaultHostAuthentication()
        config.Filters.Add(New HostAuthenticationFilter(OAuthDefaults.AuthenticationType))

        ' JSON 데이터에 카멜 케이스를 사용합니다.
        config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = New CamelCasePropertyNamesContractResolver()

        ' Web API 경로
        config.MapHttpAttributeRoutes()

        config.Routes.MapHttpRoute(
            name:="DefaultApi",
            routeTemplate:="api/{controller}/{id}",
            defaults:=New With {.id = RouteParameter.Optional}
        )
    End Sub
End Module
