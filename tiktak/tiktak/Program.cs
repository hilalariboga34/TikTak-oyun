using System;

namespace TicTacToe
{
    class Program
    {
        static char[,] board = {
            { '1', '2', '3' },
            { '4', '5', '6' },
            { '7', '8', '9' }
        };

        static char currentPlayer = 'X';

        static void Main(string[] args)
        {
            int turn = 0;
            bool gameRunning = true;

            while (gameRunning)
            {
                Console.Clear();
                PrintBoard();
                Console.WriteLine($"Oyuncu {currentPlayer}'in sırası. Lütfen bir numara seçin:");

                string input = Console.ReadLine();
                if (int.TryParse(input, out int move) && move >= 1 && move <= 9)
                {
                    if (PlaceMove(move))
                    {
                        turn++;
                        if (CheckWin())
                        {
                            Console.Clear();
                            PrintBoard();
                            Console.WriteLine($"Oyuncu {currentPlayer} kazandı!");
                            gameRunning = false;
                        }
                        else if (turn == 9)
                        {
                            Console.Clear();
                            PrintBoard();
                            Console.WriteLine("Berabere!");
                            gameRunning = false;
                        }
                        else
                        {
                            SwitchPlayer();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz hamle, lütfen başka bir numara seçin.");
                    }
                }
                else
                {
                    Console.WriteLine("Geçersiz giriş, lütfen 1 ile 9 arasında bir numara girin.");
                }
            }
            Console.WriteLine("Oyun bitti! Çıkmak için bir tuşa basın...");
            Console.ReadKey();
        }

        static void PrintBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(" {0} | {1} | {2} ", board[i, 0], board[i, 1], board[i, 2]);
                if (i < 2)
                    Console.WriteLine("---|---|---");
            }
        }

        static bool PlaceMove(int move)
        {
            int row = (move - 1) / 3;
            int col = (move - 1) % 3;

            if (board[row, col] != 'X' && board[row, col] != 'O')
            {
                board[row, col] = currentPlayer;
                return true;
            }
            return false;
        }

        static void SwitchPlayer()
        {
            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
        }

        static bool CheckWin()
        {
            // Satırlar ve sütunlar için kontrol
            for (int i = 0; i < 3; i++)
            {
                if ((board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer) ||
                    (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer))
                {
                    return true;
                }
            }

            // Çaprazlar için kontrol
            if ((board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer) ||
                (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer))
            {
                return true;
            }

            return false;
        }
    }
}
