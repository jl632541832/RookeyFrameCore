/*----------------------------------------------------------------
        // Copyright (C) Rookey
        // 版权所有
        // 开发者：rookey
        // Email：rookey@yeah.net
        // 
//----------------------------------------------------------------*/

using Rookey.Frame.EntityBase;
using Rookey.Frame.EntityBase.Attr;
using Rookey.Frame.Model.EnumSpace;
using ServiceStack.DataAnnotations;
using System;

namespace Rookey.Frame.Model.Sys
{
    /// <summary>
    /// 角色数据权限配置
    /// </summary>
    [ModuleConfig(Name = "数据权限配置", PrimaryKeyFields = "Sys_ModuleId,Sys_RoleId", Sort = 27, StandardJsFolder = "System")]
    public class Sys_RoleDataPowerConfig : BaseSysEntity
    {
        /// <summary>
        /// 模块Id
        /// </summary>
        [FieldConfig(Display = "模块", ControlType = (int)ControlTypeEnum.ComboBox, RowNum = 1, ColNum = 1, HeadSort = 1, ForeignModuleName = "模块管理")]
        public Guid? Sys_ModuleId { get; set; }

        /// <summary>
        /// 模块名称
        /// </summary>
        [Ignore]
        public string Sys_ModuleName { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>
        [FieldConfig(Display = "角色", ControlType = (int)ControlTypeEnum.DialogGrid, RowNum = 1, ColNum = 2, HeadSort = 2, ForeignModuleName = "角色管理")]
        public Guid? Sys_RoleId { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        [Ignore]
        public string Sys_RoleName { get; set; }

        /// <summary>
        /// 浏览规则
        /// </summary>
        [FieldConfig(Display = "浏览规则", ControlType = (int)ControlTypeEnum.TextAreaBox, RowNum = 2, ColNum = 1, ControlWidth = 490, HeadSort = 3, HeadWidth = 250)]
        [StringLength(4000)]
        public string ViewRule { get; set; }

        /// <summary>
        /// 编辑规则
        /// </summary>
        [FieldConfig(Display = "编辑规则", ControlType = (int)ControlTypeEnum.TextAreaBox, RowNum = 3, ColNum = 1, ControlWidth = 490, HeadSort = 4, HeadWidth = 250)]
        [StringLength(4000)]
        public string EditRule { get; set; }

        /// <summary>
        /// 删除规则
        /// </summary>
        [FieldConfig(Display = "删除规则", ControlType = (int)ControlTypeEnum.TextAreaBox, RowNum = 4, ColNum = 1, ControlWidth = 490, HeadSort = 5, HeadWidth = 250)]
        [StringLength(4000)]
        public string DelRule { get; set; }

        /// <summary>
        /// 是否启用自定义参数
        /// </summary>
        [FieldConfig(Display = "启用自定义参数", ControlType = (int)ControlTypeEnum.SingleCheckBox, RowNum = 5, ColNum = 1, HeadSort = 6)]
        public bool? IsEnableCustomerParams { get; set; }
    }
}
