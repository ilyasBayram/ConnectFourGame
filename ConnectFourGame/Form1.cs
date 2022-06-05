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
using System.Media;

namespace ConnectFourGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region variables
        string player ="";
        int count = 0;
        #endregion

        SoundPlayer BtnSound = new SoundPlayer();

        // a multidimansional array is created.
        int[,] arr = new int[6, 7];

        private void Form1_Load(object sender, EventArgs e)
        {
            ButtonCreate();
        }

        #region methods
        //This mothod creates 42 dynamic button with for loops.
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

        //At the end of the game this method stops all buttons fuction and Buttons con not be clicked any more.
        public void ButtonEnabledFalse()
        {
            foreach (Control item in this.Controls)
            {
                if (item is Button && item.Name!= "btnBlue" && item.Name != "btnRed" && item.Name != "btnRestart")
                {
                    item.Enabled = false;
                }
            }
        }

        // this method determine what players color will be.
        private void PlayerChoose()
        {
            if (player=="Green")
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

        //This method controls if four button with same color is in  order. 
        //If count variable reach to 3 the winner is written on the label and buttons con not be clicked any more.
        private void PlayerScore(int firstButton, int secondButton, int j, int i)
        {
            if ((firstButton != 0 && secondButton != 0) && firstButton == secondButton)
            {
                count++;

                if (count == 3)
                {
                    if (arr[i, j] == 1)
                    {
                        lblMessage.Visible = true;
                        lblMessage.ForeColor = Color.Red;
                        lblMessage.Text = "The winner is Red..";
                        ButtonEnabledFalse();
                    }
                    else if (arr[i, j] == 2)
                    {
                        lblMessage.Visible = true;
                        lblMessage.ForeColor = Color.GreenYellow;
                        lblMessage.Text = "The winner is Green..";
                        ButtonEnabledFalse();
                    }
                    count = 0;
                }
            }
            else
            {
                count = 0;
            }
        }

        private void Draw()
        {
            int firstButton;
            int counting = 0;
            int j = 0;
            for (int i = 0; i < 7; i++)
            {
                firstButton = arr[j, i];
                if (firstButton == 0)
                {
                    counting++;
                }
            }
            if (counting == 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "No winner. It is Draw ";
                ButtonEnabledFalse();
            }
        }

        private void ButtonSound()
        {
            BtnSound.SoundLocation = @"C:\Users\ilyas.bayram\source\repos\ConnectFourGame\ConnectFourGame\mixkit-select-click-1109.wav";
            BtnSound.Play();
        }

        // this mothod check longitudinal position of buttons and if four buttons that have same color 
        // is in order the game ends.
        private void ButtonLongitudinalControl()
        {
            int firstButton;
            int secondButton;
            int j = 0;

            if (arr[3, 0] != 0)
            {
                for (int i = 3; i > 0; i--)
                {
                    firstButton = arr[i, j];
                    secondButton = arr[i - 1, j + 1];
                    PlayerScore(firstButton, secondButton, j, i);
                    j++;
                }
                j = 0;
                count = 0;
            }
            if (arr[3, 1] != 0)
            {
                for (int i = 4; i > 0; i--)
                {
                    firstButton = arr[i, j];
                    secondButton = arr[i - 1, j + 1];
                    PlayerScore(firstButton, secondButton, j, i);
                    j++;
                }

                j = 0;
                count = 0;

                for (int i = 2; i < 5; i++)
                {
                    firstButton = arr[i, j];
                    secondButton = arr[i+1, j + 1];
                    PlayerScore(firstButton, secondButton, j, i);
                    j++;
                }
                j = 0;
                count = 0;
            }
            if (arr[3, 2] != 0)
            {
                for (int i = 5; i > 1 ; i--)
                {
                    firstButton = arr[i, j];
                    secondButton = arr[i - 1, j + 1];
                    PlayerScore(firstButton, secondButton, j, i);
                    j++;
                }
                j = 0;
                count = 0;
                for (int i = 1; i < 5; i++)
                {
                    firstButton = arr[i, j];
                    secondButton = arr[i + 1, j + 1];
                    PlayerScore(firstButton, secondButton, j, i);
                    j++;
                }
                count = 0;
            }
            if (arr[3, 3] != 0)
            {
                j = 1;
                for (int i = 5; i > 0; i--)
                {
                    firstButton = arr[i, j];
                    secondButton = arr[i - 1, j + 1];
                    PlayerScore(firstButton, secondButton, j, i);
                    j++;
                }
                j = 0;
                count = 0;
                for (int i = 0; i < 5; i++)
                {
                    firstButton = arr[i, j];
                    secondButton = arr[i + 1, j + 1];
                    PlayerScore(firstButton, secondButton, j, i);
                    j++;
                }
                count = 0;
            }
            if (arr[3, 4] != 0)
            {
                j = 2;
                for (int i = 5; i > 1; i--)
                {
                   
                    firstButton = arr[i, j];
                    secondButton = arr[i - 1, j + 1];
                    PlayerScore(firstButton, secondButton, j, i);
                    j++;
                }
                j = 1;
                count = 0;
                for (int i = 0; i < 5; i++)
                {
                    firstButton = arr[i, j];
                    secondButton = arr[i + 1, j + 1];
                    PlayerScore(firstButton, secondButton, j, i);
                    j++;
                }
                count = 0;
            }
            if (arr[3, 5] != 0)
            {
                j = 3;
                for (int i = 5; i > 2; i--)
                {
                    firstButton = arr[i, j];
                    secondButton = arr[i - 1, j + 1];
                    PlayerScore(firstButton, secondButton, j, i);
                    j++;
                }
                j = 2;
                count = 0;
                for (int i = 0; i < 4; i++)
                {
                    firstButton = arr[i, j];
                    secondButton = arr[i + 1, j + 1];
                    PlayerScore(firstButton, secondButton, j, i);
                    j++;
                }
                count = 0;
            }
            if (arr[3, 6] != 0)
            {
                j = 3;
                for (int i = 0; i < 3; i++)
                {
                    firstButton = arr[i, j];
                    secondButton = arr[i + 1, j + 1];
                    PlayerScore(firstButton, secondButton, j, i);
                    j++;
                }
                count = 0;
            }
        }

        // this mothod check horizontal position of buttons.
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
                    PlayerScore(firstButton, secondButton, j, i);
                }
                count = 0;
            }
            count = 0;
        }

        // this mothod check vertical position of buttons.
        private void ButtonVerticalControl()
        {
            int firstButton;
            int secondButton;
            int j = 0;
            for (int k = 0; k < 7; k++)
            {
                for (int i = 5; i > 0; i--)
                {
                    firstButton = arr[i, j];
                    secondButton = arr[i - 1, j];
                    PlayerScore(firstButton, secondButton, j, i);
                }
                j++;
                count = 0;
            }
            count = 0;
        }

       
        #endregion

        #region buttons
        //ıt understand which button is clicked.
        // if it is red it gives 1 as value.
        private void Button_Click(object sender, EventArgs e)
        {
            
            string name = (sender as Button).Name;
            string[] location = name.Split('_');
            int x = Convert.ToInt32(location[0]);
            int y = Convert.ToInt32(location[1]);

            if (player == "Red")
            {
                ButtonSound();
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
                Draw();
            }
            else if (player == "Green")
            {
                ButtonSound();
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
                Draw();
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

        // It restart the game, values inside the array becomes 0. Values belongs the items go back to their first value.
        private void btnRestart_Click(object sender, EventArgs e)
        {
            //finding all items on form. 

            foreach (Control item in this.Controls)
            {
                //If item is button it makes them clickable and according to their name 
                //it reset their values to their first value.
                if (item is Button)
                {
                    item.Enabled = true;

                    if (item.Name != "btnBlue" && item.Name != "btnRed" && item.Name != "btnRestart")
                    {
                        item.BackColor = Color.Azure;
                        lblBlue.Text = "";
                        lblRed.Text="";
                        player = "";
                        lblMessage.Visible = true;
                        lblMessage.ForeColor = Color.DeepPink;
                        lblMessage.Text = "Choose a color";

                        for (int i = 0; i < 6; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                arr[i, j] = 0;
                            }
                        }
                    }  
                }
            }
        }
        #endregion
    }

        #region class
    public class CreateButton : Button
    {
        //It makes round shape button.
        protected override void OnResize (EventArgs e)
            {
            base.OnResize(e);
            GraphicsPath grafic = new GraphicsPath();
            grafic.AddEllipse(new Rectangle(Point.Empty, this.Size));
            this.Region = new Region(grafic);
            }
    }
    #endregion
}
