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

        static int punishment = 2;
        static string opponent = "Rand";

        static void Main(string[] args)
        {
            filePathX = filePathO = System.IO.Directory.GetCurrentDirectory().Split("bin\\Debug\\netcoreapp3.0")[0];
            filePathX += @"Txt\IaBrainX.txt";
            filePathO += @"Txt\IaBrainO.txt";

            while (gamesPlayed < 50000)
            {
                InitializeBoard();
                InitializaVariables();

                while (!gameWon)
                {
                    DrawBoard();
                    if (playerTurn)
                    {
                        switch (opponent)
                        {
                            case "Player":
                                PlayerMove();
                                break;
                            case "Rand":
                                RandMove('X');
                                break;
                            case "IA":
                                IAMove('X');
                                break;
                        }
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
            DrawBoard(true);
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

        static void DrawBoard(bool showBoard = false)
        {
            //showBoard = true;
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
                    float[] percentages = new float[9] { 0.111f, 0.111f, 0.111f, 0.111f, 0.111f, 0.111f, 0.111f, 0.111f, 0.111f };

                    iaBrainDicX.Add(boardLocal, percentages);

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
                    float[] percentages = new float[9] { 0.111f, 0.111f, 0.111f, 0.111f, 0.111f, 0.111f, 0.111f, 0.111f, 0.111f };

                    iaBrainDicO.Add(boardLocal, percentages);

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
                DrawBoard();
                return true;
            }
            if (board[1, 0] == board[1, 1] && board[1, 1] == board[1, 2])
            {
                winnerPlayer = board[1, 0];
                DrawBoard();
                return true;
            }
            if (board[2, 0] == board[0, 1] && board[2, 1] == board[2, 2])
            {
                winnerPlayer = board[2, 0];
                DrawBoard();
                return true;
            }
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            if (board[0, 0] == board[1, 0] && board[1, 0] == board[2, 0])
            {
                winnerPlayer = board[0, 0];
                DrawBoard();
                return true;
            }
            if (board[0, 1] == board[1, 1] && board[1, 1] == board[2, 1])
            {
                winnerPlayer = board[0, 1];
                DrawBoard();
                return true;
            }
            if (board[0, 2] == board[1, 2] && board[1, 2] == board[2, 2])
            {
                winnerPlayer = board[0, 2];
                DrawBoard();
                return true;
            }
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                winnerPlayer = board[0, 0];
                DrawBoard();
                return true;
            }
            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                winnerPlayer = board[0, 2];
                DrawBoard();
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
            DrawBoard();
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
                iaXLosses++;
                foreach (Plays p in playsX)
                {
                    IAChange(p.Value, false, 'X', p.Key);
                    IAChange(p.Value, false, 'X', p.Key);
                    IAChange(p.Value, false, 'X', p.Key);
                    IAChange(p.Value, false, 'X', p.Key);
                    IAChange(p.Value, false, 'X', p.Key);
                }

                foreach (Plays p in playsO)
                {
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
                    IAChange(p.Value, true, 'X', p.Key);
                }

                foreach (Plays p in playsO)
                {
                    IAChange(p.Value, true, 'O', p.Key);
                }
            }

            if (opponent == "IA")
            {
                WriteTxtX();
            }

            WriteTxtO();
        }

        static void IAChange(string s, bool rewarding, char turn, string boardStatus = null)
        {
            if (boardStatus == null)
            {
                boardStatus = TransformBoardToString();
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
            //
            float valueToChange;
            if (rewarding)
            {
                valueToChange = (100 + punishment) / 100.0f;
            }
            else
            {
                valueToChange = (100 - punishment) / 100.0f;
            }
            //
            iaBrainDic[boardStatus][valueToBeChanged] = iaBrainDic[boardStatus][valueToBeChanged] * valueToChange;

            PercentageFix(iaBrainDic, boardStatus);
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
                newValue = Convert.ToSingle(Convert.ToInt32(newValue * 1000)) / 1000.0f;
                if (newValue >= 1.0f)
                {
                    iaBrainDic[boardStatus][i] = 0.992f;
                }
                else if (newValue <= 0)
                {
                    iaBrainDic[boardStatus][i] = 0.001f;
                }
                else
                {
                    iaBrainDic[boardStatus][i] = newValue;
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
                sw.WriteLine(TotalgamesPlayedX + 1);
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
