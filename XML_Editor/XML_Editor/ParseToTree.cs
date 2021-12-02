using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_Editor
{
    internal class ParseToTree
    {
        /*Function Description:
         * 1-Input:XML as string after Correction
         * 2-Ouput:Returns a reference to Root after parsing XML into our Tree structure
         */
        public static Node ParsingToTree(string sample) 
        {
            Node current=null; //Used to Reference Nodes on the run
            string tag=null;
            int i = 0;
            for (; sample[i] != '<'; i++) ;

           /*1-Extracting Our Root node tag after reaching it with previous loop
            *2-Creating new root node with Tag extracted and null data
            *3-Setting Parent of our Root node to Null
            */
            string rootTag=extractOpeningTag(sample, ref i);
            Node root = new Node(rootTag, null);
            current = root;
            root.setParent(null);

            for(; i < sample.Length;) 
            {
                //Closing Tag case
                if (sample[i] == '<' && sample[i + 1] == '/')
                {

                    tag = extractClosingTag(sample, ref i);

                    if (current.getParent() == null)
                    {
                        //Case we reached to our root ,in this case for closing we reached end of string so we break the loop
                        break;
                    }
                    else
                    {
                        //We didnt reach end of string so we reference back to the parent to continue adding its children.
                        current = current.getParent();

                    }

                }
                //Opening Tag case
                else if (sample[i] == '<')
                {

                    tag = extractOpeningTag(sample, ref i); //extracting tag
                    Node node = new Node(tag, null);
                    node.setParent(current); //setting parent of the new node 
                    current.addChild(node); //adding the new node into Children of current 
                    current = node; //moving on to point to next node
                }
                //Case We have data
                else if (sample[i] != '\n' && sample[i] != '\r')
                {
                    //Extracting Data
                    string data = extractData(sample, ref i);
                    //Seting Data to our current node while parsing
                    current.setData(data);
                }
                //case there is a new line or \r we want to skip all spaces follwoing them
                else if (sample[i] == '\n' || sample[i] == '\r')
                {
                    i++; //index to next character after \n or \r
                    while (sample[i] == ' ') i++; // skip all spaces

                }
                else i++;
            }
            return root;
        }
        /*Function Description:
         * 1-Input:XML string after correction,pass by reference to our current index of XML string
         * 2-Output:Returns a string OF extracted Opening tag
         */
        public static string extractOpeningTag(string sample,ref int i)
        {
            string tag = null;
            int start = i + 1;
            int incrementer = i;//temp variable to keep i not changed
            while (sample[incrementer] != '>') incrementer++; //loop until we reach closing angle bracket
            int end = incrementer;
            incrementer = 0;
            i = end + 1;    //make i points to char after >
            tag=sample.Substring(start,end-start); //extract tag
            return tag;
        }
        /*Function Description:
         * 1-Input:XML string after correction,pass by reference to our current index of XML string
         * 2-Output:Returns a string OF extracted data
         */
        public static string extractData(string sample, ref int i)
        {
            string data = null;
            int start = i;
            int incrementer = i;//temp variable to keep i not changed
            while (incrementer < sample.Length && sample[incrementer] != '<' && sample[incrementer] != '\n'&&sample[incrementer]!='\r')
            {
                incrementer++;
            }
            int end = incrementer;
            incrementer = 0;
            data=sample.Substring(start,end-start);
            i = end;
            return data;
        }
        /*Function Description:
         * 1-Input:XML string after correction,pass by reference to our current index of XML string
         * 2-Output:Returns a string OF extracted closing tag
         */
        public static string extractClosingTag(string sample, ref int i)
        {
            string tag = null;
            int start = i + 2;  //To skip < and /
            int incrementer = i; //temp variable to keep i not changed 
            while (sample[incrementer] != '>') incrementer++;
            int end = incrementer;
            incrementer = 0;
            i = end + 1;
            tag = sample.Substring(start, end - start); //extracting the closing tag
            return tag;
        }
    }
}
