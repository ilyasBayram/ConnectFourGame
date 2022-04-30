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

        private void RoundButton()
        {
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            int countRow = 0;
            for (int i = 1; i < 6; i++)
            {
                int countColom = 0;
                for (int j = 1; j < 6; j++)
                { 
                    
                    CreateButton button = new CreateButton();
                    button.Size = new Size(60, 60);
                    button.BackColor = Color.Azure;
                    button.Location = new System.Drawing.Point(200+countRow, 80+countColom);
                    button.FlatAppearance.BorderSize = 0;
                    button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    button.FlatAppearance.BorderColor = Color.Black;
                    button.ForeColor = Color.White;
                    button.Click += Button_Click;
                    this.Controls.Add(button);
                    countColom += 90;
                }
                countRow += 120;

            }
            
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if ((sender as Button).BackColor==Color.Azure)
            {
                (sender as Button).BackColor = Color.Red;
                (sender as Button).Enabled = false;
            }
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
