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
    }
}