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
    public partial class VideoTag : Form
    {
        Form1 parentform;

        public VideoTag(Form1 parent)
        {
            InitializeComponent();
            this.parentform = parent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.parentform.insertVideo(textBox1.Text, textBox2.Text, textBox3.Text, (int)numericUpDown1.Value, (int)numericUpDown2.Value);
            this.Close();
        }

        private void VideoTag_Load(object sender, EventArgs e)
        {

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

        private void button3_Click(object sender, EventArgs e)
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

                    textBox2.Text = str.Substring(index + 1);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
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

                    textBox3.Text = str.Substring(index + 1);
                }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
