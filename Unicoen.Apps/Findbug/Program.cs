using System;
using System.Linq;
using Unicoen.Languages.Java.ProgramGenerators;
using Unicoen.Model;
using Unicoen.Tests;
using System.Collections.Generic;

namespace Unicoen.Apps.Findbug {
    class Program {
        public static IEnumerable<UnifiedIdentifier> GetVariables(string name, UnifiedProgram codeObj) {
            var ids = codeObj.Descendants<UnifiedIdentifier>();
            foreach(var id in ids) {
                if (id.Name.Equals(UnifiedIdentifier.CreateVariable(name).Name)) {
                    yield return id;
                }
            }
        }

        static void Main(string[] args) {
            try {
                var inputPath = FixtureUtil.GetInputPath("Java", "BugPatterns", "NULL_SAMPLE.java");
                var codeObj = new JavaProgramGenerator().GenerateFromFile(inputPath);
                
                /*Console.WriteLine("{0}: " + idSet.Count(), idName);
                var nulls = codeObj.Descendants<UnifiedNullLiteral>();
                Console.WriteLine("null: " + nulls.Count());*/
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
        }
    }
}
