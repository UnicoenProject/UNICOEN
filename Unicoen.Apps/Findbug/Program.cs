using System;
using System.Linq;
using Unicoen.Languages.Java.ProgramGenerators;
using Unicoen.Model;
using Unicoen.Tests;

namespace Unicoen.Apps.Findbug {
    class Program {
        static void Main(string[] args) {
            try {

                var inputPath = FixtureUtil.GetInputPath("Java", "BugPatterns", "NP_ALWAYS_NULL.java");
                var codeObj = new JavaProgramGenerator().GenerateFromFile(inputPath);
                var nulls = codeObj.Descendants<UnifiedNullLiteral>();
                Console.WriteLine(nulls.Count());
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
        }
    }
}
