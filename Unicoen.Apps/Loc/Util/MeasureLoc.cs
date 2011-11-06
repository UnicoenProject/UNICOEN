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
            return TLoc.CountTLoc(inputPath);
        }

        public int MeasureBLoc(string inputPath)
        {
            return BLoc.CountBLoc(inputPath);
        }

        public int MeasureStmt(string inputPath)
        {
            var ext = Path.GetExtension(inputPath);
            switch (ext.ToLower())
            {
                case ".c":
                    return Stmt.StmtC(inputPath);
                case ".cs":
                    return Stmt.StmtCSharp(inputPath);
                case ".java":
                    return Stmt.StmtJava(inputPath);
                case ".js":
                    return Stmt.StmtJavaScript(inputPath);
                case ".py":
                    return Stmt.StmtPython(inputPath);
                case ".rb":
                    return Stmt.StmtRuby(inputPath);
                //case ".vb":
                    //return CSharpFactory.GenerateModel(code);
            }
            return 0;
        }
    }
}
