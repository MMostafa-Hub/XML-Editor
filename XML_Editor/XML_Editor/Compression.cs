using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_Editor
{
    internal class Compression
    {
        string Minifying(string str)
        {
            return str.Replace("\n", "").Replace("\r", "").Replace(" ", "");
        }
    }
}
