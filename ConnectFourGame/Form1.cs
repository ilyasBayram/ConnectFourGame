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
        int count = 0;

        int[,] arr = new int[6, 7];

        public void ButtonCreate()
        {
            int countRow = 0;

            for (int i = 1; i < 8; i++)
            {
                int countColom = 0;

                for (int j = 1; j < 7; j++)
                {
                    CreateButton button = new CreateButton();
                    button.Size = new Size(60, 60);
                    button.BackColor = Color.Azure;
                    button.Location = new System.Drawing.Point(250 + countRow, 100 + countColom);
                    button.FlatAppearance.BorderSize = 0;
                    button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    button.FlatAppearance.BorderColor = Color.Black;
                    button.ForeColor = Color.Black;
                    button.Click += Button_Click;
                    button.Name = (j - 1) + "_" + (i - 1);
                    this.Controls.Add(button);
                    button.BringToFront();
                    countColom += 70;

                }
                countRow += 75;

            }
        }

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

        private void ButtonLongitudinalControl()
        {
            int a;
            int b;
            int c;
            int j = 0;

            if (arr[3, 0] !=0)
            {
                for (int i = 3; i > 0; i--)
                {
                    a = arr[i, j];
                    b = arr[i - 1, j + 1];
                    if ((a != 0 && b != 0) && a == b)
                    {
                        count++;

                        if (count == 3)
                        {
                            if (arr[i, j] == 1)
                            {
                                lblMessage.Visible = true;
                                lblMessage.Text = "The winner is Red..";
                            }
                            else if (arr[i, j] == 2)
                            {
                                lblMessage.Visible = true;
                                lblMessage.Text = "The winner is Green..";
                            }
                            count = 0;

                        }
                    }
                    else
                    {
                        count = 0;
                    }
                    j++;
                }
                j = 0;
            }
            if (arr[3, 1] != 0)
            {
                for (int i = 4; i > 1; i--)
                {
                    a = arr[i, j];
                    b = arr[i - 1, j + 1];

                    if ((a != 0 && b != 0) && a == b)
                    {
                        count++;

                        if (count == 3)
                        {
                            if (arr[i, j] == 1)
                            {
                                lblMessage.Visible = true;
                                lblMessage.Text = "The winner is Red..";
                            }
                            else if (arr[i, j] == 2)
                            {
                                lblMessage.Visible = true;
                                lblMessage.Text = "The winner is Green..";
                            }
                            count = 0;

                        }
                    }
                    else
                    {
                        count = 0;
                    }
                    j++;
                }

                j = 0;
            }
            if (arr[3, 2] != 0)
            {
                for (int i = 5; i > 0; i--)
                {
                    a = arr[i, j];
                    b = arr[i - 1, j + 1];
                    if ((a != 0 && b != 0) && a == b)
                    {
                        count++;

                        if (count == 3)
                        {
                            if (arr[i, j] == 1)
                            {
                                lblMessage.Visible = true;
                                lblMessage.Text = "The winner is Red..";
                            }
                            else if (arr[i, j] == 2)
                            {
                                lblMessage.Visible = true;
                                lblMessage.Text = "The winner is Green..";
                            }
                            count = 0;

                        }
                    }
                    else
                    {
                        count = 0;
                    }
                    j++;
                }
                j = 0;
            }
            if (arr[3, 3] != 0)
            {
                j = 1;
                for (int i = 5; i > 0; i--)
                {
                    a = arr[i, j];
                    b = arr[i - 1, j + 1];
                    if ((a != 0 && b != 0) && a == b)
                    {
                        count++;

                        if (count == 3)
                        {
                            if (arr[i, j] == 1)
                            {
                                lblMessage.Visible = true;
                                lblMessage.Text = "The winner is Red..";
                            }
                            else if (arr[i, j] == 2)
                            {
                                lblMessage.Visible = true;
                                lblMessage.Text = "The winner is Green..";
                            }
                            count = 0;

                        }
                    }
                    else
                    {
                        count = 0;
                    }
                    j++;
                }
                j = 0;
            }
            if (arr[3, 4] != 0)
            {
                j = 2;
                for (int i = 5; i > 1; i--)
                {
                   
                    a = arr[i, j];
                    b = arr[i - 1, j + 1];
                    if ((a != 0 && b != 0) && a == b)
                    {
                        count++;

                        if (count == 3)
                        {
                            if (arr[i, j] == 1)
                            {
                                lblMessage.Visible = true;
                                lblMessage.Text = "The winner is Red..";
                            }
                            else if (arr[i, j] == 2)
                            {
                                lblMessage.Visible = true;
                                lblMessage.Text = "The winner is Green..";
                            }
                            count = 0;

                        }
                    }
                    else
                    {
                        count = 0;
                    }
                    j++;
                }
                j = 0;
            }
            if (arr[3, 5] != 0)
            {
                j = 3;
                for (int i = 5; i > 2; i--)
                {
                    a = arr[i, j];
                    b = arr[i - 1, j + 1];
                    if ((a != 0 && b != 0) && a == b)
                    {
                        count++;

                        if (count == 3)
                        {
                            if (arr[i, j] == 1)
                            {
                                lblMessage.Visible = true;
                                lblMessage.Text = "The winner is Red..";
                            }
                            else if (arr[i, j] == 2)
                            {
                                lblMessage.Visible = true;
                                lblMessage.Text = "The winner is Green..";
                            }
                            count = 0;

                        }
                    }
                    else
                    {
                        count = 0;
                    }
                    j++;
                }
                j = 0;
            }
        }

        private void ButtonHorizontalControl()
        {
            int firstButton;
            int secondButton;
            for (int i = 5; i > -1; i--)
            {
                for (int j = 0; j < 6; j++)
                {
                    firstButton = arr[i, j];
                    secondButton = arr[i, j + 1];
                    if ((firstButton!=0 && secondButton!=0)&& firstButton==secondButton)
                    {
                        count++;

                        if (count==3)
                        {
                            if (arr[i, j] == 1)
                            {
                                lblMessage.Visible = true;
                                lblMessage.Text = "The winner is Red..";
                            }
                            else if(arr[i, j] == 2)
                            {
                                lblMessage.Visible = true;
                                lblMessage.Text = "The winner is Green..";
                            }
                            count = 0;

                        }
                    }
                    else
                    {
                        count = 0;
                    }
                }
            }   
        }

        private void ButtonVerticalControl()
        {
            int firstButton;
            int secondButton;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 5; j > 0; j--)
                {
                    firstButton = arr[j, i];
                    secondButton = arr[j-1, i];
                    if ((firstButton != 0 && secondButton != 0) && firstButton == secondButton)
                    {
                        count++;

                        if (count == 3)
                        {
                            if (arr[j, i] == 1)
                            {
                                lblMessage.Visible = true;
                                lblMessage.Text = "The winner is Red..";
                            }
                            else if (arr[j, i] == 2)
                            {
                                lblMessage.Visible = true;
                                lblMessage.Text = "The winner is Green";
                            }

                        }
                    }
                    else
                    {
                        count = 0;
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ButtonCreate();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            string name = (sender as Button).Name;
            string[] location = name.Split('_');
            int x = Convert.ToInt32(location[0]);
            int y = Convert.ToInt32(location[1]);

            if (player == "Red")
            {
                
                if ((x!=0 && x % 5 == 0) || arr[x+1,y]!=0)
                {
                    (sender as Button).BackColor = Color.Red;
                    (sender as Button).Enabled = false;
                    player = "Green";
                    arr[x, y] = 1;
                }
                ButtonHorizontalControl();
                ButtonVerticalControl();
                ButtonLongitudinalControl();
            }
            else if (player == "Green")
            {
                if ((x != 0 && x % 5 == 0) || arr[x + 1, y] != 0)
                {
                    (sender as Button).BackColor = Color.GreenYellow;
                    (sender as Button).Enabled = false;
                    player = "Red";
                    arr[x, y] = 2;
                }
                ButtonHorizontalControl();
                ButtonVerticalControl();
                ButtonLongitudinalControl();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            player = "Green";
            PlayerChoose();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            player = "Red";
            PlayerChoose();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {

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
