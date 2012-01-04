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
                var inputPath = FixtureUtil.GetInputPath("Java", "BugPatterns", "NULL_SAMPLE.java");
                var codeObj = new JavaProgramGenerator().GenerateFromFile(inputPath);
                /*const string idName = "bool";
                var idSet = GetVariables(idName, codeObj);
                */

                /*var a = FindUses(codeObj);
                Console.WriteLine(a.Count());
                */

                var ast = JavaCodeToXml.Instance.Generate(
                    "{ int i; i = 1; }", p => p.block());
                var ast2 = JavaCodeToXml.Instance.Generate(
                    "{ int i, j; i = 1; j = i; }", p => p.block());

                var codeObject = JavaProgramGeneratorHelper.CreateBlock(ast);
                var codeObject2 = JavaProgramGeneratorHelper.CreateBlock(ast2);

                var defs = DefUseAnalyzer.FindDefines(codeObject);
                var uses = DefUseAnalyzer.FindUses(codeObject2);
                
                foreach (var def in defs) {
                    Console.WriteLine(def);
                }
                foreach (var use in uses) {
                    Console.WriteLine(use);
                }

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
