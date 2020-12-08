using System;

namespace AdventOfCode2020CSharp.Day1
{
    public static class Day1
    {
        public static int GetPartOneAnswer()
        {
            var input = ProgramInput.GetDayOneInput();
            var answer = default(int);
            var answerFound = false;
            for (var i = 0; i < input.Count; i++)
            {
                if (!answerFound)
                {
                    for (var j = 0; j < input.Count; j++)
                    {
                        if (input[i] + input[j] == 2020)
                        {
                            Console.WriteLine($"Index: {i} ({input[i]}) + Index: {j} ({input[j]}) = 2020");
                            answer = input[i] * input[j];
                            answerFound = true;
                            break;
                        }
                    }
                }
                else
                {
                    break;
                }
            }

            return answer;
        }

        public static int GetPartTwoAnswer()
        {
            var input = ProgramInput.GetDayOneInput();
            var answer = default(int);
            var answerFound = false;
            for (var i = 0; i < input.Count; i++)
            {
                if (!answerFound)
                {
                    for (var j = 0; j < input.Count; j++)
                    {
                        if (!answerFound)
                        {
                            for (var k = 0; k < input.Count; k++)
                            {
                                if (input[i] + input[j] + input[k] == 2020)
                                {
                                    Console.WriteLine($"Index: {i} ({input[i]}) + Index: {j} ({input[j]}) + Index: {k} ({input[k]}) = 2020");
                                    answer = input[i] * input[j] * input[k];
                                    answerFound = true;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    break;
                }
            }

            return answer;
        }
    }
}
