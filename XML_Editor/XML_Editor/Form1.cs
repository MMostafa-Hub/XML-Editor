using System.Collections;

namespace XML_Editor
{
    public partial class Form1 : Form
    {
        Node root;
        HuffmanNode huffmanNode;
        string input, output;
        bool json = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            json = false;
            richTextBox1.Clear();
            richTextBox1.AppendText(output);
            richTextBox2.Clear();
            richTextBox2.AppendText(Compression.Minifying(root));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text Files (.txt)| *.txt";
            huffmanNode = Compression.CreateHuffmanTree(richTextBox2.Text);
            string y = Compression.HuffmanCompression(richTextBox2.Text, huffmanNode);
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                BitArray bits = new BitArray(y.Length);
                for (int i = 0; i < y.Length; i++)
                {
                    if (y[i] == '0') bits[i] = false;
                    else bits[i] = true;
                }
                byte[] bytes = new byte[(bits.Length - 1) / 8 + 1];
                bits.CopyTo(bytes, 0);
                using (BinaryWriter binWriter = new BinaryWriter(File.Create(saveFileDialog1.FileName)))
                {
                    binWriter.Write(bytes);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                List<byte> bytes = new List<byte>();
                using (BinaryReader binReader = new BinaryReader(File.Open(openFileDialog2.FileName, FileMode.Open)))
                {
                    while (binReader.BaseStream.Position != binReader.BaseStream.Length)
                    {
                        bytes.Add(binReader.ReadByte());
                    }
                }
                BitArray bits = new BitArray(bytes.ToArray());
                string s = "";
                for (int i = 0; i < bits.Length; i++)
                {
                    if (bits[i] == true) s += "1";
                    else s += "0";
                }
                richTextBox1.Clear();
                richTextBox1.AppendText(output);
                richTextBox2.Clear();
                richTextBox2.AppendText(Compression.HuffmanDecompression(s, huffmanNode));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            json = false;
            richTextBox1.Clear();
            richTextBox1.AppendText(output);
            richTextBox2.Clear();
            richTextBox2.AppendText(Prettify.prettify(root));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            json = true;
            richTextBox1.Clear();
            richTextBox1.AppendText(output);
            richTextBox2.Clear();
            richTextBox2.AppendText("{\n" + XMLToJSON.convertToJSON(root) + "\n}");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (json) saveFileDialog1.Filter = "Json files (*.json)|*.json";
            else saveFileDialog1.Filter = "XML Document (.xml)|*.xml";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, richTextBox2.Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            json = false;
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
                    root = ParseToTree.ParsingToTree(output);
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = true;
                    button5.Enabled = true;
                    button6.Enabled = true;
                    button7.Enabled = true;
                }
                catch (IOException)
                {
                }
            }
        }
    }
}