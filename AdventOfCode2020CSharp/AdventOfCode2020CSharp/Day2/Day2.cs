using System;
using System.Collections.Generic;

namespace AdventOfCode2020CSharp.Day2
{
    public static class Day2
    {
        public static List<int> GetOccurenceRule(this string str)
        {
            return new List<int>
            {
                Convert.ToInt32(str.Split('-')[0]),
                Convert.ToInt32(str.Split('-')[1].Split(' ')[0])
            };
        }

        public static char GetCharacterRule(this string str)
        {
            var split = str.Split(':')[0];
            return char.Parse(split.Substring((split.Length - 1), 1));
        }

        public static string GetPassword(this string str)
        {
            var split = str.Split(':')[1];
            return split.Substring(1, split.Length - 1);
        }

        public static int GetPartOneAnswer()
        {
            var input = ProgramInput.GetDayTwoInput();
            var validPasswords = 0;
            foreach (var passwordPolicyAndRule in input)
            {
                var occurenceRule = passwordPolicyAndRule.GetOccurenceRule();
                var characterRule = passwordPolicyAndRule.GetCharacterRule();
                var password = passwordPolicyAndRule.GetPassword();
                var occurenceCount = 0;

                foreach (var letter in password)
                {
                    if (letter == characterRule)
                    {
                        occurenceCount++;
                    }
                }

                if (occurenceCount >= occurenceRule[0] &&
                    occurenceCount <= occurenceRule[1])
                {
                    validPasswords++;
                    Console.WriteLine($"Valid:   {passwordPolicyAndRule}");
                }
                else
                {
                    Console.WriteLine($"Invalid: {passwordPolicyAndRule}");
                }
            }

            return validPasswords;
        }

        public static int GetPartTwoAnswer()
        {
            var input = ProgramInput.GetDayTwoInput();
            var validPasswords = 0;
            foreach (var passwordPolicyAndRule in input)
            {
                var occurenceRule = passwordPolicyAndRule.GetOccurenceRule();
                var characterRule = passwordPolicyAndRule.GetCharacterRule();
                var password = passwordPolicyAndRule.GetPassword().ToCharArray();

                if ((password[occurenceRule[0] - 1] == characterRule &&
                    password[occurenceRule[1] - 1] != characterRule) ||
                    (password[occurenceRule[0] - 1] != characterRule &&
                    password[occurenceRule[1] - 1] == characterRule))
                {
                    validPasswords++;
                    Console.WriteLine($"Valid:   {passwordPolicyAndRule}");
                }
                else
                {
                    Console.WriteLine($"Invalid: {passwordPolicyAndRule}");
                }
            }

            return validPasswords;
        }
    }
}
