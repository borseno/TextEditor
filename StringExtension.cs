using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorsenoTextEditor
{
    static class StringExtension
    {
        public static bool In(this string @this, params string[] args) => args.Contains(@this);
    }
}
