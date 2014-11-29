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
    public partial class ImageTag : Form
    {
        Form1 parentform;

        public ImageTag(Form1 parent)
        {
            InitializeComponent();
            this.parentform = parent;
        }

        private void ImageTag_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                numericUpDown1.ReadOnly = true;
                numericUpDown2.ReadOnly = true;
            }
            else
            {
                numericUpDown1.ReadOnly = false;
                numericUpDown2.ReadOnly = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.parentform.insertImage(textBox1.Text, (int)numericUpDown1.Value, (int)numericUpDown2.Value);
            this.Close();
        }
    }
}
