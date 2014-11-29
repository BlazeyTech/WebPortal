using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Easy_Website_Developer
{
    public partial class FontSettings : Form
    {
        public string family = null;
        public int size = 0;
        public string color = null;

        Form1 parentForm;


        public FontSettings(Form1 parent)
        {
            InitializeComponent();
            this.parentForm = parent;
        }

        public void button1_Click(object sender, EventArgs e)
        {
            string fontFam = "";
            int fontSize = 1;
            string fontColor = "";

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    fontFam = "Arial";
                    break;
                case 1:
                    fontFam = "Calibri";
                    break;
                case 2:
                    fontFam = "ComicSans";
                    break;
                case 3:
                    fontFam = "Courier";
                    break;
                case 4:
                    fontFam = "Garamond";
                    break;
                case 5:
                    fontFam = "Georgia";
                    break;
                case 6:
                    fontFam = "Helvetica";
                    break;
                case 7:
                    fontFam = "Impact";
                    break;
                case 8:
                    fontFam = "Monospace";
                    break;
                case 9: 
                    fontFam = "Times New Roman";
                    break;
                case 10:
                    fontFam = "Verdana";
                    break;
                default:
                    fontFam = null;
                    break;

            }

            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    fontSize = 1;
                    break;
                case 1:
                    fontSize = 2;
                    break;
                case 2:
                    fontSize = 3;
                    break;
                case 3:
                    fontSize = 4;
                    break;
                case 4:
                    fontSize = 5;
                    break;
                case 5:
                    fontSize = 6;
                    break;
                case 6:
                    fontSize = 7;
                    break;
                default:
                    fontSize = 1;
                    break;
            }

            switch (comboBox3.SelectedIndex)
            {
                case 0:
                    fontColor = "Black";
                    break;
                case 1:
                    fontColor = "White";
                    break;
                case 2:
                    fontColor = "Green";
                    break;
                case 3:
                    fontColor = "Blue";
                    break;
                case 4:
                    fontColor = "Yellow";
                    break;
                case 5:
                    fontColor = "Red";
                    break;
                case 6:
                    fontColor = "#FF8040";
                        break;
                case 7:
                    fontColor = "#800080";
                    break;
                case 8:
                    fontColor = "#00FFFF";
                    break;
                case 9:
                    fontColor = "#43C6DB";
                    break;
                default:
                    fontColor = null;
                    break;
            }

            parentForm.insertFont(fontFam, fontSize, fontColor);
            this.Close();
        }
        
        
    }
}
