namespace XML_Editor
{
    public partial class Form1 : Form
    {
        Node root;
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
                    string x = File.ReadAllText(file);
                    richTextBox1.Clear();
                    richTextBox1.AppendText(x);
                    /*root = Compression.CreateHuffmanTree(x);
                    string y = Compression.HuffmanCompression(x, root);
                    BitArray bits = new BitArray(y.Length);
                    for (int i = 0; i < y.Length; i++)
                    {
                        if (y[i] == '0') bits[i] = false;
                        else bits[i] = true;
                    }
                    byte[] bytes = new byte[(bits.Length - 1) / 8 + 1];
                    bits.CopyTo(bytes, 0);
                    richTextBox1.AppendText(Compression.HuffmanCompression(x, root));
                    richTextBox2.AppendText(Compression.HuffmanDecompression(y, root));*/
                }
                catch (IOException)
                {
                }
            }
        }
    }
}