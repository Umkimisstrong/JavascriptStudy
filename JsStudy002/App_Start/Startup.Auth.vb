Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.Owin
Imports Microsoft.Owin.Security.Cookies
Imports Microsoft.Owin.Security.DataProtection
Imports Microsoft.Owin.Security.Google
Imports Microsoft.Owin.Security.OAuth
Imports Owin

Partial Public Class Startup
    Private Shared _oAuthOptions As OAuthAuthorizationServerOptions
    Private Shared _publicClientId As String

    ' 애플리케이션이 OAuthAuthorization을 사용하도록 설정합니다. 그런 다음 Web API에 보안을 설정할 수 있습니다.
    Shared Sub New()
        PublicClientId = "web"

        OAuthOptions = New OAuthAuthorizationServerOptions() With {
            .TokenEndpointPath = New PathString("/Token"),
            .AuthorizeEndpointPath = New PathString("/Account/Authorize"),
            .Provider = New ApplicationOAuthProvider(PublicClientId),
            .AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
            .AllowInsecureHttp = True
        }
    End Sub

    Public Shared Property OAuthOptions() As OAuthAuthorizationServerOptions
        Get
            Return _oAuthOptions
        End Get
        Private Set
            _oAuthOptions = Value
        End Set
    End Property

    Public Shared Property PublicClientId() As String
        Get
            Return _publicClientId
        End Get
        Private Set
            _publicClientId = Value
        End Set
    End Property

    ' 인증 구성에 대한 자세한 내용은 https://go.microsoft.com/fwlink/?LinkId=301864를 참조하세요.
    Public Sub ConfigureAuth(app As IAppBuilder)
        ' 요청당 단일 인스턴스를 사용하도록 db 컨텍스트, 사용자 관리자 및 로그인 관리자 구성
        app.CreatePerOwinContext(AddressOf ApplicationDbContext.Create)
        app.CreatePerOwinContext(Of ApplicationUserManager)(AddressOf ApplicationUserManager.Create)
        app.CreatePerOwinContext(Of ApplicationSignInManager)(AddressOf ApplicationSignInManager.Create)

        ' 애플리케이션이 쿠키를 사용하여 로그인한 사용자에 대한 정보를 저장하도록 설정합니다.
        ' 또한 쿠키를 사용하여 타사 로그인 공급자를 통한 사용자 로그인 관련 정보를 일시적으로 저장하도록 설정합니다.
        ' 쿠키에 서명 구성
        ' OnValidateIdentity는 사용자가 로그인할 때 애플리케이션에서 보안 스탬프를 확인하도록 설정합니다.
        ' 암호를 변경하거나 계정에 외부 로그인을 추가할 때 사용되는 보안 기능입니다.
        app.UseCookieAuthentication(New CookieAuthenticationOptions() With {
            .AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            .Provider = New CookieAuthenticationProvider() With {
                .OnValidateIdentity = SecurityStampValidator.OnValidateIdentity(Of ApplicationUserManager, ApplicationUser)(
                    validateInterval:=TimeSpan.FromMinutes(30),
                    regenerateIdentity:=Function(manager, user) user.GenerateUserIdentityAsync(manager))},
            .LoginPath = New PathString("/Account/Login")})

        app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie)

        ' 애플리케이션에서 2단계 인증 프로세스의 두 번째 단계를 확인할 때 사용자 정보를 일시적으로 저장하도록 설정합니다.
        app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5))

        ' 애플리케이션에서 전화나 전자 메일 같은 두 번째 로그인 확인 단계를 기억하도록 설정합니다.
        ' 이 옵션을 선택하면 사용자가 로그인한 디바이스에서 로그인 프로세스의 두 번째 확인 단계를 기억합니다.
        ' 로그인할 때의 [사용자 이름 및 암호 저장] 옵션과 유사합니다.
        app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie)

        ' 애플리케이션이 전달자 토큰을 사용하여 사용자를 인증하도록 설정합니다.
        app.UseOAuthBearerTokens(OAuthOptions)

        ' 타사 로그인 공급자로 로그인할 수 있으려면 다음 줄의 주석 처리를 제거합니다.
        'app.UseMicrosoftAccountAuthentication(
        '    clientId:="",
        '    clientSecret:="")

        'app.UseTwitterAuthentication(
        '   consumerKey:="",
        '   consumerSecret:="")

        'app.UseFacebookAuthentication(
        '   appId:="",
        '   appSecret:="")

        'app.UseGoogleAuthentication(New GoogleOAuth2AuthenticationOptions() With {
        '   .ClientId = "",
        '   .ClientSecret = ""})
    End Sub
End Class
