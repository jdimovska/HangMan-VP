using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hangman
{
    public partial class HighScore : Form
    {
        List<Tuple<String, int>> hs = new List<Tuple<string, int>>();
        public int score;
        public HighScore(int score)
        {
            this.score = score;
            InitializeComponent();
            textBox2.Text = Convert.ToString(score);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inp = @"../../Resources/score.txt";
            string outp = @"../../Resources/scorencr.txt";
            string decr = @"../../Resources/scoredecr.txt";
            encDecr en = new encDecr();
            if (!File.Exists(inp) && !File.Exists(outp))
            {
                File.Create(inp).Close();
                en.EncryptFile(inp, outp);
                File.Delete(inp);
                en.DecryptFile(outp, decr);
                File.Delete(outp);
                StreamWriter wr = new StreamWriter(decr, true);
                //wr.WriteLine(textBox1.Text);
                //wr.WriteLine(textBox2.Text);
                wr.WriteLine(textBox1.Text + ' ' + textBox2.Text);
                wr.Flush();
                wr.Close();
                en.EncryptFile(decr, outp);
                File.Delete(decr);
            }
            else
            {
                en.DecryptFile(outp, decr);
                File.Delete(outp);
                
                hs.Add(new Tuple<String,int>(textBox1.Text, int.Parse(textBox2.Text)));
                StreamReader read = new StreamReader(decr);
                String line;
                while((line=read.ReadLine())!=null)
                {
                    var d = line.Split(' ');
                    String name = d[0];
                    int scr = int.Parse(d[1]);
                    hs.Add(new Tuple<String, int>(name, scr));
                }
                read.Close();
                hs.Sort((x, y) => y.Item2.CompareTo(x.Item2));
                File.Delete(decr);
                File.Create(decr).Close();
                StreamWriter wr = new StreamWriter(decr, true);
                for (int j=0;j<hs.Count;j++)
                {
                    wr.WriteLine(hs[j].Item1 + ' ' + hs[j].Item2);
                }
                //wr.WriteLine(textBox1.Text);
                //wr.WriteLine(textBox2.Text);
                //wr.WriteLine(textBox1.Text + ' ' + textBox2.Text);
                wr.Flush();
                wr.Close();
                en.EncryptFile(decr, outp);
                File.Delete(decr);
            }
            this.Hide();
            Form1 home = new Form1();
            int i = 1;
            home.res(i);
           
            
        }

        private void HighScore_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if(textBox1.Text.Contains(' '))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox1, "Empty space is not allowed");
            }
            else if(textBox1.Text.Length==0)
            {
                textBox1.Text = "Unknown";
            }
            else
            {
                errorProvider1.SetError(textBox1, null);
            }
        }
    }
}
