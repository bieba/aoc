namespace AdventOfCode.Y2024.Day03;

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Diagnostics;

[ProblemName("Mull It Over")]
class Solution : Solver {

    public object PartOne(string input) {
        return Regex.Matches(input, "mul\\(([0-9]{1,3}),([0-9]{1,3})\\)")
            .Select(m => int.Parse(m.Groups[1].Value) * int.Parse(m.Groups[2].Value)).Sum();
    }

    public object PartTwo(string input) {
        var matches = Regex.Matches(input, "(do\\(\\)|don't\\(\\))|mul\\(([0-9]{1,3}),([0-9]{1,3})\\)");

        var enabled = true;
        var sum = 0;
        foreach (Match match in matches) {
            var ematch = match.Groups[1].Value;
            if (ematch == "do()" || ematch == "don't()") {
                enabled = ematch == "do()";

                continue;
            }

            if (enabled) {
                sum += int.Parse(match.Groups[2].Value) * int.Parse(match.Groups[3].Value);
            }
        }

        return sum;
    }
}