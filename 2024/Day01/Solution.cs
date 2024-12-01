namespace AdventOfCode.Y2024.Day01;

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

[ProblemName("Historian Hysteria")]
class Solution : Solver
{

    public object PartOne(string input)
    {
        var line = input.Split("\n");
        var p1 = line.Select(l => int.Parse(l.Split("   ").First()))
            .OrderBy(i => i)
            .ToList();
        var p2 = line.Select(l => int.Parse(l.Split("   ").Last()))
            .OrderBy(i => i)
            .ToList();

        var sum = 0;
        for (var i = 0; i <= p1.Count() - 1; i++)
        {
            sum += Math.Abs(p1[i] - p2[i]);
        }

        return sum;
    }

    public object PartTwo(string input)
    {
        var line = input.Split("\n");
        var p1 = line.Select(l => int.Parse(l.Split("   ").First()));
        var p2 = line.Select(l => int.Parse(l.Split("   ").Last()));

        return p1.Select(i1 => i1 * p2.Count(needle => needle.Equals(i1))).Sum();
    }
}