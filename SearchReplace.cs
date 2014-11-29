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
    public partial class SearchReplace : Form
    {
        Form1 parentForm;

        public static Boolean checkReplace = false;

        public SearchReplace(Form1 parent)
        {
            InitializeComponent();
            this.parentForm = parent;
        }
        void form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
        public void button1_Click(object sender, EventArgs e)
        {
            this.parentForm.searchText(textBox1.Text);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkReplace = true;
            }
            else
            {
                checkReplace = false;
            }
            
            this.parentForm.replaceText(checkReplace, textBox2.Text, textBox3.Text);
        }



        // Not working, attempt at getting enter to search
        private void SearchReplace_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (checkBox1.Checked == true)
                {
                    checkReplace = true;
                }
                else
                {
                    checkReplace = false;
                }

                this.parentForm.replaceText(checkReplace, textBox2.Text, textBox3.Text);
            }
        }

    }
}
