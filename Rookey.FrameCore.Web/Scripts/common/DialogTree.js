var moduleId = GetLocalQueryString("moduleId");
var moduleName = GetLocalQueryString("moduleName");
var isMutiSelect = GetLocalQueryString("ms") == '1'; //是否多选
var isAsync = GetLocalQueryString("async") == '1'; //是否为异步加载
var parentId = GetLocalQueryString("parentId"); //父ID
var id = GetLocalQueryString("id"); //父ID
var onlyLeaf = GetLocalQueryString("onlyleaf") == '1'; //是否只能选择叶子节点
var dturl = decodeURI(GetLocalQueryString("dturl")); //数据源URL
var selectIds = decodeURI(GetLocalQueryString("selectIds")); //已选择项ids
var baseUrl = '/' + CommonController.Async_Data_Controller + '/GetTreeByNode.html?moduleId=' + moduleId + '&moduleName=' + moduleName;
if (dturl && dturl.length > 0) {
    baseUrl = dturl;
}
var treeUrl = baseUrl;
if (isAsync)
    treeUrl += "&async=1";
if (parentId)
    treeUrl += "&parentId=" + parentId;
if (id)
    treeUrl += "&id=" + id;
var treeDom = $("#tree");
var treeParams = {
    checkbox: isMutiSelect, //显示复选框
    cascadeCheck: true,//定义是否层叠选中状态
    onlyLeafCheck: onlyLeaf, //是否只能选择叶子节点
    animate: true,
    url: treeUrl,
    loadFilter: function (data) {
        if (data == null) return data;
        var lastData = null;
        if (typeof (data) == 'string') {
            var tempData = eval("(" + data + ")");
            lastData = tempData;
        }
        else {
            arr = [];
            arr.push(data);
            lastData = arr;
        }
        if (typeof (OverDialogTreeLoadFilter) == "function") {
            lastData = OverDialogTreeLoadFilter(lastData, moduleName, moduleId);
        }
        return lastData;
    },
    onLoadSuccess: function () {
        if (!isAsync) { //非异步时
            treeDom.tree("collapseAll");
            var roots = treeDom.tree("getRoots"); //只有一个根结点时，展开根结点
            if (roots && roots.length == 1) {
                $.each(roots, function (i, root) {
                    treeDom.tree("expand", root.target);
                });
            }
            if (selectIds && selectIds.length > 0) {
                var arr = isMutiSelect ? selectIds.split(',') : [selectIds];
                for (var i = 0; i < arr.length; i++) {
                    var node = treeDom.tree('find', arr[i]);
                    if (node && node.target) {
                        treeDom.tree('select', node.target).tree('expandTo', node.target);
                    }
                }
            }
        }
    },
    onSelect: function (node) {
        if (node.id == GuidEmpty) return;
        var flag = treeDom.tree("isLeaf", node.target);
        var addNodeFlag = onlyLeaf ? flag : true;
        if (addNodeFlag) {
            var item = $("#selectedNodeList").find("span[targetid='" + node.target.id + "']");
            if (item.length <= 0) {
                if (!isMutiSelect) { //no checkbox
                    AddSelectedNode(node);
                }
                else {
                    treeDom.tree("check", node.target);
                }
            }
        }
    },
    onCheck: function (node, checked) {
        if (node.id == GuidEmpty) return;
        var item = $("#selectedNodeList").find("span[targetid='" + node.target.id + "']");
        //选择叶节点
        var flag = treeDom.tree("isLeaf", node.target);
        if (flag || node.state == 'closed') { //叶子节点或非叶子节点收缩状态时
            if (checked && item.length <= 0) {
                AddSelectedNode(node);
            }
            else if (!checked && item.length > 0) {
                item.parent().remove();
            }
        }//选择非叶节点
        else {
            var children = treeDom.tree("getChildren", node.target);
            $(children).each(function () {
                var cnode = $(this)[0];
                var it = $("#selectedNodeList").find("span[targetid='" + cnode.target.id + "']");
                if (cnode.checked && it.length <= 0) {
                    AddSelectedNode(cnode);
                }
                else if (!cnode.checked && it.length > 0) {
                    it.parent().remove();
                }
            });
        }
    }
};

$(function () {
    //加载通用树
    if (typeof (OverGetTreeLoadUrl) == 'function') {
        var pid = id ? id : parentId; //父ID
        var tempUrl = OverGetTreeLoadUrl(treeUrl, isMutiSelect, isAsync, onlyLeaf, selectIds, pid);
        if (tempUrl && tempUrl.length > 0) {
            treeParams.url = tempUrl;
        }
    }
    treeDom.tree(treeParams);
});

