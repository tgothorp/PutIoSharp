using System.Linq;

namespace PutIo.Sharp.Extensions
{
    internal static class StringExtensions
    {
        internal static bool IsEmptyOrAllSpaces(this string str)
        {
            return null != str && str.All(c => c.Equals(' '));
        }
    }
}