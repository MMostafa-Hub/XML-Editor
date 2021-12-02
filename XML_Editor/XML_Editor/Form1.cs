using System.Collections;

namespace XML_Editor
{
    public partial class Form1 : Form
    {
        Node root;
        HuffmanNode huffmanNode;
        string input, output;
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                try
                {
                    input = File.ReadAllText(file);
                    richTextBox1.Clear();
                    richTextBox1.AppendText(input);
                    richTextBox2.Clear();
                    output = Consistency.checkConsistency(input);
                    richTextBox2.AppendText(output);
                    /*huffmanNode = Compression.CreateHuffmanTree(x);
                    string y = Compression.HuffmanCompression(x, huffmanNode);
                    BitArray bits = new BitArray(y.Length);
                    for (int i = 0; i < y.Length; i++)
                    {
                        if (y[i] == '0') bits[i] = false;
                        else bits[i] = true;
                    }
                    byte[] bytes = new byte[(bits.Length - 1) / 8 + 1];
                    bits.CopyTo(bytes, 0);
                    richTextBox1.AppendText(Compression.HuffmanCompression(x, huffmanNode));
                    richTextBox2.AppendText(Compression.HuffmanDecompression(y, huffmanNode));*/
                }
                catch (IOException)
                {
                }
            }
        }
    }
}