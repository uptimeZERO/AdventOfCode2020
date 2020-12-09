using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020CSharp.Day4
{
    public static class Day4
    {
        public static bool HasValidFields(this Dictionary<string, string> dict)
        {
            var rulesToValidate = new List<bool>();
            foreach (var kv in dict)
            {
                switch (kv.Key)
                {
                    case "byr":
                    case "iyr":
                    case "eyr":
                    case "hgt":
                    case "hcl":
                    case "ecl":
                    case "pid":
                        rulesToValidate.Add(kv.Value != string.Empty);
                        break;
                }
            }

            return rulesToValidate.TrueForAll(x => x);
        }

        public static Dictionary<string, string> GetEmptyPassportDictionary()
        {
            var passportFields = GetAllPassportFields();
            var dict = new Dictionary<string, string>();
            foreach (var field in passportFields)
            {
                dict.Add(field, string.Empty);
            }

            return dict;
        }

        public static bool HasValidFieldData(this Dictionary<string, string> dict)
        {
            var rulesToValidate = new List<bool>();
            foreach (var kv in dict)
            {
                switch (kv.Key)
                {
                    case "byr":
                        rulesToValidate.Add(kv.Value.HasValidBirthYear());
                        Console.WriteLine($"{kv.Key}    : {kv.Value}: {kv.Value.HasValidBirthYear()}");
                        break;
                    case "iyr":
                        rulesToValidate.Add(kv.Value.HasValidIssueYear());
                        Console.WriteLine($"{kv.Key}    : {kv.Value}: {kv.Value.HasValidIssueYear()}");
                        break;
                    case "eyr":
                        rulesToValidate.Add(kv.Value.HasValidExpirationYear());
                        Console.WriteLine($"{kv.Key}    : {kv.Value}: {kv.Value.HasValidExpirationYear()}");
                        break;
                    case "hgt":
                        rulesToValidate.Add(kv.Value.HasValidHeight());
                        Console.WriteLine($"{kv.Key}    : {kv.Value}: {kv.Value.HasValidHeight()}");
                        break;
                    case "hcl":
                        rulesToValidate.Add(kv.Value.HasValidHairColour());
                        Console.WriteLine($"{kv.Key}    : {kv.Value}: {kv.Value.HasValidHairColour()}");
                        break;
                    case "ecl":
                        rulesToValidate.Add(kv.Value.HasValidEyeColour());
                        Console.WriteLine($"{kv.Key}    : {kv.Value}: {kv.Value.HasValidEyeColour()}");
                        break;
                    case "pid":
                        rulesToValidate.Add(kv.Value.HasValidPassportID());
                        Console.WriteLine($"{kv.Key}    : {kv.Value}: {kv.Value.HasValidPassportID()}");
                        break;
                }
            }

            Console.WriteLine($"Overall: {rulesToValidate.TrueForAll(x => x)}");
            Console.WriteLine("");

            return rulesToValidate.TrueForAll(x => x);
        }

        public static bool HasValidBirthYear(this string str)
        {
            return str != string.Empty &&
                Convert.ToInt32(str) >= 1920 && Convert.ToInt32(str) <= 2002;
        }

        public static bool HasValidIssueYear(this string str)
        {
            return str != string.Empty &&
                Convert.ToInt32(str) >= 2010 && Convert.ToInt32(str) <= 2020;
        }

        public static bool HasValidExpirationYear(this string str)
        {
            return str != string.Empty &&
                Convert.ToInt32(str) >= 2020 && Convert.ToInt32(str) <= 2030;
        }

        public static bool HasValidHeight(this string str)
        {
            var returnResult = false;
            if (str.Contains("in"))
            {
                var height = str.Substring(0, str.Length - 2);
                returnResult = str != string.Empty &&
                    Convert.ToInt32(height) >= 59 && Convert.ToInt32(height) <= 76;
            }
            else if (str.Contains("cm"))
            {
                var height = str.Substring(0, str.Length - 2);
                returnResult = str != string.Empty &&
                    Convert.ToInt32(height) >= 150 && Convert.ToInt32(height) <= 193;
            }

            return returnResult;
        }

        public static bool HasValidHairColour(this string str)
        {
            return str != string.Empty &&
                Regex.Match(str, "^#(?:[0-9a-f]{6})$").Success;
        }

        public static bool HasValidEyeColour(this string str)
        {
            return str != string.Empty &&
                GetValidEyeColours().Contains(str);
        }

        public static bool HasValidPassportID(this string str)
        {
            return str != string.Empty &&
                Regex.Match(str, "^[0-9]{9}$").Success;
        }

        public static List<Dictionary<string, string>> ParseInputToPassports()
        {
            var input = ProgramInput.GetDay4Input();
            var passport = string.Empty;
            var passports = new List<Dictionary<string, string>>();
            for (var i = 0; i < input.Count; i++)
            {
                if (input[i] == string.Empty)
                {
                    var fieldsAndData = passport.Split(' ');
                    var pass = GetEmptyPassportDictionary();
                    var fieldstring = "";
                    foreach (var field in fieldsAndData)
                    {
                        pass[field.Split(':')[0]] = field.Split(':')[1];
                        fieldstring = $"{fieldstring} ({field.Split(':')[0]})";
                    }

                    passports.Add(pass);
                    passport = string.Empty;
                }
                else
                {
                    if (passport == string.Empty)
                    {
                        passport = input[i];
                    }
                    else
                    {
                        passport = $"{passport} {input[i]}";
                    }
                }
            }

            return passports;
        }

        public static List<string> GetValidEyeColours()
        {
            return new List<string>()
            {
                "amb",
                "blu",
                "brn",
                "gry",
                "grn",
                "hzl",
                "oth"
            };
        }

        public static List<string> GetRequiredPassportFields()
        {
            return new List<string>()
            {
                "byr",
                "iyr",
                "eyr",
                "hgt",
                "hcl",
                "ecl",
                "pid"
            };
        }

        public static List<string> GetAllPassportFields()
        {
            return new List<string>()
            {
                "byr",
                "iyr",
                "eyr",
                "hgt",
                "hcl",
                "ecl",
                "pid",
                "cid"
            };
        }

        public static int GetPartOneAnswer()
        {
            var passports = ParseInputToPassports();
            var validPassports = 0;
            foreach (var passport in passports)
            {
                if (passport.HasValidFields())
                {
                    validPassports++;
                }
            }

            return validPassports;
        }

        public static int GetPartTwoAnswer()
        {
            var passports = ParseInputToPassports();
            var validPassports = 0;
            foreach (var passport in passports)
            {
                if (passport.HasValidFieldData())
                {
                    validPassports++;
                }
            }

            return validPassports;
        }
    }
}
