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
            string output = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ' || str[i] == '\n') continue;
                else output += str[i];
            }
            return output;
        }
    }
}
