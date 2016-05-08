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
    public partial class GameOver : Form
    {
        public GameOver()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form1 tmp = new Form1();
            tmp.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
            
        }

        private void GameOver_Load(object sender, EventArgs e)
        {

        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void GameOver_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
