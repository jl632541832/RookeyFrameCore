//初始化
$(function () {
    if (page == 'add' || page == 'edit' || page == 'view') {
        var panelbody = $('div.panel-body');
        if (panelbody && panelbody.length > 0) {
            panelbody = panelbody.eq(0);
            panelbody.find('table').css('float', 'left');
            $.getScript("/Scripts/common/Attachment.js", function () {
                var img = page == 'edit' || page == 'view' ? '/Upload/Image/Emp/' + id + '.jpg' : '';
                panelbody.append('<img class="left" id="empPhoto" style="cursor:pointer;margin-left:20px;width:150px;height:150px;" moduleName="员工管理" onclick="UploadFile(this)" num="1" src="' + img + '" onerror="javascript:this.src=\'/Images/Emp/male.jpg\'" alt="添加员工照片" title="添加员工照片，只支持jpg图片">');
            });
            if (page == 'view') {
                var obj = $('#span_Gender').parents('tr');
                var emp = GetFormDataObj();
                if (emp)
                    emp = eval('(' + emp + ')');
                var deptName = '';
                var dutyName = '';
                if (emp && emp.DeptName)
                    deptName = emp.DeptName;
                if (emp && emp.DutyName)
                    dutyName = emp.DutyName;
                obj.after('<tr id="tr_dept" style="height:30px;"><th style="padding:2px;width:100px;text-align:right">部门：</th><td style="padding:2px;width:180px">' + deptName + '</td><th style="padding:2px;width:100px;text-align:right">职务：</th><td style="padding:2px;width:180px">' + dutyName + '</td></tr>');
            }
            else if (page == 'add' || page == 'edit') {
                var obj = $('#Gender').parents('tr');
                obj.after('<tr id="tr_dept" style="height:30px;"><th style="padding:2px;width:100px;text-align:right"><font color="red">*</font>部门：</th><td style="padding:2px;width:180px"><input id="OrgM_DeptId" foreignfield="1" class="easyui-textbox" style="width:171px;height:24px;" isTree="1" url="/Page/DialogTree.html?moduleName=%e9%83%a8%e9%97%a8%e7%ae%a1%e7%90%86" valuefield="Id" textfield="Name" foreignmodulename="部门管理" foreignmoduledisplay="部门管理" isrequired="1" fielddisplay="部门" data-options="editable:false,missingMessage:null,icons: [{iconCls:\'eu-icon-search\',handler: function(e){SelectDialogData($(e.data.target))}}]"><a id="btnAddDept" title="添加部门" href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:\'eu-p2-icon-add_other\'" onclick="AddDept()"></a></td><th style="padding:2px;width:100px;text-align:right"><font color="red">*</font>职务：</th><td style="padding:2px;width:180px"><input id="OrgM_DutyId" style="width:171px;height:24px;" class="easyui-combobox" value="00000000-0000-0000-0000-000000000000" data-options="missingMessage:null,editable:false,panelMinWidth:150,valueField:\'Id\',textField:\'Name\',url:\'/OrgM/GetDeptDutys.html\'"><a id="btnAddDuty" title="添加职务" href="#" class="easyui-linkbutton" data-options="plain:true,iconCls:\'eu-p2-icon-add_other\'" onclick="AddDuty()"></a></td></tr>');
                ParserLayout('tr_dept');
                if (page == 'edit') {
                    setTimeout(function () {
                        var emp = GetFormDataObj();
                        if (emp == null || emp == '' || emp == undefined)
                            return;
                        emp = eval('(' + emp + ')');
                        var deptName = emp.DeptName;
                        var deptId = emp.DeptId;
                        var dutyId = emp.DutyId;
                        if (deptId && dutyId) {
                            $('#OrgM_DeptId').attr('v', emp.DeptId);
                            $('#OrgM_DeptId').textbox('setText', emp.DeptName);
                            $('#OrgM_DutyId').combobox('setValue', emp.DutyId);
                            OnFieldValueChanged(null, 'OrgM_DeptId', emp.DeptId, null);
                        }
                    }, 50);
                }
            }
        }
    }
    HideFields();
});

//加载完成事件
function OverOnLoadSuccess(data, gridId, moduleId, moduleName) {
    HideFields();
}

//上传后重写操作
function OverAfterUploadFile(obj, attachStr) {
    var attachObj = eval("(" + attachStr + ")");
    if (!attachObj || attachObj.length == 0)
        return;
    var item = attachObj[0];
    $('#empPhoto').attr('src', item.AttachFile.replace("~", ""));
    if (page == 'view') { //查看页面上传照片时直接保存照片
        var moduleId = GetLocalQueryString("moduleId");
        OverSaveFormAttach(moduleId, id);
    }
}

//保存员工照片
function OverSaveFormAttach(moduleId, recordId, backFun) {
    var photoPath = $('#empPhoto').attr('src');
    if (photoPath && photoPath.length > 0 && photoPath != '/Images/Emp/male.jpg') {
        ExecuteCommonAjax('/OrgM/UploadEmpPhoto.html', { id: recordId, filePath: photoPath }, function (result) {
            if (result.Message && result.Message.length > 0) {
                topWin.ShowMsg('提示', '员工照片上传失败，' + result.Message);
            }
        }, false, false);
    }
    if (typeof (backFun) == "function") {
        backFun();
    }
}

