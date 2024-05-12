using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minefield_WindowsForm
{


    public partial class Form1 : Form
    {
        int mineNumber = 5;
        int score = 0;
        public Form1()
        {

            InitializeComponent();
            lnlMine.Text = mineNumber.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;

            int mine1, mine2, mine3, mine4, mine5;

            Random rnd = new Random();
            mine1 = rnd.Next(1, 12);
            mine2 = rnd.Next(12, 24);
            mine3 = rnd.Next(24, 38);
            mine4 = rnd.Next(38, 46);
            mine5 = rnd.Next(46, 55);


            for (int i = 1; i <= 54; i++)
            {
                Button btnTemp = new Button();
                btnTemp.Name = "btn" + i.ToString();
                btnTemp.Size = new System.Drawing.Size(40, 40);
                btnTemp.UseVisualStyleBackColor = true;
                btnTemp.Tag = null;
                if (mine1 == i || mine2 == i || mine3 == i || mine4 == i || mine5 == i)
                {
                    btnTemp.Tag = true;
                }
                else
                {
                    btnTemp.Tag = false;

                }

                btnTemp.Click += btnTemp0_Click;
                flowLayoutPanel1.Controls.Add(btnTemp);

            }
        }

        private void btnTemp0_Click(object sender, EventArgs e)
        {
            
            Button clickedBtn = (Button)sender;
            bool mineFound = (bool)clickedBtn.Tag;
            if (mineFound)
            {
                mineNumber--;
                lnlMine.Text = mineNumber.ToString();
                clickedBtn.Enabled = false;
                if (mineNumber == 0)
                {
                    clickedBtn.BackColor = Color.Red;
                    MessageBox.Show("YOU LOSE", "TRY AGAIN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Thread.Sleep(3000);
                    Application.Restart();

                }

                clickedBtn.BackColor = Color.Red;
            }
            else
            {
               
                score++;
                lblScore.Text = score.ToString();

                clickedBtn.BackColor = Color.Green;
                if(score==49)
                {
                    MessageBox.Show("YOU WIN", "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Thread.Sleep(3000);
                    Application.Restart();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Restart();
           
        }
    }
}



