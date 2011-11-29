using System;
using System.Linq;
using Unicoen.Languages.Java.ProgramGenerators;
using Unicoen.Model;
using Unicoen.Tests;
using System.Collections.Generic;

namespace Unicoen.Apps.Findbug {
    class Program {
        public static IEnumerable<UnifiedIdentifier> getVariables(string name, UnifiedProgram codeObj){
            var vari = UnifiedIdentifier.CreateVariable(name);
            var id = codeObj.Descendants<UnifiedIdentifier>();
            var strV = vari.ToString();
            foreach(var ID in id){
                var strID = ID.ToString();
                if(strID.Equals(strV)){
                    yield return ID;
                }
            }
        }

        static void Main(string[] args) {
            try {
                var inputPath = FixtureUtil.GetInputPath("Java", "BugPatterns", "NP_ALWAYS_NULL.java");
                var codeObj = new JavaProgramGenerator().GenerateFromFile(inputPath);
                var idname = "bool";
                var idCount = getVariables(idname, codeObj);

                Console.WriteLine("{0}: " + idCount.Count(), idname);
                var nulls = codeObj.Descendants<UnifiedNullLiteral>();
                Console.WriteLine("null: " + nulls.Count());
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
        }
    }
}
