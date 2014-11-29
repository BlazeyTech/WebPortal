using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using WebPortal;

// insertOne inserts two strings on same line
// insertItem inserts two strings on seperate lines
// insertMultItems inserts 4 strings on seperate lines


// line 237

namespace Easy_Website_Developer
{
    public partial class Form1 : Form
    {
        public int pubTableRow = 0;
        public int pubTableCol = 0;
        private int cursorIndex = 0; // point for textbox cursor -- used in intellisense
        public string saveChange;
        public int selectedIndex = 0;
        public string searchT = "";
        public string replaceT = "";
        public static string strfilename;
        private string xx = "";
        public string savePath = null;
        private Boolean intellisenseCheck = true;

        private string intSense = "<";

        // formsettings control
        private int fontSize = 10;
        private string fontColor = "white";
        private string fontFam = "Courier New";
        private string backColor = "Gray";
        private int insControl = 1;
        private bool symbolInsert = false;



        #region lists and arrays
        public List<string> tags1 = new List<string>() {
                                 ("<html>"),
                                 ("</html>"),
                                 ("<body>"),
                                 ("</body>"),
                                 ("<div>"),
                                 ("</div>"),
                                 ("<title>"),
                                 ("</title>"),
                                 ("<head>"),
                                 ("</head>"),
                                 ("<style>"),
                                 ("</style>"),
                                 ("<blink>"),
                                 ("</blink>"),
                                 ("<blockquote>"),
                                 ("</blockquote>"),
                                 ("<b>"),
                                 ("</b>"),
                                 ("<cite>"),
                                 ("</cite>"),
                                 ("test"),
                                 ("christian")
                };

        public string[] listTags = new String[] {
            ("<!-- -->"),
            ("<!DOCTYPE>"),
            ("<a>"),
            ("<abbr>"),
            ("<address>"),
            ("<area>"),
            ("<article>"),
            ("<aside>"),
            ("<audio>"),
            ("<b>"),
            ("<base>"),
            ("<bdi>"),
            ("<bdo>"),
            ("<big>"),
            ("<blockquote>"),
            ("<body>"),
            ("<br>"),
            ("<button>"),
            ("<canvas>"),
            ("<caption>"),
            ("<center>"),
            ("<cite>"),
            ("<code>"),
            ("<col>"),
            ("<colgroup>"),
            ("<command>"),
            ("<datalist>"),
            ("<dd>"),
            ("<del>"),
            ("<details>"),
            ("<dfn>"),
            ("<dialog>"),
            ("<dir>"),
            ("<div>"),
            ("<dl>"),
            ("<dt>"),
            ("<em>"),
            ("<embed>"),
            ("<fieldset>"),
            ("<figcaption>"),
            ("<figure>"),
            ("<font>"),
            ("<footer>"),
            ("<form>"),
            ("<frame>"),
            ("<frameset>"),
            ("<h1>"),
            ("<h2>"),
            ("<h3>"),
            ("<h4>"),
            ("<h5>"),
            ("<h6>"),
            ("<head>"),
            ("<header>"),
            ("<hr>"),
            ("<html>"),
            ("<i>"),
            ("<iframe>"),
            ("<img>"),
            ("<input>"),
            ("<ins>"),
            ("<kbd>"),
            ("<keygen>"),
            ("<label>"),
            ("<legend>"),
            ("<li>"),
            ("<link>"),
            ("<map>"),
            ("<mark>"),
            ("<menu>"),
            ("<meta>"),
            ("<meter>"),
            ("<nav>"),
            ("<noframes>"),
            ("<noscript>"),
            ("<object>"),
            ("<ol>"),
            ("<optgroup>"),
            ("<option>"),
            ("<output>"),
            ("<p>"),
            ("<param>"),
            ("<pre>"),
            ("<progress>"),
            ("<q>"),
            ("<rp>"),
            ("<rt>"),
            ("<ruby>"),
            ("<s>"),
            ("<samp>"),
            ("<script>"),
            ("<section>"),
            ("<select>"),
            ("<small>"),
            ("<source>"),
            ("<span>"),
            ("<strike>"),
            ("<strong>"),
            ("<style>"),
            ("<sub>"),
            ("<summary>"),
            ("<sup>"),
            ("<table>"),
            ("<tbody>"),
            ("<td>"),
            ("<textarea>"),
            ("<tfoot>"),
            ("<th>"),
            ("<thread>"),
            ("<time>"),
            ("<title>"),
            ("<tr>"),
            ("<track>"),
            ("<tt>"),
            ("<u>"),
            ("<ul>"),
            ("<var>"),
            ("<video>"),
            ("<wbr>")
        };
        #endregion

        ListBox list = new ListBox();
        WebBrowser web = new WebBrowser();





        public Form1()
        {
            InitializeComponent();
        }
        public Form1(int a, string b)
        {
            InitializeComponent();

            if (a == 1)
            {
                b = searchT;
            }

        }
        // Main method for inserting code
        // Difference between insertItem and insertOne
        //   -insertItem adds on different lines, insertOne on same line.
        //          Use insertItem for majority of inputs
        #region Form1_Load
        private void Form1_Load(object sender, EventArgs e)
        {
            list.Visible = false;
            list.Items.AddRange(listTags);
        }
        #endregion

        // a = fontFam, b = backColor, c = fontColor, d = fontSize, e = insertControl settings
        public void formSettingsCheck(string a, string b, string c, int d, int e)
        {
            if (a != null)
            {
                fontFam = a;
            }
            if (b != null)
            {
                backColor = b;
            }
            if (c != null)
            {
                fontColor = c;

                if (fontColor.Equals("Gray"))
                {
                    textBox1.BackColor = Color.DimGray;
                }
                else if (fontColor.Equals("Red"))
                {
                    textBox1.BackColor = Color.Red;
                }
                else if (fontColor.Equals("White"))
                {
                    textBox1.BackColor = Color.White;
                }
                else if (fontColor.Equals("Black"))
                {
                    textBox1.BackColor = Color.Black;
                }
                else if (fontColor.Equals("Orange"))
                {
                    textBox1.BackColor = Color.Orange;
                }
                else if (fontColor.Equals("Green"))
                {
                    textBox1.BackColor = Color.Green;
                }
                else if (fontColor.Equals("Brown"))
                {
                    textBox1.BackColor = Color.Brown;
                }
            }
            if (d != 10)
            {
                fontSize = d;
            }
            if (e != 1)
            {
                insControl = e;
            }

            textBox1.Font = new Font(fontFam, fontSize);
        }

        #region insCntrl -- Eventually will control/override all insert methods
        // 1 string, (insControl controls newline inserting)
        private void insCntrl(string a)
        {
            if (insControl == 1) // 1 == default
            {
                if (textBox1.SelectionLength > 0)
                {
                    xx = textBox1.SelectedText;
                    textBox1.SelectedText = textBox1.SelectedText.Replace(xx, a + xx);
                }
                else
                {
                    textBox1.Paste(a + Environment.NewLine);
                }
            }
            else if (insControl == 2) // 2 == new line
            {
                if (textBox1.SelectionLength > 0)
                {
                    xx = textBox1.SelectedText;
                    textBox1.SelectedText = textBox1.SelectedText.Replace(xx, a + xx);
                }
                else
                {
                    textBox1.Paste(a + Environment.NewLine);
                }
            }
            else if (insControl == 3) // 3 == same line
            {
                if (textBox1.SelectionLength > 0)
                {
                    xx = textBox1.SelectedText;
                    textBox1.SelectedText = textBox1.SelectedText.Replace(xx, a + xx);
                }
                else
                {
                    textBox1.Paste(a);
                }
            }
        }
        private void insCntrl(string a, string b)
        {
            if (insControl == 1) //default
            {
                if (textBox1.SelectionLength > 0)
                {
                    xx = textBox1.SelectedText;
                    textBox1.SelectedText = textBox1.SelectedText.Replace(xx, a + xx + b);
                }
                else
                {
                    textBox1.Paste(a + b);
                }
            }
            else if (insControl == 2) //new line
            {
                if (textBox1.SelectionLength > 0)
                {
                    xx = textBox1.SelectedText;
                    textBox1.SelectedText = textBox1.SelectedText.Replace(xx, a + Environment.NewLine + xx + Environment.NewLine + b);
                }
                else
                {
                    textBox1.Paste(a + Environment.NewLine + b);
                }
            }
            else if (insControl == 3) //same line
            {
                if (textBox1.SelectionLength > 0)
                {
                    xx = textBox1.SelectedText;
                    textBox1.SelectedText = textBox1.SelectedText.Replace(xx, a + xx + b);
                }
                else
                {
                    textBox1.Paste(a + b);
                }
            }
        }
        private void insCntrl(string a, string b, string c)
        {
            if (insControl == 1) // default
            {
                if (textBox1.SelectionLength > 0)
                {
                    xx = textBox1.SelectedText;
                    textBox1.SelectedText = textBox1.SelectedText.Replace(xx, a + xx + b + c);
                }
                else
                {
                    textBox1.Paste(a + b + c);
                }
            }
            else if (insControl == 2) // new line
            {
                if (textBox1.SelectionLength > 0)
                {
                    xx = textBox1.SelectedText;
                    textBox1.SelectedText = textBox1.SelectedText.Replace(xx, a + xx + b + c + Environment.NewLine);
                }
                else
                {
                    textBox1.Paste(a + b + c + Environment.NewLine);
                }
            }
            else if (insControl == 3) // same line
            {
                if (textBox1.SelectionLength > 0)
                {
                    xx = textBox1.SelectedText;
                    textBox1.SelectedText = textBox1.SelectedText.Replace(xx, a + xx + b + c);
                }
                else
                {
                    textBox1.Paste(a + b + c);
                }
            }
        }
        private void insCntrl(string a, string b, string c, string d, int x) //x determines how the default inserts
        {
            if (insControl == 1) // default
            {
                if (x == 1)
                {
                    if (textBox1.SelectionLength > 0)
                    {
                        xx = textBox1.SelectedText;
                        textBox1.SelectedText = textBox1.SelectedText.Replace(xx, a + Environment.NewLine + b + xx + c + Environment.NewLine + d);
                    }
                    else
                    {
                        textBox1.Paste(a + Environment.NewLine + b + c + Environment.NewLine + d);
                    }
                }
                else if (x == 2)
                {
                    if (textBox1.SelectionLength > 0)
                    {
                        xx = textBox1.SelectedText;
                        textBox1.SelectedText = textBox1.SelectedText.Replace(xx, a + Environment.NewLine + b + xx + c + Environment.NewLine + d);
                    }
                    else
                    {
                        textBox1.Paste(a + Environment.NewLine + b + Environment.NewLine + c + Environment.NewLine + d);
                    }
                }
            }
            else if (insControl == 2) // new line
            {
                if (textBox1.SelectionLength > 0)
                {
                    xx = textBox1.SelectedText;
                    textBox1.SelectedText = textBox1.SelectedText.Replace(xx, a + Environment.NewLine + b + Environment.NewLine + xx + Environment.NewLine + c + Environment.NewLine + d);
                }
                else
                {
                    textBox1.Paste(a + Environment.NewLine + b + Environment.NewLine + c + Environment.NewLine + d);
                }
            }
            else if (insControl == 3) // same line
            {
                if (textBox1.SelectionLength > 0)
                {
                    xx = textBox1.SelectedText;
                    textBox1.SelectedText = textBox1.SelectedText.Replace(xx, a + b + xx + c + d);
                }
                else
                {
                    textBox1.Paste(a + b + c + d);
                }
            }
        }
        private void insCntrl(string a, string b, string c, string d, string e)
        {
            if (insControl == 1) // default
            {

            }
            else if (insControl == 2) // new line
            {

            }
            else if (insControl == 3) // same line
            {

            }
        }
        private void insCntrl(string a, string b, string c, string d, string e, string f)
        {
            if (insControl == 1) // default
            {

            }
            else if (insControl == 2) // new line
            {

            }
            else if (insControl == 3) // same line
            {

            }
        }

