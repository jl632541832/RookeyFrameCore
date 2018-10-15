//字段格式化重写
function OverGeneralFormatter(value, row, index, moduleName, fieldName, paramsObj, fieldType) {
    var v = value != undefined && value != null ? value : '';
    if (v == '') return v;
    if (fieldName == 'Content') {
        v = '<xmp>' + v + '</xmp>';
    }
    return v;
}