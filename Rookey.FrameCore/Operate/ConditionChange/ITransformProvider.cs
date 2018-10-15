/*----------------------------------------------------------------
        // Copyright (C) Rookey
        // ��Ȩ����
        // �����ߣ�rookey
        // Email��rookey@yeah.net
        // 
//----------------------------------------------------------------*/

using Rookey.Frame.Operate.Base.TempModel;
using System;
using System.Collections.Generic;

namespace Rookey.Frame.Operate.Base.ConditionChange
{
    public interface ITransformProvider
    {
        bool Match(ConditionItem item, Type type);
        IEnumerable<ConditionItem> Transform(ConditionItem item, Type type);
    }
}