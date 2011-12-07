using System;
using System.Linq;
using Unicoen.Languages.Java.ProgramGenerators;
using Unicoen.Model;
using Unicoen.Tests;
using System.Collections.Generic;

namespace Unicoen.Apps.Findbug {
    class Program {
        public static IEnumerable<UnifiedIdentifier> getVariables(string name, UnifiedProgram codeObj){
            var variable = UnifiedIdentifier.CreateVariable(name);
            var ids = codeObj.Descendants<UnifiedIdentifier>();
            var strV = variable.Name;
            foreach(var id in ids){
                var strId = id.Name;
                if(strId.Equals(strV)){
                    yield return id;
                }
            }
        }

        static void Main(string[] args) {
            try {
                var inputPath = FixtureUtil.GetInputPath("Java", "BugPatterns", "NULL_SAMPLE.java");
                var codeObj = new JavaProgramGenerator().GenerateFromFile(inputPath);
                var idname = "bool";
                var idSet = getVariables(idname, codeObj);

                Console.WriteLine("{0}: " + idSet.Count(), idname);
                var nulls = codeObj.Descendants<UnifiedNullLiteral>();
                Console.WriteLine("null: " + nulls.Count());
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
        }
    }
}
