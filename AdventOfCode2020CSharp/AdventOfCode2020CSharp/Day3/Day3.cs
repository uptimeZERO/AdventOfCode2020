using System;

namespace AdventOfCode2020CSharp.Day3
{
    public static class Day3
    {
        public static int GetTreeCountForSequence(int rightSteps, int down = 1)
        {
            var input = ProgramInput.GetDayThreeInput();
            var treeCount = 0;
            var position = 0;
            for (var i = 0; i < input.Count; i += down)
            {
                var tiles = input[i].ToCharArray();
                if (tiles[position] == '#')
                {
                    treeCount++;
                    tiles[position] = 'X';
                }
                else
                {
                    tiles[position] = 'O';
                }

                Console.WriteLine(new string(tiles));

                position += rightSteps;
                if (position > (tiles.Length - 1))
                {
                    position -= tiles.Length;
                }
            }

            return treeCount;
        }

        public static int GetPartOneAnswer()
        {
            return GetTreeCountForSequence(3);
        }

        public static int GetPartTwoAnswer()
        {
            return GetTreeCountForSequence(1) *
                   GetTreeCountForSequence(3) *
                   GetTreeCountForSequence(5) *
                   GetTreeCountForSequence(7) *
                   GetTreeCountForSequence(1, 2);
        }
    }
}
