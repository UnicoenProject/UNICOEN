using System;
using System.Linq;
using Unicoen.Model;
using Unicoen.Tests;
using Unicoen.Apps.Loc.Util;

namespace Unicoen.Apps.Loc {
	class Program {
		static void Main(string[] args) 
        {
            // args[0] is the language
            // arge[1] is the file name or directory name
            var inputPath = FixtureUtil.GetInputPath(args[0], args[1]);
            Console.WriteLine("Language : " + args[0]);
            Console.WriteLine("Input    : " + inputPath + "\n");
            PrintInfo(inputPath);
        }

        static void PrintInfo(string inputPath)
        {
            string tloc = "Total Lines of Code: ";
            string bloc = "Blank Lines of Code: ";
            string stmt = "Statements Count of Code: ";

            Console.WriteLine(tloc + TotalLoc.CountTotalLoc(inputPath));
            Console.WriteLine(bloc + BlankLoc.CountBlankLoc(inputPath));
            Console.WriteLine(stmt + StatementLoc.CountStatementLoc(inputPath));
            Console.WriteLine();
        }
	}
}
