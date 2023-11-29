namespace TicTacToe.Model
{
    class GameModel
    {
        private string[,] board;
        private string currentPlayer;
        private int counter;
        private readonly int boardSize;

        public GameModel()
        {
            boardSize = 3;
            board = new string[boardSize, boardSize];
            currentPlayer = "O";
            counter = 0;
        }

        public void InitBoard()
        {
            int cellNumber = 1;

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++, cellNumber++)
                {
                    board[i, j] = cellNumber.ToString();
                }
            }
        }

        public string[,] GetBoard()
        {
            return board;
        }

        public string GetCurrentPlayer()
        {
            return currentPlayer;
        }

        public void ChangeCurrentPlayer()
        {
            currentPlayer = (currentPlayer == "X") ? "O" : "X";
        }

        public bool IsValidMove(int selectedCell)
        {
            int boardSize = board.GetLength(0);
            int row = (selectedCell - 1) / boardSize;
            int col = (selectedCell - 1) % boardSize;

            if (int.TryParse(board[row, col], out _))
            {
                board[row, col] = currentPlayer;
                counter++;
                return true;
            }

            return false;
        }

        public bool IsGameOver()
        {
            return IsWinner() || counter == boardSize * boardSize;
        }

        public string? GetWinner()
        {
            if (IsWinner())
            {
                return currentPlayer;
            }
            else
            {
                return null;
            }
        }

        private bool IsWinner()
        {
            for (int i = 0; i < boardSize; i++)
            {
                if (
                    board[i, 0] == currentPlayer
                    && board[i, 1] == currentPlayer
                    && board[i, 2] == currentPlayer
                )
                {
                    return true;
                }
            }

            for (int j = 0; j < boardSize; j++)
            {
                if (
                    board[0, j] == currentPlayer
                    && board[1, j] == currentPlayer
                    && board[2, j] == currentPlayer
                )
                {
                    return true;
                }
            }

            if (
                board[0, 0] == currentPlayer
                && board[1, 1] == currentPlayer
                && board[2, 2] == currentPlayer
            )
            {
                return true;
            }

            if (
                board[0, 2] == currentPlayer
                && board[1, 1] == currentPlayer
                && board[2, 0] == currentPlayer
            )
            {
                return true;
            }

            return false;
        }
    }
}
