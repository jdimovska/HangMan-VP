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
    public partial class Form1 : Form
    {
        public bool home = true;
      
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            home = false;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            if (!home)
            {
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                label2.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            label2.Visible = true;
            home = false;
           
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void open(string text)
        {
            Igraj play = new Igraj(text);
            play.Show();
            
                this.Hide();

            


           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            open(button4.Text);

        }

        private void button5_Click(object sender, EventArgs e)
        {

            open(button5.Text);

        }

        private void button6_Click(object sender, EventArgs e)
        {

            open(button6.Text);

        }

       
    }
}
