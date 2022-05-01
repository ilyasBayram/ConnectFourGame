﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ConnectFourGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string player ="";
       
        private void PlayerChoose()
        {
            if (player=="Blue")
            {
                lblBlue.Text = "Player1";
                lblRed.Text = "Player2";
            }
            else
            {
                lblBlue.Text = "Player2";
                lblRed.Text = "Player1";
            }
            btnBlue.Enabled = false;
            btnRed.Enabled = false;
            lblMessage.Visible = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            int countRow = 0;
            for (int i = 1; i < 8; i++)
            {
                int countColom = 0;
                for (int j = 1; j < 7; j++)
                { 
                    
                    CreateButton button = new CreateButton();
                    button.Size = new Size(59, 59);
                    button.BackColor = Color.Azure;
                    button.Location = new System.Drawing.Point(250+countRow, 100+countColom);
                    button.FlatAppearance.BorderSize = 0;
                    button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    button.FlatAppearance.BorderColor = Color.Black;
                    button.ForeColor = Color.Black;
                    button.Click += Button_Click;
                    this.Controls.Add(button);
                    button.BringToFront();
                    countColom += 70;
                }
                countRow += 75;

            }
            
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (player == "Red")
            {
                (sender as Button).BackColor = Color.Red;
                (sender as Button).Enabled = false;
                player = "Blue";
            }
            else if (player == "Blue")
            {
                (sender as Button).BackColor = Color.GreenYellow;
                (sender as Button).Enabled = false;
                player = "Red";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            player = "Blue";
            PlayerChoose();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            player = "Red";
            PlayerChoose();
        }
    }
    public class CreateButton : Button
    {
        protected override void OnResize (EventArgs e)
            {
            base.OnResize(e);
            GraphicsPath grafic = new GraphicsPath();
            grafic.AddEllipse(new Rectangle(Point.Empty, this.Size));
            this.Region = new Region(grafic);
            }
    }
}
