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
    public partial class FormSettings : Form
    {
        Form1 parentForm;

        private int tabCheck = 1;
        private string comBox1 = "Courier New"; //font family
        private string comBox2 = "White"; //font color
        private string comBox3 = "Gray"; //background color
        private int comBox4 = 10; // font size 10, 3rd down but index 2
        private bool symbolInsert = false;

        private string[] box1 = {"Arial", "Calibri", "Corbel", "Courier New", "EuroRoman",
                                "Franklin Gothic Book", "Helvetica", "Myriad Pro",
                                "Segoe UI", "Typewriter Text"};
        private string[] box2 = { "Black", "Blue", "Brown", "Green", "Gray", "Orange", "Red", "White", "Yellow" };
        private string[] box3 = { "Black", "Blue", "Brown", "Green", "Gray", "Orange", "Red", "White", "Yellow" };

        public FormSettings(Form1 parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
        }
        public FormSettings(Form1 parentForm, string comBox1, string comBox2, string comBox3, int comBox4, int tabCheck, bool symbolInsert)
        {
            InitializeComponent();
            this.parentForm = parentForm;

            this.comBox1 = comBox1;
            this.comBox2 = comBox2;
            this.comBox3 = comBox3;
            this.comBox4 = comBox4;
            this.tabCheck = tabCheck;
            this.symbolInsert = symbolInsert;

            for (int i = 0; i < box1.Length; i++)
            {
                if (comBox1.Equals(box1[i].ToString()))
                {
                    comboBox1.SelectedIndex = i;
                }
            }
            for (int i = 0; i < box2.Length; i++)
            {
                if (comBox2.Equals(box2[i].ToString()))
                {
                    comboBox2.SelectedIndex = i;
                }
            }
            for (int i = 0; i < box3.Length; i++)
            {
                if (comBox3.Equals(box3[i].ToString()))
                {
                    comboBox3.SelectedIndex = i;
                }
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            
        }

        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.parentForm.formSettingsCheck(comBox1, comBox2, comBox3, comBox4, tabCheck);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            tabCheck = 2;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            tabCheck = 1;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            tabCheck = 3;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comBox1 = box1[comboBox1.SelectedIndex];
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comBox3 = box3[comboBox3.SelectedIndex].ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comBox2 = box2[comboBox2.SelectedIndex];
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            int[] box = { 8, 10, 11, 12, 14, 16, 18, 20, 24, 28, 32, 36, 40 };

            comBox4 = box[comboBox4.SelectedIndex];
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true)
            {
                radioButton6.Enabled = true;
                radioButton7.Enabled = true;
            }
            else
            {
                radioButton6.Enabled = false;
                radioButton7.Enabled = false;
            }
        }

    }
}
