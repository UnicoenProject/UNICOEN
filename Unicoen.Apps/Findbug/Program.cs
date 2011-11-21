using System;
using System.Linq;
using Unicoen.Languages.Java.ProgramGenerators;
using Unicoen.Model;
using Unicoen.Tests;

namespace Unicoen.Apps.Findbug {
    class Program {
        static void Main(string[] args) {
            try {

                var inputPath = FixtureUtil.GetInputPath("Java", "NP_ALWAYS_NULL.java");
                var codeObj = new JavaProgramGenerator().GenerateFromFile(inputPath);
                var nulls = codeObj.Descendants<UnifiedNullLiteral>();
                var sum = 0;
                foreach (var NULL in nulls) {
                    sum += NULL.Elements().Count();
                }
                Console.WriteLine(sum);
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
        }
    }
}
