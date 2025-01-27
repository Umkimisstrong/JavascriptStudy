﻿@ModelType ChangePasswordViewModel
@Code
    ViewBag.Title = "암호 변경"
End Code

<h2>@ViewBag.Title.</h2>

@Using Html.BeginForm("ChangePassword", "Manage", FormMethod.Post, New With { .class = "form-horizontal", .role = "form" })
    @Html.AntiForgeryToken()
    
    @<text>
    <h4>암호 양식 변경</h4>
    <hr />
    @Html.ValidationSummary("", New With { .class = "text-danger" })
    <div class="form-group">
        @Html.LabelFor(Function(m) m.OldPassword, New With { .class = "col-md-2 control-label" })
        <div class="col-md-10">
            @Html.PasswordFor(Function(m) m.OldPassword, New With { .class = "form-control" })
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(m) m.NewPassword, New With {.class = "col-md-2 control-label"})
        <div class="col-md-10">
            @Html.PasswordFor(Function(m) m.NewPassword, New With {.class = "form-control"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(m) m.ConfirmPassword, New With { .class = "col-md-2 control-label" })
        <div class="col-md-10">
            @Html.PasswordFor(Function(m) m.ConfirmPassword, New With { .class = "form-control" })
        </div>
    </div>
    <div class="form-group">
        <div class="col-md-offset-2 col-md-10">
            <input type="submit" value="암호 변경" class="btn btn-default" />
        </div>
    </div>
    </text>
End Using

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section