using System;

class Program
{
    static char[,] board = new char[3, 3];
    static char currentPlayer = 'X';

    static void Main()
    {
        while (true)
        {
            InitBoard();
            PlayGame();
            Console.WriteLine("Press Enter to restart the game...");
            Console.ReadLine();
        }
    }

    static void InitBoard()
    {
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                board[i, j] = ' ';
    }

    static void PlayGame()
    {
        int moves = 0;
        currentPlayer = 'X';

        while (true)
        {
            Console.Clear();
            PrintBoard();
            Console.WriteLine($"Player {(currentPlayer == 'X' ? "1 (X)" : "2 (O)")}, your move");

            int row = -1, col = -1;

            while (true)
            {
                Console.Write("Enter row number (0-2): ");
                if (!int.TryParse(Console.ReadLine(), out row) || row < 0 || row > 2)
                    continue;

                Console.Write("Enter column number (0-2): ");
                if (!int.TryParse(Console.ReadLine(), out col) || col < 0 || col > 2)
                    continue;

                if (board[row, col] == ' ')
                {
                    board[row, col] = currentPlayer;
                    moves++;
                    break;
                }
                else
                {
                    Console.WriteLine("Cell is taken. Try again.");
                }
            }

            if (CheckWin(currentPlayer))
            {
                Console.Clear();
                PrintBoard();
                Console.WriteLine($"Player {(currentPlayer == 'X' ? "1 (X)" : "2 (O)")} wins!");
                break;
            }

            if (moves == 9)
            {
                Console.Clear();
                PrintBoard();
                Console.WriteLine("Draw!");
                break;
            }

            currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
        }
    }

    static void PrintBoard()
    {
        Console.WriteLine("  0 1 2");
        for (int i = 0; i < 3; i++)
        {
            Console.Write(i + " ");
            for (int j = 0; j < 3; j++)
            {
                Console.Write(board[i, j]);
                if (j < 2) Console.Write("|");
            }
            Console.WriteLine();
            if (i < 2) Console.WriteLine("  -----");
        }
    }

    static bool CheckWin(char player)
    {
        // Rows and columns
        for (int i = 0; i < 3; i++)
            if ((board[i, 0] == player && board[i, 1] == player && board[i, 2] == player) ||
                (board[0, i] == player && board[1, i] == player && board[2, i] == player))
                return true;

        // Diagonals
        if ((board[0, 0] == player && board[1, 1] == player && board[2, 2] == player) ||
            (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player))
            return true;

        return false;
    }
}
