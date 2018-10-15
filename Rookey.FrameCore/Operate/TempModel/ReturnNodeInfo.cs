using Rookey.Frame.Model.Bpm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rookey.Frame.Operate.Base.TempModel
{
    /// <summary>
    /// 流程回退信息
    /// </summary>
    public class ReturnNodeInfo
    {
        /// <summary>
        /// 回退节点
        /// </summary>
        public Bpm_WorkNode ReturnNode { get; set; }

        /// <summary>
        /// 回退时，退回节点审批后是否直接回到当前审批节点
        /// </summary>
        public bool? IsReturnBack { get; set; }

        /// <summary>
        /// 如果IsReturnBack=true，存储当前审批节点ID
        /// </summary>
        public Guid? ReturnBackNextNode { get; set; }
    }
}
