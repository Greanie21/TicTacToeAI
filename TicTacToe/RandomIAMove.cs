using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    static class RandomIAMove
    {
        static bool firstTime = true;

        public static KeyValuePair<int,int> RandMove(char c,char[,] board)
        {
            if (firstTime)
            {
                firstTime = false;
               IaMove.InitializaVariablesForAllGames();
            }

            string boardLocal = IaMove.TransformBoardToString(board);
            string move = new Random().Next(1, 10).ToString();
            switch (move)
            {
                case "1":
                    if (board[0, 0] == '1')
                    {
                        IaMove.addPlayToIa(boardLocal, move, c);

                        return new KeyValuePair<int, int>(0, 0);
                    }
                    break;
                case "2":
                    if (board[0, 1] == '2')
                    {
                        IaMove.addPlayToIa(boardLocal, move, c);

                        return new KeyValuePair<int, int>(0, 1);
                    }
                    break;
                case "3":
                    if (board[0, 2] == '3')
                    {
                        IaMove.addPlayToIa(boardLocal, move, c);

                        return new KeyValuePair<int, int>(0, 2);
                    }
                    break;
                case "4":
                    if (board[1, 0] == '4')
                    {
                        IaMove.addPlayToIa(boardLocal, move, c);

                        return new KeyValuePair<int, int>(1, 0);
                    }
                    break;
                case "5":
                    if (board[1, 1] == '5')
                    {
                        IaMove.addPlayToIa(boardLocal, move, c);

                        return new KeyValuePair<int, int>(1,1);
                    }
                    break;
                case "6":
                    if (board[1, 2] == '6')
                    {
                        IaMove.addPlayToIa(boardLocal, move, c);

                        return new KeyValuePair<int, int>(1,2);
                    }
                    break;
                case "7":
                    if (board[2, 0] == '7')
                    {
                        IaMove.addPlayToIa(boardLocal, move, c);

                        return new KeyValuePair<int, int>(2, 0);
                    }
                    break;
                case "8":
                    if (board[2, 1] == '8')
                    {
                        IaMove.addPlayToIa(boardLocal, move, c);

                        return new KeyValuePair<int, int>(2,1);
                    }
                    break;
                case "9":
                    if (board[2, 2] == '9')
                    {
                        IaMove.addPlayToIa(boardLocal, move, c);

                        return new KeyValuePair<int, int>(2,2);
                    }
                    break;
                default:
                    return RandMove(c, board);
            }

            IaMove.IAChange(move, false, c, boardLocal);
            return RandMove(c, board);
        }
    }
}
