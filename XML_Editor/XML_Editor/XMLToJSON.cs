using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_Editor
{
    internal class XMLToJSON
    {
        /*
         * Description: Converst the XML into JSON 
         * inputs: the root node of the XML Tree
         * outputs : JSON string
         */
        public static string convertToJSON(Node node)
        {
            /* the tab equals 4 spaces */
            string indentations = (String.Concat(Enumerable.Repeat("    ", (node.getDepth() + 1))));

            /* Base Case */
            /* if it's a leaf NODE */
            if (node.getChildren().Count == 0)
            {
                /* if the node's parent is an Array then we should print only the value */
                if (isArray(node.getParent()))
                    return indentations + "\"" + node.getData() + "\"";
                else
                    return indentations + "\"" + node.getTag() + "\" : \"" + node.getData() + "\"";
            }


            /* Case if it's a non-leaf NODE */

            /* if the node is an ARRAY then the prackets should be square '[' else it should be curly '{' */
            /* the node is an ARRAY if all of its chilren's Tag are same */
            char bracket = isArray(node) ? '[' : '{';

            /* If the Node is not a leaf and its Parent is an Array */
            /* Then we shouldn't print the tag */
            string str = isArray(node.getParent()) ? indentations + bracket + "\n" : indentations + "\"" + node.getTag() + "\": " + bracket + "\n";

            /* RECURSION */
            for (int i = 0; i < node.getChildren().Count; i++)
            {
                /* recursos on the children of the node */
                str += convertToJSON(node.getChildren()[i]);

                /* handles the commas ',' and the newlines '\n' */
                if (i < node.getChildren().Count - 1)
                {
                    str += ",\n";
                }

            }
            str += '\n' + indentations + (char)(bracket + 2);


            return str;
        }
        /*
         * Description: checks if the node represents an Array or not 
         * input: node
         * output: boolean, if the node is array it returns true else it will returns false
         */
        public static bool isArray(Node? node)
        {
            /* If the nodes is null or The Children Count is equal to 1 it return False*/
            if (node == null || node.getChildren().Count() == 1) return false;

            string? refrenceTag = node.getChildren()[0].getTag();

            /* it loops over the node's children */
            /* if one of the children does have a Tag differnt from the Refrence Taf it return False */
            foreach (Node child in node.getChildren())
            {
                if (child.getTag() != refrenceTag)
                    return false;
            }
            return true;
        }
    }
}
