using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AIS
{
    class Split
    {
        public string[] RegexSplit(string text)
        {
            string[] str = Regex.Split(text, " ");
            return str;
        }
    }
}
