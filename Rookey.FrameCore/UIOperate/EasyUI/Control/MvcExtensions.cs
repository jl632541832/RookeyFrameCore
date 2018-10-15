/*----------------------------------------------------------------
        // Copyright (C) Rookey
        // 版权所有
        // 开发者：rookey
        // Email：rookey@yeah.net
        // 
//----------------------------------------------------------------*/

using Rookey.Frame.Common;
using System;
using System.Text;

namespace Rookey.Frame.UIOperate.Control
{
    /// <summary>
    /// EasyUI扩展控件
    /// </summary>
    public static class MvcExtensions
    {
        public static string CreateCheckbox(string name, string displayText, object value = null, int index = -1, bool isAllowEdit = true, string otherAttr = null)
        {
            StringBuilder htmlBuilder = new StringBuilder();
            if (index > 0) //多选checkbox
            {
                htmlBuilder.Append("<span style=\"margin-right:5px;\">");
            }
            string idStr = index >= 0 ? name + index : name;
            string disabledStr = isAllowEdit ? string.Empty : "disabled=\"disabled\"";
            string checkedStr = value == null ? string.Empty : (value.ToString() == "1" ? "checked=\"checked\"" : string.Empty);
            htmlBuilder.Append("<input " + (otherAttr == null ? string.Empty : otherAttr) + " type=\"checkbox\" " + disabledStr + " name=\"" + name + "\" id=\"" + idStr + "\" value=\"" + (value == null ? string.Empty : value.ToString()) + "\" " + checkedStr + " />");
            if (index >= 0)
            {
                if (!string.IsNullOrWhiteSpace(displayText))
                {
                    htmlBuilder.Append("<label for=\"" + idStr + "\">" + displayText + "</label>");
                }
                htmlBuilder.Append("</span>");
            }
            return htmlBuilder.ToString();
        }

        public static string CreateMutiCheckbox(string name, string chkTexts, string chkValues, object value = null, bool isAllowEdit = true, string otherAttr = null)
        {
            bool isCanEdit = isAllowEdit;
            string[] values = string.IsNullOrWhiteSpace(chkValues) ? null : chkValues.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            string[] texts = string.IsNullOrWhiteSpace(chkTexts) ? null : chkTexts.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            if (values != null && texts != null && values.Length > 0 && texts.Length > 0 && texts.Length == values.Length)
            {
                StringBuilder sb = new StringBuilder();
                string[] tempValues = values;
                if (value != null && !string.IsNullOrEmpty(value.ToString())) //编辑时赋值
                {
                    try
                    {
                        string[] token = value.ToString().Split(",".ToCharArray());
                        if (token.Length == values.Length)
                        {
                            tempValues = token;
                        }
                    }
                    catch
                    { }
                }
                for (int i = 0; i < tempValues.Length; i++)
                {
                    sb.Append(CreateCheckbox(name, texts[i], tempValues[i], i, isCanEdit, otherAttr));
                }
                return sb.ToString();
            }
            else
            {
                bool valueBool = value.ObjToBool();
                value = valueBool ? "1" : "0";
                string htm = CreateCheckbox(name, "", value, -1, isCanEdit, otherAttr);
                return htm;
            }
        }

        public static string CreateRadioButton(string name, string displayText, object value = null, int index = -1, bool isAllowEdit = true)
        {
            StringBuilder htmlBuilder = new StringBuilder();
            htmlBuilder.Append("<span style=\"margin-right:5px;\">");
            string idStr = index >= 0 ? name + index : name;
            string disabledStr = isAllowEdit ? string.Empty : "disabled=\"disabled\"";
            htmlBuilder.Append("<input type=\"radio\" " + disabledStr + " name=\"" + name + "\" id=\"" + idStr + "\" value=\"" + value + "\" />");
            if (!string.IsNullOrWhiteSpace(displayText))
            {
                htmlBuilder.Append("<label for=\"" + idStr + "\">" + displayText + "</label>");
            }
            htmlBuilder.Append("</span>");

            return htmlBuilder.ToString();
        }

        public static string CreateMutiRadioButton(string name, string rdTexts, string rdValues, object value = null, bool isAllowEdit = true)
        {
            bool isCanEdit = isAllowEdit;
            string[] values = string.IsNullOrWhiteSpace(rdValues) ? null : rdValues.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            string[] texts = string.IsNullOrWhiteSpace(rdTexts) ? null : rdTexts.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            if (values != null && texts != null && values.Length > 0 && texts.Length > 0 && texts.Length == values.Length)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < values.Length; i++)
                {
                    sb.Append(CreateRadioButton(name, texts[i], values[i], i, isCanEdit));
                }
                string js = SetRadioButtonDefaultValue(name, value);
                sb.Append(js);
                return sb.ToString();
            }
            else
            {
                string htm = CreateRadioButton(name, "", value, -1, isCanEdit);
                string js = SetRadioButtonDefaultValue(name, value);
                return htm + js;
            }
        }

        private static string SetRadioButtonDefaultValue(string name, object value)
        {
            StringBuilder jsBuilder = new StringBuilder();
            jsBuilder.Append("<script type=\"text/javascript\">");
            jsBuilder.Append("$(function () {");
            jsBuilder.Append("$('input[type=radio][name=" + name + "][value=" + value + "]').attr('checked',true);");
            jsBuilder.Append("})");
            jsBuilder.Append("</script>");
            return jsBuilder.ToString();
        }
    }
}
