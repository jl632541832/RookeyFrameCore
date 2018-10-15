//初始化
$(function () {
    if (GetCookie("UserName") && GetCookie("UserName") != null)
        $("#txtUserName").val(GetCookie("UserName"))
    $(document).keydown(function (e) {
        if (e.keyCode == 13) {
            DoLogin();
        }
    });
});

//取cookies函数    
function GetCookie(name) {
    var arr = document.cookie.match(new RegExp("(^| )" + name + "=([^;]*)(;|$)"));
    if (arr != null)
        return unescape(arr[2]);
    return null;
}

//取网页可见区域高
function GetBodyHeight() {
    var winHeight = 0;
    //获取窗口高度
    if (window.innerHeight)
        winHeight = window.innerHeight;
    else if ((document.body) && (document.body.clientHeight))
        winHeight = document.body.clientHeight;
    //通过深入Document内部对body进行检测，获取窗口大小
    if (document.documentElement && document.documentElement.clientHeight) {
        winHeight = document.documentElement.clientHeight;
    }
    return winHeight;
}

//取网页可见区域宽
function GetBodyWidth() {
    var winWidth = 0;
    //获取窗口宽度
    if (window.innerWidth)
        winWidth = window.innerWidth;
    else if ((document.body) && (document.body.clientWidth))
        winWidth = document.body.clientWidth;
    //通过深入Document内部对body进行检测，获取窗口大小
    if (document.documentElement && document.documentElement.clientWidth) {
        winWidth = document.documentElement.clientWidth;
    }
    return winWidth;
}

//用户登录
function DoLogin() {
    var username = $("#txtUserName").val();
    var password = $("#txtPwd").val();
    if (username == "") {
        $('#usernameTip').text("邮箱不能为空！");
        $("#txtUserName").focus();
        ClearErrTip();
        return;
    }
    if (password == "") {
        $('#pwdTip').text("密码不能为空！");
        $("#txtPwd").focus();
        ClearErrTip();
        return;
    }
    $.ajax({
        type: 'post',
        dataType: 'json',
        url: '/UserAsync/UserLogin.html',
        data: [
        { name: 'username', value: username },
        { name: 'userpwd', value: password },
        { name: 'isNoCode', value: true },
        { name: 'valcode', value: '' },
        { name: 'w', value: GetBodyWidth() },
        { name: 'h', value: GetBodyHeight() },
        { name: 'r', value: Math.random() }
        ],
        success: function (result) {
            if (!result) {
                $('#usernameTip').text('服务器异常！');
                ClearErrTip();
                return;
            }
            if (!result.Success) {
                if (result.Message && result.Message.indexOf('密码') > -1)
                    $('#pwdTip').text(result.Message);
                else
                    $('#usernameTip').text(result.Message);
                ClearErrTip();
                $("#txtUserName").focus();
            } else {
                location.href = "/Page/Main.html";
            }
        },
        error: function () {
            $('#usernameTip').text('服务器无响应！');
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