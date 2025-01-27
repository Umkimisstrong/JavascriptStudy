﻿@ModelType ExternalLoginListViewModel
@Imports Microsoft.Owin.Security
@Code
    Dim loginProviders = Context.GetOwinContext().Authentication.GetExternalAuthenticationTypes()
End Code
<h4>다른 서비스를 사용하여 로그인합니다.</h4>
<hr />
@If loginProviders.Count() = 0 Then
    @<div>
          <p>
              구성된 외부 인증 서비스가 없습니다. 외부 서비스를 통한 로그인을 지원하도록 이 ASP.NET 애플리케이션을 설정하는 방법에 대한 자세한 내용은
              <a href="https://go.microsoft.com/fwlink/?LinkId=403804">이 문서</a>를 참조하세요.
          </p>
    </div>
Else
    @Using Html.BeginForm("ExternalLogin", "Account", New With {.ReturnUrl = Model.ReturnUrl}, FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
        @Html.AntiForgeryToken()
        @<div id="socialLoginList">
           <p>
               @For Each p As AuthenticationDescription In loginProviders
                   @<button type="submit" class="btn btn-default" id="@p.AuthenticationType" name="provider" value="@p.AuthenticationType" title="@p.Caption 계정을 사용하여 로그인">@p.AuthenticationType</button>
               Next
           </p>
        </div>
    End Using
End If
