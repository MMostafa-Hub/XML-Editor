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
            int index = 0;
            while (index < s.Length) {
                if (s[index] == '<') {
                    int open = findChar(s, index, '<');
                    if (s[open + 1] != '/')
                    { //openning tag 
                        int close = findChar(s, open + 1, '>');
                        string str = s.Substring(open + 1, close - open - 1);//without <>
                        st.Push(str);
                        output += s.Substring(index, close - index); 
                        index = close;
                    }
                    else
                    { //closing tag
                        int slash=findChar(s, index, '/');
                        int close = findChar(s,  index , '>');
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
                    index= close;
                    }
                }
                if (s[index] != '<') 
                { //data
                    int open = findChar(s, index, '<');
                    output += s.Substring(index, open - index - 1);
                    index = open - 1;
                }
                
                
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
    /*
                 for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '<')
                {
                    if (s[i + 1] != '/')
                    { //openning tag
                        int closetag = findChar(s, i + 1, '>');
                        string str = s.Substring(i + 1, i-closetag-1); //str = ussers not <users>
                        output += s.Substring(i, closetag-i); //save the open tag in output <>
                        if (s[endtag + 1] == '<') 
                        { //another openning of child 
                            int endchildtag = findChar(s, endtag + 2, '>');
                            string childstr = s.Substring(endtag + 2, endchildtag - 1);
                            output += s.Substring(endtag + 1, endchildtag);
                        }
                    }
                    else 
                    { //closing tag
                        if (s[i + 1] == '/')
                        {
                            int endtag = findChar(s, i + 1, '>');
                            string tagend = s.Substring(i + 2, endtag - 1); //end tag
                            if (tagend == st.Peek())
                            { //compare the end tag with the top of stack
                                output += s.Substring(i, endtag);
                                st.Pop();
                           }
                            else 
                            {
                            
                            }
                        }
                    }

                }
            } 
*/
}
