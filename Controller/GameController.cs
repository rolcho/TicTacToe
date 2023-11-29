using TicTacToe.Model;
using TicTacToe.View;

namespace TicTacToe.Controller
{
    class GameController
    {
        private readonly GameModel gameModel;
        private readonly GameView gameView;
        private int selectedCell;
        private bool validInput;

        public GameController()
        {
            gameModel = new GameModel();
            gameView = new GameView();
            selectedCell = 0;
            validInput = true;
        }

        public void StartGame()
        {
            gameModel.InitBoard();

            while (!gameModel.IsGameOver())
            {
                gameModel.ChangeCurrentPlayer();
                string currentPlayer = gameModel.GetCurrentPlayer();
                do
                {
                    gameView.DrawBoard(gameModel.GetBoard());
                    if (!validInput)
                    {
                        gameView.DisplayMessage("Please enter a valid number.");
                    }
                    selectedCell = gameView.GetPlayerInput(currentPlayer);
                    validInput = gameModel.IsValidMove(selectedCell);
                } while (!validInput);
            }

            gameView.DrawBoard(gameModel.GetBoard());
            string winner = gameModel.GetWinner()!;

            if (winner == null)
            {
                gameView.DisplayMessage("Tie game.");
            }
            else
            {
                gameView.DisplayMessage($"The winner is: {winner}");
            }
        }
    }
}
