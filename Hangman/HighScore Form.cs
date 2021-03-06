﻿using System;
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
    public partial class Form2 : Form
    {
        public string outp = @"../../Resources/scorencr.txt";
        public string decr = @"../../Resources/scoredecr.txt";
        public Form2()
        {
            InitializeComponent();
            if (File.Exists(outp))
            {
                button1.Enabled = true;
                encDecr en = new encDecr();
                en.DecryptFile(outp, decr);
                File.Delete(outp);
                StreamReader read = new StreamReader(decr);
                String line;
                int c = 0;
                int i = 0;
                Label[] labels = new Label[] { label2, label3, label4, label5, label6, label7, label8, label9, label10, label11 };
                while (c < 5 && (line = read.ReadLine()) != null)
                {
                    var d = line.Split(' ');
                    String name = d[0];
                    String score = d[1];
                    labels[i].Text = name;
                    labels[i].Visible = true;
                    i++;
                    labels[i].Text = score;
                    labels[i].Visible = true;
                    i++;
                    c++;

                }
                read.Close();
                en.EncryptFile(decr, outp);
                File.Delete(decr);
            }
        }
        public void OnBackToMainClicked(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to clear all the scores?",
                "Clear High Scores",
                MessageBoxButtons.YesNo);
            if(res==DialogResult.Yes)
            {
                File.Delete(outp);
                int c = 0;
                int i = 0;
                Label[] labels = new Label[] { label2, label3, label4, label5, label6, label7, label8, label9, label10, label11 };
                while (c < 5)
                {
                    labels[i].Visible = false;
                    i++;
                    labels[i].Visible = false;
                    i++;
                    c++;
                }
                button1.Enabled = false;
            }
        }
    }
}
