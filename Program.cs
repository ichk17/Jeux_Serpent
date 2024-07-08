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

        static void InitGame()
        {
            snake.Clear();
            snake.Add(new Point(width / 2, height / 2));
            GenerateFood();
        }

        static void DrawBoard()
        {
            Console.Clear();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (snake.Any(p => p.X == x && p.Y == y))
                    {
                        Console.Write("O");
                    }
                    else if (food.X == x && food.Y == y)
                    {
                        Console.Write("X");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("Score: " + score);
        }

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

        static void Update()
        {
            Point head = snake[0];
            Point newHead = new Point();

            switch (currentDirection)
            {
                case Direction.Up:
                    newHead = new Point(head.X, head.Y - 1);
                    break;
                case Direction.Down:
                    newHead = new Point(head.X, head.Y + 1);
                    break;
                case Direction.Left:
                    newHead = new Point(head.X - 1, head.Y);
                    break;
                case Direction.Right:
                    newHead = new Point(head.X + 1, head.Y);
                    break;
            }

            if (newHead.X < 0 || newHead.Y < 0 || newHead.X >= width || newHead.Y >= height || snake.Any(p => p.X == newHead.X && p.Y == newHead.Y))
            {
                gameOver = true;
                return;
            }

            snake.Insert(0, newHead);

            if (newHead.X == food.X && newHead.Y == food.Y)
            {
                score++;
                GenerateFood();
            }
            else
            {
                snake.RemoveAt(snake.Count - 1);
            }
        }

        static void GenerateFood()
        {
            do
            {
                food = new Point(rand.Next(width), rand.Next(height));
            }
            while (snake.Any(p => p.X == food.X && p.Y == food.Y));
        }
    }
}