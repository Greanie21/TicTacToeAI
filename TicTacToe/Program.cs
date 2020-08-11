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
        static int ties = 0;

        static int gamesPlayed = 0;
        static int maxGames = 1000 * 1000 * 1000;//10*1000*1000
        static int TotalgamesPlayedX;
        static int TotalgamesPlayedO;

        static int punishmentOrRewardPercent = 2;
        static string gameModeX = "RANDOM";//PLAYER, RANDOM, IA
        static string gameModeO = "IA";//PLAYER, RANDOM, IA

        static void Main(string[] args)
        {
            filePathX = filePathO = System.IO.Directory.GetCurrentDirectory().Split("bin\\Debug\\netcoreapp3.0")[0];
            filePathX += @"Txt\IaBrainX.txt";
            filePathO += @"Txt\IaBrainO.txt";

            InitializaVariablesForAllGames();
            while (gamesPlayed < maxGames)
            {
                InitializeBoard();
                InitializaVariablesForEachGame();

                PlayGame();

                IAFinalEachGame();
                gamesPlayed++;
            }
            FinalLastGame();

            Console.Beep();

            Console.WriteLine("Player 'X':" + gameModeX);
            Console.WriteLine("Games Ia 'X' Lost:" + iaXLosses);

            Console.WriteLine("Player 'O':" + gameModeO);
            Console.WriteLine("Games Ia 'O' Lost:" + iaOLosses);

            Console.WriteLine("Ties:" + ties);

            Console.WriteLine("Total Games:" + gamesPlayed);
        }

        #region Initialize the game
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

        static void InitializaVariablesForAllGames()
        {
            iaBrainDicX = new Dictionary<string, float[]>();
            iaBrainDicO = new Dictionary<string, float[]>();
            numberOfSameMovesX = new Dictionary<string, int>();
            numberOfSameMovesO = new Dictionary<string, int>();

            ReadTxtX();
            ReadTxtO();
        }

        static void InitializaVariablesForEachGame()
        {
            gameWon = false;
            playerTurn = true;
            playsO = new List<Plays>();
            playsX = new List<Plays>();
        }


        #endregion

        static void DrawBoard(bool showBoard = false)
        {
            if (gameModeX == "PLAYER" || gameModeO == "PLAYER")
            {
                showBoard = true;
            }

            if (showBoard)
            {
                Console.Clear();

                if (errorPlayer)
                {
                    Console.WriteLine("Joga Direito");
                    errorPlayer = false;
                }

                Console.WriteLine(board[0, 0] + "|" + board[0, 1] + "|" + board[0, 2]);
                Console.WriteLine("-----");
                Console.WriteLine(board[1, 0] + "|" + board[1, 1] + "|" + board[1, 2]);
                Console.WriteLine("-----");
                Console.WriteLine(board[2, 0] + "|" + board[2, 1] + "|" + board[2, 2]);
            }
        }

        static void PlayGame()
        {
            while (!gameWon)
            {
                DrawBoard();
                if (playerTurn)
                {
                    switch (gameModeX)
                    {
                        case "PLAYER":
                            PlayerMove('X');
                            break;
                        case "RANDOM":
                            RandMove('X');
                            break;
                        case "IA":
                            IAMove('X');
                            break;
                    }
                }
                else
                {
                    switch (gameModeO)
                    {
                        case "PLAYER":
                            PlayerMove('O');
                            break;
                        case "RANDOM":
                            RandMove('O');
                            break;
                        case "IA":
                            IAMove('O');
                            break;
                    }
                }

                if (errorPlayer == false)
                {
                    playerTurn = !playerTurn;
                    gameWon = WinCondition();

                    if (gameWon)
                    {
                        DrawBoard();

                        if (gameModeX == "PLAYER" || gameModeO == "PLAYER")
                        {
                            Console.WriteLine("Jogo Encerrado!!!");
                            Console.WriteLine("Pressione Enter para continuar!");
                            Console.Read();
                        }

                    }
                }
            }
        }

        #region Moves
        static void PlayerMove(char c)
        {
            string move = Console.ReadLine();
            switch (move)
            {
                case "1":
                    if (board[0, 0] == '1')
                    {
                        board[0, 0] = c;
                    }
                    else
                    {
                        errorPlayer = true;
                    }
                    break;
                case "2":
                    if (board[0, 1] == '2')
                    {
                        board[0, 1] = c;
                    }
                    else
                    {
                        errorPlayer = true;
                    }
                    break;
                case "3":
                    if (board[0, 2] == '3')
                    {
                        board[0, 2] = c;
                    }
                    else
                    {
                        errorPlayer = true;
                    }
                    break;
                case "4":
                    if (board[1, 0] == '4')
                    {
                        board[1, 0] = c;
                    }
                    else
                    {
                        errorPlayer = true;
                    }
                    break;
                case "5":
                    if (board[1, 1] == '5')
                    {
                        board[1, 1] = c;
                    }
                    else
                    {
                        errorPlayer = true;
                    }
                    break;
                case "6":
                    if (board[1, 2] == '6')
                    {
                        board[1, 2] = c;
                    }
                    else
                    {
                        errorPlayer = true;
                    }
                    break;
                case "7":
                    if (board[2, 0] == '7')
                    {
                        board[2, 0] = c;
                    }
                    else
                    {
                        errorPlayer = true;
                    }
                    break;
                case "8":
                    if (board[2, 1] == '8')
                    {
                        board[2, 1] = c;
                    }
                    else
                    {
                        errorPlayer = true;
                    }
                    break;
                case "9":
                    if (board[2, 2] == '9')
                    {
                        board[2, 2] = c;
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
            string boardLocal = TransformBoardToString();
            string move = new Random().Next(1, 10).ToString();
            switch (move)
            {
                case "1":
                    if (board[0, 0] == '1')
                    {
                        addPlayToIa(boardLocal, move, c);

                        board[0, 0] = c;
                    }
                    else
                    {
                        IAChange(move, false, c);
                        RandMove(c);
                    }
                    break;
                case "2":
                    if (board[0, 1] == '2')
                    {
                        addPlayToIa(boardLocal, move, c);

                        board[0, 1] = c;
                    }
                    else
                    {
                        IAChange(move, false, c);
                        RandMove(c);
                    }
                    break;
                case "3":
                    if (board[0, 2] == '3')
                    {
                        addPlayToIa(boardLocal, move, c);

                        board[0, 2] = c;
                    }
                    else
                    {
                        IAChange(move, false, c);
                        RandMove(c);
                    }
                    break;
                case "4":
                    if (board[1, 0] == '4')
                    {
                        addPlayToIa(boardLocal, move, c);

                        board[1, 0] = c;
                    }
                    else
                    {
                        IAChange(move, false, c);
                        RandMove(c);
                    }
                    break;
                case "5":
                    if (board[1, 1] == '5')
                    {
                        addPlayToIa(boardLocal, move, c);

                        board[1, 1] = c;
                    }
                    else
                    {
                        IAChange(move, false, c);
                        RandMove(c);
                    }
                    break;
                case "6":
                    if (board[1, 2] == '6')
                    {
                        addPlayToIa(boardLocal, move, c);

                        board[1, 2] = c;
                    }
                    else
                    {
                        IAChange(move, false, c);
                        RandMove(c);
                    }
                    break;
                case "7":
                    if (board[2, 0] == '7')
                    {
                        addPlayToIa(boardLocal, move, c);

                        board[2, 0] = c;
                    }
                    else
                    {
                        IAChange(move, false, c);
                        RandMove(c);
                    }
                    break;
                case "8":
                    if (board[2, 1] == '8')
                    {
                        addPlayToIa(boardLocal, move, c);

                        board[2, 1] = c;
                    }
                    else
                    {
                        IAChange(move, false, c);
                        RandMove(c);
                    }
                    break;
                case "9":
                    if (board[2, 2] == '9')
                    {
                        addPlayToIa(boardLocal, move, c);

                        board[2, 2] = c;
                    }
                    else
                    {
                        IAChange(move, false, c);
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
                        addPlayToIa(boardLocal, move, c);

                        board[0, 0] = c;
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
                        addPlayToIa(boardLocal, move, c);

                        board[0, 1] = c;
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
                        addPlayToIa(boardLocal, move, c);

                        board[0, 2] = c;
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
                        addPlayToIa(boardLocal, move, c);

                        board[1, 0] = c;
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
                        addPlayToIa(boardLocal, move, c);

                        board[1, 1] = c;
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
                        addPlayToIa(boardLocal, move, c);

                        board[1, 2] = c;
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
                        addPlayToIa(boardLocal, move, c);

                        board[2, 0] = c;
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
                        addPlayToIa(boardLocal, move, c);

                        board[2, 1] = c;
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
                        addPlayToIa(boardLocal, move, c);

                        board[2, 2] = c;
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

            Dictionary<string, float[]> iaBrainDic;
            if (turn == 'X')
            {
                iaBrainDic = iaBrainDicX;
            }
            else
            {
                iaBrainDic = iaBrainDicO;
            }

            if (iaBrainDic.ContainsKey(boardLocal))
            {
                for (int i = 0; i < iaBrainDic[boardLocal].Length; i++)
                {
                    char[] boardChar = boardLocal.ToCharArray();
                    //the +48 is to converto to asc table
                    if (boardChar[i] == Convert.ToChar((i + 1) + 48))
                    {
                        possibleMoves.Add(iaBrainDic[boardLocal][i]);
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
                float[] percentages = new float[9] { 0.111f, 0.111f, 0.111f, 0.111f, 0.111f, 0.111f, 0.111f, 0.111f, 0.111f };

                iaBrainDic.Add(boardLocal, percentages);

                return "5";
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

        static void addPlayToIa(string boardLocal, string move, char turn)
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
        #endregion

        static bool WinCondition()
        {
            //VERTICAL
            if (board[0, 0] == board[0, 1] && board[0, 1] == board[0, 2])
            {
                winnerPlayer = board[0, 0];
                return true;
            }
            if (board[1, 0] == board[1, 1] && board[1, 1] == board[1, 2])
            {
                winnerPlayer = board[1, 0];
                return true;
            }
            if (board[2, 0] == board[2, 1] && board[2, 1] == board[2, 2])
            {
                winnerPlayer = board[2, 0];
                return true;
            }
            //HORIZONTAL
            if (board[0, 0] == board[1, 0] && board[1, 0] == board[2, 0])
            {
                winnerPlayer = board[0, 0];
                return true;
            }
            if (board[0, 1] == board[1, 1] && board[1, 1] == board[2, 1])
            {
                winnerPlayer = board[0, 1];
                return true;
            }
            if (board[0, 2] == board[1, 2] && board[1, 2] == board[2, 2])
            {
                winnerPlayer = board[0, 2];
                return true;
            }
            //CROSS
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                winnerPlayer = board[0, 0];
                return true;
            }
            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                winnerPlayer = board[0, 2];
                return true;
            }
            //GAME NOT OVER YET
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
            //TIE
            winnerPlayer = 'N';
            return true;
        }

        #region IA Things
        static void IAFinalEachGame()
        {
            if (winnerPlayer == 'X')
            {
                iaOLosses++;

                if (gameModeO == "IA" || gameModeO == "PLAYER")
                {
                    foreach (Plays p in playsX)
                    {
                        IAChange(p.Value, true, 'X', p.Key);
                    }
                }

                foreach (Plays p in playsO)
                {
                    IAChange(p.Value, false, 'O', p.Key);
                }
            }
            else if (winnerPlayer == 'O')
            {
                iaXLosses++;

                foreach (Plays p in playsX)
                {
                    IAChange(p.Value, false, 'X', p.Key);
                }

                if (gameModeX == "IA" || gameModeX == "PLAYER")
                {
                    foreach (Plays p in playsO)
                    {
                        IAChange(p.Value, true, 'O', p.Key);
                    }
                }
            }
            else
            {
                ties++;

                if (gameModeO == "PLAYER")
                {
                    foreach (Plays p in playsX)
                    {
                        IAChange(p.Value, true, 'X', p.Key);
                    }
                }
                else if (gameModeO == "RAMDOM")
                {
                    //foreach (Plays p in playsX)
                    //{
                    //    IAChange(p.Value, false, 'X', p.Key);
                    //}
                }

                if (gameModeX == "PLAYER")
                {
                    foreach (Plays p in playsO)
                    {
                        IAChange(p.Value, true, 'O', p.Key);
                    }
                }
                else if (gameModeO == "RAMDOM")
                {
                    //foreach (Plays p in playsO)
                    //{
                    //    IAChange(p.Value, false, 'O', p.Key);
                    //}
                }
            }
        }

        static void FinalLastGame()
        {
            WriteTxtX();

            WriteTxtO();
        }

        static void IAChange(string s, bool rewarding, char turn, string boardLocal = null)
        {
            if (boardLocal == null)
            {
                boardLocal = TransformBoardToString();
            }
            int valueToBeChanged = Int32.Parse(s) - 1;

            Dictionary<string, float[]> iaBrainDic;
            if (turn == 'X')
            {
                iaBrainDic = iaBrainDicX;
            }
            else
            {
                iaBrainDic = iaBrainDicO;
            }

            if (iaBrainDic.ContainsKey(boardLocal) == false)
            {
                float[] percentages = new float[9] { 0.111f, 0.111f, 0.111f, 0.111f, 0.111f, 0.111f, 0.111f, 0.111f, 0.111f };

                iaBrainDic.Add(boardLocal, percentages);
            }

            float valueToChange;
            if (rewarding)
            {
                valueToChange = (100 + punishmentOrRewardPercent) / 100.0f;
            }
            else
            {
                valueToChange = (100 - punishmentOrRewardPercent) / 100.0f;
            }

            iaBrainDic[boardLocal][valueToBeChanged] = iaBrainDic[boardLocal][valueToBeChanged] * valueToChange;

            PercentageFix2(iaBrainDic, boardLocal);
        }

        static void PercentageFix(Dictionary<string, float[]> iaBrainDic, string boardStatus)
        {
            float total = 0;

            for (int i = 0; i < iaBrainDic[boardStatus].Length; i++)
            {
                total += iaBrainDic[boardStatus][i];
            }

            for (int i = 0; i < iaBrainDic[boardStatus].Length; i++)
            {
                float percentageOfValue = iaBrainDic[boardStatus][i] * 100 / total;
                float newValue = percentageOfValue / 100;
                newValue = MathF.Round(newValue, 2);
                if (newValue >= 1.0f)
                {
                    iaBrainDic[boardStatus][i] = 0.92f;
                }
                else if (newValue <= 0)
                {
                    iaBrainDic[boardStatus][i] = 0.01f;
                }
                else
                {
                    iaBrainDic[boardStatus][i] = newValue;
                }
            }
        }

        static void PercentageFix2(Dictionary<string, float[]> iaBrainDic, string boardStatus)
        {
            float total = 0;

            for (int i = 0; i < iaBrainDic[boardStatus].Length; i++)
            {
                total += iaBrainDic[boardStatus][i];
            }

            float valueToSubtract = (total - 1.0f) / 9;

            for (int i = 0; i < iaBrainDic[boardStatus].Length; i++)
            {
                float newValue = iaBrainDic[boardStatus][i] - valueToSubtract;
                newValue = MathF.Round(newValue, 2);

                if (newValue >= 1.0f)
                {
                    iaBrainDic[boardStatus][i] = 0.92f;
                }
                else if (newValue <= 0)
                {
                    iaBrainDic[boardStatus][i] = 0.01f;
                }
                else
                {
                    iaBrainDic[boardStatus][i] = newValue;
                }
            }
        }
        #endregion

        #region Utilitary things
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
        #endregion

        #region Read and Write Txt
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
                        float[] percentages = new float[9] { float.Parse(strSplit[1]), float.Parse(strSplit[2]), float.Parse(strSplit[3]), float.Parse(strSplit[4]), float.Parse(strSplit[5]), float.Parse(strSplit[6]), float.Parse(strSplit[7]), float.Parse(strSplit[8]), float.Parse(strSplit[9]) };
                        iaBrainDicX.Add(strSplit[0], percentages);
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
                StringBuilder text = new StringBuilder();
                text.Append((TotalgamesPlayedX + gamesPlayed).ToString());
                text.Append('\n');

                foreach (KeyValuePair<string, float[]> kvp in iaBrainDicX)
                {
                    string line = kvp.Key + "/";

                    foreach (float percentages in kvp.Value)
                    {
                        line += percentages + "/";
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

                    text.Append(line);
                    text.Append('\n');
                }
                sw.Write(text);
            }
        }

        static void WriteTxtO()
        {
            using (StreamWriter sw = new StreamWriter(filePathO))
            {
                StringBuilder text = new StringBuilder();
                text.Append((TotalgamesPlayedO + gamesPlayed).ToString());
                text.Append('\n');

                foreach (KeyValuePair<string, float[]> kvp in iaBrainDicO)
                {
                    string line = kvp.Key + "/";

                    foreach (float chanceToMakeThisMove in kvp.Value)
                    {
                        line += chanceToMakeThisMove + "/";
                    }

                    int sameMovesCount;
                    if (numberOfSameMovesO.TryGetValue(kvp.Key, out sameMovesCount))
                    {
                        line += sameMovesCount.ToString();
                    }
                    else
                    {
                        line += "0";
                    }

                    text.Append(line);
                    text.Append('\n');
                }
                sw.Write(text);
            }
        }
        #endregion
    }
}
