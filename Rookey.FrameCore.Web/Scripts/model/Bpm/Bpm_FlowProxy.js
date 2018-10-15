//字段值变更事件
function OverOnFieldValueChanged(moduleInfo, fieldName, newValue, oldValue) {
    if (fieldName == "Bpm_WorkFlowId") {
        if (workNodes && workNodes.length > 0) {
            var tempData = [];
            for (var i = 0; i < workNodes.length; i++) {
                if (workNodes[i].Bpm_WorkFlowId == newValue && workNodes[i].WorkNodeType == 2) {
                    tempData.push(workNodes[i]);
                }
            }
            $('#Bpm_WorkNodeId').combobox('loadData', tempData);
        }
    }
    else if (fieldName == "OrgM_EmpProxyId") {
        var empId = $('#OrgM_EmpId').attr('v');
        if (empId == newValue) {
            topWin.ShowMsg('提示', '代理人和被代理人不能相同！');
        }
    }
    else if (fieldName == "OrgM_EmpId") {
        var empProxyId = $('#OrgM_EmpProxyId').attr('v');
        if (empProxyId == newValue) {
            topWin.ShowMsg('提示', '代理人和被代理人不能相同！');
        }
    }
}

var workNodes = null;
function OverOnFieldLoadSuccess(fieldName, valueField, textField) {
    if (fieldName == "Bpm_WorkNodeId") {
        if (workNodes == null) {
            workNodes = $('#Bpm_WorkNodeId').combobox('getData');
            var workflowId = $('#Bpm_WorkFlowId').combobox('getValue');
            if (workflowId && workflowId.length > 0) {
                OverOnFieldValueChanged(null, 'Bpm_WorkFlowId', workflowId, null);
            }
        }
    }
}

//保存前验证
function OverBeforeSaveVerify(backFun) {
    var empId = $('#OrgM_EmpId').attr('v');
    var proxyEmpId = $('#OrgM_EmpProxyId').attr('v');
    if (empId == proxyEmpId) {
        backFun('代理人和被代理人不能相同！');
        return;
    }
    backFun(null);
}