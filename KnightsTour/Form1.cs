using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace KnightsTour
{
    public partial class Form1 : Form
    {
        public ChessBoard cb;
        public Form1()
        {
      
            InitializeComponent();
            cb = new ChessBoard();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            System.Drawing.SolidBrush jumpedToSquare = new System.Drawing.SolidBrush(System.Drawing.Color.Green);
            System.Drawing.SolidBrush knightCurrent = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (cb.visited[x, y] == false)
                    {
                        g.FillRectangle(myBrush, new Rectangle(x * 70, y * 70, 70, 70));
                    }
                    else
                    {
                        g.FillRectangle(jumpedToSquare, new Rectangle(x * 70, y * 70, 70, 70));
                    }
                    g.DrawRectangle(Pens.Red, new Rectangle(x * 70, y*70, 70, 70));
                    

                }
            }
         
            //Fill rectangle when currentSquare
            var xPos = cb.currentPos.Item1;
            var yPos = cb.currentPos.Item2;
            g.FillRectangle(knightCurrent, new Rectangle(xPos * 70, yPos * 70, 70, 70));
            g.DrawRectangle(Pens.Red, new Rectangle(xPos * 70, yPos * 70, 70, 70));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get current position, 

            var listOfPlaces = cb.ValidMoves(cb.currentPos.Item1, cb.currentPos.Item2);

            var least = 100;
            var potentialNextCandiates = new List < Tuple<int, int>>();
            var nextX = -1;
            var nextY = -1;
            foreach (var place in listOfPlaces)
            {
                var number = cb.ValidMoves(place.Item1, place.Item2).Count();
                if (number < least)
                {
                    least = number;
                    nextX = place.Item1;
                    nextY = place.Item2;
                }
            }


            // Move to next Position

            if (nextX == -1 && nextY == -1)
            {
                if (cb.moves == 63)
                {
                    MessageBox.Show("We won!");
                }
                else
                {
                    MessageBox.Show("We are trapped.");
                }
                return;
                
            }
            else 
            {
                cb.MoveToPosition(nextX, nextY);
            }
            // Repaint.

            this.Refresh();
            Thread.Sleep(300);
            button1_Click(sender, e);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cb.Reset();
            this.Refresh();
        }
    }
}
