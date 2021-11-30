using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_Editor
{
    internal class Consistency
    {
        static string checkConsistency(string s) {
            Stack <string> st = new Stack<string>(); 

            string output= "";

            return output;
        }
        static int findChar(string s,int index,char a) {
            for (int i = index; i < s.Length; i++) {
                if (a == s[i])
                    return i;
            }
            return 0;  
        }
        static int findBetween(string s,int start, int end, char a) {
            for (int i = start; i < end; i++) {
                if (a == s[i])
                    return i;
            }
            return 0;
        }

    }
}
