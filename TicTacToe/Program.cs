using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace TicTacToe
{
    class Program
    {
        static string filePathX;
        static string filePathO;
        static public bool gameWon = false;
        static public char[,] board;
        static public bool playerTurn = true;
        static bool errorPlayer = false;
        static Dictionary<string, float[]> iaBrainDicX;
        static Dictionary<string, float[]> iaBrainDicO;
        static Dictionary<string, int> numberOfSameMovesX;
        static Dictionary<string, int> numberOfSameMovesO;
        static List<Plays> playsX;
        static List<Plays> playsO;
        static char winnerPlayer;
        static int iaXLosses = 0;
        static int iaOLosses = 0;

        static int gamesPlayed = 0;
        static int TotalgamesPlayedX;
        static int TotalgamesPlayedO;

        static int punishment = 5;

        static void Main(string[] args)
        {
            filePathX = filePathO = System.IO.Directory.GetCurrentDirectory().Split("bin\\Debug\\netcoreapp3.0")[0];
            filePathX += @"Txt\IaBrainX.txt";
            filePathO += @"Txt\IaBrainO.txt";
            while (gamesPlayed < 10000)
            {
                InitializeBoard();
                InitializaVariables();

                while (!gameWon)
                {
                    Draw();
                    if (playerTurn)
                    {
                        //PlayerMove();
                        //RandMove('X');
                        IAMove('X');
                    }
                    else
                    {
                        IAMove('O');
                    }
                    gameWon = WinCondition();
                }
                IAFinalGame();
                gamesPlayed++;
            }
            Console.Beep();
            Console.WriteLine("Games Ia 'X' Lost:" + iaXLosses);
            Console.WriteLine("Games Ia 'O' Lost:" + iaOLosses);
            
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
            playsO = new List<Plays>();
            playsX = new List<Plays>();
            iaBrainDicX = new Dictionary<string, float[]>();
            iaBrainDicO = new Dictionary<string, float[]>();
            numberOfSameMovesX = new Dictionary<string, int>();
            numberOfSameMovesO = new Dictionary<string, int>();

            ReadTxtX();
            ReadTxtO();
        }

        static void Draw()
        {
            bool showBoard = false;
            if (showBoard)
            {
                Console.Clear();
                if (errorPlayer)
                {
                    Console.WriteLine("Joga Direito");
                }
                errorPlayer = false;
                Console.WriteLine(board[0, 0] + "|" + board[0, 1] + "|" + board[0, 2]);
                Console.WriteLine("-----");
                Console.WriteLine(board[1, 0] + "|" + board[1, 1] + "|" + board[1, 2]);
                Console.WriteLine("-----");
                Console.WriteLine(board[2, 0] + "|" + board[2, 1] + "|" + board[2, 2]);
            }
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
            string boardLocal = TransformBoardToString();
            string move = DetermineMove(boardLocal, c);

            switch (move)
            {
                case "1":
                    if (board[0, 0] == '1')
                    {
                        addPlay(boardLocal, move, c);

                        board[0, 0] = c;
                        playerTurn = !playerTurn;
                    }
                    else
                    {
                        IAChange(move, false, c);
                        IAMove(c);
                    }
                    break;
                case "2":
                    if (board[0, 1] == '2')
                    {
                        addPlay(boardLocal, move, c);

                        board[0, 1] = c;
                        playerTurn = !playerTurn;
                    }
                    else
                    {
                        IAChange(move, false, c);
                        IAMove(c);
                    }
                    break;
                case "3":
                    if (board[0, 2] == '3')
                    {
                        addPlay(boardLocal, move, c);

                        board[0, 2] = c;
                        playerTurn = !playerTurn;
                    }
                    else
                    {
                        IAChange(move, false, c);
                        IAMove(c);
                    }
                    break;
                case "4":
                    if (board[1, 0] == '4')
                    {
                        addPlay(boardLocal, move, c);

                        board[1, 0] = c;
                        playerTurn = !playerTurn;
                    }
                    else
                    {
                        IAChange(move, false, c);
                        IAMove(c);
                    }
                    break;
                case "5":
                    if (board[1, 1] == '5')
                    {
                        addPlay(boardLocal, move, c);

                        board[1, 1] = c;
                        playerTurn = !playerTurn;
                    }
                    else
                    {
                        IAChange(move, false, c);
                        IAMove(c);
                    }
                    break;
                case "6":
                    if (board[1, 2] == '6')
                    {
                        addPlay(boardLocal, move, c);

                        board[1, 2] = c;
                        playerTurn = !playerTurn;
                    }
                    else
                    {
                        IAChange(move, false, c);
                        IAMove(c);
                    }
                    break;
                case "7":
                    if (board[2, 0] == '7')
                    {
                        addPlay(boardLocal, move, c);

                        board[2, 0] = c;
                        playerTurn = !playerTurn;
                    }
                    else
                    {
                        IAChange(move, false, c);
                        IAMove(c);
                    }
                    break;
                case "8":
                    if (board[2, 1] == '8')
                    {
                        addPlay(boardLocal, move, c);

                        board[2, 1] = c;
                        playerTurn = !playerTurn;
                    }
                    else
                    {
                        IAChange(move, false, c);
                        IAMove(c);
                    }
                    break;
                case "9":
                    if (board[2, 2] == '9')
                    {
                        addPlay(boardLocal, move, c);

                        board[2, 2] = c;
                        playerTurn = !playerTurn;
                    }
                    else
                    {
                        IAChange(move, false, c);
                        IAMove(c);
                    }
                    break;
                default:
                    Console.WriteLine("Logical error!");
                    break;
            }
        }

        static string DetermineMove(string boardLocal, char turn)
        {
            List<float> possibleMoves = new List<float>();
            if (turn == 'X')
            {
                if (iaBrainDicX.ContainsKey(boardLocal))
                {
                    for (int i = 0; i < iaBrainDicX[boardLocal].Length; i++)
                    {
                        char[] boardChar = boardLocal.ToCharArray();
                        //the +48 is to converto to asc table
                        if (boardChar[i] == Convert.ToChar((i + 1) + 48))
                        {
                            possibleMoves.Add(iaBrainDicX[boardLocal][i]);
                        }
                        else
                        {
                            possibleMoves.Add(float.MinValue);
                        }
                    }

                    return returnBiggest(possibleMoves).ToString();
                }
                else
                {
                    float[] f = new float[9] { 0.11f, 0.11f, 0.11f, 0.11f, 0.11f, 0.11f, 0.11f, 0.11f, 0.11f };

                    //char[,] boardTemp = new char[3, 3];

                    iaBrainDicX.Add(boardLocal, f);

                    return "5";
                }
            }
            else
            {
                if (iaBrainDicO.ContainsKey(boardLocal))
                {
                    for (int i = 0; i < iaBrainDicO[boardLocal].Length; i++)
                    {
                        char[] boardChar = boardLocal.ToCharArray();
                        //the +48 is to converto to asc table
                        if (boardChar[i] == Convert.ToChar((i + 1) + 48))
                        {
                            possibleMoves.Add(iaBrainDicO[boardLocal][i]);
                        }
                        else
                        {
                            possibleMoves.Add(float.MinValue);
                        }
                    }

                    return returnBiggest(possibleMoves).ToString();
                }
                else
                {
                    float[] f = new float[9] { 0.11f, 0.11f, 0.11f, 0.11f, 0.11f, 0.11f, 0.11f, 0.11f, 0.11f };

                    //char[,] boardTemp = new char[3, 3];

                    iaBrainDicO.Add(boardLocal, f);

                    return "5";
                }
            }
        }

        static int returnBiggest(List<float> values)
        {
            if (values.Count == 1)
            {
                return 0;
            }
            int smallest = 0;


            for (int i = 1; i < values.Count; i++)
            {
                if (values[i] > values[i - 1])
                {
                    smallest = i;
                }
            }

            //convert 1...9 (board) to 0...8(array)
            return smallest + 1;
        }

        static void addPlay(string boardLocal, string move, char turn)
        {
            Plays p = new Plays(boardLocal, move);
            if (turn == 'X')
            {
                playsX.Add(p);
                addCountSameMovesX(boardLocal);
            }
            else
            {
                playsO.Add(p);
                addCountSameMovesO(boardLocal);
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

        static void IAFinalGame()
        {
            if (winnerPlayer == 'X')
            {
                foreach (Plays p in playsX)
                {
                    IAChange(p.Value, true, 'X', p.Key);
                    IAChange(p.Value, true, 'X', p.Key);
                    IAChange(p.Value, true, 'X', p.Key);
                    IAChange(p.Value, true, 'X', p.Key);
                    IAChange(p.Value, true, 'X', p.Key);
                }

                iaOLosses++;
                foreach (Plays p in playsO)
                {
                    IAChange(p.Value, false, 'O', p.Key);
                    IAChange(p.Value, false, 'O', p.Key);
                    IAChange(p.Value, false, 'O', p.Key);
                    IAChange(p.Value, false, 'O', p.Key);
                    IAChange(p.Value, false, 'O', p.Key);
                }
            }
            else if (winnerPlayer == 'O')
            {
                foreach (Plays p in playsX)
                {
                    IAChange(p.Value, false, 'X', p.Key);
                    IAChange(p.Value, false, 'X', p.Key);
                    IAChange(p.Value, false, 'X', p.Key);
                    IAChange(p.Value, false, 'X', p.Key);
                    IAChange(p.Value, false, 'X', p.Key);
                }
                iaXLosses++;

                foreach (Plays p in playsO)
                {
                    IAChange(p.Value, true, 'O', p.Key);
                    IAChange(p.Value, true, 'O', p.Key);
                    IAChange(p.Value, true, 'O', p.Key);
                    IAChange(p.Value, true, 'O', p.Key);
                    IAChange(p.Value, true, 'O', p.Key);
                }
            }
            else
            {
                //empate
                foreach (Plays p in playsX)
                {
                    IAChange(p.Value, false, 'X', p.Key);
                }

                foreach (Plays p in playsO)
                {
                    IAChange(p.Value, true, 'O', p.Key);
                }
            }
            WriteTxtX();
            WriteTxtO();
        }

        static void IAChange(string s, bool rewarding, char turn, string boardStatus = null)
        {
            if (boardStatus == null)
            {
                boardStatus = TransformBoardToString();
            }
            int valueToBeChanged = Int32.Parse(s) - 1;

            if (turn == 'X')
            {
                if (rewarding)
                {
                    float reward = 0.001f * punishment;

                    for (int i = 0; i < iaBrainDicX[boardStatus].Length; i++)
                    {
                        if (i == valueToBeChanged)
                        {
                            iaBrainDicX[boardStatus][i] += reward;
                            if (iaBrainDicX[boardStatus][i] > 100.0f)
                            {
                                iaBrainDicX[boardStatus][i] = 100.0f;
                            }
                        }
                        else
                        {
                            iaBrainDicX[boardStatus][i] -= (reward / 8);
                            if (iaBrainDicX[boardStatus][i] < 0.0f)
                            {
                                iaBrainDicX[boardStatus][i] = 0.0f;
                            }
                        }
                    }
                }
                else
                {
                    float subtract = 0.001f * punishment;


                    for (int i = 0; i < iaBrainDicX[boardStatus].Length; i++)
                    {
                        if (i == valueToBeChanged)
                        {
                            iaBrainDicX[boardStatus][i] -= subtract;
                            if (iaBrainDicX[boardStatus][i] < 0.0f)
                            {
                                iaBrainDicX[boardStatus][i] = 0.0f;
                            }
                        }
                        else
                        {
                            iaBrainDicX[boardStatus][i] += (subtract / 8);
                            if (iaBrainDicX[boardStatus][i] > 100.0f)
                            {
                                iaBrainDicX[boardStatus][i] = 100.0f;
                            }
                        }
                    }
                }
            }
            else
            {
                if (rewarding)
                {
                    float reward = 0.001f * punishment;

                    for (int i = 0; i < iaBrainDicO[boardStatus].Length; i++)
                    {
                        if (i == valueToBeChanged)
                        {
                            iaBrainDicO[boardStatus][i] += reward;
                            if (iaBrainDicO[boardStatus][i] > 100.0f)
                            {
                                iaBrainDicO[boardStatus][i] = 100.0f;
                            }
                        }
                        else
                        {
                            iaBrainDicO[boardStatus][i] -= (reward / 8);
                            if (iaBrainDicO[boardStatus][i] < 0.0f)
                            {
                                iaBrainDicO[boardStatus][i] = 0.0f;
                            }
                        }
                    }
                }
                else
                {
                    float subtract = 0.001f * punishment;


                    for (int i = 0; i < iaBrainDicO[boardStatus].Length; i++)
                    {
                        if (i == valueToBeChanged)
                        {
                            iaBrainDicO[boardStatus][i] -= subtract;
                            if (iaBrainDicO[boardStatus][i] < 0.0f)
                            {
                                iaBrainDicO[boardStatus][i] = 0.0f;
                            }
                        }
                        else
                        {
                            iaBrainDicO[boardStatus][i] += (subtract / 8);
                            if (iaBrainDicO[boardStatus][i] > 100.0f)
                            {
                                iaBrainDicO[boardStatus][i] = 100.0f;
                            }
                        }
                    }
                }
            }
        }

        static string TransformBoardToString(char[,] boardStatus = null)
        {
            if (boardStatus == null)
            {
                boardStatus = board;
            }

            string newBoard = string.Empty;

            //this causes stackoverflow
            //for (int i = 0; i <= 2; i++)
            //{
            //    for (int j = 0; j <= 2; j++)
            //    {
            //        newBoard += boardStatus[i, j];
            //    }
            //}

            //this dont
            newBoard += boardStatus[0, 0];
            newBoard += boardStatus[0, 1];
            newBoard += boardStatus[0, 2];
            newBoard += boardStatus[1, 0];
            newBoard += boardStatus[1, 1];
            newBoard += boardStatus[1, 2];
            newBoard += boardStatus[2, 0];
            newBoard += boardStatus[2, 1];
            newBoard += boardStatus[2, 2];

            return newBoard;
        }

        static void addCountSameMovesX(string boardLocal)
        {
            if (numberOfSameMovesX.ContainsKey(boardLocal))
            {
                numberOfSameMovesX[boardLocal]++;
            }
            else
            {
                numberOfSameMovesX.Add(boardLocal, 1);
            }
        }

        static void addCountSameMovesO(string boardLocal)
        {
            if (numberOfSameMovesO.ContainsKey(boardLocal))
            {
                numberOfSameMovesO[boardLocal]++;
            }
            else
            {
                numberOfSameMovesO.Add(boardLocal, 1);
            }
        }

        static void ReadTxtX()
        {
            using (StreamReader sr = new StreamReader(filePathX))
            {
                //if ia is not empty
                if (sr.Peek() >= 0)
                {
                    TotalgamesPlayedX = int.Parse(sr.ReadLine());
                    while (sr.Peek() >= 0)
                    {
                        string preSplit = sr.ReadLine();
                        string[] strSplit = preSplit.Split('/');
                        float[] f = new float[9] { float.Parse(strSplit[1]), float.Parse(strSplit[2]), float.Parse(strSplit[3]), float.Parse(strSplit[4]), float.Parse(strSplit[5]), float.Parse(strSplit[6]), float.Parse(strSplit[7]), float.Parse(strSplit[8]), float.Parse(strSplit[9]) };
                        iaBrainDicX.Add(strSplit[0], f);
                        if (strSplit.Length == 11)
                        {
                            numberOfSameMovesX.Add(strSplit[0], Int32.Parse(strSplit[10]));
                        }
                        else
                        {
                            numberOfSameMovesX.Add(strSplit[0], 0);
                        }
                    }
                }
                else
                {
                    TotalgamesPlayedX = 0;
                }
            }
        }

        static void ReadTxtO()
        {
            using (StreamReader sr = new StreamReader(filePathO))
            {
                //if ia is not empty
                if (sr.Peek() >= 0)
                {
                    TotalgamesPlayedO = int.Parse(sr.ReadLine());
                    while (sr.Peek() >= 0)
                    {
                        string preSplit = sr.ReadLine();
                        string[] strSplit = preSplit.Split('/');
                        float[] f = new float[9] { float.Parse(strSplit[1]), float.Parse(strSplit[2]), float.Parse(strSplit[3]), float.Parse(strSplit[4]), float.Parse(strSplit[5]), float.Parse(strSplit[6]), float.Parse(strSplit[7]), float.Parse(strSplit[8]), float.Parse(strSplit[9]) };
                        iaBrainDicO.Add(strSplit[0], f);
                        if (strSplit.Length == 11)
                        {
                            numberOfSameMovesO.Add(strSplit[0], Int32.Parse(strSplit[10]));
                        }
                        else
                        {
                            numberOfSameMovesO.Add(strSplit[0], 0);
                        }
                    }
                }
                else
                {
                    TotalgamesPlayedO = 0;
                }
            }
        }

        static void WriteTxtX()
        {
            using (StreamWriter sw = new StreamWriter(filePathX))
            {
                sw.WriteLine(TotalgamesPlayedX + 1);
                foreach (KeyValuePair<string, float[]> kvp in iaBrainDicX)
                {
                    string line = kvp.Key + "/";

                    foreach (float chanceToMakeThisMove in kvp.Value)
                    {
                        line += chanceToMakeThisMove + "/";
                    }

                    int sameMovesCount;
                    if (numberOfSameMovesX.TryGetValue(kvp.Key, out sameMovesCount))
                    {
                        line += sameMovesCount.ToString();
                    }
                    else
                    {
                        line += "0";
                    }

                    sw.WriteLine(line);
                }
            }
        }

        static void WriteTxtO()
        {
            using (StreamWriter sw = new StreamWriter(filePathO))
            {
                sw.WriteLine(TotalgamesPlayedO + 1);
                foreach (KeyValuePair<string, float[]> kvp in iaBrainDicO)
                {
                    string line = kvp.Key + "/";

                    foreach (float chanceToMakeThisMove in kvp.Value)
                    {
                        line += chanceToMakeThisMove + "/";
                    }
                    //line = line.Remove(line.Length - 1);

                    int sameMovesCount;
                    if (numberOfSameMovesO.TryGetValue(kvp.Key, out sameMovesCount))
                    {
                        line += sameMovesCount.ToString();
                    }
                    else
                    {
                        line += "0";
                    }

                    sw.WriteLine(line);
                }
            }
        }
    }
}
