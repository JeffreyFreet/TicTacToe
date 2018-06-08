using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        //True = X
        //False = O
        bool turn = true;
        int counter = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tic Tac Toe\nMade by Jeffrey Freet");
        }

        private void btnClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (turn)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }

            turn = !turn;
            counter++;
            b.Enabled = false;
            checkWinner();
        }

        private void checkWinner()
        {
            bool winner = false;
            
            //Horizontal Checks
            if((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                winner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                winner = true;
            if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                winner = true;

            //Vertical Checks
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                winner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                winner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                winner = true;

            //Diagonal Checks
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                winner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                winner = true;

            if (winner)
            {
                disableButtons();

                string player = "";
                if (turn)
                {
                    player = "O";
                    oCount.Text = (Int32.Parse(oCount.Text) + 1).ToString();
                }
                else
                {
                    player = "X";
                    xCount.Text = (Int32.Parse(xCount.Text) + 1).ToString();
                }

                MessageBox.Show(player + " is the Winner!", "Winner!");
            }
            else
            {
                if(counter == 9)
                {
                    MessageBox.Show("Tie Game!", "Draw!");
                    drawCount.Text = (Int32.Parse(drawCount.Text) + 1).ToString();
                }
            }
        }

        private void disableButtons()
        {
                foreach (Control c in Controls)
                {
                    try
                    {
                        Button b = (Button)c;
                        b.Enabled = false;
                    }
                    catch { }
                }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            counter = 0;

                foreach (Control c in Controls)
                {
                    try
                    {
                        Button b = (Button)c;
                        b.Enabled = true;
                        b.Text = "";
                    }
                    catch { }
                }
        }

        private void btnEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (b.Enabled)
            {
                if (turn)
                    b.Text = "X";
                else
                    b.Text = "O";
            }
        }

        private void btnLeave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                b.Text = "";
            }
        }

        private void resetScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oCount.Text = "0";
            xCount.Text = "0";
            drawCount.Text = "0";
        }

        private void resetGameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
