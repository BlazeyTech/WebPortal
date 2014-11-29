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
    public partial class ListTagForm : Form
    {
        Form1 parent;

        public ListTagForm(Form1 parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = 0;

            if (comboBox1.SelectedIndex == 0)
            {
                a = 0;
            }
            else
            {
                a = 1;
            }

            parent.insertList(a, (int)numericUpDown1.Value);
            this.Close();
        }
    }
}
