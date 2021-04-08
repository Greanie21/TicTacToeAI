using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    static class RoboManual
    {
        public static KeyValuePair<int, int> Play(char player, char[,] board)
        {
            KeyValuePair<int, int> kvp;
            char enemy = 'X';
            if (player == 'X')
            {
                enemy = 'O';
            }

            kvp = Play2(player, board);
            if (kvp.Key != -1)
            {
                return kvp;
            }

            kvp = Play2(enemy, board);
            if (kvp.Key != -1)
            {
                return kvp;
            }


            return new KeyValuePair<int, int>(0, 0);
        }

        static KeyValuePair<int, int> Play2(char c, char[,] board)
        {
            if (board[0, 0] == board[0, 1] && board[0, 1] == c && board[0, 2] == 3)
            {
                return new KeyValuePair<int, int>(0, 2);
            }
            if (board[1, 0] == board[1, 1] && board[1, 1] == c && board[1, 2] == 6)
            {
                return new KeyValuePair<int, int>(1, 2);
            }
            if (board[2, 0] == board[2, 1] && board[2, 1] == c && board[2, 2] == 9)
            {
                return new KeyValuePair<int, int>(2, 2);
            }

            if (board[0, 0] == board[1, 0] && board[1, 0] == c && board[2, 0] == 7)
            {
                return new KeyValuePair<int, int>(2, 0);
            }
            if (board[0, 1] == board[1, 1] && board[1, 1] == c && board[2, 1] == 8)
            {
                return new KeyValuePair<int, int>(2, 1);
            }
            if (board[0, 2] == board[1, 2] && board[1, 2] == c && board[2, 2] == 9)
            {
                return new KeyValuePair<int, int>(2, 2);
            }

            return new KeyValuePair<int, int>(-1, -1);
        }
    }
}
