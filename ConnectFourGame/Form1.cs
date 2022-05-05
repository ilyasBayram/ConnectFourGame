using System;
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

        List<string> fromLeftToRightFirst = new List<string>();
        List<string> fromLeftToRightSecond = new List<string>();
        List<string> fromLeftToRightThird = new List<string>();
        List<string> fromLeftToRightForth = new List<string>();
        List<string> fromLeftToRightFifth = new List<string>();
        List<string> fromLeftToRightSixth = new List<string>();

        List<string> fromDownToUpFirst = new List<string>();
        List<string> fromDownToUpSecond = new List<string>();
        List<string> fromDownToUpThird = new List<string>();
        List<string> fromDownToUpFourth = new List<string>();
        List<string> fromDownToUpFifth = new List<string>();
        List<string> fromDownToUpSixth = new List<string>();
        List<string> fromDownToUpSeventh = new List<string>();

        List<string> fromLeftToRightDiagonalFirst = new List<string>();
        List<string> fromLeftToRightDiagonalSecond = new List<string>();
        List<string> fromLeftToRightDiagonalThird = new List<string>();
        List<string> fromLeftToRightDiagonalFourth = new List<string>();
        List<string> fromLeftToRightDiagonalFifth = new List<string>();
        List<string> fromLeftToRightDiagonalSixth = new List<string>();

        List<string> fromRightToLeftDiagonalFirst = new List<string>();
        List<string> fromRightToLeftDiagonalSecond = new List<string>();
        List<string> fromRightToLeftDiagonalThird = new List<string>();
        List<string> fromRightToLeftDiagonalFourth = new List<string>();
        List<string> fromRightToLeftDiagonalFifth = new List<string>();
        List<string> fromRightToLeftDiagonalSixth = new List<string>();



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
            int buttonName = 1;
            for (int i = 1; i < 8; i++)
            {
                int countColom = 0;
                
                for (int j = 1; j < 7; j++)
                { 
                    CreateButton button = new CreateButton();
                    button.Size = new Size(60, 60);
                    button.BackColor = Color.Azure;
                    button.Location = new System.Drawing.Point(250+countRow, 100+countColom);
                    button.FlatAppearance.BorderSize = 0;
                    button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    button.FlatAppearance.BorderColor = Color.Black;
                    button.ForeColor = Color.Black;
                    button.Click += Button_Click;
                    button.Name = buttonName.ToString();
                    button.Text = buttonName.ToString();
                    this.Controls.Add(button);
                    button.BringToFront();
                    countColom += 70;
                    buttonName++;
                }
                countRow += 75;

            }
            
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (player == "Red")
            {
                if (bu)
                {

                }
                else
                {
                    (sender as Button).BackColor = Color.Red;
                    (sender as Button).Enabled = false;
                    player = "Blue";
                } 
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
