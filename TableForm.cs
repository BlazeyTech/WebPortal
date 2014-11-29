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
    public partial class TableForm : Form
    {
        Form1 parentform;

        public TableForm(Form1 parent)
        {
            InitializeComponent();
            this.parentform = parent;
        }

        private void TableForm_Load(object sender, EventArgs e)
        {
            numericUpDown1.Increment = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (numericUpDown1.Value > -1 && numericUpDown2.Value > -1)
            {
                if (checkBox1.Checked != false)
                {
                    this.parentform.insertTable((int)numericUpDown1.Value, (int)numericUpDown2.Value, true);
                }
                else
                {
                    this.parentform.insertTable((int)numericUpDown1.Value, (int)numericUpDown2.Value, false);
                }
            }

            this.Close();
        }
    }
}
