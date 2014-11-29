using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Easy_Website_Developer;
using System.IO;

namespace WebPortal
{
    public partial class IFrameForm : Form
    {
        Form1 parentform;
        public IFrameForm(Form1 parentform)
        {
            InitializeComponent();
            this.parentform = parentform;
        }
        public IFrameForm(Form1 parentform, string a)
        {
            InitializeComponent();
            this.parentform = parentform;

            if (a != null)
            {
                textBox1.Text = a;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parentform.insertIFrame(textBox1.Text, comboBox1.SelectedIndex, (int)numericUpDown1.Value, (int)numericUpDown2.Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string a = Form1.strfilename;

            Stream myStream;
            OpenFileDialog openFile = new OpenFileDialog();

            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if ((myStream = openFile.OpenFile()) != null)
                {
                    string str = openFile.FileName;

                    int index = str.LastIndexOf("\\");

                    textBox1.Text = str.Substring(index + 1);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
