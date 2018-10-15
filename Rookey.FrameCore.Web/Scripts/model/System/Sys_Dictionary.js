﻿var page = GetLocalQueryString("page"); //页面类型标识

//保存前数据处理
function OverMainModuleDataHandleBeforeSaved(data) {
    if (data && data.length > 0) {
        for (var i = 0; i < data.length; i++) {
            var obj = data[i];
            if (obj.name == 'ClassName' && !obj.value) {
                obj.value = $("#ClassName").combobox("getText");
                break;
            }
        }
    }
    return null;
}

//重写字段选择事件
function OverOnFieldSelect(record, fieldName, valueField, textField) {
    if (page == "add") {
        if (fieldName == "ClassName") { //新增时选择字典分类后自动带出最大排序号
            $.get("/" + CommonController.Async_System_Controller + "/GetDicClassMaxSort.html", { className: record[valueField] }, function (result) {
                if (result && result.MaxSort) {
                    $("#Sort").numberbox("setValue", result.MaxSort + 1);
                }
                else {
                    $("#Sort").numberbox("setValue", 1);
                }
            });
        }
    }
}