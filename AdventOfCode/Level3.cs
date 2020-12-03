using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode
{
    public class Level3
    {
        public void PrintResult()
        {
            Console.WriteLine("Puzzle 1 result: " + Puzzel1());
            Console.WriteLine("Puzzle 2 result: " + Puzzel2());
        }

        private string Puzzel1()
        {
            bool[,] trees = ReadInput();
            var foundTrees = FindTrees(trees, 3, 1);

            return foundTrees.ToString();
        }

        private string Puzzel2()
        {
            bool[,] trees = ReadInput();
            double foundTrees = FindTrees(trees,1,1);
            foundTrees *= FindTrees(trees, 3, 1);
            foundTrees *= FindTrees(trees, 5, 1);
            foundTrees *= FindTrees(trees, 7, 1);
            foundTrees *= FindTrees(trees, 1, 2);

            return foundTrees.ToString();
        }

        private static int FindTrees(bool[,] trees,int right, int down)
        {
            int horizontalPos = 0;
            int maxHorizontalPos = trees.GetUpperBound(1) + 1;
            int foundTrees = 0;

            //for each row
            for (int i = down; i <= trees.GetUpperBound(0); i += down)
            {
                horizontalPos += right;
                horizontalPos %= maxHorizontalPos;

                if (trees[i, horizontalPos])
                {
                    foundTrees++;
                }
            }

            return foundTrees;
        }

        private bool[,] ReadInput()
        {
            var input = File.ReadAllLines("Input/level3.txt");
            bool[,] treeMap = new bool[input.Length, input[0].Length];

            for(int i = 0; i < input.Length; i++)
            {
                var line = input[i];
                for(int pos = 0; pos < line.Length;pos++)
                {
                    //set true for trees
                    treeMap[i, pos] = line[pos].Equals('#');
                }
            }

            return treeMap;
        }
    }
}
