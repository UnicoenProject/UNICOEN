using System;
using System.Linq;
using Unicoen.Languages.Java.ProgramGenerators;
using Unicoen.Model;
using Unicoen.Tests;
using Unicoen.Apps.Loc.Util;

namespace Unicoen.Apps.Loc {
	class Program {
		static void Main(string[] args) 
        {
            var cInputPath = FixtureUtil.GetInputPath("C", "fibonacci.c");
            PrintInfo(cInputPath);

            var cSharpInputPath = FixtureUtil.GetInputPath("CSharp", "Student.cs");
            PrintInfo(cSharpInputPath);

            var javaInputPath = FixtureUtil.GetInputPath("Java", "Fibonacci.java");
            PrintInfo(javaInputPath);

            var jsInputPath = FixtureUtil.GetInputPath("JavaScript", "student.js");
            PrintInfo(jsInputPath);

            var pyInputPath = FixtureUtil.GetInputPath("Python2", "fibonacci.py");
            //PrintInfo(pyInputPath);

            var rubyInputPath = FixtureUtil.GetInputPath("Ruby18", "fibonacci.rb");
            //PrintInfo(rubyInputPath);
        }

        static void PrintInfo(string inputPath)
        {
            string tloc = "Total Lines of Code: ";
            string bloc = "Blank Lines of Code: ";
            string stmt = "Statements Count of Code: ";

            Console.WriteLine("\n" + inputPath);
            Console.WriteLine(tloc + new MeasureLoc().MeasureTLoc(inputPath));
            Console.WriteLine(bloc + new MeasureLoc().MeasureBLoc(inputPath));
            Console.WriteLine(stmt + new MeasureLoc().MeasureStmt(inputPath));
        }
	}
}
