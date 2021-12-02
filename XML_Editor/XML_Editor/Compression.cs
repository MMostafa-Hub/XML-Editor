using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_Editor
{
    internal class Compression
    {
        public static string Minifying(Node node)
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
        private static PriorityQueue<HuffmanNode,int> CharacterFrequencies(string s)
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

        //This function takes a string and uses Huffman Algorithm to create a Huffman tree based on the frequency of its characters and returns the root
        public static HuffmanNode CreateHuffmanTree(string s)
        {
            //heap that holds each character and its frequency
            PriorityQueue<HuffmanNode,int> heap = CharacterFrequencies(s);
            //create root node
            HuffmanNode root = new HuffmanNode();
            while (heap.Count > 1)
            {
                //character with least frequency
                HuffmanNode x = heap.Dequeue();
                //character with second least frequency
                HuffmanNode y = heap.Dequeue();
                //new node that will hold the sum of their frequencies
                HuffmanNode f = new HuffmanNode();
                f.setFreq(x.GetFreq() + y.GetFreq());
                //set the new node's left node to character with least frequency
                f.leftNode = x;
                //set the new node's right node to character with second least frequency
                f.rightNode = y;
                //set root to be this new node
                root = f;
                //add the new node to the heap
                heap.Enqueue(f, f.GetFreq());
            }

            return root;
        }

        /*this function takes a Huffman tree and an array. The function stores the Huffman code of each character in its
         respective Unicode index*/
        private static string[] CodeArray(HuffmanNode root, string[] array, string code = "")
        {
            //if the function reached a character node
            if (root.leftNode == null && root.rightNode == null)
            {
                //put its code in its corresponding index
                array[(int)root.GetC()] = code; 
                return array;
            }
            //go to left node and add '0' to the code
            CodeArray(root.leftNode, array, code + "0");
            //go to right node and add '1' to the code
            CodeArray(root.rightNode, array, code + "1");
            return array;
        }

        private static string HuffmanEncoding(string input, string[] CodeArray)
        {
            string output = "";
            for (int i = 0; i < input.Length; i++)
            {
                output += CodeArray[input[i]];
            }
            return output;
        }


        public static string HuffmanDecompression(string input, HuffmanNode root)
        {
            string output = "";
            HuffmanNode point = root;
            for (int i = 0;i < input.Length;i++)
            {
                if (input[i] == '0') point = point.leftNode;
                else point = point.rightNode;
                if (point.leftNode == null && point.rightNode == null)
                {
                    output += point.GetC();
                    point = root;
                }
            }
            return output;
        }

        public static string HuffmanCompression(string input, HuffmanNode root)
        {
            return HuffmanEncoding(input, CodeArray(root, new string[1112064]));
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
