namespace AdventOfCode.Y2023.Day01;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

[ProblemName("Trebuchet?!")]
class Solution : Solver {

    Regex NumberRegex = new Regex(@"\d");
    Regex NumberAndWordsRegex = new Regex(@"(?=(\d|one|two|three|four|five|six|seven|eight|nine))");
    Dictionary<string, int> WordToNumber = new Dictionary<string, int>(){

    };

    public object PartOne(string input) {
        var sum = 0;

        foreach (var line in input.Split("\n")) {
            sum += calculateSum(line);
        }

        return sum;
    }

    public object PartTwo(string input) {
        var sum = 0;

        foreach (var line in input.Split("\n")) {
            var matches = NumberAndWordsRegex.Matches(line);
            var m1 = matches.First().Groups[1].Value;
            var m2 = matches.Last().Groups[1].Value;

            sum += ParseMatch(m1) * 10 + ParseMatch(m2);
        }

        return sum;
    }

    private int calculateSum(string line) {
        var matches = NumberRegex.Matches(line);

        if(matches.Count == 0) {
            return 0;
        }

        int.TryParse(matches.First().Value, out var n1);
        int.TryParse(matches.Last().Value, out var n2);

        return n1 * 10 + n2;
    }

    private static int ParseMatch(string s){
        return s switch {
            "one" => 1,
            "two" => 2,
            "three" => 3,
            "four" => 4,
            "five" => 5,
            "six" => 6,
            "seven" => 7,
            "eight" => 8,
            "nine" => 9,
            _ => int.Parse(s)
        };
    }
}