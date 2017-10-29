using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElliottProject5
{
    public partial class Form1 : Form
    {
        public Tree tree = new Tree();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string text = System.IO.File.ReadAllText(@"BinaryTextFile.txt");

            //Splits text file by the characters below
            char[] delimiterChars = { ' ', '"', '.', ':', '\t', '\r', '\n', '?', '!', ';', '(', ')' };
            string[] words = text.Split(delimiterChars);


            foreach (string s in words)
            {
                if (!string.IsNullOrWhiteSpace(s.Replace(",", "")))
                {
                    //ToLower makes all words lowercase
                    tree.insert(s.ToLower().Replace(",", ""));
                }
            }
            string display ="";
            tree.displayTree(ref display);
            txtBox.Text = display;
            label1.Text = "Total Word Count: " + tree.counter.ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
