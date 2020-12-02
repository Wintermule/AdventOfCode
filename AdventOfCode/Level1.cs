using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public class Level1
    {
        private const int desiredResult = 2020;
        public void PrintResult()
        {
            IEnumerable<int> inputValues = ReadInput();


            foreach (var value in inputValues)
            {
                foreach (var secondValue in inputValues)
                {
                    foreach (var thirdValue in inputValues)
                    {
                        //what are the odds of the same value actually giving the result.. LOL
                        if (secondValue != value && secondValue != thirdValue
                            && thirdValue != value)
                        {
                            if (secondValue + value + thirdValue == desiredResult)
                            {
                                Console.WriteLine(value);
                                Console.WriteLine(secondValue);
                                Console.WriteLine(thirdValue);
                                Console.WriteLine(value * secondValue * thirdValue);
                            }
                        }
                    }
                }
            }
        }

        private IEnumerable<int> ReadInput()
        {
            var input = File.ReadAllLines("Input/level1.txt");

            return input.Select(int.Parse);
        }
    }
}