        #endregion

        #region insertItem
        private void insertItem(string a, string b)
        {

                if (textBox1.SelectionLength > 0)
                {
                    xx = textBox1.SelectedText;
                    textBox1.SelectedText = textBox1.SelectedText.Replace(xx, a + xx + b);
                }
                else
                {
                    textBox1.Paste(a + Environment.NewLine + b);
                }
        }

        // override 3

        private void insertItem(string a, string b, string c)
        {
            if (textBox1.SelectionLength > 0)
            {
                xx = textBox1.SelectedText;
                textBox1.SelectedText = textBox1.SelectedText.Replace(xx, a + Environment.NewLine + b + Environment.NewLine + xx + Environment.NewLine + c);
            }
            else
            {
                textBox1.Paste(a + Environment.NewLine + b + Environment.NewLine + c);
            }
        }

        //override 4

        private void insertItem(string a, string b, string c, string d)
        {
            if (textBox1.SelectionLength > 0)
            {
                xx = textBox1.SelectedText;
                textBox1.SelectedText = textBox1.SelectedText.Replace(xx, a + Environment.NewLine + b + Environment.NewLine + xx + Environment.NewLine + c + Environment.NewLine + d);
            }
            else
            {
                textBox1.Paste(a + Environment.NewLine + b + Environment.NewLine + c + Environment.NewLine + d);
            }
        }

        //override 5

        private void insertItem(string a, string b, string c, string d, string e)
        {
            if (textBox1.SelectionLength > 0)
            {
                xx = textBox1.SelectedText;
                textBox1.SelectedText = textBox1.SelectedText.Replace(xx, a + Environment.NewLine + b + Environment.NewLine + xx + Environment.NewLine + c + Environment.NewLine + d + Environment.NewLine + e);
            }
            else
            {
                textBox1.Paste(a + Environment.NewLine + b + Environment.NewLine + c + Environment.NewLine + d + Environment.NewLine + e);
            }
        }

        // override 6
        private void insertItem(string a, string b, string c, string d, string e, string f)
        {
            if (textBox1.SelectionLength > 0)
            {
                xx = textBox1.SelectedText;
                textBox1.SelectedText = textBox1.SelectedText.Replace(xx, a + Environment.NewLine + b + xx + c + Environment.NewLine + d + xx + e + Environment.NewLine + f);
            }
            else
            {
                textBox1.Paste(a + Environment.NewLine + b + c + Environment.NewLine + d + xx + e + Environment.NewLine + f);
            }
        }

        //override 8

        private void insertItem(string a, string b, string c, string d, string e, string f, string g, string h)
        {
            if (textBox1.SelectionLength > 0)
            {
                xx = textBox1.SelectedText;
                textBox1.SelectedText = textBox1.SelectedText.Replace(xx, a + Environment.NewLine + b + Environment.NewLine + c + xx + d + Environment.NewLine + e + xx + f + Environment.NewLine + g + Environment.NewLine + h);
            }
            else
            {
                textBox1.Paste(a + Environment.NewLine + b + Environment.NewLine + c + xx + d + Environment.NewLine + e + xx + f + Environment.NewLine + g + Environment.NewLine + h);
            }
        }
        
        #endregion
        #region insertOne
        public void insertOne(string a)
        {
            if (textBox1.SelectionLength > 0)
            {
                xx = textBox1.SelectedText;
                textBox1.SelectedText = textBox1.SelectedText.Replace(xx, a + xx);
            }
            else
            {
                textBox1.Paste(a + Environment.NewLine);
            }
        }
        private void insertOne(string a, string b)
        {
            if (textBox1.SelectionLength > 0)
            {
                xx = textBox1.SelectedText;
                textBox1.SelectedText = textBox1.SelectedText.Replace(xx, a + xx + b);
            }
            else
            {
                textBox1.Paste(a + b);
            }
        }
        #endregion
        #region insertNewLine (alternate to insertOne and insertItem) -- Useful for HTML and Body tags
        public void insertNewLine(string a)
        {
            if (textBox1.SelectionLength > 0)
            {
                xx = textBox1.SelectedText;
                textBox1.SelectedText = textBox1.SelectedText.Replace(xx, a + Environment.NewLine + xx + Environment.NewLine); 
            }
            else
            {
                textBox1.Paste(a + Environment.NewLine);
            }
        }
        private void insertNewLine(string a, string b)
        {
            if (textBox1.SelectionLength > 0)
            {
                xx = textBox1.SelectedText;
                textBox1.SelectedText = textBox1.SelectedText.Replace(xx, a + Environment.NewLine + xx + Environment.NewLine + b + Environment.NewLine);
            }
            else
            {
                textBox1.Paste(a + Environment.NewLine + b);
            }
        }
        #endregion
        #region insertMultItems
        public void insertMultItems(string a, string b, string c, string d)
        {

            if (textBox1.SelectionLength > 0)
            {
                xx = textBox1.SelectedText;
                textBox1.SelectedText = textBox1.SelectedText.Replace(xx, a + Environment.NewLine + b + Environment.NewLine + xx + Environment.NewLine + c + Environment.NewLine + d);
            }
            else
            {
                textBox1.Paste(a + Environment.NewLine + b + Environment.NewLine + c + Environment.NewLine + d);
            }
        }
        #endregion
        #region insertCSS
        public void insertCSS(string a)
        {
            if (textBox1.SelectionLength > 0)
            {
                xx = textBox1.SelectedText;
                textBox1.SelectedText = textBox1.SelectedText.Replace(xx, a + xx + ";");
            }
            else
            {
                textBox1.Paste(a + ";");
            }
        }
        #endregion
        #region insertMultCSS
        private void insertMultCSS(string a, string b, string c, string d)
        {
            if (textBox1.SelectionLength > 0 && c != null && d != null)
            {
                xx = textBox1.SelectedText;
                textBox1.SelectedText = textBox1.SelectedText.Replace(xx, a + xx + ";" + Environment.NewLine + b + ";" + Environment.NewLine + c + ";" + Environment.NewLine + d + ";");
                
            }
            else if (textBox1.SelectionLength > 0 && c == null && d == null)
            {
                xx = textBox1.SelectedText;
                textBox1.SelectedText = textBox1.SelectedText.Replace(xx, a + xx + ";" + Environment.NewLine + b + ";");
                
            }
            else if (textBox1.SelectionLength > 0 && d == null)
            {
                xx = textBox1.SelectedText;
                textBox1.SelectedText = textBox1.SelectedText.Replace(xx, a + xx + ";" + Environment.NewLine + b + ";" + Environment.NewLine + c + ";");

            }
            else if (textBox1.SelectionLength == 0 && c == null && d == null)
            {
                textBox1.Paste(a + ";" + Environment.NewLine + b + ";");
            }
            else if (textBox1.SelectionLength == 0 && d == null)
            {
                textBox1.Paste(a + ";" + Environment.NewLine + b + ";" + Environment.NewLine + c + ";");
            }
            else
            {
                textBox1.Paste(a + ";" + Environment.NewLine + b + ";" + Environment.NewLine + c + ";" + Environment.NewLine + d + ";");
            }
        }
        #endregion
        #region insertFont
        public void insertFont(string family, int size, string color) // insert HTML <font>
        {

            if (textBox1.SelectionLength > 0)
            {
                xx = textBox1.SelectedText;
                textBox1.SelectedText = textBox1.SelectedText.Replace(xx, "<font family=\"" + family + "\" size=\"" + size + "\" color=\"" + color + "\">" + xx + "</font>");

            }
            else
            {
                textBox1.Paste("<font family=\"" + family + "\" size=\"" + size + "\" color=\"" + color + "\"></font>");
            }
        }
        #endregion
        #region saveFile (save as)
        public void saveFile(string path)
        {
            if (path != null)
            {
                System.IO.File.WriteAllText(path + ".html", textBox1.Text);
                saveChange = textBox1.Text;
            }
            else if (path == null)
            {

            }
            saveChange = textBox1.Text;
        }
        #endregion
        #region saveFile (actual save)
        private void saveAllToolStripMenuItem_Click(object sender, EventArgs e) // save file
        {
            SaveFileDialog saveFile = new SaveFileDialog();

            if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (saveFile.FileName.Contains(".html"))
                {
                    File.WriteAllText(saveFile.FileName, textBox1.Text);
                    strfilename = saveFile.FileName;
                }
                else if (strfilename != null)
                {
                    File.WriteAllText(strfilename, textBox1.Text);
                }
                else if (!saveFile.FileName.Contains(".html"))
                {
                    File.WriteAllText(saveFile.FileName + ".html", textBox1.Text);
                    strfilename = saveFile.FileName + ".html";
                }
                else
                {
                    File.WriteAllText(saveFile.FileName + ".html", textBox1.Text);
                    strfilename = saveFile.FileName + ".html";
                }
                saveChange = textBox1.Text;
            }
        }
        #endregion
        #region saveFile (Menu item)
        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();

