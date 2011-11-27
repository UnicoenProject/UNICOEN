using System;
using System.Linq;
using Unicoen.Languages.Java.ProgramGenerators;
using Unicoen.Model;
using Unicoen.Tests;
using System.Collections.Generic;

namespace Unicoen.Apps.Findbug {
    class Program {
        public static int getVariables(string name, UnifiedProgram codeObj) {
            var vari = UnifiedIdentifier.CreateVariable(name);
            var id = codeObj.Descendants<UnifiedIdentifier>();
            var sum = 0;
            foreach (var ID in id) {
                var strID = ID.ToString();
                var strV = vari.ToString();
                if (strID.Equals(strV)) {
                    sum++;
                }
            }
            return sum;
        }

        /*public static IEnumerable<UnifiedIdentifier> getVariables(string name{

        }*/

        static void Main(string[] args) {
            try {
                var inputPath = FixtureUtil.GetInputPath("Java", "BugPatterns", "NP_ALWAYS_NULL.java");
                var codeObj = new JavaProgramGenerator().GenerateFromFile(inputPath);
                var count = getVariables("bool", codeObj);
                
                Console.WriteLine(count);
                var nulls = codeObj.Descendants<UnifiedNullLiteral>();
                Console.WriteLine(nulls.Count());
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
        }
    }
}
