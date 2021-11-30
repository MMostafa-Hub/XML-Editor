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
            //if it has no children, then it's a tag and its data, so return their string
            if (node.getChildren().Count() == 0) return output += "<" + node.getTag() + ">" + node.getData() + "</" + node.getTag() + ">";

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

        //This function returns a priority queue of HuffmanNodes of the characters in the string and their frequencies
        PriorityQueue<HuffmanNode,int> CharacterFrequencies(string s)
        {
            //the priority queue to be returned
            PriorityQueue<HuffmanNode,int> heap = new PriorityQueue<HuffmanNode,int>();
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
                //add character's HuffmanNode to queue if it occurred at least once in the string
                if (frequencyArray[i] != 0) heap.Enqueue(new HuffmanNode((char)i, frequencyArray[i]), frequencyArray[i]);
            }
            return heap;
        }

        HuffmanNode CreateHuffmanTree(PriorityQueue<HuffmanNode, int> heap)
        {
            HuffmanNode root = new HuffmanNode();
            while (heap.Count > 1)
            {
                HuffmanNode x = heap.Dequeue();
                HuffmanNode y = heap.Dequeue();
                HuffmanNode f = new HuffmanNode();
                f.setFreq(x.GetFreq() + y.GetFreq());
                f.leftNode = x;
                f.rightNode = y;
                root = f;
                heap.Enqueue(f, f.GetFreq());
            }

            return root;
        }
    }

    internal class HuffmanNode
    {
        private char? c;
        private int freq;
        public HuffmanNode? leftNode;
        public HuffmanNode? rightNode;

        public HuffmanNode()
        {
            
        }

        public HuffmanNode(char c, int freq)
        {
            this.c = c;
            this.freq = freq;
            leftNode = null;
            rightNode = null;
        }
        public char? GetC()
        {
            return c;
        }

        public int GetFreq()
        {
            return freq;
        }

        public void setC(char c)
        {
            this.c = c;
        }

        public void setFreq(int freq)
        {
            this.freq= freq;
        }
    }
}
