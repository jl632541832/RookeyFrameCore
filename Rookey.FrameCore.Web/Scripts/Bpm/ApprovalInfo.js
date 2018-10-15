$(function () {
    var gridDom = $('#tb_approvalList');
    var formatHandler = function () {
        var rows = gridDom.datagrid('getRows');
        if (rows && rows.length > 0) {
            var row = rows[rows.length - 1];
            if (row.NextHandler) {
                var tempStr = row.NextHandler.replace(/<\/?.+?>/g, "");
                if (tempStr) {
                    var rowIndex = gridDom.datagrid("getRowIndex", row);
                    row.NextHandler = '<span style="font-weight: bold;color: red;">' + row.NextHandler + '（待批）</span>';
                    gridDom.datagrid('updateRow', {
                        index: rowIndex,
                        row: row
                    });
                }
            }
        }
    };
    var options = gridDom.datagrid('options');
    if (options.columns && options.columns.length > 0 && options.columns[0].length > 0) {
        for (var i = 0; i < options.columns[0].length; i++) {
            if (options.columns[0][i].field == 'ApprovalOpinions') {
                options.columns[0][i].formatter = function (value, row, index) {
                    if (value) {
                        return "<a href='javascript:void(0)' title='" + value + "' onclick='ShowOpinions(this)'>" + value + "</a>";
                    }
                    return value;
                };
            }
        }
    }
    options.onLoadSuccess = function (dts) {
        formatHandler();
        AutoMergeAppInfoCell(); //合并审批信息单元格
    };
    gridDom.datagrid(options);
    AutoMergeAppInfoCell();
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
