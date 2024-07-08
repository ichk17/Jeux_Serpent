using System;
using System.Collections.Generic;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            InitGame();
            while (!gameOver)
            {
                DrawBoard();
                ProcessInput();
                Update();
                System.Threading.Thread.Sleep(delay);
            }
            Console.Clear();
            Console.WriteLine("Game Over! Your score: " + score);
        }

        static void InitGame() {}
        static void DrawBoard() {}
        static void ProcessInput() {}
        static void Update() {}

        static int width = 20;
        static int height = 20;
        static int score = 0;
        static bool gameOver = false;
        static int delay = 500; // Temps entre chaque tour (en millisecondes)

        static void ProcessInput()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (currentDirection != Direction.Down)
                            currentDirection = Direction.Up;
                        break;
                    case ConsoleKey.DownArrow:
                        if (currentDirection != Direction.Up)
                            currentDirection = Direction.Down;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (currentDirection != Direction.Right)
                            currentDirection = Direction.Left;
                        break;
                    case ConsoleKey.RightArrow:
                        if (currentDirection != Direction.Left)
                            currentDirection = Direction.Right;
                        break;
                }
            }
        }
    }
}