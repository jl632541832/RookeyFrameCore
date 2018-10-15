/*----------------------------------------------------------------
        // Copyright (C) Rookey
        // 版权所有
        // 开发者：rookey
        // Email：rookey@yeah.net
        // 
//----------------------------------------------------------------*/

using Rookey.Frame.EntityBase;
using Rookey.Frame.EntityBase.Attr;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;

namespace Rookey.Frame.Model.Bpm
{
    /// <summary>
    /// 流程代理
    /// </summary>
    [ModuleConfig(Name = "流程代理", PrimaryKeyFields = "Bpm_WorkFlowId,Bpm_WorkNodeId,OrgM_EmpId,OrgM_DeptId", Sort = 82, StandardJsFolder = "Bpm")]
    public class Bpm_FlowProxy : BaseBpmEntity
    {
        /// <summary>
        /// 流程Id
        /// </summary>
        [FieldConfig(Display = "流程", ControlType = (int)ControlTypeEnum.ComboBox, IsRequired = true, RowNum = 1, ColNum = 1, HeadSort = 1, ForeignModuleName = "流程信息")]
        public Guid? Bpm_WorkFlowId { get; set; }

        /// <summary>
        /// 流程名称
        /// </summary>
        [Ignore]
        public string Bpm_WorkFlowName { get; set; }

        /// <summary>
        /// 流程节点Id
        /// </summary>
        [FieldConfig(Display = "节点", ControlType = (int)ControlTypeEnum.ComboBox, IsRequired = true, RowNum = 1, ColNum = 2, HeadSort = 2, ForeignModuleName = "流程结点")]
        public Guid? Bpm_WorkNodeId { get; set; }

        /// <summary>
        /// 父流程节点名称
        /// </summary>
        [Ignore]
        public string Bpm_WorkNodeName { get; set; }

        /// <summary>
        /// 被代理人
        /// </summary>
        [FieldConfig(Display = "被代理人", ControlType = (int)ControlTypeEnum.DialogTree, IsRequired = true, RowNum = 2, ColNum = 1, HeadWidth = 80, HeadSort = 3, ForeignModuleName = "员工管理")]
        public Guid? OrgM_EmpId { get; set; }

        /// <summary>
        /// 被代理人
        /// </summary>
        [Ignore]
        public string OrgM_EmpName { get; set; }

        /// <summary>
        /// 被代理人部门
        /// </summary>
        [FieldConfig(Display = "被代理人部门", ControlType = (int)ControlTypeEnum.DialogTree, RowNum = 2, ColNum = 2, HeadWidth = 80, HeadSort = 4, ForeignModuleName = "部门管理")]
        public Guid? OrgM_DeptId { get; set; }

        /// <summary>
        /// 被代理人部门
        /// </summary>
        [Ignore]
        public string OrgM_DeptName { get; set; }

        /// <summary>
        /// 代理人
        /// </summary>
        [FieldConfig(Display = "代理人", ControlType = (int)ControlTypeEnum.DialogTree, IsRequired = true, RowNum = 3, ColNum = 1, HeadWidth = 80, HeadSort = 5, ForeignModuleName = "员工管理")]
        public Guid? OrgM_EmpProxyId { get; set; }

        /// <summary>
        /// 代理人
        /// </summary>
        [Ignore]
        public string OrgM_EmpProxyName { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        [FieldConfig(Display = "是否启用", ControlType = (int)ControlTypeEnum.SingleCheckBox, DefaultValue = "1", RowNum = 3, ColNum = 2, HeadSort = 6)]
        public bool IsValid { get; set; }

        /// <summary>
        /// 有效开始时间
        /// </summary>
        [FieldConfig(Display = "有效开始时间", ControlType = (int)ControlTypeEnum.DateTimeBox, RowNum = 4, ColNum = 1, HeadSort = 7)]
        public DateTime? ValidStartTime { get; set; }

        /// <summary>
        /// 有效结束时间
        /// </summary>
        [FieldConfig(Display = "有效结束时间", ControlType = (int)ControlTypeEnum.DateTimeBox, RowNum = 4, ColNum = 2, HeadSort = 8)]
        public DateTime? ValidEndTime { get; set; }
    }
}
