@Imports Microsoft.AspNet.Identity

@If Request.IsAuthenticated
    @Using Html.BeginForm("LogOff", "Account", New With { .area = "" }, FormMethod.Post, New With { .id = "logoutForm", .class = "navbar-right" })
        @Html.AntiForgeryToken()
        @<ul class="nav navbar-nav navbar-right">
            <li>
                @Html.ActionLink("안녕하세요. " + User.Identity.GetUserName() + "!", "Index", "Manage", routeValues := New With { .area = "" }, htmlAttributes := New With { .title = "Manage" })
            </li>
            <li><a href="javascript:sessionStorage.removeItem('accessToken');$('#logoutForm').submit();">로그오프</a></li>
        </ul>
    End Using
Else
    @<ul class="nav navbar-nav navbar-right">
        <li>@Html.ActionLink("등록", "Register", "Account", routeValues := New With { .area = "" }, htmlAttributes := New With { .id = "registerLink" })</li>
        <li>@Html.ActionLink("로그인", "Login", "Account", routeValues := New With { .area = "" }, htmlAttributes := New With { .id = "loginLink" })</li>
    </ul>
End If
