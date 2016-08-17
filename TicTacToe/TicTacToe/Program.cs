using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    enum Status { Running, Draw, Xwin, Owin };
    class TicTacToeGame
    {
        private char[,] _board;
        private char _nextMove;
        private Status _status;

        public TicTacToeGame()
        {
            _board = new char[3, 3];
            _status = Status.Running;
            _nextMove = 'X';
        }
        public override string ToString()
        {
            var stat =  _status == Status.Running ? "" : _status == Status.Draw ? "\nThe game is over by Draw" : _status == Status.Xwin ? "\nThe game is over X player wins" : "\nThe game is over O player wins";
            return
                _board[0, 0] + "|" + _board[0, 1] + "|" + _board[0, 2] + "\n" +
                "-----" + "\n" +
                _board[1, 0] + "|" + _board[1, 1] + "|" + _board[1, 2] + "\n" +
                "-----" + "\n" +
                _board[2, 0] + "|" + _board[2, 1] + "|" + _board[2, 2] + stat; 
        }
        private void changeMove()
        {
            _nextMove = _nextMove == 'X' ? 'O' : 'X';
        }
        public void move(int row,int column)
        {
            _board[row, column] = _nextMove;
            checkGameStatus();
        }
        public bool isLegal(int row, int column)
        {
            if (_status == Status.Running)
                if ((row > -1 && row < 3) && (column > -1 && column < 3))
                    if (_board[row, column].Equals('\0'))
                        return true;
            return false;
        }
        private void checkGameStatus()
        {
            var count = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
            var totalMarks = 0;
            for (int i = 0; i < 3; i++)
            {
                if (_board[0, i] == _nextMove)
                    ++count[0];
                if (_board[1, i] == _nextMove)
                    ++count[1];
                if (_board[2, i] == _nextMove)
                    ++count[2];
                if (_board[i, 0] == _nextMove)
                    ++count[3];
                if (_board[i, 1] == _nextMove)
                    ++count[4];
                if (_board[i, 2] == _nextMove)
                    ++count[5];
                if (_board[i, i] == _nextMove)
                    ++count[6];
                if (_board[2 - i, i] == _nextMove)
                    ++count[7];
            }
            Array.Sort(count);
            Array.Reverse(count);
            if (count[0] == 3)
            {
                _status = _nextMove == 'X' ? Status.Xwin : Status.Owin;
                return;
            }

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (_board[i, j] != '\0')
                        ++totalMarks;
            if (totalMarks == 9)
                _status = Status.Draw;
            else
                changeMove();
        }
        public bool IsGameOver
        {
            get
            {
                return _status==Status.Running;
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            var game = new TicTacToeGame();
            string ans;
            var moveString = new string[2];
            var move = new int[2];
            Console.WriteLine(game);
            while (game.IsGameOver)
            {
                do
                {
                    do
                    {
                        Console.WriteLine("Enter ligal move");
                        ans = Console.ReadLine();
                    } while (ans.Split(' ').Length != 2);
                    moveString = ans.Split(' ');
                } while (!(int.TryParse(moveString[0], out move[0]) && int.TryParse(moveString[1], out move[1]) && game.isLegal(move[0],move[1])));
                game.move(move[0], move[1]);
                Console.WriteLine(game);
            }
        }
    }
}
