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
            Stack<string> st = new Stack<string>();
            string output = "";
            int index = 0;
            while (index < s.Length)
            {

                if (s[index] == '<')
                {
                    int open = findChar(s, index, '<');
                    if (s[open + 1] != '/')
                    { //openning tag 
                        int close = findChar(s, open + 1, '>');
                        string str = s.Substring(open + 1, close - open - 1);//without <>
                        st.Push(str);
                        output += s.Substring(index, close - index+1);
                        index = close;
                        index++;
                        continue;
                    }
                    else
                    { //closing tag
                        int slash = findChar(s, index, '/');
                        int close = findChar(s, index, '>');
                        string str = s.Substring(slash + 1, close - slash - 1);
                        if (str == st.Peek())
                        {
                            output += "<" + "/" + st.Peek() + ">";
                            st.Pop();
                        }
                        else
                        {
                            while (str != st.Peek())
                            {
                                output += "<" + "/" + st.Peek() + ">";
                                st.Pop();
                            }
                            st.Pop();
                        }
                        index = close;
                        index++;
                        continue;
                    }
                }
                if (s[index] != '<')
                { //data
                    int open = findChar(s, index, '<');
                    int length = open - index;
                    output += s.Substring(index);
                    index = open - 1;
                    index++;
                    continue;
                }

            }
            while (st.Count != 0)
            {
                output += "</" + st.Peek() + ">";
                st.Pop();
            }
            return output;
        }
        static int findChar(string s,int index,char a) {
            for (int i = index; i < s.Length; i++) {
                if (a == s[i])
                    return i;
            }
            return -1;  
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