//添加部门
function AddDept() {
    var toolbar = [{
        text: "确 定",
        iconCls: "eu-icon-ok",
        handler: function (e) {
            var url = '/OrgM/AddDept.html';
            var params = { deptname: topWin.$('#deptname').val() };
            ExecuteCommonAjax(url, params, function (result) {
                if (result.Success) {
                    $('#OrgM_DeptId').attr('v', result.DeptId);
                    $('#OrgM_DeptId').textbox('setText', result.DeptName);
                    topWin.CloseDialog();
                }
                else {
                    topWin.ShowMsg('提示', '添加部门失败，' + result.Message);
                }
            }, false);
        }
    }, {
        text: '取 消',
        iconCls: "eu-icon-close",
        handler: function (e) {
            topWin.CloseDialog();
        }
    }];
    var content = "<table style='margin-top:15px;margin-left:15px;'><tr><td>部门名称：</td><td><input type='text' id='deptname' name='deptname' style='width:200px;'/></td></tr></table>";
    topWin.OpenDialog("添加部门", content, toolbar, 330, 160, 'eu-p2-icon-add_other');
}

//添加职务
function AddDuty() {
    var deptId = $('#OrgM_DeptId').attr('v');
    if (!deptId) {
        topWin.ShowMsg('提示', '请先选择部门');
        return;
    }
    var toolbar = [{
        text: "确 定",
        iconCls: "eu-icon-ok",
        handler: function (e) {
            var url = '/OrgM/AddDuty.html';
            var params = { deptId: deptId, dutyname: topWin.$('#dutyname').val() };
            ExecuteCommonAjax(url, params, function (result) {
                if (result.Success) {
                    $('#OrgM_DutyId').combobox('reload', '/OrgM/GetDeptDutys.html?deptId=' + deptId).combobox('setValue', result.DutyId);
                    topWin.CloseDialog();
                }
                else {
                    topWin.ShowMsg('提示', '添加职务失败，' + result.Message);
                }
            }, false);
        }
    }, {
        text: '取 消',
        iconCls: "eu-icon-close",
        handler: function (e) {
            topWin.CloseDialog();
        }
    }];
    var content = "<table style='margin-top:15px;margin-left:15px;'><tr><td>职务名称：</td><td><input type='text' id='dutyname' name='dutyname' style='width:200px;'/></td></tr></table>";
    topWin.OpenDialog("添加职务", content, toolbar, 330, 160, 'eu-p2-icon-add_other');
}

//字段值改变事件
function OnFieldValueChanged(moduleInfo, fieldName, vf, oldValue, obj) {
    if (fieldName == 'OrgM_DeptId') {
        var dutyId = $('#OrgM_DutyId').combobox('getValue');
        var dutyName = $('#OrgM_DutyId').combobox('getText');
        $('#OrgM_DutyId').combobox('clear').combobox('reload', '/OrgM/GetDeptDutys.html?deptId=' + vf);
        if (dutyId) {
            $('#OrgM_DutyId').combobox('setValue', dutyId);
        }
    }
}

//保存前验证
function OverBeforeSaveVerify(backFun, obj) {
    if (page == 'add') {
        var deptId = $('#OrgM_DeptId').attr('v');
        var dutyId = $('#OrgM_DutyId').combobox('getValue');
        if (dutyId == GuidEmpty)
            dutyId = null;
        if (deptId && deptId.length > 0 && !dutyId) {
            backFun('请选择职务');
            return;
        }
    }
    backFun(null);
}

//保存前数据处理
function OverMainModuleDataHandleBeforeSaved(data) {
    if (page == 'add') {
        var deptId = $('#OrgM_DeptId').attr('v');
        var dutyId = $('#OrgM_DutyId').combobox('getValue');
        if (deptId && deptId.length > 0 && dutyId && dutyId.length > 0) {
            data.DeptId = deptId;
            data.DutyId = dutyId;
        }
    }
}


//弹出框时移除敏感字段
function HideFields() {
    if (page == 'fdGrid') {
        $("td[field='Photo']").remove();
        $("td[field='BirthdayDate']").remove();
        $("td[field='Height']").remove();
        $("td[field='BloodType']").remove();
        $("td[field='Education']").remove();
        $("td[field='IsMarriage']").remove();
        $("td[field='StartWorkDate']").remove();
        $("td[field='EntryDate']").remove();
        $("td[field='StatusChangeDate']").remove();
        $("td[field='PositiveDate']").remove();
        $("td[field='Nationality']").remove();
        $("td[field='Hometown']").remove();
        $("td[field='Political']").remove();
        $("td[field='Religion']").remove();
        $("td[field='Sort']").remove();
        $("td[field='CreateUserName']").remove();
        $("td[field='ModifyUserName']").remove();
        $("td[field='CreateDate']").remove();
        $("td[field='ModifyDate']").remove();
        $('#btn_changeSearch').remove(); //不允许切换搜索
        $("a[id^='btn_advanceSearch']").remove(); //不允许高级搜索
    }
}