//搜索节点
function SearchNode(value) {
    if (!isAsync) { //同步
        if (!value) return;
        var target = $("#tree li span.tree-title:contains('" + value + "')").parent();
        if (target.length <= 0) {
            top.ShowMsg("提示", "未找到任何相关节点");
            return;
        }
        $(target).each(function () {
            var tt = $(this);
            var parentNode = treeDom.tree("getParent", tt);
            while (parentNode != null) {
                if (parentNode != null) {
                    treeDom.tree("expand", parentNode.target);
                    parentNode = treeDom.tree("getParent", parentNode.target);
                }
            }
        });
        treeDom.tree("select", target);
    }
    else { //异步
        if (!value) {
            treeParams.url = treeUrl;
            treeParams.queryParams = { q: '' };
        }
        else {
            treeParams.url = baseUrl;
            treeParams.queryParams = { q: value };
        }
        treeDom.tree(treeParams);
    }
}

//已设置或选择添加记录
//node:节点
function AddSelectedNode(node) {
    if (!node) return;
    var nodeList = $("#selectedNodeList");
    if (!isMutiSelect) nodeList.html('');
    var dom = document.createDocumentFragment();
    var span = document.createElement("span");
    var title = "删除"
    var clickMethod = "UnSelect(this)";
    var spClass = "attaDelete";
    var spText = "删除";
    $(span).attr("class", "attaItem");
    var a = document.createElement("a");
    $(a).attr("href", "javascript:void(0);");
    $(a).text(node.text);
    $(a).attr("dataId", node.id);
    try {
        var parentNode = treeDom.tree("getParent", node.target);
        if (parentNode && parentNode.id != GuidEmpty) {
            $(a).attr("parentId", parentNode.id);
            $(a).attr("parentText", parentNode.text);
            var parent2Node = treeDom.tree("getParent", parentNode.target);
            if (parent2Node && parent2Node.id != GuidEmpty) {
                $(a).attr("parent2Id", parent2Node.id);
                $(a).attr("parent2Text", parent2Node.text);
                var parent3Node = treeDom.tree("getParent", parent2Node.target);
                if (parent3Node && parent3Node.id != GuidEmpty) {
                    $(a).attr("parent3Id", parent3Node.id);
                    $(a).attr("parent3Text", parent3Node.text);
                    var parent4Node = treeDom.tree("getParent", parent3Node.target);
                    if (parent4Node && parent4Node.id != GuidEmpty) {
                        $(a).attr("parent4Id", parent4Node.id);
                        $(a).attr("parent4Text", parent4Node.text);
                        var parent5Node = treeDom.tree("getParent", parent4Node.target);
                        if (parent5Node && parent5Node.id != GuidEmpty) {
                            $(a).attr("parent5Id", parent5Node.id);
                            $(a).attr("parent5Text", parent5Node.text);
                        }
                    }
                }
            }
        }
    } catch (e) { }
    var sp = document.createElement("span");
    $(sp).attr("class", spClass);
    $(sp).attr("title", title);
    $(sp).attr("onclick", clickMethod);
    $(sp).attr("targetId", node.target.id);
    $(sp).text(spText);
    span.appendChild(a);
    span.appendChild(sp);
    dom.appendChild(span);
    nodeList[0].appendChild(dom);
}

//取消选择
function UnSelect(obj) {
    try {
        var targetId = $(obj).attr("targetId");
        var target = $("#" + targetId);
        treeDom.tree("uncheck", target);
    } catch (e) { }
    $(obj).parent("span.attaItem").remove();
}

//获取已选数据
//isMutiSelect:是否多选
function GetSelectData() {
    var data = [];
    $("#selectedNodeList a").each(function (i, item) {
        var dataId = $(this).attr("dataId");
        if (dataId) {
            var dataText = $(this).text();
            var obj = { Id: dataId, Name: dataText };
            //parentid
            var parentId = $(this).attr("parentId");
            var parentText = $(this).attr("parentText");
            if (parentId) {
                obj.ParentId = parentId;
                obj.ParentText = parentText;
                //parent2id
                var parent2Id = $(this).attr("parent2Id");
                var parent2Text = $(this).attr("parent2Text");
                if (parent2Id) {
                    obj.Parent2Id = parent2Id;
                    obj.Parent2Text = parent2Text;
                    //parent3id
                    var parent3Id = $(this).attr("parent3Id");
                    var parent3Text = $(this).attr("parent3Text");
                    if (parent3Id) {
                        obj.Parent3Id = parent3Id;
                        obj.Parent3Text = parent3Text;
                        //parent4id
                        var parent4Id = $(this).attr("parent4Id");
                        var parent4Text = $(this).attr("parent4Text");
                        if (parent4Id) {
                            obj.Parent4Id = parent4Id;
                            obj.Parent4Text = parent4Text;
                            //parent5id
                            var parent5Id = $(this).attr("parent5Id");
                            var parent5Text = $(this).attr("parent5Text");
                            if (parent5Id) {
                                obj.Parent5Id = parent5Id;
                                obj.Parent5Text = parent5Text;
                            }
                        }
                    }
                }
            }
            data.push(obj);
        }
    });
    return isMutiSelect ? data : data[0];
}