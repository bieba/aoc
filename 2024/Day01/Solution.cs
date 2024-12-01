namespace AdventOfCode.Y2024.Day01;

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

[ProblemName("Historian Hysteria")]
class Solution : Solver {

    public object PartOne(string input) {
        var parts = input.Split("\n")
            .Select(l => l.Split(" ", StringSplitOptions.RemoveEmptyEntries));
        var p1 = parts.Select(l => int.Parse(l[0]))
            .OrderBy(i => i)
            .ToList();
        var p2 = parts.Select(l => int.Parse(l[1]))
            .OrderBy(i => i)
            .ToList();

        var sum = 0;
        for (var i = 0; i <= p1.Count - 1; i++) {
            sum += Math.Abs(p1[i] - p2[i]);
        }

        return sum;
    }

    public object PartTwo(string input) {
        var parts = input.Split("\n")
            .Select(l => l.Split(" ", StringSplitOptions.RemoveEmptyEntries));
        var p1 = parts.Select(l => int.Parse(l[0]));
        var p2 = parts.Select(l => int.Parse(l[1]));

        return p1.Select(i1 => i1 * p2.Count(needle => needle.Equals(i1))).Sum();
    }
}