            if (strfilename != null)
            {
                File.WriteAllText(strfilename, textBox1.Text);
            }
            else
            {
                if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (saveFile.FileName.Contains(".html"))
                    {
                        File.WriteAllText(saveFile.FileName, textBox1.Text);
                    }
                    else
                    {
                        File.WriteAllText(saveFile.FileName + ".html", textBox1.Text);
                    }

                }
            }
            saveChange = textBox1.Text;
        }
        #endregion
        #region openFile
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e) // open file
        {
            Stream myStream;
            OpenFileDialog openFile = new OpenFileDialog();

            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if ((myStream = openFile.OpenFile()) != null)
                {
                    strfilename = openFile.FileName;
                    string filetext = File.ReadAllText(strfilename);
                    textBox1.Text = filetext;

                    Form1 aa = new Form1();
                    aa.Text = "WebPortal Alpha - " + strfilename;

                    if (strfilename.Contains(".html"))
                    {

                    }
                    else
                    {
                        strfilename = strfilename + ".html";
                    }
                    saveChange = textBox1.Text;
                }
            }
        }
        #endregion
        #region browserPreview
        private void browserPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (browserPreviewToolStripMenuItem.Checked == true && strfilename != null)
            {

                Uri uri = new Uri("file:///" + strfilename);

                textBox1.Dock = DockStyle.Left;
                textBox1.Width = this.Width / 2;
                web.Dock = DockStyle.Right;
                web.Width = this.Width / 2;
                //web.Show();
                //web.Navigate(uri);

                FileStream source = new FileStream(strfilename, FileMode.Open, FileAccess.Read);
                web.DocumentStream = source;
                web.Show();
                


            }
            else if (browserPreviewToolStripMenuItem.Checked == false && strfilename != null)
            {
                textBox1.Dock = DockStyle.Fill;
                web.Hide();
            }
            else
            {
                browserPreviewToolStripMenuItem.Checked = false;
                MessageBox.Show("It would appear you are trying to preview something that doesn't exist. Save or open a file to use the Browser Preview feature.", "Do you even code bro?");
            }
        }
        #endregion
        #region searchText
        public void searchText(string searchT) // search function
        {

            if (searchT != null)
            {
                if (textBox1.TextLength > 0)
                {
                    if (textBox1.Text.Contains(searchT))
                    {
                        if (textBox1.SelectedText != searchT)
                        {
                            textBox1.Focus();
                            textBox1.SelectionStart = textBox1.Text.IndexOf(searchT);
                            textBox1.SelectionLength = searchT.Length;
                            selectedIndex = textBox1.Text.IndexOf(searchT) + searchT.Length;
                        }

                        else if (textBox1.SelectedText == searchT)
                        {
                            textBox1.Focus();
                            textBox1.SelectionStart = selectedIndex + textBox1.Text.IndexOf(searchT);
                            textBox1.SelectionLength = searchT.Length;
                        }
                        

                    }
                }
            }
        }
        #endregion
        #region replaceText
        public void replaceText(Boolean alpha, string searchT, string replaceT) // replace text function
        {
            if (searchT != null)
            {
                if (textBox1.TextLength > 0)
                {
                    if (textBox1.Text.Contains(searchT))
                    {
                        if (textBox1.SelectedText != searchT)
                        {
                            textBox1.Focus();
                            textBox1.SelectionStart = textBox1.Text.IndexOf(searchT);
                            textBox1.SelectionLength = searchT.Length;
                            textBox1.Text.Replace(textBox1.SelectedText, replaceT);
                        }

                        else if (textBox1.SelectedText == searchT)
                        {
                            textBox1.Focus();
                            
                        }


                    }
                }
            }
        }
        #endregion
        #region textBox1_KeyUp Fix to Alt Sound + triggering menu
        public void textBox1_KeyUp(object sender, KeyEventArgs e) // autocomplete
        {
            if (e.Modifiers.Equals(Keys.Alt))
            {
                if (e.KeyCode == Keys.Menu)
                {
                    e.Handled = true;
                }
            } 

        }
        #endregion
        #region KeyDown (Autocomplete)
        List<string> fullList = new List<string>();
        List<string> tempList = new List<string>();
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (intellisenseCheck == true)
            {

                if (e.Shift && e.KeyValue == 188) // shift + comma
                {

                    // Find the position of the caret
                    Point point = this.textBox1.GetPositionFromCharIndex(textBox1.SelectionStart);
                    point.Y += (int)Math.Ceiling(this.textBox1.Font.GetHeight()) + 2;
                    point.X += 2; // for Courier, may need a better method

                    list.Location = new Point(point.Y, point.X);
                    list.Height = textBox1.Height / 3;
                    list.SelectedIndex = 0;
                    list.BringToFront();
                    list.Visible = true;
                    list.Parent = textBox1;
                    list.Show();

                    cursorIndex = textBox1.SelectionStart;

                }
                else if (list.Visible == true)
                {
                    if (e.KeyData == Keys.Down && list.SelectedIndex < list.Items.Count - 1) // up arrow control
                    {
                        list.SelectedIndex += 1;

                    }
                    else if (e.KeyData == Keys.Up && list.SelectedIndex > 0) // down arrow control
                    {
                        list.SelectedIndex -= 1;
                    }
                    else if (e.KeyData == Keys.Enter) // enter inserts currently selected index
                    {
                        int selectState = list.SelectedIndex;
                        int tempLength = intSense.Length;

                        if (selectState < list.Items.Count && selectState >= 0)
                        {
                            string temptext = list.Items[selectState].ToString();

                            if (tempLength < 2)
                            {
                                textBox1.Paste(list.Items[selectState].ToString().Substring(1));
                            }
                            else
                                textBox1.Paste(list.Items[selectState].ToString().Substring(tempLength, 1 + list.Items[selectState].ToString().Length - tempLength));
                            
                            

                        }
                        else
                        {
                            textBox1.Paste(list.Items[0].ToString().Substring(1));
                        }

                        list.Visible = false;
                        //textBox1.Text = textBox1.Text.Trim();

                        tempList.Clear();
                        list.Items.Clear();

                        for (int i = 0; i < listTags.Length; i++)
                        {
                            fullList.Add(listTags[i]);
                            //tempList.Add(listTags[i]);
                        }

                        for (int i = 0; i < listTags.Length; i++)
                        {
                            list.Items.Add(fullList[i]);
                        }

                        intSense = "<";
                    }
                    else if (e.Shift && e.KeyValue == 190)
                    {
                        list.Visible = false;
                    }

                    // back space control
                    else if (e.KeyData == Keys.Back) 
                    {
                        if (textBox1.SelectionStart <= cursorIndex + 1) // closes list if user deletes the < that opens list
                        {
                            list.Visible = false;
                        }
                    }

                    // closes list via escape
                    else if (e.KeyData == Keys.Escape)
                    {
                        list.Visible = false;
                    }

                     // A Key
                    else if (e.KeyData == Keys.A)
                    {
                        keyArraySearch(Keys.A);

                        if (tempList.Count > 0) //catches error for templist not loading
                        {
                            list.Items.Clear();
                        }


                        //templist shows up on actual list
                        for (int i = 0; i < tempList.Count; i++)
                        {
                            list.Items.Add(tempList[i]);
                        }
                    }



                    // calls method to refine search
                    else
                    {
                        keyArraySearch(e.KeyData);
                    }


                }
            }
        }

        private void keyArraySearch(Keys a) // not currently working
        {
            if (a == Keys.A)
                intSense += "a";
            else if (a == Keys.B)
                intSense += "b";
            else if (a == Keys.C)
                intSense += "c";
            else if (a == Keys.D)
                intSense += "d";
            else if (a == Keys.E)
                intSense += "e";
            else if (a == Keys.F)
                intSense += "f";
            else if (a == Keys.G)
                intSense += "g";
            else if (a == Keys.H)
                intSense += "h";
            else if (a == Keys.I)
                intSense += "i";
            else if (a == Keys.J)
                intSense += "j";
            else if (a == Keys.K)
                intSense += "k";
            else if (a == Keys.L)
                intSense += "l";
            else if (a == Keys.M)
                intSense += "m";
            else if (a == Keys.N)
                intSense += "n";
            else if (a == Keys.O)
                intSense += "o";
            else if (a == Keys.P)
                intSense += "p";
            else if (a == Keys.Q)
                intSense += "q";
            else if (a == Keys.R)
                intSense += "r";
            else if (a == Keys.S)
                intSense += "s";
            else if (a == Keys.T)
                intSense += "t";
            else if (a == Keys.U)
                intSense += "u";
            else if (a == Keys.V)
                intSense += "v";
            else if (a == Keys.V)
                intSense += "v";
            else if (a == Keys.W)
                intSense += "w";
            else if (a == Keys.X)
                intSense += "x";
            else if (a == Keys.Y)
                intSense += "y";
            else if (a == Keys.Z)
                intSense += "z";


            for (int i = 0; i < listTags.Length; i++)
            {
                fullList.Add(listTags[i]);

                //refines list to items typed
                if (fullList[i].StartsWith(intSense)) //currently not working
                {
                    tempList.Add(fullList[i]); //
                }
                //handles when user is typing and no tag found
                //else
                //{
                //    list.Visible = false;
                //    tempList.Clear();
                //    list.Items.Clear();

                //    for (int j = 0; j < listTags.Length; j++)
                //    {
                //        fullList.Add(listTags[j]);
                //    }

                //    for (int j = 0; j < listTags.Length; j++)
                //    {
                //        list.Items.Add(fullList[j]);
                //    }

                //    intSense = "<";
                //}

                #region oldCode
                //List<string> fullList = new List<string>();
                //List<string> tempList = new List<string>();

                //char theKey = (char)a;
                //string s = "<" + theKey;

                //for (int i = 0; i < listTags.Length; i++) 
                //{
                //    fullList.Add(listTags[i]);

                //    //refines list to items typed
                //    if (fullList[i].StartsWith(s)) //currently not working
                //    {
                //        tempList.Add(fullList[i]); //
                //    }
                //}

                //if (tempList.Count > 0) //catches error for templist not loading
                //{
                //    list.Items.Clear();
                //}


                //for (int i = 0; i < tempList.Count; i++)
                //{
                //    list.Items.Add(tempList[i]);
                //}
                #endregion

            }
        }
        #endregion

        private void listBox_Enter(object sender, KeyEventArgs e)
        {
            //make enter button donothing here
        }

        private void listBox_MouseClick(object sender, MouseEventArgs e)
        {
            int selectState = list.SelectedIndex;
            if (selectState < list.Items.Count && selectState > 0)
            {
                textBox1.Paste(list.Items[selectState] + "");

            }
            list.Visible = false;
        }
        private void listBox_DoubleClick(object sender, EventArgs e)
        {
            int selectState = list.SelectedIndex;
            if (selectState < list.Items.Count && selectState > 0)
            {
                textBox1.Paste(list.Items[selectState] + "");

            }
            list.Visible = false;
        }

        #region Shortcuts (Form1_KeyDown)
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Alt)
            {
                // fixes menu trap bug. suppress and handled control this.
                e.SuppressKeyPress = true;
                e.Handled = true;

                if (e.KeyCode.ToString() == "B")
                {
                    insertOne("<button type=\"button\">", "</button>");
                    e.Handled = true;
                }
                if (e.KeyCode.ToString() == "S")
                {
                    insertOne("<span style=\"\">", "</span>");
                }
                if (e.KeyCode.ToString() == "U")
                {
                    insertItem("<ul>", "<li></li>", "<li></li>", "<li></li>", "</ul>");
                }
                if (e.KeyCode.ToString() == "C")
                {
                    insertOne("<!-- ", " -->");
                }
                if (e.KeyCode.ToString() == "F")
                {
                    FontSettings fnt = new FontSettings(this);
                    fnt.Show();
                }

            } // end of all alt shortcuts

            if (e.Control)
            {
                if (e.KeyCode.ToString() == "P") // paragraph shortcut
                {
                    insertOne("<p>", "</p>");
                    //e.SuppressKeyPress = true;
                }
                if (e.KeyCode.ToString() == "F") // form shortcut
                {
                    insertItem("<form action=\"\" method=\"\">", "</form>");
                }
                if (e.KeyCode.ToString() == "I")
                {
                    if (textBox1.SelectedText != null)
                    {
                        textBox1.SelectedText = "    " + textBox1.SelectedText;
                    }
                    else
                    {
                        textBox1.Paste("    ");
                    }
                }
                if (e.KeyCode.ToString() == "S")
                {
                    saveFile(savePath);
                }

                if (e.KeyCode.ToString() == "N")
                {
                    Form1 a = new Form1();
                    a.Show();
                }

                if (e.KeyCode.ToString() == "D")
                {
                    insertItem("<div class=\"\">", "</div>");
                }
                if (e.KeyCode.ToString() == "L")
                {
                    insertOne("<a href=\"\">", "</a>");
                }
                if (e.KeyCode.ToString() == "A")
                {
                    textBox1.SelectAll();
                }
                if (e.KeyCode.ToString() == "B")
                {
                    textBox1.Paste("<br />" + Environment.NewLine);
                }
                if (e.KeyCode.ToString() == "S")
                {
                    SaveFileDialog saveFile = new SaveFileDialog();

                    if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        File.WriteAllText(saveFile.FileName, textBox1.Text);
                    }
                }
                if (e.KeyCode.ToString() == "U")
                {
                    insertOne("<u>", "</u>");
                }
                if (e.KeyCode.ToString() == "T")
                {
                    TableForm tf = new TableForm(this);

                    if (pubTableCol == 0 && pubTableRow == 0)
                    {
                        tf.Show();

                        //insertItem("<table border=\"\">", "<tr>", "<td>", "</td>", "<td>", "</td>", "<tr>", "</table>");
                    }
                    else if (textBox1.SelectedText != null)
                    {
                        insertTable(pubTableRow, pubTableCol, true);
                    }
                    else
                    {
                        insertTable(pubTableRow, pubTableCol, false);
                    }
                }
                if (e.KeyCode.ToString() == "Q")
                {
                    insertOne("<q>", "</q>");
                }
                if ( e.KeyCode.ToString() == "O")
                {
                    insertOne("<object height=\"\" width=\"\" data=\"\">", "</object>");
                }
                if (e.KeyCode.ToString() == "M")
                {
                    insertMultItems("<video height=\"\" width=\"\" controls>", "<source src=\"\" type=\"video/\">", "</video>", null);
                }
                if (e.KeyCode.ToString() == "J")
                {
                    insertItem("<script>", "</script>");
                }
                if (e.KeyCode.ToString() == "H")
                {
                    textBox1.Paste("<hr />" + Environment.NewLine + "" + Environment.NewLine);
                }
                if (e.KeyCode.ToString() == "E")
                {
                    textBox1.Paste("<embed src=\"\">");
                }
                // Currently not working ====================
                if (e.KeyCode.ToString() == ",")
                {
                    textBox1.Paste("&#60");
                }
                if (e.KeyCode.ToString() == ".")
                {
                    textBox1.Paste("&#62");
                }
                if (e.KeyData == Keys.Escape)
                {
                    list.Visible = false;
                }
                // ==========================================

                e.SuppressKeyPress = true;
            } //end of ctrl shortcuts
        }
        #endregion
        #region FormClosing
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (textBox1.Text == "")
            {
                e.Cancel = false;
            }
            else if (strfilename == null && textBox1.Text != "")
            {
                Form1 f1 = new Form1();
                DialogResult ddd = MessageBox.Show("Are you sure you want to exit? All unsaved data will be deleted.", "Unsaved Data", MessageBoxButtons.YesNo);

                if (ddd == DialogResult.Yes)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }

            }
            else if (saveChange.Equals(textBox1.Text))
            {
                e.Cancel = false;
            }
            else
            {
                Form1 f1 = new Form1();
                DialogResult ddd = MessageBox.Show("Are you sure you want to exit? All unsaved data will be deleted.", "Unsaved Data", MessageBoxButtons.YesNo);

                if (ddd == DialogResult.Yes)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
        #endregion
        #region insertTable
        public void insertTable(int a, int b, Boolean c)
        {
            pubTableRow = a;
            pubTableCol = b;

            if (c != false)
            {
                xx = textBox1.SelectedText;
                textBox1.Paste("<table border=\"\">" + Environment.NewLine);
                for (int i = 1; i <= a; i++)
                {
                    textBox1.Paste("<tr>" + Environment.NewLine);

                    for (int j = 1; j <= b; j++)
                    {
                        textBox1.Paste("<td>" + xx + "</td>" + Environment.NewLine);
                    }
                    textBox1.Paste("</tr>" + Environment.NewLine);
                }
                textBox1.Paste("</table>");
            }
            else
            {
                textBox1.Paste("<table border=\"\">" + Environment.NewLine);

                for (int i = 1; i <= a; i++)
                {
                    textBox1.Paste("<tr>" + Environment.NewLine);

                    for (int j = 1; j <= b; j++)
                    {
                        textBox1.Paste("<td></td>" + Environment.NewLine);
                    }
                    textBox1.Paste("</tr>" + Environment.NewLine);
                }
                textBox1.Paste("</table>");
            }
            xx = "";
        }
        #endregion
        #region insertAudio
        public void insertAudio(string a)
        {
            if (a.Contains(".mp3"))
            {
                textBox1.Paste("<audio controls>" + Environment.NewLine);
                textBox1.Paste("<source src=\"" + a + "\" type=\"audio/mpeg\"" + Environment.NewLine);
                textBox1.Paste("</audio>");
            }
            else if (a.Contains(".wav"))
            {
                textBox1.Paste("<audio controls>" + Environment.NewLine);
                textBox1.Paste("<source src=\"" + a + "\" type=\"audio/wav\"" + Environment.NewLine);
                textBox1.Paste("</audio>");
            }
            else if (a.Contains(".ogg"))
            {
                textBox1.Paste("<audio controls>" + Environment.NewLine);
                textBox1.Paste("<source src=\"" + a + "\" type=\"audio/ogg\"" + Environment.NewLine);
                textBox1.Paste("</audio>");
            }
            else
            {
                DialogResult result1 = MessageBox.Show("The File type entered is not compatible with HTML5. Please any of these file types: .mp3, .wav, .ogg", "Invalid File Type", MessageBoxButtons.OK);

            }
        }
        #endregion
        #region insertVideo
        public void insertVideo(string a, string b, string c, int num1, int num2)
        {
            bool invalidType = false;

            textBox1.Paste("<video width=\"" + num1 + "\" height=\"" + num2 + "\" controls>" + Environment.NewLine);

            if (a.Contains(".mp4"))
            {
                textBox1.Paste("<source src=\"" + a + "\" type=\"video/mp4\">" + Environment.NewLine);
            }
            else if (a.Contains(".webm"))
            {
                textBox1.Paste("<source src=\"" + a + "\" type=\"video/webm\">" + Environment.NewLine);
            }
            else if (a.Contains(".ogg"))
            {
                textBox1.Paste("<source src=\"" + a + "\" type=\"video/ogg\">" + Environment.NewLine);
            }
            else
            {
                invalidType = true;
            }
            if (b != null)
            {
                if (b.Contains(".mp4"))
                {
                    textBox1.Paste("<source src=\"" + b + "\" type=\"video/mp4\">" + Environment.NewLine);
                }
                else if (b.Contains(".webm"))
                {
                    textBox1.Paste("<source src=\"" + b + "\" type=\"video/webm\">" + Environment.NewLine);
                }
                else if (b.Contains(".ogg"))
                {
                    textBox1.Paste("<source src=\"" + b + "\" type=\"video/ogg\">" + Environment.NewLine);
                }
                else
                {
                    invalidType = true;
                }
            }
            if (c != null)
            {
                if (c.Contains(".mp4"))
                {
                    textBox1.Paste("<source src=\"" + c + "\" type=\"video/mp4\">" + Environment.NewLine);
                }
                else if (c.Contains(".webm"))
                {
                    textBox1.Paste("<source src=\"" + c + "\" type=\"video/webm\">" + Environment.NewLine);
                }
                else if (c.Contains(".ogg"))
                {
                    textBox1.Paste("<source src=\"" + c + "\" type=\"video/ogg\">" + Environment.NewLine);
                }
                else
                {
                    invalidType = true;
                }
            }
            textBox1.Paste("</video>" + Environment.NewLine);
            if (invalidType == true)
            {
                DialogResult result1 = MessageBox.Show("The File type entered is not compatible with HTML5. Please any of these file types: .mp4, .webm, .ogg", "Invalid File Type", MessageBoxButtons.OK);
            }
        }
        #endregion
        #region insertImage
        public void insertImage(string a, int b, int c)
        {
            if (b < 1 && c < 1)
            {
                textBox1.Paste("<img src=\"" + a + "\">");
            }
            else
            {
                textBox1.Paste("<img src=\"" + a + "\" height=\"" + b + "\" width=\"" + c + "\">");
            }
        }
        #endregion
        #region insertList
        public void insertList(int type, int amount)
        {
            string tempStuff = textBox1.SelectedText;

            if (type == 0) // unordered list
            {
                textBox1.Paste("<ul>" + Environment.NewLine);

                if (tempStuff != null)
                {
                    for (int i = 0; i < amount; i++)
                    {
                        textBox1.Paste("<li>" + tempStuff + "</li>" + Environment.NewLine);
                    }
                }
                else
                {
                    for (int i = 0; i < amount; i++)
                    {
                        textBox1.Paste("<li></li>" + Environment.NewLine);
                    }
                }

                textBox1.Paste("</ul>" + Environment.NewLine);
            }
            else // oredered list
            {
                textBox1.Paste("<ol>" + Environment.NewLine);

                if (tempStuff != null)
                {
                    for (int i = 0; i < amount; i++)
                    {
                        textBox1.Paste("<li>" + tempStuff + "</li>" + Environment.NewLine);
                    }
                }
                else
                {
                    for (int i = 0; i < amount; i++)
                    {
                        textBox1.Paste("<li></li>" + Environment.NewLine);
                    }
                }

                textBox1.Paste("</ol>" + Environment.NewLine);
            }
        }
        #endregion
        #region insertIFrame
        public void insertIFrame(string a, int b, int c, int d)
        {

        }
        #endregion
        #region insertSymbol
        public void insertSymbol(string symbol)
        {
            insertOne(symbol);
        }
        #endregion

        #region CSSAnimation
        public void cssFormAnimation()
        {

        }
        public void cssFormAnimation(string name, int duration, bool[] tf, int delay, int iCount, string direction, string playState)
        {

        }
        #endregion
        #region commenting out
        private void commentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.SelectedText.StartsWith("<!--") && textBox1.SelectedText.EndsWith("-->"))
            {
                textBox1.SelectedText = textBox1.SelectedText.Substring(5, textBox1.SelectedText.Length - 9);
            }
            else
                insertOne("<!-- ", " -->");
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (textBox1.SelectedText.StartsWith("<!--") && textBox1.SelectedText.EndsWith("-->"))
            {
                textBox1.SelectedText = textBox1.SelectedText.Substring(5, textBox1.SelectedText.Length - 9);
                //textBox1.Text.Replace(textBox1.SelectedText, textBox1.SelectedText.Substring(4, textBox1.SelectedText.Length - 4));
            }
            else
                insertOne("<!-- ", " -->");
        }
        #endregion







        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
        }

        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<b>", "</b>");
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // do not touch
        }

        
        
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form1 buck = new Form1();
            buck.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void familyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FontSettings font = new FontSettings(this);
            font.Show();
        }

        private void codeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            insCntrl("<code>", "</code>");
        }

        private void italicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<i>", "</i>");
        }

        private void articleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<article>", "</article>");
        }

        private void bodyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<body>", "</body>");
        }

        

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Are you sure you want to delete all text? This cannot be undone once confirmed.", "Delete Warning", MessageBoxButtons.YesNo);

            if (result1 == DialogResult.Yes)
            {
                textBox1.Clear();
            }
            
        }

        private void footerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<footer>", "</footer>");
        }

        private void formToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<form action=\"\" method=\"\">", "</form>");
        }

        private void headToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<head>", "</head>");
        }

        private void hTMLToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            insCntrl("<html>", "</html>");
        }

        private void lineBreakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<br />");
        }

        private void thematicBreakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<hr />");
        }

        private void paragraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<p>", "</p>");
        }

        private void webLinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<a href=\"", "\">", "</a>");
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            insCntrl("<div class=\"\">", "</div>");
        }

        private void imageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageTag it = new ImageTag(this);
            it.Show();
        }

        private void size1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<h1>", "</h1>");
        }

        private void size2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<h2>", "</h2>");
        }

        private void size3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<h3>", "</h3>");
        }

        private void size4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<h4>", "</h4>");
        }

        private void size5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<h5>", "</h5>");
        }

        private void size6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<h6>", "</h6>");
        }

        private void size7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<h7>", "</h7>");
        }

        private void styleSheetLinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<link rel=\"stylesheet\" type=\"text/css\" href=\"", "\">");
        }

        private void strongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<strong>", "</strong>");
        }

        private void emphasizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<em>", "</em>");
        }

        private void definitionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<dfn>", "</dfn>");
        }

        private void sampleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<samp>", "</samp>");
        }

        private void variableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<var>", "</var>");
        }

        private void objectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<object height=\"\" width=\"\" data=\"", "\"></object>");
        }

        private void optionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertItem("<select><option value=\"\">", "</option></select>");
        }

        private void buttonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<button type=\"button\">", "</button>");
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            FontSettings font = new FontSettings(this);
            font.Show();
        }


        private void subscriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<sub>", "</sub>");
        }

        private void superscriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<sup>", "</sup>");
        }

        private void tableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TableForm tf = new TableForm(this);
            tf.Show();
        }

        private void videoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VideoTag vt = new VideoTag(this);
            vt.Show();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            VideoTag vt = new VideoTag(this);
            vt.Show();
        }

        private void soundClipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AudioTag at = new AudioTag(this);
            at.Show();
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            AudioTag at = new AudioTag(this);
            at.Show();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void baseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertOne("<base href=\"\" target=\"\">", "</base>");
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            insCntrl("<a href=\"", "\">", "</a>");
        }

        private void orderedListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertItem("<ol>", "<li>", "</li>", "<li>", "</li>", "</ol>");
        }

        private void unorderedListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertItem("<ul>", "<li>", "</li>", "<li>", "</li>", "</ul>");
        }

        private void descriptionListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertItem("<dl>", "<dt>", "</dt>", "<dd>", "</dd>", "</dl>");
        }

        private void shortcutsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shortcuts shortkey = new Shortcuts();
            shortkey.Show();
        }

        private void embedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<embed src=\"", "\">");
        }

        private void highlightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<mark>", "</mark>");
        }

        private void navigationLinksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<nav>", "</nav>");
        }

        private void meterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertItem("<meter value=\"\">", "</meter>");
        }

        private void quoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<q>", "</q>");
        }

        private void progressBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertOne("<progress value=\"\" max=\"\">", "</progress>");
        }

        private void strikethroughToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<s>", "</s>");
        }

        private void scriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<script>", "</script>");
        }

        private void canvasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertOne("<canvas id=\"\">", "</canvas>");
        }

        private void summaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<summary>", "</summary>");
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // redo code here
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            insCntrl("<div style=\"\">", "</div>");
        }




        
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();

            if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                File.WriteAllText(saveFile.FileName, textBox1.Text);
            }
        }

        private void hTMLTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste("<!DOCTYPE html>");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.Show();
        }

        private void titleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<title>", "</title>");
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            BugsUpdates bugs = new BugsUpdates();
            bugs.Show();
        }

        private void bugsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BugsUpdates bugs = new BugsUpdates();
            bugs.Show();
        }

        private void animationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            insertMultCSS("animation: ", "-webkit-animation: ", null, null);
        }

        private void animationnameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("animation-name: ", "-webkit-animation-name: ", null, null);
        }

        private void animationdurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("animation-duration: ", "-webkit-animation-duration: ", null, null);
        }

        private void animationtimingfunctionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("animation-timing-function: ", "-webkit-animation-timing-function: ", null, null);
        }

        private void animationdelayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("animation-delay: ", "-webkit-animation-delay: ", null, null);
        }

        private void animationiterationcountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("animation-iteration-count: ", "-webkit-animation-iteration-count: ", null, null);
        }

        private void animationdirectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("animation-direction: ", "-webkit-animation-direction: ", null, null);
        }

        private void animationplaystateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("animation-play-state: ", "-webkit-animation-play-state: ", null, null);
        }

        private void backgroundToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            insertCSS("background: ");
        }

        private void backgroundattachmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("background-image: ", "background-repeat: ", "background-attachment: ", null);
        }

        private void backgroundcolorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertCSS("background-color: ");
        }

        private void backgroundimageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertCSS("background-image: ");
        }

        private void backgroundpositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("background-image: ", "background-repeat: ", "background-attachment: ", "background-position: ");
        }

        private void backgroundrepeatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("background-image: ", "background-repeat: ", null, null);
        }

        private void backgroundclipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("background-color: ", "background-clip: ", null, null);
        }

        private void backgroundoriginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("background-image: ", "background-repeat: ", "background-position: ", "background-origin: ");
        }

        private void backgroundsizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("background: ", "background-size: ", "background-repeat: ", null);
        }

        private void borderToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            insertCSS("border: ");
        }

        private void borderbottomToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            insertMultCSS("border-style: ", "border-bottom: ", null, null);
        }

        private void borderbottomcolorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("border-style: ", "border-bottom-color: ", null, null);
        }

        private void borderbottomstyleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("border-style: ", "border-bottom-style: ", null, null);
        }

        private void borderbottomwidthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("border-style: ", "border-bottom-width: ", null, null);
        }

        private void borderbottomleftradiusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("border: ", "border-bottom-left-radius: ", null, null);
        }

        private void borderbottomrightradiusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("border: ", "border-bottom-right-radius: ", null, null);
        }

        private void borderbolorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("border-style: ", "border-color: ", null, null);
        }

        private void borderleftToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            insertMultCSS("border-style: ", "border-left: ", null, null);
        }

        private void borderleftcolorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("border-style: ", "border-left-color: ", null, null);
        }

        private void borderleftstyleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("border-style: ", "border-left-style: ", null, null);
        }

        private void borderleftwidthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("border-style: ", "border-left-width: ", null, null);
        }

        private void borderimageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            insertMultCSS("-webkit-border-image: ", "-o-border-image: ", "border-image: ", null);
        }

        private void borderimageoutsetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("border-image-source: ", "border-image-outset: ", null, null);
        }

        private void borderimagerepeatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("border-image-source: ", "border-image-repeat: ", null, null);
        }

        private void borderimagesliceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("border-image-source: ", "border-image-slice: ", null, null);
        }

        private void borderimagesourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertCSS("border-image-source: ");
        }

        private void borderimagewidthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("border-image-source: ", "border-image-width: ", null, null);
        }

        private void borderradiusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("border: ", "border-radius: ", null, null);
        }

        private void borderrightToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            insertMultCSS("border-style: ", "border-right: ", null, null);
        }

        private void borderrightcolorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("border-style: ", "border-right-color: ", null, null);
        }

        private void borderrightstyleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("border-style: ", "border-right-style: ", null, null);
        }

        private void borderrightwidthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("border-style: ", "border-right-width: ", null, null);
        }

        private void borderstyleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertCSS("border-style: ");
        }

        private void bordertopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("border-style: ", "border-top: ", null, null);
        }

        private void bordertopcolorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("border-style: ", "border-top-color: ", null, null);
        }

        private void bordertopToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            insertMultCSS("border-style: ", "border-top-style: ", null, null);
        }

        private void bordertopwidthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("border-style: ", "border-top-width: ", null, null);
        }

        private void bordertopleftradiusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("border: ", "border-top-left-radius: ", null, null);
        }

        private void bordertoprightradiusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("border: ", "border-top-right-radius: ", null, null);
        }

        private void borderwidthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("border-style: ", "border-width: ", null, null);
        }

        private void outlineToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            insertCSS("outline: ");
        }

        private void outlinecolorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("outline-style: ", "outline-color: ", null, null);
        }

        private void outlinestyleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertCSS("outline-style: ");
        }

        private void outlinewidthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("outline-style: ", "outline-width: ", null, null);
        }

        private void boxalignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("-moz-box-pack: ", "-moz-box-align: ", "-webkit-box-pack: ", "-webkit-box-align: ");
        }

        private void boxdirectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("display: -moz-box", "-moz-box-direction: ", "display: -webkit-box", "-webkit-box-direction: ");
        }

        private void boxflexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("-moz-box-flex: ", "-webkit-box-flex: ", "box-flex: ", "border: ");
        }

        private void boxordinalgroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("-ms-flex-order: ", "-moz-box-ordinal-group: ", "-webkit-box-ordinal-group: ", "box-ordinal-group: ");
        }

        private void boxorientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("display: -moz-box", "-moz-box-orient: ", "display: -webkit-box", "-webkit-box-orient: ");
        }

        private void colorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            insertCSS("color: ");
        }

        private void columncountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("column-count: ", "-moz-column-count: ", "-webkit-column-count: ", null);
        }

        private void columngapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("column-gap: ", "-moz-column-gap: ", "-webkit-column-gap: ", null);
        }

        private void columnruleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("column-rule: ", "-moz-column-rule: ", "-webkit-column-rule: ", null);
        }

        private void columnrulecolorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("column-rule-color: ", "-moz-column-rule-color: ", "-webkit-column-rule-color: ", null);
        }

        private void columnrulestyleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("column-rule-style: ", "-moz-column-rule-style: ", "-webkit-column-rule-style: ", null);
        }

        private void columnrulewidthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("column-rule-width: ", "-moz-column-rule-width: ", "-webkit-column-rule-width: ", null);
        }

        private void columnspanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("column-span: ", "-webkit-column-span: ", null, null);
        }

        private void columnwidthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("column-width: ", "-moz-column-width: ", "-webkit-column-width: ", null);
        }

        private void columnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultCSS("columns: ", "-webkit-columns: ", "-moz-columns: ", null);
        }

        private void heightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertCSS("height: ");
        }

        private void widthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertCSS("width: ");
        }

        private void maxheightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertCSS("max-height: ");
        }

        private void maxwidthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertCSS("max-width: ");
        }

        private void minheightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertCSS("min-height: ");
        }

        private void minwidthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertCSS("min-width: ");
        }

        private void codeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<tt>", "</tt>");
        }

        private void underlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<u>", "</u>");
        }

        private void smallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<small>", "</small>");
        }

        private void bigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<big>", "</big>");
        }

        private void marqueeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<marquee>", "</marquee>");
        }

        private void blinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<blink>", "</blink>");
        }

        private void spanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertOne("<span style=\"\">", "</span>");
        }

        private void columnsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            insertMultItems("<colgroup>", "<col style=\"\" span=\"\">", "<col style=\"\" span=\"\">", "</colgroup>"); //example981
        }

        private void blockQuoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<blockquote cite=\"\">", "</blockquote>");
        }

        private void citationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<cite>", "</cite>");
        }

        private void mirrorTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertOne("<bdo dir=\"rtl\">", "</bdo>");
        }

        private void dataListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMultItems("<datalist id=\"\">", "<option value=\"\">", "<option value=\"\">", "</datalist>");
        }

        private void inputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste("<input type=\"\" name=\"\" value=\"\">");

            
        }

        private void legendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<fieldset>", "<legend>", "</legend>", "</fieldset>", 1); //example3338
        }

        private void centerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            insCntrl("<center>", "</center>");
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#60");
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#62");
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#64");
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#91");
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#93");
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#96");
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#126");
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#123");
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#125");
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#124");
        }

        private void iFrameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertOne("<iframe src=\"\" frameborder=\"\" height=\"\" width=\"\">", "</iframe>");
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#8704");
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#8706");
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#8707");
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#8709");
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#8711");
        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#8712");
        }

        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#8713");
        }

        private void toolStripMenuItem22_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#8715");
        }

        private void toolStripMenuItem24_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#8721");
        }

        private void toolStripMenuItem25_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#8730");
        }

        private void toolStripMenuItem26_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#8733");
        }

        private void toolStripMenuItem27_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#8734");
        }

        private void toolStripMenuItem28_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#8736");
        }

        private void toolStripMenuItem29_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#8747");
        }

        private void toolStripMenuItem30_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#8756");
        }

        private void toolStripMenuItem31_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#8764");
        }

        private void toolStripMenuItem32_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#8773");
        }

        private void toolStripMenuItem33_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#8776");
        }

        private void toolStripMenuItem34_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#8800");
        }

        private void toolStripMenuItem35_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#8801");
        }

        private void toolStripMenuItem36_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#8804");
        }

        private void toolStripMenuItem37_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#8805");
        }

        private void toolStripMenuItem38_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#8869");
        }

        private void γToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#915");
        }

        private void δToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#916");
        }

        private void θToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#920");
        }

        private void λToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#923");
        }

        private void ξToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#926");
        }

        private void πToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#928");
        }

        private void σToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#928");
        }

        private void φToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#934");
        }

        private void ψToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#936");
        }

        private void ωToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#937");
        }

        private void αToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#945");
        }

        private void βToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#946");
        }

        private void γToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#947");
        }

        private void δToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#948");
        }

        private void εToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#949");
        }

        private void ζToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#950");
        }

        private void ηToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#951");
        }

        private void θToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#952");
        }

        private void ιToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#953");
        }

        private void κToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#954");
        }

        private void λToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#955");
        }

        private void μToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#956");
        }

        private void νToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#957");
        }

        private void ξToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#958");
        }

        private void οToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#959");
        }

        private void πToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#960");
        }

        private void ρToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#961");
        }

        private void ςToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#962");
        }

        private void σToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#963");
        }

        private void τToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#964");
        }

        private void υToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#965");
        }

        private void φToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#966");
        }

        private void χToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#967");
        }

        private void ωToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#969");
        }

        private void ϑToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#977");
        }

        private void υToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#978");
        }

        private void ϖToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#982");
        }

        private void œToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#338");
        }

        private void œToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#339");
        }

        private void šToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#352");
        }

        private void šToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#353");
        }

        private void ÿToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#376");
        }

        private void ƒToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#402");
        }

        private void toolStripMenuItem39_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#8212");
        }

        private void toolStripMenuItem23_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#8224");
        }

        private void toolStripMenuItem40_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#8225");
        }

        private void toolStripMenuItem41_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#8226");
        }

        private void toolStripMenuItem42_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#8230");
        }

        private void toolStripMenuItem43_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#8240");
        }

        private void toolStripMenuItem44_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#8254");
        }

        private void toolStripMenuItem45_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#8364");
        }

        private void toolStripMenuItem46_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#153");
        }

        private void toolStripMenuItem47_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#8592");
        }

        private void toolStripMenuItem48_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#8593");
        }

        private void toolStripMenuItem49_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#8594");
        }

        private void toolStripMenuItem50_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#8595");
        }

        private void toolStripMenuItem51_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#8596");
        }

        private void toolStripMenuItem52_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#8629");
        }

        private void toolStripMenuItem53_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#9674");
        }

        private void toolStripMenuItem54_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#9824");
        }

        private void toolStripMenuItem55_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#9827");
        }

        private void toolStripMenuItem56_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#9829");
        }

        private void toolStripMenuItem57_Click(object sender, EventArgs e)
        {
            textBox1.Paste("&#9830");
        }

        private void tutorialsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        

        private void cSSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            insertItem("<style type=\"text/css\">", "</style>");
        }

        private void pageLinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insCntrl("<a name=\"", "\">", "</a>");
        }

        
        

        private void shortcutButtonsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (shortcutButtonsToolStripMenuItem.Checked == false)
            {
                toolStrip1.Visible = false;
            }
            else
            {
                toolStrip1.Visible = true;
            }
        }

        private void blackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Black;
            menuCheckedOne(1);
        }
        #region menuCheckedOne
        private void menuCheckedOne(int jj)
        {
            if (jj == 1)
            {
                blackToolStripMenuItem.Checked = true;
                blueToolStripMenuItem.Checked = false;
                brownToolStripMenuItem.Checked = false;
                greenToolStripMenuItem.Checked = false;
                greyToolStripMenuItem.Checked = false;
                orangeToolStripMenuItem.Checked = false;
                redToolStripMenuItem.Checked = false;
                whiteToolStripMenuItem.Checked = false;
                yellowToolStripMenuItem.Checked = false;
            }
            else if (jj == 2)
            {
                blueToolStripMenuItem.Checked = true;
                blackToolStripMenuItem.Checked = false;
                brownToolStripMenuItem.Checked = false;
                greenToolStripMenuItem.Checked = false;
                greyToolStripMenuItem.Checked = false;
                orangeToolStripMenuItem.Checked = false;
                redToolStripMenuItem.Checked = false;
                whiteToolStripMenuItem.Checked = false;
                yellowToolStripMenuItem.Checked = false;
            }
            else if (jj == 3)
            {
                brownToolStripMenuItem.Checked = true;
                blueToolStripMenuItem.Checked = false;
                blackToolStripMenuItem.Checked = false;
                greenToolStripMenuItem.Checked = false;
                greyToolStripMenuItem.Checked = false;
                orangeToolStripMenuItem.Checked = false;
                redToolStripMenuItem.Checked = false;
                whiteToolStripMenuItem.Checked = false;
                yellowToolStripMenuItem.Checked = false;
            }
            else if (jj == 4)
            {
                greenToolStripMenuItem.Checked = true;
                blueToolStripMenuItem.Checked = false;
                blackToolStripMenuItem.Checked = false;
                brownToolStripMenuItem.Checked = false;
                greyToolStripMenuItem.Checked = false;
                orangeToolStripMenuItem.Checked = false;
                redToolStripMenuItem.Checked = false;
                whiteToolStripMenuItem.Checked = false;
                yellowToolStripMenuItem.Checked = false;
            }
            else if (jj == 5)
            {
                greyToolStripMenuItem.Checked = true;
                blueToolStripMenuItem.Checked = false;
                blackToolStripMenuItem.Checked = false;
                brownToolStripMenuItem.Checked = false;
                greenToolStripMenuItem.Checked = false;
                orangeToolStripMenuItem.Checked = false;
                redToolStripMenuItem.Checked = false;
                whiteToolStripMenuItem.Checked = false;
                yellowToolStripMenuItem.Checked = false;
            }
            else if (jj == 6)
            {
                orangeToolStripMenuItem.Checked = true;
                blueToolStripMenuItem.Checked = false;
                blackToolStripMenuItem.Checked = false;
                brownToolStripMenuItem.Checked = false;
                greenToolStripMenuItem.Checked = false;
                greyToolStripMenuItem.Checked = false;
                redToolStripMenuItem.Checked = false;
                whiteToolStripMenuItem.Checked = false;
                yellowToolStripMenuItem.Checked = false;
            }
            else if (jj == 7)
            {
                redToolStripMenuItem.Checked = true;
                blueToolStripMenuItem.Checked = false;
                blackToolStripMenuItem.Checked = false;
                brownToolStripMenuItem.Checked = false;
                greenToolStripMenuItem.Checked = false;
                greyToolStripMenuItem.Checked = false;
                orangeToolStripMenuItem.Checked = false;
                whiteToolStripMenuItem.Checked = false;
                yellowToolStripMenuItem.Checked = false;
            }
            else if (jj == 8)
            {
                whiteToolStripMenuItem.Checked = true;
                blueToolStripMenuItem.Checked = false;
                blackToolStripMenuItem.Checked = false;
                brownToolStripMenuItem.Checked = false;
                greenToolStripMenuItem.Checked = false;
                greyToolStripMenuItem.Checked = false;
                orangeToolStripMenuItem.Checked = false;
                redToolStripMenuItem.Checked = false;
                yellowToolStripMenuItem.Checked = false;
            }
            else if (jj == 9)
            {
                yellowToolStripMenuItem.Checked = true;
                blueToolStripMenuItem.Checked = false;
                blackToolStripMenuItem.Checked = false;
                brownToolStripMenuItem.Checked = false;
                greenToolStripMenuItem.Checked = false;
                greyToolStripMenuItem.Checked = false;
                orangeToolStripMenuItem.Checked = false;
                redToolStripMenuItem.Checked = false;
                whiteToolStripMenuItem.Checked = false;
            }
        #endregion
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Blue;
            menuCheckedOne(2);
        }

        private void brownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.SaddleBrown;
            menuCheckedOne(3);
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Green;
            menuCheckedOne(4);
        }

        private void greyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Gray;
            menuCheckedOne(5);
        }

        private void orangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Orange;
            menuCheckedOne(6);
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Red;
            menuCheckedOne(7);
        }

        private void whiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.White;
            menuCheckedOne(8);
        }

        private void yellowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Yellow;
            menuCheckedOne(9);
        }

        

        private void arialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Font = new Font("Arial", fontSize);
            fontFam = "Arial";
            menuCheckTwo(1);
        }

        private void courierNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Font = new Font("Courier New", fontSize);
            fontFam = "Courier New";
            menuCheckTwo(4);
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        #region MenuCheckTwo
        private void menuCheckTwo(int jz)
        {
            if (jz == 1)
            {
                arialToolStripMenuItem.Checked = true;
                calibriToolStripMenuItem.Checked = false;
                corbelToolStripMenuItem.Checked = false;
                courierNewToolStripMenuItem.Checked = false;
                euroRomanToolStripMenuItem.Checked = false;
                franklinGothicBookToolStripMenuItem.Checked = false;
                helveticaToolStripMenuItem.Checked = false;
                myriadProToolStripMenuItem.Checked = false;
                segoeUIToolStripMenuItem.Checked = false;
                typewriterTextToolStripMenuItem.Checked = false;
            }
            else if (jz == 2)
            {
                arialToolStripMenuItem.Checked = false;
                calibriToolStripMenuItem.Checked = true;
                corbelToolStripMenuItem.Checked = false;
                courierNewToolStripMenuItem.Checked = false;
                euroRomanToolStripMenuItem.Checked = false;
                franklinGothicBookToolStripMenuItem.Checked = false;
                helveticaToolStripMenuItem.Checked = false;
                myriadProToolStripMenuItem.Checked = false;
                segoeUIToolStripMenuItem.Checked = false;
                typewriterTextToolStripMenuItem.Checked = false;
            }
            else if (jz == 3)
            {
                arialToolStripMenuItem.Checked = false;
                calibriToolStripMenuItem.Checked = false;
                corbelToolStripMenuItem.Checked = true;
                courierNewToolStripMenuItem.Checked = false;
                euroRomanToolStripMenuItem.Checked = false;
                franklinGothicBookToolStripMenuItem.Checked = false;
                helveticaToolStripMenuItem.Checked = false;
                myriadProToolStripMenuItem.Checked = false;
                segoeUIToolStripMenuItem.Checked = false;
                typewriterTextToolStripMenuItem.Checked = false;
            }
            else if (jz == 4)
            {
                arialToolStripMenuItem.Checked = false;
                calibriToolStripMenuItem.Checked = false;
                corbelToolStripMenuItem.Checked = false;
                courierNewToolStripMenuItem.Checked = true;
                euroRomanToolStripMenuItem.Checked = false;
                franklinGothicBookToolStripMenuItem.Checked = false;
                helveticaToolStripMenuItem.Checked = false;
                myriadProToolStripMenuItem.Checked = false;
                segoeUIToolStripMenuItem.Checked = false;
                typewriterTextToolStripMenuItem.Checked = false;
            }
            else if (jz == 5)
            {
                arialToolStripMenuItem.Checked = false;
                calibriToolStripMenuItem.Checked = false;
                corbelToolStripMenuItem.Checked = false;
                courierNewToolStripMenuItem.Checked = false;
                euroRomanToolStripMenuItem.Checked = true;
                franklinGothicBookToolStripMenuItem.Checked = false;
                helveticaToolStripMenuItem.Checked = false;
                myriadProToolStripMenuItem.Checked = false;
                segoeUIToolStripMenuItem.Checked = false;
                typewriterTextToolStripMenuItem.Checked = false;
            }
            else if (jz == 6)
            {
                arialToolStripMenuItem.Checked = false;
                calibriToolStripMenuItem.Checked = false;
                corbelToolStripMenuItem.Checked = false;
                courierNewToolStripMenuItem.Checked = false;
                euroRomanToolStripMenuItem.Checked = false;
                franklinGothicBookToolStripMenuItem.Checked = true;
                helveticaToolStripMenuItem.Checked = false;
                myriadProToolStripMenuItem.Checked = false;
                segoeUIToolStripMenuItem.Checked = false;
                typewriterTextToolStripMenuItem.Checked = false;
            }
            else if (jz == 7)
            {
                arialToolStripMenuItem.Checked = false;
                calibriToolStripMenuItem.Checked = false;
                corbelToolStripMenuItem.Checked = false;
                courierNewToolStripMenuItem.Checked = false;
                euroRomanToolStripMenuItem.Checked = false;
                franklinGothicBookToolStripMenuItem.Checked = false;
                helveticaToolStripMenuItem.Checked = true;
                myriadProToolStripMenuItem.Checked = false;
                segoeUIToolStripMenuItem.Checked = false;
                typewriterTextToolStripMenuItem.Checked = false;
            }
            else if (jz == 8)
            {
                arialToolStripMenuItem.Checked = false;
                calibriToolStripMenuItem.Checked = false;
                corbelToolStripMenuItem.Checked = false;
                courierNewToolStripMenuItem.Checked = false;
                euroRomanToolStripMenuItem.Checked = false;
                franklinGothicBookToolStripMenuItem.Checked = false;
                helveticaToolStripMenuItem.Checked = false;
                myriadProToolStripMenuItem.Checked = true;
                segoeUIToolStripMenuItem.Checked = false;
                typewriterTextToolStripMenuItem.Checked = false;
            }
            else if (jz == 9)
            {
                arialToolStripMenuItem.Checked = false;
                calibriToolStripMenuItem.Checked = false;
                corbelToolStripMenuItem.Checked = false;
                courierNewToolStripMenuItem.Checked = false;
                euroRomanToolStripMenuItem.Checked = false;
                franklinGothicBookToolStripMenuItem.Checked = false;
                helveticaToolStripMenuItem.Checked = false;
                myriadProToolStripMenuItem.Checked = false;
                segoeUIToolStripMenuItem.Checked = true;
                typewriterTextToolStripMenuItem.Checked = false;
            }
            else if (jz == 10)
            {
                arialToolStripMenuItem.Checked = false;
                calibriToolStripMenuItem.Checked = false;
                corbelToolStripMenuItem.Checked = false;
                courierNewToolStripMenuItem.Checked = false;
                euroRomanToolStripMenuItem.Checked = false;
                franklinGothicBookToolStripMenuItem.Checked = false;
                helveticaToolStripMenuItem.Checked = false;
                myriadProToolStripMenuItem.Checked = false;
                segoeUIToolStripMenuItem.Checked = false;
                typewriterTextToolStripMenuItem.Checked = true;
            }
        }
                #endregion

        #region fontCheckThree
        private void fontCheckThree(int numTwo)
        {
            if (numTwo == 58)
            {
                toolStripMenuItem58.Checked = true;
                toolStripMenuItem59.Checked = false;
                toolStripMenuItem60.Checked = false;
                toolStripMenuItem61.Checked = false;
                toolStripMenuItem62.Checked = false;
                toolStripMenuItem63.Checked = false;
                toolStripMenuItem64.Checked = false;
                toolStripMenuItem65.Checked = false;
                toolStripMenuItem66.Checked = false;
                toolStripMenuItem67.Checked = false;
                toolStripMenuItem68.Checked = false;
                toolStripMenuItem69.Checked = false;
                toolStripMenuItem70.Checked = false;
                toolStripMenuItem71.Checked = false;
            }
            if (numTwo == 59)
            {
                toolStripMenuItem58.Checked = false;
                toolStripMenuItem59.Checked = true;
                toolStripMenuItem60.Checked = false;
                toolStripMenuItem61.Checked = false;
                toolStripMenuItem62.Checked = false;
                toolStripMenuItem63.Checked = false;
                toolStripMenuItem64.Checked = false;
                toolStripMenuItem65.Checked = false;
                toolStripMenuItem66.Checked = false;
                toolStripMenuItem67.Checked = false;
                toolStripMenuItem68.Checked = false;
                toolStripMenuItem69.Checked = false;
                toolStripMenuItem70.Checked = false;
                toolStripMenuItem71.Checked = false;
            }
            if (numTwo == 60)
            {
                toolStripMenuItem58.Checked = false;
                toolStripMenuItem59.Checked = false;
                toolStripMenuItem60.Checked = true;
                toolStripMenuItem61.Checked = false;
                toolStripMenuItem62.Checked = false;
                toolStripMenuItem63.Checked = false;
                toolStripMenuItem64.Checked = false;
                toolStripMenuItem65.Checked = false;
                toolStripMenuItem66.Checked = false;
                toolStripMenuItem67.Checked = false;
                toolStripMenuItem68.Checked = false;
                toolStripMenuItem69.Checked = false;
                toolStripMenuItem70.Checked = false;
                toolStripMenuItem71.Checked = false;
            }
            if (numTwo == 61)
            {
                toolStripMenuItem58.Checked = false;
                toolStripMenuItem59.Checked = false;
                toolStripMenuItem60.Checked = false;
                toolStripMenuItem61.Checked = true;
                toolStripMenuItem62.Checked = false;
                toolStripMenuItem63.Checked = false;
                toolStripMenuItem64.Checked = false;
                toolStripMenuItem65.Checked = false;
                toolStripMenuItem66.Checked = false;
                toolStripMenuItem67.Checked = false;
                toolStripMenuItem68.Checked = false;
                toolStripMenuItem69.Checked = false;
                toolStripMenuItem70.Checked = false;
                toolStripMenuItem71.Checked = false;
            }
            if (numTwo == 62)
            {
                toolStripMenuItem58.Checked = false;
                toolStripMenuItem59.Checked = false;
                toolStripMenuItem60.Checked = false;
                toolStripMenuItem61.Checked = false;
                toolStripMenuItem62.Checked = true;
                toolStripMenuItem63.Checked = false;
                toolStripMenuItem64.Checked = false;
                toolStripMenuItem65.Checked = false;
                toolStripMenuItem66.Checked = false;
                toolStripMenuItem67.Checked = false;
                toolStripMenuItem68.Checked = false;
                toolStripMenuItem69.Checked = false;
                toolStripMenuItem70.Checked = false;
                toolStripMenuItem71.Checked = false;
            }
            if (numTwo == 63)
            {
                toolStripMenuItem58.Checked = false;
                toolStripMenuItem59.Checked = false;
                toolStripMenuItem60.Checked = false;
                toolStripMenuItem61.Checked = false;
                toolStripMenuItem62.Checked = false;
                toolStripMenuItem63.Checked = true;
                toolStripMenuItem64.Checked = false;
                toolStripMenuItem65.Checked = false;
                toolStripMenuItem66.Checked = false;
                toolStripMenuItem67.Checked = false;
                toolStripMenuItem68.Checked = false;
                toolStripMenuItem69.Checked = false;
                toolStripMenuItem70.Checked = false;
                toolStripMenuItem71.Checked = false;
            }
            if (numTwo == 64)
            {
                toolStripMenuItem58.Checked = false;
                toolStripMenuItem59.Checked = false;
                toolStripMenuItem60.Checked = false;
                toolStripMenuItem61.Checked = false;
                toolStripMenuItem62.Checked = false;
                toolStripMenuItem63.Checked = false;
                toolStripMenuItem64.Checked = true;
                toolStripMenuItem65.Checked = false;
                toolStripMenuItem66.Checked = false;
                toolStripMenuItem67.Checked = false;
                toolStripMenuItem68.Checked = false;
                toolStripMenuItem69.Checked = false;
                toolStripMenuItem70.Checked = false;
                toolStripMenuItem71.Checked = false;
            }
            if (numTwo == 65)
            {
                toolStripMenuItem58.Checked = false;
                toolStripMenuItem59.Checked = false;
                toolStripMenuItem60.Checked = false;
                toolStripMenuItem61.Checked = false;
                toolStripMenuItem62.Checked = false;
                toolStripMenuItem63.Checked = false;
                toolStripMenuItem64.Checked = false;
                toolStripMenuItem65.Checked = true;
                toolStripMenuItem66.Checked = false;
                toolStripMenuItem67.Checked = false;
                toolStripMenuItem68.Checked = false;
                toolStripMenuItem69.Checked = false;
                toolStripMenuItem70.Checked = false;
                toolStripMenuItem71.Checked = false;
            }
            if (numTwo == 66)
            {
                toolStripMenuItem58.Checked = false;
                toolStripMenuItem59.Checked = false;
                toolStripMenuItem60.Checked = false;
                toolStripMenuItem61.Checked = false;
                toolStripMenuItem62.Checked = false;
                toolStripMenuItem63.Checked = false;
                toolStripMenuItem64.Checked = false;
                toolStripMenuItem65.Checked = false;
                toolStripMenuItem66.Checked = true;
                toolStripMenuItem67.Checked = false;
                toolStripMenuItem68.Checked = false;
                toolStripMenuItem69.Checked = false;
                toolStripMenuItem70.Checked = false;
                toolStripMenuItem71.Checked = false;
            }
            if (numTwo == 67)
            {
                toolStripMenuItem58.Checked = false;
                toolStripMenuItem59.Checked = false;
                toolStripMenuItem60.Checked = false;
                toolStripMenuItem61.Checked = false;
                toolStripMenuItem62.Checked = false;
                toolStripMenuItem63.Checked = false;
                toolStripMenuItem64.Checked = false;
                toolStripMenuItem65.Checked = false;
                toolStripMenuItem66.Checked = false;
                toolStripMenuItem67.Checked = true;
                toolStripMenuItem68.Checked = false;
                toolStripMenuItem69.Checked = false;
                toolStripMenuItem70.Checked = false;
                toolStripMenuItem71.Checked = false;
            }
            if (numTwo == 68)
            {
                toolStripMenuItem58.Checked = false;
                toolStripMenuItem59.Checked = false;
                toolStripMenuItem60.Checked = false;
                toolStripMenuItem61.Checked = false;
                toolStripMenuItem62.Checked = false;
                toolStripMenuItem63.Checked = false;
                toolStripMenuItem64.Checked = false;
                toolStripMenuItem65.Checked = false;
                toolStripMenuItem66.Checked = false;
                toolStripMenuItem67.Checked = false;
                toolStripMenuItem68.Checked = true;
                toolStripMenuItem69.Checked = false;
                toolStripMenuItem70.Checked = false;
                toolStripMenuItem71.Checked = false;
            }
            if (numTwo == 69)
            {
                toolStripMenuItem58.Checked = false;
                toolStripMenuItem59.Checked = false;
                toolStripMenuItem60.Checked = false;
                toolStripMenuItem61.Checked = false;
                toolStripMenuItem62.Checked = false;
                toolStripMenuItem63.Checked = false;
                toolStripMenuItem64.Checked = false;
                toolStripMenuItem65.Checked = false;
                toolStripMenuItem66.Checked = false;
                toolStripMenuItem67.Checked = false;
                toolStripMenuItem68.Checked = false;
                toolStripMenuItem69.Checked = true;
                toolStripMenuItem70.Checked = false;
                toolStripMenuItem71.Checked = false;
            }
            if (numTwo == 70)
            {
                toolStripMenuItem58.Checked = false;
                toolStripMenuItem59.Checked = false;
                toolStripMenuItem60.Checked = false;
                toolStripMenuItem61.Checked = false;
                toolStripMenuItem62.Checked = false;
                toolStripMenuItem63.Checked = false;
                toolStripMenuItem64.Checked = false;
                toolStripMenuItem65.Checked = false;
                toolStripMenuItem66.Checked = false;
                toolStripMenuItem67.Checked = false;
                toolStripMenuItem68.Checked = false;
                toolStripMenuItem69.Checked = false;
                toolStripMenuItem70.Checked = true;
                toolStripMenuItem71.Checked = false;
            }
            if (numTwo == 71)
            {
                toolStripMenuItem58.Checked = false;
                toolStripMenuItem59.Checked = false;
                toolStripMenuItem60.Checked = false;
                toolStripMenuItem61.Checked = false;
                toolStripMenuItem62.Checked = false;
                toolStripMenuItem63.Checked = false;
                toolStripMenuItem64.Checked = false;
                toolStripMenuItem65.Checked = false;
                toolStripMenuItem66.Checked = false;
                toolStripMenuItem67.Checked = false;
                toolStripMenuItem68.Checked = false;
                toolStripMenuItem69.Checked = false;
                toolStripMenuItem70.Checked = false;
                toolStripMenuItem71.Checked = true;
            }
        }
        #endregion

        #region BackgroundColorSelect
        private void blackToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Black;
            menuCheckTwo(1);
        }

        private void blueToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Blue;
            menuCheckTwo(2);
        }

        private void brownToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.SaddleBrown;
            menuCheckTwo(3);
        }

        private void greenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Green;
            menuCheckTwo(4);
        }

        private void grayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Gray;
            menuCheckTwo(5);
        }

        private void orangeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Orange;
            menuCheckTwo(6);
        }

        private void redToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Red;
            menuCheckTwo(7);
        }

        private void whiteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
            menuCheckTwo(8);
        }

        private void yellowToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Yellow;
            menuCheckTwo(9);
        }
