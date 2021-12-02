using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_Editor
{
    internal class Prettify
    {
    /*Function Description:
     * Input:Root Node of Tree
     * Output:Generates a prettified XML as String (returns String)
     */
        public static string prettify(Node node)
        {
            string output = "";

            //Base case for recursive when we reach leaves of The tree
            if (node.getChildren().Count == 0)
            {
                //case our leaf tag is body we want tags and data on seaparate lines
                if (node.getTag() == "body")
                {
                    return output += Indent(node.getDepth()) + "<" + node.getTag() + ">" + "\n" + Indent(node.getDepth()) + node.getData() + "\n" + Indent(node.getDepth()) + "</" + node.getTag() + ">" + "\n";
                }

                //For anyother leaves We want to get tags and data on Same Line
                else
                {
                    return output += Indent(node.getDepth()) + "<" + node.getTag() + ">" +node.getData() +  "</" + node.getTag() + ">" + "\n";

                }

                //Following Comment is to be used if things go bad
                //return output +=Indent(node.getDepth())+ "<" + node.getTag() + ">" +"\n"+ Indent(node.getDepth()) + node.getData()+"\n"+ Indent(node.getDepth()) + "</" + node.getTag() + ">"+"\n";
            }

            //Constructing Opening tag in case of Non-Leaf node
            output += Indent(node.getDepth()) + '<' + node.getTag() + '>'+"\n";
            
            //Looping on children of Each Non-leaf node
            foreach (Node child in node.getChildren())
            { 
                output+=prettify(child);
            }

            //Construcing Closing Tag in case of Non-leaf node
            output += Indent(node.getDepth())+"</" + node.getTag()+">"+"\n";
            return output;
        }
        /*Function Description:
         * Input:Depth of current node
         * Output Generates The indentation based on the depth
         */
        public static string Indent(int depth)
        {
            string blank = "";
            for (int i = 0; i < depth; i++)
            {
                blank += "    ";
            }
            return blank;
        }
    }
}
