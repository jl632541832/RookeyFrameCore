var lf1 = null; //联动字段1，当前JS加载成功后初始化
var lf2 = null; //联动字段2，当前JS加载成功后初始化
var lf3 = null; //联动字段3，当前JS加载成功后初始化
var initLf2Data = null; //二级联动字段字典数据
var initLf3Data = null; //三级联动字段字典数据

//加载二级联动字段
//lf1Id:一级联动字段字典ID
function LoadLf2Data(lf1Id) {
    if (initLf2Data && initLf2Data.length > 0) {
        var tempdata = [];
        for (var i = 0; i < initLf2Data.length; i++) {
            if (initLf2Data[i].ParentId == lf1Id || initLf2Data[i].Id == '') {
                tempdata.push(initLf2Data[i]);
            }
        }
        $('#' + lf2).combobox('clear').combobox('loadData', tempdata);
    }
}

//加载三级联动字段
//lf2Id:二级联动字段字典ID
function LoadLf3Data(lf2Id) {
    if (initLf3Data && initLf3Data.length > 0) {
        var tempdata = [];
        for (var i = 0; i < initLf3Data.length; i++) {
            if (initLf3Data[i].ParentId == lf2Id || initLf3Data[i].Id == '') {
                tempdata.push(initLf3Data[i]);
            }
        }
        $('#' + lf3).combobox('clear').combobox('loadData', tempdata);
    }
}

//字段选择事件
function OverOnLinkFieldSelect(record, fieldName, valueField, textField, obj) {
    try {
        if (fieldName == lf1) {
            $('#' + lf2).combobox('clear').combobox('loadData', [{ Id: '', Name: '请选择' }]);
            $('#' + lf3).combobox('clear').combobox('loadData', [{ Id: '', Name: '请选择' }]);
            LoadLf2Data(record.RecordId);
        }
        else if (fieldName == lf2) {
            $('#' + lf3).combobox('clear').combobox('loadData', [{ Id: '', Name: '请选择' }]);
            LoadLf3Data(record.RecordId);
        }
    } catch (ex) { }
}

//字段加载成功后
function OverOnLinkFieldLoadSuccess(fieldName, valueField, textField) {
    if (fieldName == lf2) {
        if (initLf2Data == null) {
            initLf2Data = $('#' + lf2).combobox('getData');
            var tempid = $('#' + lf1).combobox('getValue');
            var lf1Data = $('#' + lf1).combobox('getData');
            if (tempid && lf1Data && lf1Data.length > 0) {
                var v = $('#' + lf2).combobox('getValue');
                var lf1Id = null;
                for (var i = 0; i < lf1Data.length; i++) {
                    if (lf1Data[i].Id == tempid) {
                        lf1Id = lf1Data[i].RecordId;
                        break;
                    }
                }
                if (lf1Id) {
                    LoadLf2Data(lf1Id);
                    $('#' + lf2).combobox('setValue', v);
                }
            }
            //else {
            //    $('#' + lf2).combobox('clear').combobox('loadData', [{ Id: '', Name: '请选择' }]);
            //}
        }
    }
    else if (fieldName == lf3) {
        if (initLf3Data == null) {
            initLf3Data = $('#' + lf3).combobox('getData');
            var tempid = $('#' + lf2).combobox('getValue');
            if (tempid && initLf2Data && initLf2Data.length > 0) {
                var v = $('#' + lf3).combobox('getValue');
                var lf2Id = null;
                for (var i = 0; i < initLf2Data.length; i++) {
                    if (initLf2Data[i].Id == tempid) {
                        lf2Id = initLf2Data[i].RecordId;
                        break;
                    }
                }
                if (lf2Id) {
                    LoadLf3Data(lf2Id);
                    $('#' + lf3).combobox('setValue', v);
                }
            }
            //else {
            //    $('#' + lf3).combobox('clear').combobox('loadData', [{ Id: '', Name: '请选择' }]);
            //}
        }
    }
}