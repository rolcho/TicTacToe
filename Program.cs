using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Runtime.InteropServices;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            int boardSize = 3;
            string player = "O";
            int counter = 0;

            if (boardSize == 0)
            {
                return;
            }

            string[,] board = CreateBoard(boardSize);

            do
            {
                DrawBoard(board);
                player = ChangePlayer(player);
                board = SetSelection(board, player);
            } while (!IsWinner(board) && ++counter < board.Length);

            DrawBoard(board);

            if (counter == board.Length)
            {
                Console.WriteLine("Tie game.");

            }
            else
            {
                Console.WriteLine($"The winner is: {player}");
            }
        }


        static string[,] SetSelection(string[,] board, string player)
        {
            var boardSize = board.GetLength(0);
            bool isInvalidValue;
            int row = -1, col = -1;

            do
            {

                Console.WriteLine($"It is {player}'s turn. Enter the cell number:");
                var cell = Console.ReadLine();

                if (!int.TryParse(cell, out int cellValue))
                {
                    Console.WriteLine($"Please enter a number between 1 and {board.Length}");
                    isInvalidValue = true;
                    continue;
                }

                if (cellValue < 1 || cellValue > board.Length)
                {
                    Console.WriteLine($"Please enter a number between 1 and {board.Length}");
                    isInvalidValue = true;
                    continue;
                }

                row = (cellValue - 1) / boardSize;
                col = (cellValue - 1) % boardSize;

                if (!int.TryParse(board[row, col], out _))
                {
                    Console.WriteLine($"{cellValue} is already taken by: {board[row, col]}");
                    isInvalidValue = true;
                    continue;
                }

                isInvalidValue = false;

            } while (isInvalidValue);


            board[row, col] = player;

            return board;
        }

        static string ChangePlayer(string playerChar)
        {
            return playerChar == "X" ? "O" : "X";
        }

        static string[,] CreateBoard(int size)
        {
            var board = new string[size, size];
            var counter = 1;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    board[i, j] = counter++.ToString();
                }
            }

            return board;
        }

        static void DrawBoard(string[,] board)
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

        static bool IsWinner(string[,] board)
        {
            {
                int size = board.GetLength(0);
                bool isDiagonal = true;
                bool isAntidiagonal = true;

                for (int i = 0; i < size; i++)
                {
                    bool isColumn = board[0, i] == board[1, i] && board[1, i] == board[2, i];
                    bool isRow = board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2];
                    bool isNotDiagonal = i > 0 && board[i, i] != board[i - 1, i - 1];
                    bool isNotAntiDiagonal = i > 0 && board[size - i - 1, size - i - 1] != board[size - i, size - i];

                    if (isColumn || isRow)
                    {
                        return true;
                    }

                    if (isNotDiagonal)
                    {
                        isDiagonal = false;
                    }

                    if (isNotAntiDiagonal)
                    {
                        isAntidiagonal = false;
                    }
                }

                if (isDiagonal || isAntidiagonal)
                {
                    return true;
                }

                return false;
            }
        }

    }
}
