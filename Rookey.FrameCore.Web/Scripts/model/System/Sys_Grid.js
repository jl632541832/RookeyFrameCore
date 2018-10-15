//重置视图类型
function ReSetGridType(obj) {
    var rows = GetFinalSelectRows(obj);
    var ids = '';
    if (rows && rows.length > 0) {
        for (var i = 0; i < rows.length; i++) {
            if (rows[i].Id && (rows[i].GridType == 0 || rows[i].GridType == 5))
                ids += rows[i].Id + ",";
        }
        if (ids.length > 0) {
            ids = ids.substr(0, ids.length - 1);
        }
    }
    if (ids && ids.length > 0) {
        var toolbar = [{
            text: "确 定",
            iconCls: "eu-icon-ok",
            handler: function (e) {
                var url = '/' + CommonController.System_Controller + '/ReSetGridType.html';
                var params = { ids: ids, gridtype: topWin.$('#gridType').val() };
                ExecuteCommonAjax(url, params, function (result) {
                    if (result.Success) {
                        topWin.CloseDialog();
                        var win = isNfm ? parent : top.getCurrentTabFrame()[0].contentWindow;
                        win.RefreshGrid();
                    }
                }, true);
            }
        }, {
            text: '取 消',
            iconCls: "eu-icon-close",
            handler: function (e) {
                topWin.CloseDialog();
            }
        }];
        var content = '<table style="margin-top:15px;margin-left:15px;"><tr><td>视图类型：</td><td>';
        content += '<select id="gridType" name="gridType" style="width:200px;">';
        content += '<option value="0">列表视图</option>';
        content += '<option value="5">无附属视图</option>';
        content += '</select>';
        content += '</td></tr></table>';
        topWin.OpenDialog("重置视图类型", content, toolbar, 330, 160, 'eu-icon-user');
    }
    else {
        topWin.ShowMsg("提示", "请选择视图类型为【列表视图】或【无附属视图】的记录！");
        return;
    }
}