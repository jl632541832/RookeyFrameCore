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

namespace Rookey.Frame.Model.Other
{
    /// <summary>
    /// 分布式锁
    /// </summary>
    [ModuleConfig(Name = "分布式锁", Sort = 1, IsAllowAdd = false, IsAllowEdit = false, StandardJsFolder = "Other")]
    [CompositeIndex(true, "ModuleFlag", "Method_Flag")]
    public class Other_DistributedLock : BaseOtherEntity
    {
        /// <summary>
        /// 模块标识
        /// </summary>
        [FieldConfig(Display = "模块标识", RowNum = 1, ColNum = 1, ControlType = (int)ControlTypeEnum.LabelBox, HeadSort = 1)]
        [StringLength(100)]
        public string ModuleFlag { get; set; }

        /// <summary>
        /// 方法标识
        /// </summary>
        [FieldConfig(Display = "方法标识", RowNum = 1, ColNum = 2, ControlType = (int)ControlTypeEnum.LabelBox, HeadSort = 2)]
        [StringLength(50)]
        public string Method_Flag { get; set; }

        /// <summary>
        /// 更新时间戳
        /// </summary>
        [FieldConfig(Display = "更新时间", RowNum = 2, ColNum = 1, ControlType = (int)ControlTypeEnum.LabelBox, HeadSort = 3)]
        public double Update_Timesamp { get; set; }

        /// <summary>
        /// 失效时间戳
        /// </summary>
        [FieldConfig(Display = "失效时间", RowNum = 2, ColNum = 2, ControlType = (int)ControlTypeEnum.LabelBox, HeadSort = 3)]
        public double Invalid_Timesamp { get; set; }

        /// <summary>
        /// 服务器
        /// </summary>
        [FieldConfig(Display = "服务器", RowNum = 3, ColNum = 1, ControlType = (int)ControlTypeEnum.LabelBox, HeadSort = 4)]
        [StringLength(20)]
        public string Maching { get; set; }

        /// <summary>
        /// 进程ID
        /// </summary>
        [FieldConfig(Display = "进程ID", RowNum = 3, ColNum = 2, ControlType = (int)ControlTypeEnum.LabelBox, HeadSort = 5)]
        [StringLength(20)]
        public string ProcessId { get; set; }

        /// <summary>
        /// 线程ID
        /// </summary>
        [FieldConfig(Display = "线程ID", RowNum = 4, ColNum = 1, ControlType = (int)ControlTypeEnum.LabelBox, HeadSort = 6)]
        [StringLength(20)]
        public string ThreadId { get; set; }

        /// <summary>
        /// 锁描述
        /// </summary>
        [FieldConfig(Display = "锁描述", RowNum = 4, ColNum = 2, ControlType = (int)ControlTypeEnum.LabelBox, HeadSort = 7)]
        [StringLength(100)]
        public string Des { get; set; }
    }
}
