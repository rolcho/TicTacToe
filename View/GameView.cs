namespace TicTacToe.View
{
    class GameView
    {
        public void DrawBoard(string[,] board)
        {
            Console.Clear();

            var topLine = "_";
            for (int i = 0; i < board.GetLength(0); i++)
            {
                var row1 = ("|");
                var row2 = ("|");
                var row3 = ("|");

                for (int j = 0; j < board.GetLength(1); j++)
                {
                    var cell = board[i, j];
                    if (i == 0)
                    {
                        topLine += "______";
                    }
                    row1 += "     |";
                    row2 += $"  {cell}  |";
                    row3 += "_____|";
                }

                if (i == 0)
                {
                    Console.WriteLine(topLine);
                }

                Console.WriteLine(row1);
                Console.WriteLine(row2);
                Console.WriteLine(row3);
            }
            Console.WriteLine();
        }

        public int GetPlayerInput(string currentPlayer)
        {
            do
            {
                DisplayMessage($"It is {currentPlayer}'s turn. Enter the cell number:");
                string input = Console.ReadLine()!;

                if (!int.TryParse(input, out int selectedCell))
                {
                    DisplayMessage("Please enter a valid number.");
                }
                else if (selectedCell < 1 || selectedCell > 9)
                {
                    Console.WriteLine("Please enter a number between 1 and 9.");
                }
                else
                {
                    return selectedCell;
                }
            } while (true);
        }

        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
