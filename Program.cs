﻿using TicTacToe.Controller;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            GameController gameController = new GameController();
            gameController.StartGame();
        }
    }
}
