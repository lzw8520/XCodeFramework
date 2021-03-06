﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCodeFramework.Core.Extensions
{
    public static class HashCodeByPropertyExtensions
    {
        public static int GetHashCodeOnProperties<T>(this T inspect)
        {
            return inspect.GetType().GetProperties().Select(o => o.GetValue(inspect)).GetListHashCode();
        }

        public static int GetListHashCode<T>(this IEnumerable<T> sequence)
        {
            return sequence
                .Select(item => item == null ? 0 : item.GetHashCode())
                .Aggregate((total, nextCode) => total ^ nextCode);
        }
    }
}
