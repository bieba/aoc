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
            .OrderBy(i => i);
        var p2 = line.Select(l => int.Parse(l.Split("   ").Last()))
            .OrderBy(i => i);

        var sum = 0;
        for (var i = 0; i <= p1.Count() - 1; i++)
        {
            var c1 = p1.Skip(i).First();
            var c2 = p2.Skip(i).First();

            sum += Math.Abs(c1 - c2);
        }

        return sum;
    }

    public object PartTwo(string input)
    {
        var line = input.Split("\n");
        var p1 = line.Select(l => int.Parse(l.Split("   ").First()));
        var p2 = line.Select(l => int.Parse(l.Split("   ").Last()));

        var sum = 0;
        for (var i = 0; i <= p1.Count() - 1; i++)
        {
            var c1 = p1.Skip(i).First();
            var c2 = p2.Count(needle => needle.Equals(c1));

            sum += c1 * c2;
        }

        return sum;
    }
}