#endregion

        private void calibriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Font = new Font("Calibri", fontSize);
            fontFam = "Calibri";
            menuCheckTwo(2);
        }

        private void corbelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Font = new Font("Corbel", fontSize);
            fontFam = "Corbel";
            menuCheckTwo(3);
        }

        private void euroRomanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Font = new Font("EuroRoman", fontSize);
            fontFam = "EuroRoman";
            menuCheckTwo(5);
        }

        private void toolStripMenuItem58_Click(object sender, EventArgs e)
        {
            fontSize = 8;
            textBox1.Font = new Font(fontFam, fontSize);
            fontCheckThree(58);
        }

        private void toolStripMenuItem59_Click(object sender, EventArgs e)
        {
            fontSize = 9;
            textBox1.Font = new Font(fontFam, fontSize);
            fontCheckThree(59);
        }

        private void toolStripMenuItem60_Click(object sender, EventArgs e)
        {
            fontSize = 10;
            textBox1.Font = new Font(fontFam, fontSize);
            fontCheckThree(60);
        }

        private void toolStripMenuItem61_Click(object sender, EventArgs e)
        {
            fontSize = 11;
            textBox1.Font = new Font(fontFam, fontSize);
            fontCheckThree(61);
        }

        private void toolStripMenuItem62_Click(object sender, EventArgs e)
        {
            fontSize = 12;
            textBox1.Font = new Font(fontFam, fontSize);
            fontCheckThree(62);
        }

        private void toolStripMenuItem63_Click(object sender, EventArgs e)
        {
            fontSize = 14;
            textBox1.Font = new Font(fontFam, fontSize);
            fontCheckThree(63);
        }

        private void toolStripMenuItem64_Click(object sender, EventArgs e)
        {
            fontSize = 16;
            textBox1.Font = new Font(fontFam, fontSize);
            fontCheckThree(64);
        }

        private void toolStripMenuItem65_Click(object sender, EventArgs e)
        {
            fontSize = 18;
            textBox1.Font = new Font(fontFam, fontSize);
            fontCheckThree(65);
        }

        private void toolStripMenuItem66_Click(object sender, EventArgs e)
        {
            fontSize = 20;
            textBox1.Font = new Font(fontFam, fontSize);
            fontCheckThree(66);
        }

        private void toolStripMenuItem67_Click(object sender, EventArgs e)
        {
            fontSize = 24;
            textBox1.Font = new Font(fontFam, fontSize);
            fontCheckThree(67);
        }

        private void toolStripMenuItem68_Click(object sender, EventArgs e)
        {
            fontSize = 28;
            textBox1.Font = new Font(fontFam, fontSize);
            fontCheckThree(68);
        }

        private void toolStripMenuItem69_Click(object sender, EventArgs e)
        {
            fontSize = 32;
            textBox1.Font = new Font(fontFam, fontSize);
            fontCheckThree(69);
        }

        private void toolStripMenuItem70_Click(object sender, EventArgs e)
        {
            fontSize = 36;
            textBox1.Font = new Font(fontFam, fontSize);
            fontCheckThree(70);
        }

        private void toolStripMenuItem71_Click(object sender, EventArgs e)
        {
            fontSize = 40;
            textBox1.Font = new Font(fontFam, fontSize);
            fontCheckThree(71);
        }

        private void franklinGothicBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Font = new Font("Franklin Gothic Book", fontSize);
            fontFam = "Franklin Gothic Book";
            menuCheckTwo(6);
        }

        private void helveticaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Font = new Font("Helvetica", fontSize);
            fontFam = "Helvetica";
            menuCheckTwo(7);
        }

        private void myriadProToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Font = new Font("Myriad Pro", fontSize);
            fontFam = "Myriad Pro";
            menuCheckTwo(8);
        }

        private void segoeUIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Font = new Font("Segoe UI", fontSize);
            fontFam = "Segoe UI";
            menuCheckTwo(9);
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            insertItem("<button type=\"button\">", "</button>");
        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            insertItem("<article>", "</article>");
        }

        private void toolStripButton17_Click(object sender, EventArgs e)
        {
            insertItem("<q>", "</q>");
        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {
            insertOne("<span style=\"\">", "</span>");
        }

        private void toolStripButton19_Click(object sender, EventArgs e)
        {
            ListTagForm lf = new ListTagForm(this);
            lf.Show();

            //insertItem("<ul>", "<li>", "</li>", "<li>", "</li>", "<ul>");
        }

        private void toolStripButton20_Click(object sender, EventArgs e)
        {
            insertItem("<ol>", "<li>", "</li>", "<li>", "</li>", "</ol>");
        }

        private void toolStripButton21_Click(object sender, EventArgs e)
        {
            TableForm tf = new TableForm(this);
            tf.Show();
        }

        private void toolStripButton22_Click(object sender, EventArgs e)
        {
            insertMultItems("<colgroup>", "<col style=\"\" span=\"\">", "<col style=\"\" span=\"\">", "</colgroup>");
        }



        public void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchReplace sr = new SearchReplace(this);
            sr.Show();
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int fontSize = 10;
            fontColor = "white";
            fontFam = "Courier New";
            backColor = "Gray";
            insControl = 1;
            symbolInsert = false;


            bool tempBool = false;
            if (fontSize != 10) 
            {
                tempBool = true;
            }
            else if (!fontColor.Equals("white"))
            {
                tempBool = true;
            }
            else if (!fontFam.Equals("Courier New"))
            {
                tempBool = true;
            }
            else if (!backColor.Equals("Gray"))
            {
                tempBool = true;
            }
            else if (insControl != 1)
            {
                tempBool = true;
            }
            else if (symbolInsert != false)
            {
                tempBool = true;
            }

            if (tempBool == false)
            {
                FormSettings formset = new FormSettings(this);
                formset.Show();
            }
            else if (tempBool == true)
            {
                FormSettings formset = new FormSettings(this, fontFam, backColor, fontColor, fontSize, insControl, symbolInsert);
                formset.Show();
            }
            
        }

        

        private void toolStripButton18_Click(object sender, EventArgs e)
        {
            SearchReplace sr = new SearchReplace(this);
            sr.Show();
        }

        private void activateRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActivationForm aF = new ActivationForm(this);
            aF.Show();
        }

        private void searchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SearchReplace sr = new SearchReplace(this);
            sr.Show();
        }

        private void webLinkToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            insCntrl("<a href=\"", "\">", "</a>");
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (browserPreviewToolStripMenuItem.Checked == true)
            {
                textBox1.Dock = DockStyle.Left;
                textBox1.Width = this.Width / 2;
                web.Dock = DockStyle.Right;
                web.Width = this.Width / 2;
            }
            else
            {

            }
        }

        private void toolStripButton23_Click(object sender, EventArgs e)
        {
            CSSForm csf = new CSSForm(this);

            

            csf.Show();
        }

        private void toolStripButton24_Click(object sender, EventArgs e)
        {
            insertOne("<code>", "</code>");
        }

        private void toolStripButton25_Click(object sender, EventArgs e)
        {
            ImageTag it = new ImageTag(this);
            it.Show();
        }

        private void toolStripButton27_Click(object sender, EventArgs e)
        {
            insertOne("<b>", "</b>");
        }

        private void toolStripButton29_Click(object sender, EventArgs e)
        {
            insertOne("<i>", "</i>");
        }

        private void toolStripButton28_Click(object sender, EventArgs e)
        {
            insertOne("<u>", "</u>");
        }

        private void toolStripButton26_Click(object sender, EventArgs e)
        {

        }

        private void intellisenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (intellisenseToolStripMenuItem.Checked == false)
            {
                intellisenseCheck = false;
            }
            else
            {
                intellisenseCheck = true;
            }
        }

        private void symbolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertSymbol iSym = new InsertSymbol(this);
            iSym.Show();
        }

        private void toolStripButton20_Click_1(object sender, EventArgs e)
        {
            InsertSymbol iSym = new InsertSymbol(this);
            iSym.Show();
        }

        private void Form1_MaximumSizeChanged(object sender, EventArgs e)
        {
            if (browserPreviewToolStripMenuItem.Checked == true)
            {
                textBox1.Dock = DockStyle.Left;
                textBox1.Width = this.Width / 2;
                web.Dock = DockStyle.Right;
                web.Width = this.Width / 2;
            }
            else
            {

            }
        }

        private void typewriterTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Font = new Font("Txt", fontSize, FontStyle.Bold);
            fontFam = "Txt";
            menuCheckTwo(10);
        }

        private void toolStripButton30_Click(object sender, EventArgs e)
        {
            insertOne("<center>", "</center>");
        }

        private void toolStripButton32_Click(object sender, EventArgs e)
        {
            if (textBox1.SelectedText != null)
            {

            }

            insertOne("<iframe src=\"\" frameborder=\"\" height=\"\" width=\"\">", "</iframe>");
            IFrameForm iff = new IFrameForm(this);
            iff.Show();
        }

       

        

        
    }


    
}
