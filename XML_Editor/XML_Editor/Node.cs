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
        private List<Node> children;
        private int depth;

        /* NAIVE Constructor */
        public Node(string tag, string? data, Node? parent, List<Node> children, int depth)
        {
            this.tag = tag;
            this.data = data;
            this.parent = parent;
            this.children = children;
            this.depth = depth;
        }

               
        /* construct a CHILD */
        public Node(string tag, string? data, Node parent)
        {
            this.tag = tag;
            this.data = data;

            // IMP: Parent Cannot be NULL 
            this.parent = parent;
            this.depth = parent.depth++;
            this.children = new List<Node>();
        }

        /* construct a ROOT */
        public Node(string tag, string? data)
        {
            this.tag = tag;
            this.data = data;
            this.parent = null;
            this.depth = 0;
            this.children = new List<Node>();
        }

        /* Appends a node into the children list */
        public void addChild(Node child_node)
        {
            children.Append(child_node);
        }


        /* GETTERS */
        public Node? getParent()
        {
            return parent;
        }
        public List<Node> getChildren()
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
