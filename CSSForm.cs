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
    public partial class CSSForm : Form
    {
        Form1 parentForm;

        public CSSForm(Form1 parent)
        {
            InitializeComponent();
            this.parentForm = parent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool [] a = new bool[5];
            for (int i = 0; i < 6; i++) 
            {
                if (checkedListBox1.GetItemChecked(i) == true) 
                {
                    a[i] = true;
                }
            }

            string one = comboBox2.SelectedIndex.ToString();
            string two = comboBox3.SelectedIndex.ToString();

            //this.parentForm.cssFormAnimation(textBox1.Text, (int)numericUpDown1.Value, a, (int) numericUpDown2.Value, numericUpDown3.Value, one, two);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
