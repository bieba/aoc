namespace AdventOfCode.Y2024.Day02;

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading;
using Microsoft.VisualBasic;

[ProblemName("Red-Nosed Reports")]
class Solution : Solver {

    private static List<int> Idiff = new List<int>() { 1, 2, 3 };
    private static List<int> Ddiff = new List<int>() { -1, -2, -3 };

    public object PartOne(string input) {
        var lines = input.Split("\n");
        var reportsList = lines.Select(l => l.Split(" ").Select(int.Parse).ToList());

        return reportsList.Where(IsSafe).Count();
    }

    private bool IsSafe(List<int> report) {
        var x = report.Skip(-1).Zip(report.Skip(1));
        var d = x.Select(z => z.First - z.Second);

        return d.All(Idiff.Contains) || d.All(Ddiff.Contains);
    }

    public object PartTwo(string input) {
        var lines = input.Split("\n");
        var reportsList = lines.Select(l => l.Split(" ").Select(int.Parse).ToList());

        var count = 0;
        foreach (var report in reportsList) {
            var b = new List<bool>();
            for (var i = 0; i <= report.Count - 1; i++) {
                var newReport = report.Take(i).Concat(report.Skip(i + 1)).ToList();
                b.Add(IsSafe(newReport));
            }

            if(IsSafe(report) || b.Any(v => v)){
                count++;
            }
        }

        return count;
    }
}