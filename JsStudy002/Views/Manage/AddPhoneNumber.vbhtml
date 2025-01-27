﻿@ModelType AddPhoneNumberViewModel
@Code
    ViewBag.Title = "전화 번호"
End Code

<h2>@ViewBag.Title.</h2>

@Using Html.BeginForm("AddPhoneNumber", "Manage", FormMethod.Post, New With { .class = "form-horizontal", .role = "form" })
    @Html.AntiForgeryToken()
    @<text>
    <h4>전화 번호 추가</h4>
    <hr />
    @Html.ValidationSummary("", New With { .class = "text-danger" })
    <div class="form-group">
        @Html.LabelFor(Function(m) m.Number, New With { .class = "col-md-2 control-label" })
        <div class="col-md-10">
            @Html.TextBoxFor(Function(m) m.Number, New With{ .class = "form-control" })
        </div>
    </div>
    <div class="form-group">
        <div class="col-md-offset-2 col-md-10">
            <input type="submit" class="btn btn-default" value="제출" />
        </div>
    </div>
    </text>
End Using

@Section Scripts 
    @Scripts.Render("~/bundles/jqueryval")
End Section
