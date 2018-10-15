//主框架对象
var mainPlatform = {
    init: function () {
        this.bindEvent();
    },
    bindEvent: function () {
        var self = this;
        // 顶部大菜单单击事件
        $(document).on('click', '.pf-nav-item', function () {
            $('.pf-nav-item').removeClass('current');
            $(this).addClass('current');
            // 渲染对应侧边菜单
            var mid = $(this).data('menu');
            self.render(mid);
        });
        //顶部大菜单翻页
        $(document).on('click', '.pf-nav-prev,.pf-nav-next', function () {
            if ($(this).hasClass('disabled')) return;
            if ($(this).hasClass('pf-nav-next')) {
                page++;
                $('.pf-nav').stop().animate({ 'margin-top': -70 * page }, 200);
                if (page == pages) {
                    $(this).addClass('disabled');
                    $('.pf-nav-prev').removeClass('disabled');
                } else {
                    $('.pf-nav-prev').removeClass('disabled');
                }
            } else {
                page--;
                $('.pf-nav').stop().animate({ 'margin-top': -70 * page }, 200);
                if (page == 0) {
                    $(this).addClass('disabled');
                    $('.pf-nav-next').removeClass('disabled');
                } else {
                    $('.pf-nav-next').removeClass('disabled');
                }
            }
        });
        //单击左侧菜单
        $(document).on('click', '.sider-nav li', function () {
            if ($(this).parent().hasClass('sider-nav-s')) {
                $('.sider-nav-s li').removeClass('active');
                $(this).addClass('active');
            }
            else {
                $('.sider-nav li').removeClass('current');
                $(this).addClass('current');
            }
            var url = $(this).attr('url');
            if (url) {
                var title = $(this).attr('display');
                AddTab(null, title, url);
            }
        });
        //退出事件
        $(document).on('click', '.pf-logout', function () {
            layer.confirm('您确定要退出吗？', {
                icon: 4,
                title: '确定退出' //按钮
            }, function () {
                location.href = 'login.html';
            });
        });
        //左侧菜单收起
        $(document).on('click', '.toggle-icon', function () {
            $(this).closest("#pf-bd").toggleClass("toggle");
            setTimeout(function () {
                $(window).resize();
            }, 300)
        });
        //修改密码
        $('#btnChangePwd').click(function () {
            var toolbar = [{
                text: "确 定",
                iconCls: "eu-icon-ok",
                handler: function (e) {
                    top.GetCurrentDialogFrame()[0].contentWindow.SaveModifyPwd(function () {
                        top.ShowMsg("提示", "密码修改成功！", function () {
                            top.CloseDialog();
                        });
                    });
                }
            }, {
                text: '取 消',
                iconCls: "eu-icon-close",
                handler: function (e) {
                    top.CloseDialog();
                }
            }];
            top.OpenDialog("修改密码", '/Page/ChangePwd.html', toolbar, 480, 250, 'eu-icon-changePwd');
        });
        //切换账号
        $('#btnChangeUser').click(function () {
            var toolbar = [{
                text: "确 定",
                iconCls: "eu-icon-ok",
                handler: function (e) {
                    var url = '/' + CommonController.User_Controller + '/ChangeUser.html';
                    var params = { username: $('#username').val() };
                    ExecuteCommonAjax(url, params, function (result) {
                        if (result.Success)
                            window.location.href = "/Page/Main.html";
                        else
                            top.ShowMsg('提示', result.Message);
                    }, false);
                }
            }, {
                text: '取 消',
                iconCls: "eu-icon-close",
                handler: function (e) {
                    top.CloseDialog();
                }
            }];
            var content = "<table style='margin-top:15px;margin-left:15px;'><tr><td>用户名：</td><td><input type='text' id='username' name='username' style='width:200px;'/></td></tr></table>";
            top.OpenDialog("切换账号", content, toolbar, 330, 160, 'eu-icon-user');
        });
    },
    render: function (menuId) { //加载子菜单
        if ($('#pf-sider h2.pf-model-name').attr('menuid') == menuId)
            return;
        var url = "/System/LoadChildMenusHtml.html";
        var params = { menuId: menuId };
        $.get(url, params, function (html) {
            $('#pf-sider').html(html);
        }, 'html');
    },
};

$(function () {
    mainPlatform.init();
    $('.easyui-tabs1').tabs({
        tabHeight: 44,
        onSelect: function (title, index) {
            //var currentTab = $('.easyui-tabs1').tabs("getSelected");
            //if (currentTab.find("iframe") && currentTab.find("iframe").size()) {
            //    currentTab.find("iframe").attr("src", currentTab.find("iframe").attr("src"));
            //}
        }
    });
    $(window).resize(function () {
        $('.tabs-panels').height($("#pf-page").height() - 46);
        $('.panel-body').height($("#pf-page").height() - 76)
    }).resize();
    var page = 0,
        pages = ($('.pf-nav').height() / 70) - 1;
    if (pages === 0) {
        $('.pf-nav-prev,.pf-nav-next').hide();
    }
});

//获取当前tab的iframe
function getCurrentTabFrame() {
    var tab = GetSelectedTab();
    var iframe = tab.find("iframe:first");
    return iframe;
}

//获取tab中的第一个iframe
//tabIndexOrTitle:tab索引或标题
function getTabFrame(tabIndexOrTitle) {
    var tab = GetTab(null, tabIndexOrTitle);
    var iframe = tab.find("iframe:first");
    return iframe;
}

//获取当前tab的frame内的dom对象
//domId:domId
function getCurrentTabFrameDom(domId) {
    var tab = GetSelectedTab();
    var iframe = tab.find("iframe:first");
    return iframe.contents().find("#" + domId);
}

//获取当前tab的frmae内的dom对象
//selector:选择器
function getCurrentTabFrameDomBySelector(selector) {
    var tab = GetSelectedTab();
    var iframe = tab.find("iframe:first");
    return iframe.contents().find(selector);
}

//获取当前tab的frame内的某个标签内的dom对象
//tag:标签
//startDomId:Id以startDomId开始的
function getCurrentTabFrameSomeDom(tag, startDomId) {
    var tab = GetSelectedTab();
    var iframe = tab.find("iframe:first");
    return iframe.contents().find(tag + "[id^='" + startDomId + "']");
}
