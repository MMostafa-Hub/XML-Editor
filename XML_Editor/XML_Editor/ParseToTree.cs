using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_Editor
{
    internal class ParseToTree
    {
        public static Node ParsingToTree(string sample) 
        {
            Node current=null; //Used to Reference Nodes on the run
            int start=0 ,end=0 ; //Indices For Substrings
            int incrementer=0; //internal Use for looping
            string tag=null;
            for(int i = 0; i < sample.Length;) 
            {
                //Closing Tag case
                if(sample[i]=='<'&&sample[i+1]=='/')
                {
                    //Implement Closing tag;
                    break;
                }
                //Opening Tag case
                else if(sample[i]=='<')
                { 
                    start=i+1;
                    incrementer=i;
                    while (sample[incrementer] != '>') incrementer++;
                    end=incrementer;
                    incrementer=0;
                    i=end+1;
                    tag=sample.Substring(start,end-start); //extracting tag
                    Node node =new Node(tag,null);
                    if (current == null)
                    {
                        node.setParent(null); //setting parent of our node
                    }
                    else 
                    {
                        node.setParent(current);
                    }
                    current=node; // Saving The current Parent
                }
                //Case We have data
                else if (sample[i] != '\n' && sample[i] != '\r') 
                {
                    
                    start = i;
                    incrementer = i;
                    //We loop until we have a new tag 
                    //looping until end of string is to be fixed
                    while (incrementer <sample.Length && sample[incrementer] != '<' && sample[incrementer] != '\n')
                    {
                        incrementer++;
                    }
                    end = incrementer;
                    incrementer= 0;
                    string data=sample.Substring(start,end-start); //Extracting Data 
                    current.setData(data);
                    
                    i = end;
                }
            }
            return current;
        }
    }
}
