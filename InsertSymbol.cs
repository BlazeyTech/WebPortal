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
    public partial class InsertSymbol : Form
    {

        Form1 parentform;
        private int selectedNum = 0;


        #region Arrarys n shit

        private List<string> ascii = new List<string>() {
            ("<"),
            (">"),
            ("["),
            ("]"),
            ("{"),
            ("}"),
            ("|"),
            ("~"),
            ("'"),
            ("@")
        };
        private List<string> ascii2 = new List<string>() {
            ("&#60"),
            ("&#62"),
            ("&#91"),
            ("&#93"),
            ("&#123"),
            ("&#125"),
            ("#124"),
            ("&#126"),
            ("&#96"),
            ("&#64")
        };
        private List<string> math = new List<string>()
        {
            ("∀"),
            ("∂"),
            ("∃"),
            ("∅"),
            ("∇"),
            ("∈"),
            ("∉"),
            ("∋"),
            ("∑"),
            ("√"),
            ("∝"),
            ("∞"),
            ("∠"),
            ("∫"),
            ("∴"),
            ("∼"),
            ("≅"),
            ("≈"),
            ("≠"),
            ("≡"),
            ("≤"),
            ("≥"),
            ("⊥")
        };
        private List<string> math2 = new List<string>()
        {
            ("&#8704"),
            ("&#8706"),
            ("&#8707"),
            ("&#8709"),
            ("&#8711"),
            ("&#8712"),
            ("&#8713"),
            ("&#8715"),
            ("&#8721"),
            ("&#8730"),
            ("&#8733"),
            ("&#8734"),
            ("&#8736"),
            ("&#8747"),
            ("&#8756"),
            ("&#8764"),
            ("&#8773"),
            ("&#8776"),
            ("&#8800"),
            ("&#8801"),
            ("&#8804"),
            ("&#8805"),
            ("&#8869")
        };
        private List<string> greek = new List<string>()
        {
            ("Γ"),
            ("Δ"),
            ("Θ"),
            ("Λ"),
            ("Ξ"),
            ("Π"),
            ("Σ"),
            ("Φ"),
            ("Ψ"),
            ("Ω"),
            ("α"),
            ("β"),
            ("γ"),
            ("δ"),
            ("ε"),
            ("ζ"),
            ("η"),
            ("θ"),
            ("ι"),
            ("κ"),
            ("λ"),
            ("μ"),
            ("ν"),
            ("ξ"),
            ("ο"),
            ("π"),
            ("ρ"),
            ("ς"),
            ("σ"),
            ("τ"),
            ("υ"),
            ("φ"),
            ("χ"),
            ("ω"),
            ("ϑ"),
            ("ϒ"),
            ("ϖ")
        };
        private List<string> greek2 = new List<string>()
        {
            ("&#915"),
            ("&#916"),
            ("&#920"),
            ("&#923"),
            ("&#926"),
            ("&#928"),
            ("&#928"),
            ("&#934"),
            ("&#936"),
            ("&#937"),
            ("&#945"),
            ("&#946"),
            ("&#947"),
            ("&#948"),
            ("&#949"),
            ("&#950"),
            ("&#951"),
            ("&#952"),
            ("&#953"),
            ("&#954"),
            ("&#955"),
            ("&#956"),
            ("&#957"),
            ("&#958"),
            ("&#959"),
            ("&#960"),
            ("&#961"),
            ("&#962"),
            ("&#963"),
            ("&#964"),
            ("&#965"),
            ("&#966"),
            ("&#967"),
            ("&#969"),
            ("&#977"),
            ("&#978"),
            ("&#982")
        };
        private List<string> other = new List<string>()
        {
            ("Œ"),
            ("œ"),
            ("Š"),
            ("š"),
            ("Ÿ"),
            ("ƒ"),
            ("—"),
            ("†"),
            ("‡"),
            ("•"),
            ("…"),
            ("‰"),
            ("‾"),
            ("€"),
            ("™"),
            ("←"),
            ("↑"),
            ("→"),
            ("↓"),
            ("↔"),
            ("↵"),
            ("◊"),
            ("♠"),
            ("♣"),
            ("♥"),
            ("♦")
        };
        private List<string> other2 = new List<string>()
        {
            ("&#338"),
            ("&#339"),
            ("&#352"),
            ("&#353"),
            ("&#376"),
            ("&#402"),
            ("&#8212"),
            ("&#8224"),
            ("&#8225"),
            ("&#8226"),
            ("&#8230"),
            ("&#8240"),
            ("&#8254"),
            ("&#8364"),
            ("&#153"),
            ("&#8592"),
            ("&#8593"),
            ("&#8594"),
            ("&#8595"),
            ("&#8596"),
            ("&#8629"),
            ("&#9674"),
            ("&#9824"),
            ("&#9827"),
            ("&#9829"),
            ("&#9830")
        };
#endregion

        public InsertSymbol(Form1 parent)
        {
            InitializeComponent();
            this.parentform = parent;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                clearShit();

                for (int i = 0; i < ascii.Count; i++)
                {
                    checkedListBox1.Items.Add(ascii[i]);
                }
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                clearShit();

                for (int i = 0; i < math.Count; i++)
                {
                    checkedListBox1.Items.Add(math[i]);
                }
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                clearShit();

                for (int i = 0; i < greek.Count; i++)
                {
                    checkedListBox1.Items.Add(greek[i]);
                }
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                clearShit();

                for (int i = 0; i < other.Count; i++)
                {
                    checkedListBox1.Items.Add(other[i]);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void clearShit()
        {
            checkedListBox1.Items.Clear(); // clears checkListBox when selecting new list
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < checkedListBox1.Items.Count; ++ix)
                if (ix != e.Index) checkedListBox1.SetItemChecked(ix, false);

            selectedNum = e.Index;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count < 1)
            {
                MessageBox.Show("You must select a symbol to insert!", "Come on, man!");
            }
            else
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    parentform.insertSymbol(ascii2[selectedNum]);
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    parentform.insertSymbol(math2[selectedNum]);
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    parentform.insertSymbol(greek2[selectedNum]);
                }
                else if (comboBox1.SelectedIndex == 3)
                {
                    parentform.insertSymbol(other2[selectedNum]);
                }

                this.Close();
            }

        }

    }
}
