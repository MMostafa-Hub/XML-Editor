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

        //This function returns a priority queue of the characters in the string and their frequencies
        PriorityQueue<char,int> CharacterFrequencies(string s)
        {
            //the priority queue to be returned
            PriorityQueue<char,int> heap = new PriorityQueue<char,int>();
            //used to store the frequency of each character. XML files use UTF-8 encoding which has 1,112,064 different characters
            int[] frequencyArray = new int[1112064];
            //loop on every character in the string
            for (int i = 0; i < s.Length; i++)
            {
                //increment the frequency of this character in the array
                frequencyArray[s[i]]++;
            }
            for (int i = 0; i < frequencyArray.Length; i++)
            {
                //add character to queue if it occurred at least once in the string
                if (frequencyArray[i] != 0) heap.Enqueue((char)i, frequencyArray[i]);
            }
            return heap;
        }


    }

    internal class HuffmanNode
    {
        private char c;
        private int freq;
        HuffmanNode leftNode;
        HuffmanNode rightNode;

        HuffmanNode(char c, int freq)
        {
            this.c = c;
            this.freq = freq;
            leftNode = null;
            rightNode = null;
        }
    }
}
