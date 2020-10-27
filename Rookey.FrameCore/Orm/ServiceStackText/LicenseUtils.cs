// Copyright (c) ServiceStack, Inc. All Rights Reserved.
// License: https://raw.github.com/ServiceStack/ServiceStack/master/license.txt

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using ServiceStack.Text;
using ServiceStack.Text.Common;

namespace ServiceStack
{
    public class LicenseException : Exception
    {
        public LicenseException(string message) : base(message) { }
        public LicenseException(string message, Exception innerException) : base(message, innerException) {}
    }

    public enum LicenseType
    {
        Free,
        Indie,
        Business,
        Enterprise,
        TextIndie,
        TextBusiness,
        OrmLiteIndie,
        OrmLiteBusiness,
        RedisIndie,
        RedisBusiness,
        AwsIndie,
        AwsBusiness,
        Trial,
        Site,
        TextSite,
        RedisSite,
        OrmLiteSite,
    }

    [Flags]
    public enum LicenseFeature : long
    {
        None = 0,
        All = Premium | Text | Client | Common | Redis | OrmLite | ServiceStack | Server | Razor | Admin | Aws,
        RedisSku = Redis | Text,
        OrmLiteSku = OrmLite | Text,
        AwsSku = Aws | Text,
        Free = None,
        Premium = 1 << 0,
        Text = 1 << 1,
        Client = 1 << 2,
        Common = 1 << 3,
        Redis = 1 << 4,
        OrmLite = 1 << 5,
        ServiceStack = 1 << 6,
        Server = 1 << 7,
        Razor = 1 << 8,
        Admin = 1 << 9,
        Aws = 1 << 10,
    }

    public enum QuotaType
    {
        Operations,      //ServiceStack
        Types,           //Text, Redis
        Fields,          //ServiceStack, Text, Redis, OrmLite
        RequestsPerHour, //Redis
        Tables,          //OrmLite, Aws
        PremiumFeature,  //AdminUI, Advanced Redis APIs, etc
    }

    /// <summary>
    /// Internal Utilities to verify licensing
    /// </summary>
    public static class LicenseUtils
    {
        public static class FreeQuotas
        {
            public const int ServiceStackOperations = int.MaxValue;
            public const int TypeFields = int.MaxValue;
            public const int RedisTypes = int.MaxValue;
            public const int RedisRequestPerHour = int.MaxValue;
            public const int OrmLiteTables = int.MaxValue;
            public const int AwsTables = int.MaxValue;
            public const int PremiumFeature = 0;
        }
    }
}