using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TicTacToe
{
    static class IaMove
    {
        static string filePathX;
        static string filePathO;
        static Dictionary<string, float[]> iaBrainDicX;
        static Dictionary<string, float[]> iaBrainDicO;
        static Dictionary<string, int> numberOfSameMovesX;
        static Dictionary<string, int> numberOfSameMovesO;
        static List<Plays> playsX;
        static List<Plays> playsO;
        static int punishmentOrRewardPercent = 15;

        static int TotalgamesPlayedX;
        static int TotalgamesPlayedO;

        static public KeyValuePair<int, int> IAMove(char c, char[,] board)
        {
            if (filePathX == null)
            {
                InitializaVariablesForAllGames();
            }
            string boardLocal = TransformBoardToString(board);
            string move = DetermineMove(boardLocal, c);

            switch (move)
            {
                case "1":
                    if (board[0, 0] == '1')
                    {
                        addPlayToIa(boardLocal, move, c);

                        return new KeyValuePair<int, int>(0, 0);
                    }
                    break;
                case "2":
                    if (board[0, 1] == '2')
                    {
                        addPlayToIa(boardLocal, move, c);

                        return new KeyValuePair<int, int>(0,1);
                    }
                    break;
                case "3":
                    if (board[0, 2] == '3')
                    {
                        addPlayToIa(boardLocal, move, c);
                        return new KeyValuePair<int, int>(0,2);
                    }
                    break;
                case "4":
                    if (board[1, 0] == '4')
                    {
                        addPlayToIa(boardLocal, move, c);

                        return new KeyValuePair<int, int>(1,0);
                    }
                    break;
                case "5":
                    if (board[1, 1] == '5')
                    {
                        addPlayToIa(boardLocal, move, c);

                        return new KeyValuePair<int, int>(1,1);
                    }
                    break;
                case "6":
                    if (board[1, 2] == '6')
                    {
                        addPlayToIa(boardLocal, move, c);

                        return new KeyValuePair<int, int>(1,2);
                    }
                    break;
                case "7":
                    if (board[2, 0] == '7')
                    {
                        addPlayToIa(boardLocal, move, c);

                        return new KeyValuePair<int, int>(2,0);
                    }
                    break;
                case "8":
                    if (board[2, 1] == '8')
                    {
                        addPlayToIa(boardLocal, move, c);

                        return new KeyValuePair<int, int>(2,1);
                    }
                    break;
                case "9":
                    if (board[2, 2] == '9')
                    {
                        addPlayToIa(boardLocal, move, c);

                        return new KeyValuePair<int, int>(2,2);
                    }
                    break;
                default:
                    throw new Exception("Logical error!");
            }

            IAChange(move, false, c, boardLocal);
            return IAMove(c, board);
        }

        public static void InitializaVariablesForAllGames()
        {
            filePathX = filePathO = Directory.GetCurrentDirectory().Split("bin\\Debug\\netcoreapp3.0")[0];
            filePathX += @"Txt\IaBrainX.txt";
            filePathO += @"Txt\IaBrainO.txt";

            iaBrainDicX = new Dictionary<string, float[]>();
            iaBrainDicO = new Dictionary<string, float[]>();
            numberOfSameMovesX = new Dictionary<string, int>();
            numberOfSameMovesO = new Dictionary<string, int>();

            StartNewGame();

            ReadTxtX();
            ReadTxtO();
        }

        static void StartNewGame()
        {
            playsO = new List<Plays>();
            playsX = new List<Plays>();
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

        public static void IAChange(string s, bool rewarding, char turn, string boardLocal)
        {
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
            int biggest = 0;


            for (int i = 1; i < values.Count; i++)
            {
                if (values[i] > values[biggest])
                {
                    biggest = i;
                }
            }

            //convert 0...8(array) to 1...9 (board)
            return biggest + 1;
        }

        static public void addPlayToIa(string boardLocal, string move, char turn)
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


        static public void IAFinalEachGame(char winnerPlayer, string gameModeO, string gameModeX)
        {
            if (winnerPlayer == 'X')
            {
                if (gameModeO == "IA" || gameModeO == "PLAYER" || true)
                {
                    foreach (Plays p in playsX)
                    {
                        //IAChange(p.Value, true, 'X', p.Key);
                    }
                }

                foreach (Plays p in playsO)
                {
                    IAChange(p.Value, false, 'O', p.Key);
                }
            }
            else if (winnerPlayer == 'O')
            {
                foreach (Plays p in playsX)
                {
                    IAChange(p.Value, false, 'X', p.Key);
                }

                if (gameModeX == "IA" || gameModeX == "PLAYER" || true)
                {
                    foreach (Plays p in playsO)
                    {
                        //IAChange(p.Value, true, 'O', p.Key);
                    }
                }
            }
            else
            {
                if (gameModeO == "PLAYER" /*|| gameModeO == "RAMDOM"*/)
                {
                    foreach (Plays p in playsX)
                    {
                        IAChange(p.Value, true, 'X', p.Key);
                    }
                }

                if (gameModeX == "PLAYER" /*|| gameModeO == "RAMDOM"*/)
                {
                    foreach (Plays p in playsO)
                    {
                        IAChange(p.Value, true, 'O', p.Key);
                    }
                }
            }
            StartNewGame();
        }

        #region Utiletary
        public static string TransformBoardToString(char[,] boardStatus)
        {
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
            }
        }

        static public void WriteTxtX(int gamesPlayed)
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

        static public void WriteTxtO(int gamesPlayed)
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
