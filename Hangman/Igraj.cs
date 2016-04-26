using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hangman
{
    public partial class Igraj : Form
    {
        string category;
        string s;
        string temp;
        string st = "";
        public Igraj(string category)
        {
            InitializeComponent();
            DoubleBuffered = true;
            this.category = category;
            s = "";
            temp = "";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void Igraj_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            char pom = Convert.ToChar(button3.Text);
            vpisiBukva(pom);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            char pom = Convert.ToChar(button1.Text);
            vpisiBukva(pom);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            char pom = Convert.ToChar(button2.Text);
            vpisiBukva(pom);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button27_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            numericUpDown1.Enabled = false;
        }

        private void button28_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure?", "End game",
               MessageBoxButtons.YesNo, 
               MessageBoxIcon.Question); 
            if (result == DialogResult.Yes)
            {
               
                Form1 tmp = new Form1();
                tmp.Show();
                this.Hide();
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;
            char pom = Convert.ToChar(button4.Text);
            vpisiBukva(pom);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Enabled = false;
            char pom = Convert.ToChar(button5.Text);
            vpisiBukva(pom);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Enabled = false;
            char pom = Convert.ToChar(button6.Text);
            vpisiBukva(pom);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button7.Enabled = false;
            char pom = Convert.ToChar(button7.Text);
            vpisiBukva(pom);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button8.Enabled = false;
            char pom = Convert.ToChar(button8.Text);
            vpisiBukva(pom);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            button9.Enabled = false;
            char pom = Convert.ToChar(button9.Text);
            vpisiBukva(pom);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            button10.Enabled = false;
            char pom = Convert.ToChar(button10.Text);
            vpisiBukva(pom);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            button11.Enabled = false;
            char pom = Convert.ToChar(button11.Text);
            vpisiBukva(pom);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            button12.Enabled = false;
            char pom = Convert.ToChar(button12.Text);
            vpisiBukva(pom);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            button13.Enabled = false;
            char pom = Convert.ToChar(button13.Text);
            vpisiBukva(pom);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            button15.Enabled = false;
            char pom = Convert.ToChar(button15.Text);
            vpisiBukva(pom);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            char pom = Convert.ToChar(button14.Text);
            vpisiBukva(pom);
            button14.Enabled = false;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            button16.Enabled = false;
            char pom = Convert.ToChar(button16.Text);
            vpisiBukva(pom);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            button17.Enabled = false;
            char pom = Convert.ToChar(button17.Text);
            vpisiBukva(pom);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            button18.Enabled = false;
            char pom = Convert.ToChar(button18.Text);
            vpisiBukva(pom);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            button19.Enabled = false;
            char pom = Convert.ToChar(button19.Text);
            vpisiBukva(pom);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            button20.Enabled = false;
            char pom = Convert.ToChar(button20.Text);
            vpisiBukva(pom);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            button21.Enabled = false;
            char pom = Convert.ToChar(button21.Text);
            vpisiBukva(pom);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            button22.Enabled = false;
            char pom = Convert.ToChar(button22.Text);
            vpisiBukva(pom);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            button23.Enabled = false;
            char pom = Convert.ToChar(button23.Text);
            vpisiBukva(pom);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            button24.Enabled = false;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            button25.Enabled = false;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            button26.Enabled = false;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            
            groupBox1.Enabled = true;
            int brojac = (int)numericUpDown1.Value;
            s = "";
            for (int i = 0; i < brojac; i++)
            {
                s += "_";
            }
            label3.Text = s;

            Data data = new Data(category);
            temp = data.getWord((int)numericUpDown1.Value);

            textBox1.Text = temp;


        }
        private void vpisiBukva(char c)
        {
            
            char[] orginal = temp.ToCharArray();
            char[] crticki = s.ToCharArray();
            for (int i = 0; i < (int)numericUpDown1.Value; i++)
            {
                c = Char.ToLower(c);
                if (c == orginal[i])
                {
                    crticki[i] = c;
                }
                
            }
            s = "";
            for (int j = 0; j < crticki.Length; j++)
            {
                s += crticki[j];
                label3.Text = s;
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
