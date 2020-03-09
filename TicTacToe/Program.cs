using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace TicTacToe
{
    class Program
    {
        static public bool gameWon = false;
        static public char[,] board;
        static public bool playerTurn = true;
        static bool errorPlayer = false;
        static Dictionary<string, float[]> dic;
        static List<Plays> plays;
        static char winnerPlayer;
        static int iaLosses = 0;
        static int gamesPlayed = 0;

        static int punishment = 5;

        static void Main(string[] args)
        {
            while (gamesPlayed < 1000)
            {
                InitializeBoard();
                InitializaVariables();

                while (!gameWon)
                {
                    Draw();
                    if (playerTurn)
                    {
                        //PlayerMove();
                        RandMove('X');
                    }
                    else
                    {
                        IAMove('O');
                    }
                    gameWon = WinCondition();
                }
                IAFinalGame();
                gamesPlayed++;
                //limpar memoria?
            }
            Console.WriteLine("Games Ia Lost:" + iaLosses);
            Console.WriteLine("Total Games:" + gamesPlayed);
        }

        static void InitializeBoard()
        {
            board = new char[3, 3];
            board[0, 0] = '1';
            board[0, 1] = '2';
            board[0, 2] = '3';
            board[1, 0] = '4';
            board[1, 1] = '5';
            board[1, 2] = '6';
            board[2, 0] = '7';
            board[2, 1] = '8';
            board[2, 2] = '9';
        }

        static void InitializaVariables()
        {
            gameWon = false;
            plays = new List<Plays>();
            dic = new Dictionary<string, float[]>();

            ReadTxt();
        }

        static void Draw()
        {
            //Console.Clear();
            //if (errorPlayer)
            //{
            //    Console.WriteLine("Joga Direito");
            //}
            //errorPlayer = false;
            //Console.WriteLine(board[0, 0] + "|" + board[0, 1] + "|" + board[0, 2]);
            //Console.WriteLine("-----");
            //Console.WriteLine(board[1, 0] + "|" + board[1, 1] + "|" + board[1, 2]);
            //Console.WriteLine("-----");
            //Console.WriteLine(board[2, 0] + "|" + board[2, 1] + "|" + board[2, 2]);
        }

        static void PlayerMove()
        {
            string move = Console.ReadLine();
            switch (move)
            {
                case "1":
                    if (board[0, 0] == '1')
                    {
                        board[0, 0] = 'X';
                        playerTurn = !playerTurn;
                    }
                    else
                    {
                        errorPlayer = true;
                    }
                    break;
                case "2":
                    if (board[0, 1] == '2')
                    {
                        board[0, 1] = 'X';
                        playerTurn = !playerTurn;
                    }
                    else
                    {
                        errorPlayer = true;
                    }
                    break;
                case "3":
                    if (board[0, 2] == '3')
                    {
                        board[0, 2] = 'X';
                        playerTurn = !playerTurn;
                    }
                    else
                    {
                        errorPlayer = true;
                    }
                    break;
                case "4":
                    if (board[1, 0] == '4')
                    {
                        board[1, 0] = 'X';
                        playerTurn = !playerTurn;
                    }
                    else
                    {
                        errorPlayer = true;
                    }
                    break;
                case "5":
                    if (board[1, 1] == '5')
                    {
                        board[1, 1] = 'X';
                        playerTurn = !playerTurn;
                    }
                    else
                    {
                        errorPlayer = true;
                    }
                    break;
                case "6":
                    if (board[1, 2] == '6')
                    {
                        board[1, 2] = 'X';
                        playerTurn = !playerTurn;
                    }
                    else
                    {
                        errorPlayer = true;
                    }
                    break;
                case "7":
                    if (board[2, 0] == '7')
                    {
                        board[2, 0] = 'X';
                        playerTurn = !playerTurn;
                    }
                    else
                    {
                        errorPlayer = true;
                    }
                    break;
                case "8":
                    if (board[2, 1] == '8')
                    {
                        board[2, 1] = 'X';
                        playerTurn = !playerTurn;
                    }
                    else
                    {
                        errorPlayer = true;
                    }
                    break;
                case "9":
                    if (board[2, 2] == '9')
                    {
                        board[2, 2] = 'X';
                        playerTurn = !playerTurn;
                    }
                    else
                    {
                        errorPlayer = true;
                    }
                    break;
                default:
                    errorPlayer = true;
                    break;
            }
        }

        static void RandMove(char c)
        {
            Random rnd = new Random();
            string move = rnd.Next(1, 10).ToString();
            switch (move)
            {
                case "1":
                    if (board[0, 0] == '1')
                    {
                        board[0, 0] = c;
                        playerTurn = !playerTurn;
                    }
                    else
                    {
                        RandMove(c);
                    }
                    break;
                case "2":
                    if (board[0, 1] == '2')
                    {
                        board[0, 1] = c;
                        playerTurn = !playerTurn;
                    }
                    else
                    {
                        RandMove(c);
                    }
                    break;
                case "3":
                    if (board[0, 2] == '3')
                    {
                        board[0, 2] = c;
                        playerTurn = !playerTurn;
                    }
                    else
                    {
                        RandMove(c);
                    }
                    break;
                case "4":
                    if (board[1, 0] == '4')
                    {
                        board[1, 0] = c;
                        playerTurn = !playerTurn;
                    }
                    else
                    {
                        RandMove(c);
                    }
                    break;
                case "5":
                    if (board[1, 1] == '5')
                    {
                        board[1, 1] = c;
                        playerTurn = !playerTurn;
                    }
                    else
                    {
                        RandMove(c);
                    }
                    break;
                case "6":
                    if (board[1, 2] == '6')
                    {
                        board[1, 2] = c;
                        playerTurn = !playerTurn;
                    }
                    else
                    {
                        RandMove(c);
                    }
                    break;
                case "7":
                    if (board[2, 0] == '7')
                    {
                        board[2, 0] = c;
                        playerTurn = !playerTurn;
                    }
                    else
                    {
                        RandMove(c);
                    }
                    break;
                case "8":
                    if (board[2, 1] == '8')
                    {
                        board[2, 1] = c;
                        playerTurn = !playerTurn;
                    }
                    else
                    {
                        RandMove(c);
                    }
                    break;
                case "9":
                    if (board[2, 2] == '9')
                    {
                        board[2, 2] = c;
                        playerTurn = !playerTurn;
                    }
                    else
                    {
                        RandMove(c);
                    }
                    break;
                default:
                    RandMove(c);
                    break;
            }
        }

        static void IAMove(char c)
        {
            string move = "5";
            if (dic.ContainsKey(TransformBoardToString()))
            {
                for (int i = 0; i <= 8; i++)
                {
                    if (dic[TransformBoardToString()][i] >= dic[TransformBoardToString()][1] && dic[TransformBoardToString()][i] >= dic[TransformBoardToString()][2] && dic[TransformBoardToString()][i] >= dic[TransformBoardToString()][3] && dic[TransformBoardToString()][i] >= dic[TransformBoardToString()][4] && dic[TransformBoardToString()][i] >= dic[TransformBoardToString()][5] && dic[TransformBoardToString()][i] >= dic[TransformBoardToString()][6] && dic[TransformBoardToString()][i] >= dic[TransformBoardToString()][7] && dic[TransformBoardToString()][i] >= dic[TransformBoardToString()][8])
                    {
                        move = i.ToString();
                    }
                }
            }
            else
            {
                float[] f = new float[9] { 0.11f, 0.11f, 0.11f, 0.11f, 0.11f, 0.11f, 0.11f, 0.11f, 0.11f };

                char[,] boardTemp = new char[3, 3];
                //boardTemp = (char[,])board.Clone();
                //for (int i = 0; i < 3; i++)
                //{
                //    boardTemp[0,i] = board.CopyTo(boardTemp[0], 0);
                //}
                //Array.Copy(board, 0, boardTemp, 0, board.Length);
                //dic.Add(boardTemp, f);

                dic.Add(TransformBoardToString(), f);
            }
            switch (move)
            {
                case "1":
                    if (board[0, 0] == '1')
                    {
                        Plays p = new Plays(TransformBoardToString(), move);
                        plays.Add(p);

                        board[0, 0] = c;
                        playerTurn = !playerTurn;
                    }
                    else
                    {
                        IAChange(move, false);
                        IAMove(c);
                    }
                    break;
                case "2":
                    if (board[0, 1] == '2')
                    {
                        Plays p = new Plays(TransformBoardToString(), move);
                        plays.Add(p);

                        board[0, 1] = c;
                        playerTurn = !playerTurn;
                    }
                    else
                    {
                        IAChange(move, false);
                        IAMove(c);
                    }
                    break;
                case "3":
                    if (board[0, 2] == '3')
                    {
                        Plays p = new Plays(TransformBoardToString(), move);
                        plays.Add(p);

                        board[0, 2] = c;
                        playerTurn = !playerTurn;
                    }
                    else
                    {
                        IAChange(move, false);
                        IAMove(c);
                    }
                    break;
                case "4":
                    if (board[1, 0] == '4')
                    {
                        Plays p = new Plays(TransformBoardToString(), move);
                        plays.Add(p);

                        board[1, 0] = c;
                        playerTurn = !playerTurn;
                    }
                    else
                    {
                        IAChange(move, false);
                        IAMove(c);
                    }
                    break;
                case "5":
                    if (board[1, 1] == '5')
                    {
                        Plays p = new Plays(TransformBoardToString(), move);
                        plays.Add(p);

                        board[1, 1] = c;
                        playerTurn = !playerTurn;
                    }
                    else
                    {
                        IAChange(move, false);
                        IAMove(c);
                    }
                    break;
                case "6":
                    if (board[1, 2] == '6')
                    {
                        Plays p = new Plays(TransformBoardToString(), move);
                        plays.Add(p);

                        board[1, 2] = c;
                        playerTurn = !playerTurn;
                    }
                    else
                    {
                        IAChange(move, false);
                        IAMove(c);
                    }
                    break;
                case "7":
                    if (board[2, 0] == '7')
                    {
                        Plays p = new Plays(TransformBoardToString(), move);
                        plays.Add(p);

                        board[2, 0] = c;
                        playerTurn = !playerTurn;
                    }
                    else
                    {
                        IAChange(move, false);
                        IAMove(c);
                    }
                    break;
                case "8":
                    if (board[2, 1] == '8')
                    {
                        Plays p = new Plays(TransformBoardToString(), move);
                        plays.Add(p);

                        board[2, 1] = c;
                        playerTurn = !playerTurn;
                    }
                    else
                    {
                        IAChange(move, false);
                        IAMove(c);
                    }
                    break;
                case "9":
                    if (board[2, 2] == '9')
                    {
                        Plays p = new Plays(TransformBoardToString(), move);
                        plays.Add(p);

                        board[2, 2] = c;
                        playerTurn = !playerTurn;
                    }
                    else
                    {
                        IAChange(move, false);
                        IAMove(c);
                    }
                    break;
                default:
                    IAChange(move, false);
                    IAMove(c);
                    break;
            }
        }

        static bool WinCondition()
        {
            if (board[0, 0] == board[0, 1] && board[0, 1] == board[0, 2])
            {
                winnerPlayer = board[0, 0];
                Draw();
                return true;
            }
            if (board[1, 0] == board[1, 1] && board[1, 1] == board[1, 2])
            {
                winnerPlayer = board[1, 0];
                Draw();
                return true;
            }
            if (board[2, 0] == board[0, 1] && board[2, 1] == board[2, 2])
            {
                winnerPlayer = board[2, 0];
                Draw();
                return true;
            }
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            if (board[0, 0] == board[1, 0] && board[1, 0] == board[2, 0])
            {
                winnerPlayer = board[0, 0];
                Draw();
                return true;
            }
            if (board[0, 1] == board[1, 1] && board[1, 1] == board[2, 1])
            {
                winnerPlayer = board[0, 1];
                Draw();
                return true;
            }
            if (board[0, 2] == board[1, 2] && board[1, 2] == board[2, 2])
            {
                winnerPlayer = board[0, 2];
                Draw();
                return true;
            }
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                winnerPlayer = board[0, 0];
                Draw();
                return true;
            }
            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                winnerPlayer = board[0, 2];
                Draw();
                return true;
            }
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            int cont = 1;
            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    if (board[i, j] == char.Parse(cont.ToString()))
                    {
                        return false;
                    }
                    cont++;
                }
            }
            winnerPlayer = 'N';
            Draw();
            return true;
        }

        static void IAChange(string s, bool rewarding, string boardStatus = null)
        {
            if (boardStatus == null)
            {
                boardStatus = TransformBoardToString();
            }

            if (rewarding)
            {
                float reward = dic[boardStatus][Int32.Parse(s)] / 100 * punishment;
                dic[boardStatus][Int32.Parse(s)] += reward;
            }
            else
            {
                float subtract = dic[boardStatus][Int32.Parse(s)] / 100.0f * punishment;
                dic[boardStatus][Int32.Parse(s)] -= subtract;
            }
        }

        static void IAFinalGame()
        {
            if (winnerPlayer == 'X')
            {
                iaLosses++;
                //ia perdeu
                //Console.WriteLine("Ia Lost!");
                foreach (Plays p in plays)
                {
                    IAChange(p.Value, false, p.Key);
                }
            }
            else
            {
                //ia ganhou
                //Console.WriteLine("Ia Won!");
                foreach (Plays p in plays)
                {
                    IAChange(p.Value, true, p.Key);
                }
            }
            WriteTxt();
        }

        static string TransformBoardToString(char[,] boardStatus = null)
        {
            if (boardStatus == null)
            {
                boardStatus = board;
            }

            string newBoard = string.Empty;

            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    newBoard += boardStatus[i, j];
                }
            }
            return newBoard;
        }

        static void ReadTxt()
        {
            string path = @"C:\Users\alu201620608\Downloads\TicTacToe\TicTacToe\Txt\IaBrain.txt";

            using (StreamReader sr = new StreamReader(path))
            {
                while (sr.Peek() >= 0)
                {
                    string[] strSplit = sr.ReadLine().Split('/');
                    float[] f = new float[9] { float.Parse(strSplit[1]), float.Parse(strSplit[2]), float.Parse(strSplit[3]), float.Parse(strSplit[4]), float.Parse(strSplit[5]), float.Parse(strSplit[6]), float.Parse(strSplit[7]), float.Parse(strSplit[8]), float.Parse(strSplit[9]) };
                    dic.Add(strSplit[0], f);
                }
            }
        }

        static void WriteTxt()
        {
            string path = @"C:\Users\alu201620608\Downloads\TicTacToe\TicTacToe\Txt\IaBrain.txt";

            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (KeyValuePair<string, float[]> k in dic)
                {
                    string s = k.Key + "/";

                    foreach (float f in k.Value)
                    {
                        s += f + "/";
                    }
                    s = s.Remove(s.Length - 1);
                    sw.WriteLine(s);
                }
            }
        }
    }
}
