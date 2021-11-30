using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_Editor
{
    internal class Compression
    {
        string Minifying(Node node)
        {
            //string to store the output after removing indentations and whitespaces
            string output = "";
            //if the passed node is null, return an empty string
            if (node == null) return output;
            //base case for recursive function
            //if it has no children, then it's just data (not a tag), so return it
            if (node.getChildren().Count() == 0) return output += node.getData();

            //recursive case
            //since it passed the base case, then it has children. So, it is an opening tag
            output += "<" + node.getTag() + ">";
            //call the minifying function on each child
            foreach (Node child in node.getChildren())
            {
                //append returned strings to output string
                output += Minifying(child);
            }
            //after iterating on all children, add the closing tag
            output += "</" + node.getTag() + ">";
            return output;
        }

        string HuffmanCompression(string s)
        {
            string output = "";

            return output;
        }
    }

    internal class HuffmanNode
    {
        private char c;
        private int freq;
        HuffmanNode leftNode;
        HuffmanNode rightNode;
    }
}
