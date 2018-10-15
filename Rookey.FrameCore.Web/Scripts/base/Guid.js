﻿//表示全局唯一标识符 (GUID)。
//使用方法：
//1、  生成一个新GUID：var guid = Guid.NewGuid();
//2、  生成一个所有值均为0的GUID：
//a)         var guid = new Guid();
//b)         var guid = Guid.Empty;
//3、  比较两个GUID是否相等：g1.Equals(g2);
//4、  获取Guid的字符串形式。其中， format为String类型的可选参数，其含义为：
//a)         “N”： xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
//b)         “D”  由连字符分隔的 32 位数字 xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
//c)         “B”  括在大括号中、由连字符分隔的 32 位数字：{xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx}
//d)         “P”  括在圆括号中、由连字符分隔的 32 位数字：(xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx)

//空guid
var GuidEmpty = '00000000-0000-0000-0000-000000000000';

function Guid(g){
     var arr = new Array(); //存放32位数值的数组    
     if (typeof(g) == "string"){ //如果构造函数的参数为字符串
         InitByString(arr, g);
     }
     else{
         InitByOther(arr);
     }
     //返回一个值，该值指示 Guid 的两个实例是否表示同一个值。
     this.Equals = function(o){
         if (o && o.IsGuid){
              return this.ToString() == o.ToString();
         }
         else{
              return false;
         }
     }
     //Guid对象的标记
     this.IsGuid = function(){}
     //返回 Guid 类的此实例值的 String 表示形式。
     this.ToString = function(format){
         if(typeof(format) == "string"){
              if (format == "N" || format == "D" || format == "B" || format == "P"){
                   return ToStringWithFormat(arr, format);
              }
              else{
                   return ToStringWithFormat(arr, "D");
              }
         }
         else{
              return ToStringWithFormat(arr, "D");
         }
     }
     //由字符串加载
     function InitByString(arr, g){
         g = g.replace(/\{|\(|\)|\}|-/g, "");
         g = g.toLowerCase();
         if (g.length != 32 || g.search(/[^0-9,a-f]/i) != -1){
              InitByOther(arr);
         }
         else{
             for (var i = 0; i < g.length; i++) {
                 var o = g.substr(i, 1);
                   arr.push(o);
              }
         }
     }
     //由其他类型加载
     function InitByOther(arr){
         var i = 32;
         while(i--){
              arr.push("0");
         }
     }
     /*
     根据所提供的格式说明符，返回此 Guid 实例值的 String 表示形式。
     N  32 位： xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
     D  由连字符分隔的 32 位数字 xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx 
     B  括在大括号中、由连字符分隔的 32 位数字：{xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx} 
     P  括在圆括号中、由连字符分隔的 32 位数字：(xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx) 
     */
     function ToStringWithFormat(arr, format){
         switch(format){
              case "N":
                   return arr.toString().replace(/,/g, "");
              case "D":
                   var str = arr.slice(0, 8) + "-" + arr.slice(8, 12) + "-" + arr.slice(12, 16) + "-" + arr.slice(16, 20) + "-" + arr.slice(20,32);
                   str = str.replace(/,/g, "");
                   return str;
              case "B":
                   var str = ToStringWithFormat(arr, "D");
                   str = "{" + str + "}";
                   return str;
              case "P":
                   var str = ToStringWithFormat(arr, "D");
                   str = "(" + str + ")";
                   return str;
              default:
                   return new Guid();
         }
     }
}
//Guid 类的默认实例，其值保证均为零。
Guid.Empty = new Guid();
//初始化 Guid 类的一个新实例。
Guid.NewGuid = function(){
     var g = "";
     var i = 32;
     while(i--){
         g += Math.floor(Math.random()*16.0).toString(16);
     }
     return new Guid(g);
}

//是否为Guid
function IsGuid(str) {
    var reg = new RegExp("[0-9a-z]{8}-[0-9a-z]{4}-[0-9a-z]{4}-[0-9a-z]{4}-[0-9a-z]{12}");
    if (str && str.length>0) {
        if (str.match(reg) != null) {
            return true;
        }
        return false;
    }
    return false;
}