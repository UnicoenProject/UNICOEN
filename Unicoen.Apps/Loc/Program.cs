using System;
using System.Linq;
using Unicoen.Model;
using Unicoen.Tests;
using Unicoen.Apps.Loc.Util;

namespace Unicoen.Apps.Loc {
	class Program {
		static void Main(string[] args) 
		{
			// BASIC MEASUREMENT
			// args[0] is the language
			// arge[1] is the file name or directory name
			
			if (args.Length == 2)
			{
				var inputPath = FixtureUtil.GetInputPath(args[0], args[1]);
				Console.WriteLine("Language : " + args[0]);
				Console.WriteLine("Input    : " + inputPath + "\n");
				PrintBasicInfo(inputPath);
			}

			// DIFFERENTIAL MEASUREMENT
			// args[0] is the language
			// arge[1] is the original source code file
			// arge[2] is the modified source code file

			if (args.Length == 3)
			{
				var orign = FixtureUtil.GetInputPath(args[0], args[1]);
				var modif = FixtureUtil.GetInputPath(args[0], args[2]);
				Console.WriteLine("Language      : " + args[0] + "\n");
				Console.WriteLine("File 1 : " + orign);
				PrintBasicInfo(orign);
				Console.WriteLine("File 2 : " + modif);
				PrintBasicInfo(modif);
				PrintDifferentialInfo(orign, modif);
			}
		}

		static void PrintBasicInfo(string inputPath)
		{
			Console.WriteLine("Total Lines of Code      : " + TotalLoc.Count(inputPath));
			Console.WriteLine("Blank Lines of Code      : " + BlankLoc.Count(inputPath));
			Console.WriteLine("Statements Count of Code : " + StatementLoc.Count(inputPath));
			Console.WriteLine();
		}

		static void PrintDifferentialInfo(string orign, string modif)
		{
			DiffCounter c = DifferentialLoc.Count(orign, modif);
			Console.WriteLine("Added Line of Code    : " + c.AddedCount);
			Console.WriteLine("Deleted Line of Code  : " + c.DeletedCount);
			Console.WriteLine("Modified Line of Code : " + c.ModifiedCount);
			Console.WriteLine("Equal Line of Code    : " + c.EqualCount);
			Console.WriteLine();
		}

	}
}
