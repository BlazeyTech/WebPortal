using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Easy_Website_Developer;

namespace WebPortal
{
    public partial class ActivationForm : Form
    {
        Form1 parentform;

        public List<string> keys = new List<string>()
        {
            "98ACF-32GB0-7793A-51D0C-4G8J6"
        };
        public ActivationForm(Form1 parent)
        {
            InitializeComponent();
            this.parentform = parent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string firstName = textBox6.Text;
            string lastName = textBox7.Text;

            string serial = textBox1 + "-" + textBox2 + "-" + textBox3 + "-" + textBox4 + "-" + textBox5;

            if (serial == keys[0])
            {
                this.Close();
            }

        }

        private void ActivationForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
