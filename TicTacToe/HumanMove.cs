using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    static class HumanMove
    {
        static public KeyValuePair<int, int> PlayerMove(char c, char[,] board)
        {
            string move = Console.ReadLine();
            switch (move)
            {
                case "1":
                    if (board[0, 0] == '1')
                    {
                        return new KeyValuePair<int, int>(0, 0);
                    }
                    else
                    {
                        return new KeyValuePair<int, int>(-1, -1);
                    }
                case "2":
                    if (board[0, 1] == '2')
                    {
                        return new KeyValuePair<int, int>(0,1);
                    }
                    else
                    {
                        return new KeyValuePair<int, int>(-1, -1);
                    }
                case "3":
                    if (board[0, 2] == '3')
                    {
                        return new KeyValuePair<int, int>(0,2);
                    }
                    else
                    {
                        return new KeyValuePair<int, int>(-1, -1);
                    }

                case "4":
                    if (board[1, 0] == '4')
                    {
                        return new KeyValuePair<int, int>(1,0);
                    }
                    else
                    {
                        return new KeyValuePair<int, int>(-1, -1);
                    }

                case "5":
                    if (board[1, 1] == '5')
                    {
                        return new KeyValuePair<int, int>(1,1);
                    }
                    else
                    {
                        return new KeyValuePair<int, int>(-1, -1);
                    }

                case "6":
                    if (board[1, 2] == '6')
                    {
                        return new KeyValuePair<int, int>(1,2);
                    }
                    else
                    {
                        return new KeyValuePair<int, int>(-1, -1);
                    }

                case "7":
                    if (board[2, 0] == '7')
                    {
                        return new KeyValuePair<int, int>(2,0);
                    }
                    else
                    {
                        return new KeyValuePair<int, int>(-1, -1);
                    }

                case "8":
                    if (board[2, 1] == '8')
                    {
                        return new KeyValuePair<int, int>(2,1);
                    }
                    else
                    {
                        return new KeyValuePair<int, int>(-1, -1);
                    }

                case "9":
                    if (board[2, 2] == '9')
                    {
                        return new KeyValuePair<int, int>(2,2);
                    }
                    else
                    {
                        return new KeyValuePair<int, int>(-1, -1);
                    }
                default:
                    return new KeyValuePair<int, int>(-1, -1);
            }
        }
    }
}
