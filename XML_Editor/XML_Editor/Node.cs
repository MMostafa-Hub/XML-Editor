using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_Editor
{
    internal class Node
    {
        /* 
         * <tag> // Parent depth = 1
         *      <tag> data </tag> // Child, depth = 0
         * <tag> 
         */
        private string tag; 
        private string? data;
        private Node? parent;
        private List<Node>? children;
        private int depth;

        public Node(string tag, string? data, Node? parent, List<Node>? children, int depth)
        {
            this.tag = tag;
            this.data = data;
            this.parent = parent;
            this.children = children;
            this.depth = depth;
        }

        public Node? getParent()
        {
            return parent;
        }
        public List<Node>? getChildren()
        {
            return children;
        }
        public string getTag()
        {
            return tag;
        }
        public string? getData()
        {
            return data;
        }
        public int getDepth()
        {
            return depth;
        }
    }
}
