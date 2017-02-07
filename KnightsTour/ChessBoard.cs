using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KnightsTour
{
    public class ChessBoard
    {
        public bool[,] visited = new bool[8, 8]; 
        public Tuple<int, int> currentPos { get; set; }
        public int moves { get; set; }

        public ChessBoard()
        {
            // Initialize blank chess board
            for (int x=0; x<8; x++)
            {
                for (int y=0; y<8; y++)
                {
                    visited[x, y] = false;
                }
            }

            Random rnd = new Random();
            // Set knight on a random square
            var xStart = rnd.Next(0, 8);
            var yStart = rnd.Next(0, 8);
            currentPos = Tuple.Create(xStart, yStart);
            visited[xStart, yStart] = true;
            moves = 0;
        }

        public int NumberOfMoves(int x, int y)
        {
            //Number of Moves from a given point on the chess board
            return ValidMoves(x, y).Count();
        }

        public List<Tuple<int,int>> ValidMoves(int x, int y)
        {
            var result = new List<Tuple<int, int>>();
            /// x | y
            // ------
            // +1, +2
            // +1, -2
            // -1, +2
            // -1, -2
            // +2, +1
            // +2, -1
            // -2, +1
            // -2, -1

            int xPos = x;
            int yPos = y;
            

            if (xPos+1<8 && yPos+2 <8 && visited[xPos+1 ,yPos+2]==false)
            {
                result.Add(new Tuple<int, int>(xPos + 1, yPos + 2));
            }
            if (xPos + 1 < 8 && yPos - 2 >= 0 && visited[xPos+1, yPos-2] == false)
            {
                result.Add(new Tuple<int, int>(xPos + 1, yPos - 2));
            }
            if (xPos - 1 >= 0 && yPos + 2 < 8 && visited[xPos-1, yPos+2] == false)
            {
                result.Add(new Tuple<int, int>(xPos - 1, yPos + 2));
            }
            if (xPos - 1 >= 0 && yPos - 2 >= 0 && visited[xPos-1, yPos-2] == false)
            {
                result.Add(new Tuple<int, int>(xPos - 1, yPos - 2));
            }
            if (xPos + 2  < 8 && yPos + 1 < 8 && visited[xPos+2, yPos+1] == false)
            {
                result.Add(new Tuple<int, int>(xPos + 2, yPos + 1));
            }
            if (xPos + 2 < 8 && yPos - 1 >= 0  && visited[xPos+2, yPos-1] == false)
            {
                result.Add(new Tuple<int, int>(xPos + 2, yPos - 1));
            }
            if (xPos - 2 >= 0 && yPos + 1 < 8 && visited[xPos-2, yPos+1] == false)
            {
                result.Add(new Tuple<int, int>(xPos - 2, yPos + 1));
            }
            if (xPos - 2 >= 0 && yPos -1 >= 0 && visited[xPos-2, yPos-1] == false)
            {
                result.Add(new Tuple<int, int>(xPos - 2, yPos -1));
            }
            // Return a list of valid moves from the current position

            return result;
        }

        public bool MoveToPosition(int x, int y)
        {
            currentPos = new Tuple<int, int>(x, y);
            visited[x, y] = true;
            moves++;
            return true;
        }

        public bool Reset()
        {
            // Initialize blank chess board
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    visited[x, y] = false;
                }
            }

            Random rnd = new Random();
            // Set knight on a random square
            var xStart = rnd.Next(0, 8);
            var yStart = rnd.Next(0, 8);
            currentPos = Tuple.Create(xStart, yStart);
            visited[xStart, yStart] = true;
            moves = 0;

            return true;

        }
    }
}
