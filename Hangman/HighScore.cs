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
    public partial class HighScore : Form
    {
        public int score;
        public HighScore(int score)
        {
            this.score = score;
            InitializeComponent();
            textBox2.Text = Convert.ToString(score);
        }


    }
}
