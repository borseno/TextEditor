using System.Linq;

namespace BorsenoTextEditor.Extensions
{
    static class StringExtension
    {
        public static bool In(this string @this, params string[] args) => args.Contains(@this);
    }
}
