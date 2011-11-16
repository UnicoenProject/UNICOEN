using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Unicoen.Apps.Loc.Util;

namespace Unicoen.Apps.Loc.Util
{
    class MeasureLoc
    {
        public int MeasureTLoc(string inputPath)
        {
            return TotalLoc.CountTotalLoc(inputPath);
        }

        public int MeasureBLoc(string inputPath)
        {
            return BlankLoc.CountBlankLoc(inputPath);
        }

        public int MeasureStmt(string inputPath)
        {
            var ext = Path.GetExtension(inputPath);
            switch (ext.ToLower())
            {
                case ".c":
                    return StatementLoc.StmtC(inputPath);
                case ".cs":
                    return StatementLoc.StmtCSharp(inputPath);
                case ".java":
                    return StatementLoc.StmtJava(inputPath);
                case ".js":
                    return StatementLoc.StmtJavaScript(inputPath);
                case ".py":
                    return StatementLoc.StmtPython(inputPath);
                case ".rb":
                    return StatementLoc.StmtRuby(inputPath);
                //case ".vb":
                    //return CSharpFactory.GenerateModel(code);
            }
            return 0;
        }
    }
}
