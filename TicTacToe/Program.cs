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
        static char winnerPlayer;

        static int iaXLosses = 0;
        static int iaOLosses = 0;
        static int ties = 0;

        static int gamesPlayed = 0;
        static int maxGames = 100 * 1000 * 1000;

        static string gameModeX = "RANDOM";//PLAYER, RANDOM, IA
        static string gameModeO = "RANDOM";//PLAYER, RANDOM, IA

        static void Main(string[] args)
        {
            while (gamesPlayed < maxGames)
            {
                InitializeBoard();
                InitializaVariablesForEachGame();

                PlayGame();

                FinalEachGame();
                gamesPlayed++;
            }

            IaMove.WriteTxtX(gamesPlayed);
            IaMove.WriteTxtO(gamesPlayed);

            Console.Beep();

            Console.WriteLine("Player 'X':" + gameModeX);
            Console.WriteLine("Games Ia 'X' Lost:" + iaXLosses + " - " + (int)((iaXLosses / (float)gamesPlayed) * 100.0f) + " %\n");

            Console.WriteLine("Player 'O':" + gameModeO);
            Console.WriteLine("Games Ia 'O' Lost:" + iaOLosses + " - " + (int)((iaOLosses / (float)gamesPlayed) * 100.0f) + " %\n");

            Console.WriteLine("Ties:" + ties + " - " + (int)((ties / (float)gamesPlayed) * 100.0f) + "%\n");

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

        static void InitializaVariablesForEachGame()
        {
            gameWon = false;
            playerTurn = true;
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
                char activePlayer;
                KeyValuePair<int, int> kvp = new KeyValuePair<int, int>(-1, -1);
                if (playerTurn)
                {
                    activePlayer = 'X';
                    switch (gameModeX)
                    {
                        case "PLAYER":
                            kvp = HumanMove.PlayerMove(activePlayer, board);
                            if (kvp.Key == -1)
                            {
                                errorPlayer = true;
                            }
                            else
                            {
                                board[kvp.Key, kvp.Value] = activePlayer;
                            }
                            break;
                        case "RANDOM":
                            kvp = RandomIAMove.RandMove(activePlayer, board);
                            if (kvp.Key == -1)
                            {
                                errorPlayer = true;
                            }
                            else
                            {
                                board[kvp.Key, kvp.Value] = activePlayer;
                            }
                            break;
                        case "IA":
                            kvp = IaMove.IAMove(activePlayer, board);
                            if (kvp.Key == -1)
                            {
                                errorPlayer = true;
                            }
                            else
                            {
                                board[kvp.Key, kvp.Value] = activePlayer;
                            }
                            break;
                    }
                }
                else
                {
                    activePlayer = 'O';
                    switch (gameModeO)
                    {
                        case "PLAYER":
                            kvp = HumanMove.PlayerMove(activePlayer, board);
                            if (kvp.Key == -1)
                            {
                                errorPlayer = true;
                            }
                            else
                            {
                                board[kvp.Key, kvp.Value] = activePlayer;
                            }
                            break;
                        case "RANDOM":
                            kvp = RandomIAMove.RandMove(activePlayer, board);
                            if (kvp.Key == -1)
                            {
                                errorPlayer = true;
                            }
                            else
                            {
                                board[kvp.Key, kvp.Value] = activePlayer;
                            }
                            break;
                        case "IA":
                            if (kvp.Key == -1)
                            {
                                errorPlayer = true;
                            }
                            else
                            {
                                board[kvp.Key, kvp.Value] = activePlayer;
                            }
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
        //static void RandMove(char c)
        //{
        //    string boardLocal = TransformBoardToString();
        //    string move = new Random().Next(1, 10).ToString();
        //    switch (move)
        //    {
        //        case "1":
        //            if (board[0, 0] == '1')
        //            {
        //                //addPlayToIa(boardLocal, move, c);

        //                board[0, 0] = c;
        //            }
        //            else
        //            {
        //                IAChange(move, false, c);
        //                RandMove(c);
        //            }
        //            break;
        //        case "2":
        //            if (board[0, 1] == '2')
        //            {
        //                //addPlayToIa(boardLocal, move, c);

        //                board[0, 1] = c;
        //            }
        //            else
        //            {
        //                IAChange(move, false, c);
        //                RandMove(c);
        //            }
        //            break;
        //        case "3":
        //            if (board[0, 2] == '3')
        //            {
        //                //addPlayToIa(boardLocal, move, c);

        //                board[0, 2] = c;
        //            }
        //            else
        //            {
        //                IAChange(move, false, c);
        //                RandMove(c);
        //            }
        //            break;
        //        case "4":
        //            if (board[1, 0] == '4')
        //            {
        //                //addPlayToIa(boardLocal, move, c);

        //                board[1, 0] = c;
        //            }
        //            else
        //            {
        //                IAChange(move, false, c);
        //                RandMove(c);
        //            }
        //            break;
        //        case "5":
        //            if (board[1, 1] == '5')
        //            {
        //                //addPlayToIa(boardLocal, move, c);

        //                board[1, 1] = c;
        //            }
        //            else
        //            {
        //                IAChange(move, false, c);
        //                RandMove(c);
        //            }
        //            break;
        //        case "6":
        //            if (board[1, 2] == '6')
        //            {
        //                //addPlayToIa(boardLocal, move, c);

        //                board[1, 2] = c;
        //            }
        //            else
        //            {
        //                IAChange(move, false, c);
        //                RandMove(c);
        //            }
        //            break;
        //        case "7":
        //            if (board[2, 0] == '7')
        //            {
        //                //addPlayToIa(boardLocal, move, c);

        //                board[2, 0] = c;
        //            }
        //            else
        //            {
        //                IAChange(move, false, c);
        //                RandMove(c);
        //            }
        //            break;
        //        case "8":
        //            if (board[2, 1] == '8')
        //            {
        //                //addPlayToIa(boardLocal, move, c);

        //                board[2, 1] = c;
        //            }
        //            else
        //            {
        //                IAChange(move, false, c);
        //                RandMove(c);
        //            }
        //            break;
        //        case "9":
        //            if (board[2, 2] == '9')
        //            {
        //                //addPlayToIa(boardLocal, move, c);

        //                board[2, 2] = c;
        //            }
        //            else
        //            {
        //                IAChange(move, false, c);
        //                RandMove(c);
        //            }
        //            break;
        //        default:
        //            RandMove(c);
        //            break;
        //    }
        //}

        //static void IAMove(char c)
        //{
        //    string boardLocal = TransformBoardToString();
        //    string move = DetermineMove(boardLocal, c);

        //    switch (move)
        //    {
        //        case "1":
        //            if (board[0, 0] == '1')
        //            {
        //                addPlayToIa(boardLocal, move, c);

        //                board[0, 0] = c;
        //            }
        //            else
        //            {
        //                IAChange(move, false, c);
        //                IAMove(c);
        //            }
        //            break;
        //        case "2":
        //            if (board[0, 1] == '2')
        //            {
        //                addPlayToIa(boardLocal, move, c);

        //                board[0, 1] = c;
        //            }
        //            else
        //            {
        //                IAChange(move, false, c);
        //                IAMove(c);
        //            }
        //            break;
        //        case "3":
        //            if (board[0, 2] == '3')
        //            {
        //                addPlayToIa(boardLocal, move, c);

        //                board[0, 2] = c;
        //            }
        //            else
        //            {
        //                IAChange(move, false, c);
        //                IAMove(c);
        //            }
        //            break;
        //        case "4":
        //            if (board[1, 0] == '4')
        //            {
        //                addPlayToIa(boardLocal, move, c);

        //                board[1, 0] = c;
        //            }
        //            else
        //            {
        //                IAChange(move, false, c);
        //                IAMove(c);
        //            }
        //            break;
        //        case "5":
        //            if (board[1, 1] == '5')
        //            {
        //                addPlayToIa(boardLocal, move, c);

        //                board[1, 1] = c;
        //            }
        //            else
        //            {
        //                IAChange(move, false, c);
        //                IAMove(c);
        //            }
        //            break;
        //        case "6":
        //            if (board[1, 2] == '6')
        //            {
        //                addPlayToIa(boardLocal, move, c);

        //                board[1, 2] = c;
        //            }
        //            else
        //            {
        //                IAChange(move, false, c);
        //                IAMove(c);
        //            }
        //            break;
        //        case "7":
        //            if (board[2, 0] == '7')
        //            {
        //                addPlayToIa(boardLocal, move, c);

        //                board[2, 0] = c;
        //            }
        //            else
        //            {
        //                IAChange(move, false, c);
        //                IAMove(c);
        //            }
        //            break;
        //        case "8":
        //            if (board[2, 1] == '8')
        //            {
        //                addPlayToIa(boardLocal, move, c);

        //                board[2, 1] = c;
        //            }
        //            else
        //            {
        //                IAChange(move, false, c);
        //                IAMove(c);
        //            }
        //            break;
        //        case "9":
        //            if (board[2, 2] == '9')
        //            {
        //                addPlayToIa(boardLocal, move, c);

        //                board[2, 2] = c;
        //            }
        //            else
        //            {
        //                IAChange(move, false, c);
        //                IAMove(c);
        //            }
        //            break;
        //        default:
        //            Console.WriteLine("Logical error!");
        //            break;
        //    }
        //}

        //static string DetermineMove(string boardLocal, char turn)
        //{
        //    List<float> possibleMoves = new List<float>();

        //    Dictionary<string, float[]> iaBrainDic;
        //    if (turn == 'X')
        //    {
        //        iaBrainDic = iaBrainDicX;
        //    }
        //    else
        //    {
        //        iaBrainDic = iaBrainDicO;
        //    }

        //    if (iaBrainDic.ContainsKey(boardLocal))
        //    {
        //        for (int i = 0; i < iaBrainDic[boardLocal].Length; i++)
        //        {
        //            char[] boardChar = boardLocal.ToCharArray();
        //            //the +48 is to converto to asc table
        //            if (boardChar[i] == Convert.ToChar((i + 1) + 48))
        //            {
        //                possibleMoves.Add(iaBrainDic[boardLocal][i]);
        //            }
        //            else
        //            {
        //                possibleMoves.Add(float.MinValue);
        //            }
        //        }

        //        return returnBiggest(possibleMoves).ToString();
        //    }
        //    else
        //    {
        //        float[] percentages = new float[9] { 0.111f, 0.111f, 0.111f, 0.111f, 0.111f, 0.111f, 0.111f, 0.111f, 0.111f };

        //        iaBrainDic.Add(boardLocal, percentages);

        //        return "5";
        //    }
        //}

        //static int returnBiggest(List<float> values)
        //{
        //    if (values.Count == 1)
        //    {
        //        return 0;
        //    }
        //    int smallest = 0;


        //    for (int i = 1; i < values.Count; i++)
        //    {
        //        if (values[i] > values[i - 1])
        //        {
        //            smallest = i;
        //        }
        //    }

        //    //convert 1...9 (board) to 0...8(array)
        //    return smallest + 1;
        //}

        //static void addPlayToIa(string boardLocal, string move, char turn)
        //{
        //    Plays p = new Plays(boardLocal, move);
        //    if (turn == 'X')
        //    {
        //        playsX.Add(p);
        //        addCountSameMovesX(boardLocal);
        //    }
        //    else
        //    {
        //        playsO.Add(p);
        //        addCountSameMovesO(boardLocal);
        //    }

        //}
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
        static void FinalEachGame()
        {
            IaMove.IAFinalEachGame(winnerPlayer, gameModeO, gameModeX);
            if (winnerPlayer == 'X')
            {
                iaOLosses++;
            }
            else if (winnerPlayer == 'O')
            {
                iaXLosses++;
            }
            else
            {
                ties++;
            }
        }
        #endregion
    }
}
