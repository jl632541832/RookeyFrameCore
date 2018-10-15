//初始化
$(function () {
    $(document).keydown(function (e) {
        if (e.keyCode == 13) {
            DoReg();
        }
    });
});

//用户注册
function DoReg() {
    var username = $('#username').val();
    var userpwd = $('#userpwd').val();
    var useralias = $('#useralias').val();
    if (username == "") {
        $('#usernameTip').text("邮箱不能为空！");
        $("#username").focus();
        ClearErrTip();
        return;
    }
    if (userpwd == "") {
        $('#pwdTip').text("密码不能为空！");
        $("#userpwd").focus();
        ClearErrTip();
        return;
    }
    if (useralias.length > 15) {
        $('#useraliasTip').text("昵称不能超过15个字符！");
        ClearErrTip();
        return;
    }
    $.ajax({
        type: 'post',
        dataType: 'json',
        url: '/User/UserReg.html',
        data: { username: username, userpwd: userpwd, useralias: useralias },
        success: function (result) {
            if (!result) {
                $('#usernameTip').text('服务器无响应，请重试！');
                ClearErrTip();
                return;
            }
            if (!result.Success) {
                $('#usernameTip').text(result.Message);
                ClearErrTip();
            } else {
                SetCookie('UserName', username);
                location.href = "/User/Login.html";
            }
        },
        error: function (err) {
            $('#usernameTip').text('服务器无响应，请重试！');
            ClearErrTip();
        },
        beforeSend: function () {
        },
        complete: function () {
        }
    });
}

//清除错误提示
function ClearErrTip() {
    setTimeout(function () { $(".error-tip").html("") }, 3000);
}

//两个参数，一个是cookie的名子，一个是值  
function SetCookie(name, value) {
    var cookie = name + "=" + escape(value);
    document.cookie = cookie;
}