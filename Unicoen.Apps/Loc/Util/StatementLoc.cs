using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unicoen.Model;
using Unicoen.Languages.C.ProgramGenerators;
using Unicoen.Languages.CSharp.ProgramGenerators;
using Unicoen.Languages.Java.ProgramGenerators;
using Unicoen.Languages.JavaScript.ProgramGenerators;
using Unicoen.Languages.Python2.ProgramGenerators;
using Unicoen.Languages.Python3.ProgramGenerators;
using Unicoen.Languages.Ruby18.Model;

namespace Unicoen.Apps.Loc.Util
{
    class StatementLoc
    {
        public static int StmtC(string inputPath)
        {
            var codeObj = new CProgramGenerator().GenerateFromFile(inputPath);
            return CountStmt(codeObj);
        }

        public static int StmtCSharp(string inputPath)
        {
            var codeObj = new CSharpProgramGenerator().GenerateFromFile(inputPath);
            return CountStmt(codeObj);
        }

        public static int StmtJava(string inputPath)
        {
            var codeObj = new JavaProgramGenerator().GenerateFromFile(inputPath);
            return CountStmt(codeObj);
        }

        public static int StmtJavaScript(string inputPath)
        {
            var codeObj = new JavaScriptProgramGenerator().GenerateFromFile(inputPath);
            return CountStmt(codeObj);
        }

        public static int StmtPython(string inputPath)
        {
            var codeObj = new Python2ProgramGenerator().GenerateFromFile(inputPath);
            return CountStmt(codeObj);
        }

        public static int StmtRuby(string inputPath)
        {
            var codeObj = new Ruby18ProgramGenerator().GenerateFromFile(inputPath);
            return CountStmt(codeObj);
        }

        private static int CountStmt(UnifiedProgram codeObject)
        {
            var blocks = codeObject.Descendants<UnifiedBlock>();
            var sum = 0;
            foreach (var block in blocks)
            {
                sum += block.Elements().Count();
            }
            return sum;
        }
    }
}
