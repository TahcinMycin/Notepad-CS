//https://youtu.be/3ate_o27GeA
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MyNotes
{
    public partial class Form1 : Form
    {
        public static string FindText=" ";
        public static string RepaceText;
        public static Boolean matchcase;
        int d;
        public Form1()
        {
            InitializeComponent();
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "";
        }

        private void undoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Text Files(*txt)|*.txt|All files(*.*)|*.*|C/C++ Files(*.cpp)|*.c|C# Files(*.cs)|*.cs|HTML Files(*.html)|*.html|PHP Files(*.php)|*.php|C/C++ Notes(*.cnotes)|*.cnotes";
            op.FilterIndex = 2;
            op.RestoreDirectory = true;
            string Filename = "";
            if(op.ShowDialog()==DialogResult.OK)
            {
                try
                {
                    Filename = op.FileName;
                    StreamReader sr = File.OpenText(Filename);
                    richTextBox1.Text = "";
                    string strline;
                    while ((strline = sr.ReadLine() )!= null)
                    {
                        richTextBox1.Text += strline + "\n";
                    }
                    richTextBox1.SelectionStart = 0;
                    richTextBox1.SelectionLength = 0;
                    this.Text = Filename;
                    sr.Close();
                }
                catch(Exception en)
                {
                    MessageBox.Show("Error Occured:\n" + en.ToString());
                }
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
            undoToolStripMenuItem.Enabled = false;
            redoToolStripMenuItem.Enabled = true;
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
            undoToolStripMenuItem.Enabled = true;
            redoToolStripMenuItem.Enabled = false;
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }
        
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "All files(*.*)|*.*|Text Files(*txt)|*.txt|C/C++ Files(*.cpp)|*.c|C# Files(*.cs)|*.cs|HTML Files(*.html)|*.html|PHP Files(*.php)|*.php|C/C++ Notes(*.cnotes)|*.cnotes";
            var r= saveFileDialog1.ShowDialog();
            if(r==System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName);
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

            richTextBox1.Clear();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(about frm=new about())
            {
                frm.ShowDialog();
            }
        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "All files(*.*)|*.*|Text Files(*txt)|*.txt|C/C++ Files(*.cpp)|*.c|C# Files(*.cs)|*.cs|HTML Files(*.html)|*.html|PHP Files(*.php)|*.php|C/C++ Notes(*.cnotes)|*.cnotes";
            var r = saveFileDialog1.ShowDialog();
            if (r == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > 0)
            {
                undoToolStripMenuItem.Enabled = true;
                cutToolStripMenuItem.Enabled = true;
                copyToolStripMenuItem.Enabled = true;
                selectAllToolStripMenuItem.Enabled = true;
            }
            else
            {
                undoToolStripMenuItem.Enabled = false;
                redoToolStripMenuItem.Enabled = false;
                cutToolStripMenuItem.Enabled = false;
                copyToolStripMenuItem.Enabled = false;
                selectAllToolStripMenuItem.Enabled = false;
            }
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Text Files(*txt)|*.txt|All files(*.*)|*.*|C/C++ Files(*.cpp)|*.c|C# Files(*.cs)|*.cs|HTML Files(*.html)|*.html|PHP Files(*.php)|*.php|C/C++ Notes(*.cnotes)|*.cnotes";
            op.FilterIndex = 2;
            op.RestoreDirectory = true;
            string Filename = "";
            if (op.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Filename = op.FileName;
                    StreamReader sr = File.OpenText(Filename);
                    richTextBox1.Text = "";
                    string strline;
                    while ((strline = sr.ReadLine()) != null)
                    {
                        richTextBox1.Text += strline + "\n";
                    }
                    richTextBox1.SelectionStart = 0;
                    richTextBox1.SelectionLength = 0;
                    this.Text = Filename;
                    sr.Close();
                }
                catch (Exception en)
                {
                    MessageBox.Show("Error Occured:\n" + en.ToString());
                }
            }
        }

        private void dateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text +=" "+ DateTime.Now;
        }

        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.Font,FontStyle.Bold);
        }

        private void italicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Italic);
        }

        private void underlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Underline);
        }

        private void strikeThroughToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Strikeout);
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
        }

        private void sellectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Find r = new Find();
            r.ShowDialog();
            if(FindText!=null)
            {
                d = richTextBox1.Find(FindText);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (FindText != null)
            {
                if(matchcase==true)
                {
                    d = richTextBox1.Find(FindText, (d + 1), richTextBox1.Text.Length, RichTextBoxFinds.MatchCase);

                }
                else
                {
                    d = richTextBox1.Find(FindText, (d + 1), richTextBox1.Text.Length, RichTextBoxFinds.None);
                }
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            replace r = new replace();
            r.ShowDialog();
            richTextBox1.Find(FindText);
            richTextBox1.SelectedText = RepaceText;
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            if(richTextBox1.WordWrap==true)
            {
                richTextBox1.WordWrap = false;
            }
            else
            {
                richTextBox1.WordWrap = true;
            }
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            richTextBox1.Font = fontDialog1.Font;
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            richTextBox1.BackColor = colorDialog1.Color;
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            richTextBox1.ForeColor = colorDialog1.Color;
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            richTextBox1.SelectionColor = colorDialog1.Color;
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            richTextBox1.SelectionBackColor = colorDialog1.Color;
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (about frm = new about())
            {
                frm.ShowDialog();
            }
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
