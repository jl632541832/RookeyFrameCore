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
        [FieldConfig(Display = "性别", ControlType = (int)ControlTypeEnum.ComboBox, RowNum = 2, ColNum = 2, GroupName = "基础信息", HeadSort = 5)]
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
        [FieldConfig(Display = "出生日期", ControlType = (int)ControlTypeEnum.DateBox, RowNum = 3, ColNum = 1, GroupName = "基础信息", HeadSort = 6)]
        public DateTime? BirthdayDate { get; set; }

        /// <summary>
        /// 身高
        /// </summary>
        [FieldConfig(Display = "身高", ControlType = (int)ControlTypeEnum.IntegerBox, RowNum = 3, ColNum = 2, GroupName = "基础信息", HeadSort = 7)]
        public int? Height { get; set; }

        /// <summary>
        /// 学历
        /// </summary>
        [FieldConfig(Display = "学历", ControlType = (int)ControlTypeEnum.ComboBox, RowNum = 4, ColNum = 1, GroupName = "基础信息", HeadSort = 8)]
        public int Education { get; set; }

        /// <summary>
        /// 学历（枚举类型）
        /// </summary>
        [Ignore]
        public EducationEnum EducationOfEnum
        {
            get
            {
                return (EducationEnum)Enum.Parse(typeof(EducationEnum), Education.ToString());
            }
            set { Education = (int)value; }
        }

        /// <summary>
        /// 婚姻状况
        /// </summary>
        [FieldConfig(Display = "婚姻状况", ControlType = (int)ControlTypeEnum.SingleCheckBox, RowNum = 4, ColNum = 2, GroupName = "基础信息", HeadSort = 9)]
        public bool? IsMarriage { get; set; }

        /// <summary>
        /// 血型
        /// </summary>
        [FieldConfig(Display = "血型", ControlType = (int)ControlTypeEnum.ComboBox, RowNum = 5, ColNum = 1, GroupName = "基础信息", HeadSort = 10)]
        public int BloodType { get; set; }

        /// <summary>
        /// 血型（枚举类型）
        /// </summary>
        [Ignore]
        public BloodTypeEnum BloodTypeOfEnum
        {
            get
            {
                return (BloodTypeEnum)Enum.Parse(typeof(BloodTypeEnum), BloodType.ToString());
            }
            set { BloodType = (int)value; }
        }
        #endregion

        #region 联系方式
        /// <summary>
        /// 移动电话
        /// </summary>
        [FieldConfig(Display = "移动电话", ControlType = (int)ControlTypeEnum.TextBox, RowNum = 6, ColNum = 1, GroupName = "联系方式", HeadSort = 11)]
        public string Mobile { get; set; }

        /// <summary>
        /// 办公电话
        /// </summary>
        [FieldConfig(Display = "办公电话", ControlType = (int)ControlTypeEnum.TextBox, RowNum = 6, ColNum = 2, GroupName = "联系方式", HeadSort = 12)]
        public string OfficePhone { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        [FieldConfig(Display = "电子邮箱", ControlType = (int)ControlTypeEnum.TextBox, RowNum = 7, ColNum = 1, GroupName = "联系方式", HeadSort = 13)]
        public string Email { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        [FieldConfig(Display = "传真", ControlType = (int)ControlTypeEnum.TextBox, RowNum = 7, ColNum = 2, GroupName = "联系方式", HeadSort = 14)]
        public string Fax { get; set; }

        #endregion

        #region 状态信息
        /// <summary>
        /// 员工状态
        /// </summary>
        [FieldConfig(Display = "员工状态", ControlType = (int)ControlTypeEnum.ComboBox, RowNum = 8, ColNum = 1, GroupName = "状态信息", HeadSort = 15)]
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
        [FieldConfig(Display = "员工类型", ControlType = (int)ControlTypeEnum.ComboBox, RowNum = 8, ColNum = 2, GroupName = "状态信息", HeadSort = 16)]
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

        /// <summary>
        /// 最早参加工作日期
        /// </summary>
        [FieldConfig(Display = "参工日期", ControlType = (int)ControlTypeEnum.DateBox, RowNum = 9, ColNum = 1, GroupName = "状态信息", HeadSort = 17)]
        public DateTime? StartWorkDate { get; set; }

        /// <summary>
        /// 入职日期
        /// </summary>
        [FieldConfig(Display = "入职日期", ControlType = (int)ControlTypeEnum.DateBox, RowNum = 9, ColNum = 2, GroupName = "状态信息", HeadSort = 18)]
        public DateTime? EntryDate { get; set; }

        /// <summary>
        /// 转正日期
        /// </summary>
        [FieldConfig(Display = "转正日期", ControlType = (int)ControlTypeEnum.DateBox, RowNum = 10, ColNum = 1, GroupName = "状态信息", HeadSort = 19)]
        public DateTime? PositiveDate { get; set; }

        /// <summary>
        /// 离退日期
        /// </summary>
        [FieldConfig(Display = "离退日期", ControlType = (int)ControlTypeEnum.DateBox, RowNum = 10, ColNum = 2, GroupName = "状态信息", HeadSort = 20)]
        public DateTime? StatusChangeDate { get; set; }
        #endregion

        #region 国籍信仰
        /// <summary>
        /// 国籍-字典
        /// </summary>
        [FieldConfig(Display = "国籍", ControlType = (int)ControlTypeEnum.TextBox, RowNum = 11, ColNum = 1, GroupName = "国籍信仰", HeadSort = 21)]
        public string Nationality { get; set; }

        /// <summary>
        /// 籍贯-字典
        /// </summary>
        [FieldConfig(Display = "籍贯", ControlType = (int)ControlTypeEnum.TextBox, RowNum = 11, ColNum = 2, GroupName = "国籍信仰", HeadSort = 22)]
        public string Hometown { get; set; }

        /// <summary>
        /// 民族-字典
        /// </summary>
        [FieldConfig(Display = "民族", ControlType = (int)ControlTypeEnum.TextBox, RowNum = 12, ColNum = 1, GroupName = "国籍信仰", HeadSort = 23)]
        public string Political { get; set; }

        /// <summary>
        /// 宗教-字典
        /// </summary>
        [FieldConfig(Display = "宗教", ControlType = (int)ControlTypeEnum.TextBox, RowNum = 12, ColNum = 2, GroupName = "国籍信仰", HeadSort = 24)]
        public string Religion { get; set; }
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