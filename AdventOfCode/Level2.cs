using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public class Level2
    {
        public void PrintResult()
        {
            var input = ReadInput();
            var validPasswordCount = 0;
            foreach (var passwordInput in input)
            {
                if(IsValidPasswordExtended(passwordInput))
                {
                    validPasswordCount++;
                }
            }

            Console.WriteLine("Valid passwords {0}", validPasswordCount);
        }

        private bool IsValidPassword(Level2Input passwordInput)
        {
            var count = passwordInput.password.Count(character => character.Equals(passwordInput.passwordChar));

            return count >= passwordInput.lowerRange && count <= passwordInput.higherRange;
        }

        //Used for level 2 of that day
        private bool IsValidPasswordExtended(Level2Input passwordInput)
        {
            //not zero index because we have a space at pos 0 and i am too lazy to fix 
            bool lowcorrect = passwordInput.password[passwordInput.lowerRange].Equals(passwordInput.passwordChar);
            bool highcorrect = passwordInput.password[passwordInput.higherRange].Equals(passwordInput.passwordChar);
            if (highcorrect || lowcorrect)
            {
                return highcorrect != lowcorrect;
            }

            return false;
        }


        private IEnumerable<Level2Input> ReadInput()
        {
            var input = File.ReadAllLines("Input/level2.txt");

            var parsedInput = new List<Level2Input>();

            foreach (var line in input)
            {
                var split = line.Split(':');
                var splitedSplit = split[0].Split(' ');
                var range = splitedSplit[0];
                var rangeSplit = range.Split('-');

                parsedInput.Add(new Level2Input()
                {
                    lowerRange = int.Parse(rangeSplit[0]),
                    higherRange = int.Parse(rangeSplit[1]),
                    passwordChar = splitedSplit[1][0],
                    password = split[1]
                });
            }

            return parsedInput;
        }
    }

    public class Level2Input
    {
        public char passwordChar;
        public int lowerRange;
        public int higherRange;
        public string password;
    }
}
