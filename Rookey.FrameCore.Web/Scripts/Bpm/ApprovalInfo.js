$(function () {
    AutoMergeAppInfoCell();
    var dataBody = $('#tb_approvalList').data().datagrid.dc.body2;
    dataBody.find("td[field='ApprovalOpinions'] span").each(function (i, item) {
        var text = $(item).text();
        text = "<a href='javascript:void(0)' title='" + text + "' onclick='ShowOpinions(this)'>" + text + "</a>";
        $(item).html(text);
    });
});

//弹出显示处理意见
function ShowOpinions(obj) {
    var title = $(obj).attr('title');
    var toolbar = [{
        text: '关闭',
        iconCls: "eu-icon-close",
        handler: function (e) {
            topWin.CloseDialog();
        }
    }];
    var content = "<div style='margin:20px'>" + title + "</div>";
    topWin.OpenDialog('处理意见', content, toolbar);
}

//自动合并审批信息单元格
function AutoMergeAppInfoCell() {
    $.getScript('/Scripts/easyui-extension/datagrid-autoMergeCells.js', function () {
        var gridObj = $('#tb_approvalList');
        gridObj.datagrid("autoMergeCells", ['NodeName']);
        $('#div_approvalListTitle td').css('vertical-align', 'middle');
    });
}
