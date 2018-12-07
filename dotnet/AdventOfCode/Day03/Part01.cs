using System;
using System.IO;
using System.Linq;

namespace AdventOfCode.Day03
{
    public class Part01
    {
        public static void Run()
        {
            var lines = File.ReadAllLines("./Day03/input.txt");
            var rectangles = lines.Select(Rectangle.Create).ToList();
            var gamefield = new Gamefield();
            foreach (var rectangle in rectangles)
                gamefield.AddToArea(rectangle);
            var result = gamefield.GetOverlappingCellCount();
            Console.WriteLine(result);
        }

        class Rectangle
        {
            public string Id { get; }
            public int X { get; }
            public int Y { get; }
            public int Width { get; }
            public int Height { get; }

            private Rectangle(string id, int x, int y, int width, int height)
            {
                Id = id;
                X = x;
                Y = y;
                Width = width;
                Height = height;
            }

            public static Rectangle Create(string input) // #1 @ 808,550: 12x22
            {
                var split = input.Replace(':', '\0').Split(' ');
                var xy = split[2].Split(',', ':').Select(int.Parse).ToList();
                var widthHeight = split[3].Split('x').Select(int.Parse).ToList();
                return new Rectangle(split[0], xy[0], xy[1], widthHeight[0], widthHeight[1]);
            }
        }

        class Gamefield
        {
            private int[][] Area { get; } = new int[10_000][];
            
            public void AddToArea(Rectangle rectangle)
            {
                for (var i = rectangle.X; i < rectangle.X + rectangle.Width; i++)
                for (var j = rectangle.Y; j < rectangle.Y + rectangle.Height; j++)
                {
                    if (Area[i] == null)
                        Area[i] = new int[10_000];
                    Area[i][j]++;
                }
            }

            public int GetOverlappingCellCount() => Area
                .Where(x => x != null)
                .SelectMany(ints => ints)
                .Count(num => num > 1);
        }
    }
}