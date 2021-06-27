using System;
namespace Mars.Utils.Extensions
{
    public static class DecimalExtensions
    {
        public static decimal ToDecimal(this object obj) => Convert.ToDecimal(obj);
    }
}
