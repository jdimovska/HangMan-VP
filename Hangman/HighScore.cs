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
                wr.WriteLine(textBox1.Text);
                wr.WriteLine(textBox2.Text);
                wr.Flush();
                wr.Close();
                en.EncryptFile(decr, outp);
                File.Delete(decr);
            }
            else
            {
                en.DecryptFile(outp, decr);
                File.Delete(outp);
                StreamWriter wr = new StreamWriter(decr, true);
                wr.WriteLine(textBox1.Text);
                wr.WriteLine(textBox2.Text);
                wr.Flush();
                wr.Close();
                en.EncryptFile(decr, outp);
                File.Delete(decr);
            }
            this.Close();
            Form1 home = new Form1();
            int i = 1;
            home.res(i);
            
        }
    }
}
