using System;
using System.Linq;
using Unicoen.Languages.Java.ProgramGenerators;
using Unicoen.Model;
using Unicoen.Tests;
using System.Collections.Generic;
using Code2Xml.Languages.Java.CodeToXmls;

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

        public static IEnumerable<IUnifiedElement> FindDefines(UnifiedProgram codeObj) {
            var binaryExpressions = codeObj.Descendants<UnifiedBinaryExpression>();
            foreach (var be in binaryExpressions) {
                if (be.Operator.Sign.Equals("=")) {
                    var leftName = "";
                    var left = be.LeftHandSide as UnifiedVariableIdentifier;
                    if (left != null) {
                        leftName = left.Name;
                        Console.WriteLine(leftName);
                    }
                    var right = be.RightHandSide as UnifiedNullLiteral;
                    if (right != null) {
                        Console.WriteLine("{0} is NULL", leftName);
                    }
                    yield return be;
                }
            }
        }

        static void Main(string[] args) {
            try {
                var inputPath = FixtureUtil.GetInputPath("Java", "BugPatterns", "NP_NULL_ON_SOME_PATH.java");
                var codeObj = new JavaProgramGenerator().GenerateFromFile(inputPath);
                const string idName = "bool";
                var idSet = GetVariables(idName, codeObj);
                var ast = JavaCodeToXml.Instance.Generate(
                    "{ int i; i = 1; }", p => p.block());
                var codeObject = JavaProgramGeneratorHelper.CreateBlock(ast);

                var definitions = DefUseAnalyzer.FindDefines(codeObject);
                
                Console.WriteLine("{0}: " + idSet.Count(), idName);
                Console.WriteLine(definitions.Count());
                var nulls = codeObj.Descendants<UnifiedNullLiteral>();
                Console.WriteLine("null: " + nulls.Count());
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
        }
    }
}
