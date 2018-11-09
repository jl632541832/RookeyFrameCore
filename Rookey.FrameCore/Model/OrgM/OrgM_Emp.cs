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

namespace Rookey.Frame.Model.OrgM
{
    /// <summary>
    /// 员工管理
    /// </summary>
    [ModuleConfig(Name = "员工管理", ModuleEditMode = (int)ModuleEditModeEnum.TabFormEdit, PrimaryKeyFields = "Code", TitleKey = "Name", StandardJsFolder = "OrgM", Sort = 73)]
    public class OrgM_Emp : BaseOrgMEntity
    {
        #region 基础信息

        /// <summary>
        /// 员工编号
        /// </summary>
        [FieldConfig(Display = "编号", RowNum = 1, ColNum = 1, IsFrozen = true, IsRequired = true, IsUnique = true, GroupName = "基础信息", HeadSort = 0)]
        [StringLength(100)]
        public string Code { get; set; }

        /// <summary>
        /// 员工姓名
        /// </summary>
        [FieldConfig(Display = "姓名", RowNum = 1, ColNum = 2, IsFrozen = true, IsRequired = true, GroupName = "基础信息", HeadSort = 1)]
        [StringLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// 英文名
        /// </summary>
        [FieldConfig(Display = "英文名", RowNum = 2, ColNum = 1, GroupName = "基础信息", HeadSort = 2)]
        [StringLength(100)]
        public string EName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [FieldConfig(Display = "性别", ControlType = (int)ControlTypeEnum.ComboBox, RowNum = 2, ColNum = 2, GroupName = "基础信息", HeadSort = 3)]
        public int Gender { get; set; }

        /// <summary>
        /// 员工性别（枚举类型）
        /// </summary>
        [Ignore]
        public GenderEnum GenderOfEnum
        {
            get
            {
                return (GenderEnum)Enum.Parse(typeof(GenderEnum), Gender.ToString());
            }
            set { Gender = (int)value; }
        }

        /// <summary>
        /// 出生日期
        /// </summary>
        [FieldConfig(Display = "出生日期", ControlType = (int)ControlTypeEnum.DateBox, RowNum = 3, ColNum = 1, GroupName = "基础信息", HeadSort = 4)]
        public DateTime? BirthdayDate { get; set; }
        
        #endregion

        #region 联系方式
        /// <summary>
        /// 移动电话
        /// </summary>
        [FieldConfig(Display = "移动电话", ControlType = (int)ControlTypeEnum.TextBox, RowNum = 4, ColNum = 1, GroupName = "联系方式", HeadSort = 5)]
        public string Mobile { get; set; }

        /// <summary>
        /// 办公电话
        /// </summary>
        [FieldConfig(Display = "办公电话", ControlType = (int)ControlTypeEnum.TextBox, RowNum = 4, ColNum = 2, GroupName = "联系方式", HeadSort = 6)]
        public string OfficePhone { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        [FieldConfig(Display = "电子邮箱", ControlType = (int)ControlTypeEnum.TextBox, RowNum = 4, ColNum = 3, GroupName = "联系方式", HeadSort = 7)]
        public string Email { get; set; }

        #endregion

        #region 状态信息
        /// <summary>
        /// 员工状态
        /// </summary>
        [FieldConfig(Display = "员工状态", ControlType = (int)ControlTypeEnum.ComboBox, RowNum = 5, ColNum = 1, GroupName = "状态信息", HeadSort = 8)]
        public int EmpStatus { get; set; }

        /// <summary>
        /// 员工状态（枚举类型）
        /// </summary>
        [Ignore]
        public EmpStatusEnum EmpStatusOfEnum
        {
            get
            {
                return (EmpStatusEnum)Enum.Parse(typeof(EmpStatusEnum), EmpStatus.ToString());
            }
            set { EmpStatus = (int)value; }
        }

        /// <summary>
        /// 员工类型
        /// </summary>
        [FieldConfig(Display = "员工类型", ControlType = (int)ControlTypeEnum.ComboBox, RowNum = 5, ColNum = 2, GroupName = "状态信息", HeadSort = 9)]
        public int EmployeeType { get; set; }

        /// <summary>
        /// 员工类型（枚举类型）
        /// </summary>
        [Ignore]
        public EmployeeTypeEnum EmployeeTypeOfEnum
        {
            get
            {
                return (EmployeeTypeEnum)Enum.Parse(typeof(EmployeeTypeEnum), EmployeeType.ToString());
            }
            set { EmployeeType = (int)value; }
        }
        
        #endregion

        #region 其他 
        /// <summary>
        /// 部门ID
        /// </summary>
        [Ignore]
        public Guid? DeptId { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        [Ignore]
        public string DeptName { get; set; }

        /// <summary>
        /// 职务ID
        /// </summary>
        [Ignore]
        public Guid? DutyId { get; set; }

        /// <summary>
        /// 职务名称
        /// </summary>
        [Ignore]
        public string DutyName { get; set; }

        /// <summary>
        /// 自定义字段1
        /// </summary>
        [NoField]
        [StringLength(100)]
        public string F1 { get; set; }

        /// <summary>
        /// 自定义字段2
        /// </summary>
        [NoField]
        [StringLength(100)]
        public string F2 { get; set; }

        /// <summary>
        /// 自定义字段3
        /// </summary>
        [NoField]
        [StringLength(100)]
        public string F3 { get; set; }
        #endregion
    }
}