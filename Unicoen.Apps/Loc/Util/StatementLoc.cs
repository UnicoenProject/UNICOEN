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
using System.IO;

namespace Unicoen.Apps.Loc.Util
{
    public class StatementLoc
    {
        // measure number of statements as the logical lines of code
        public static int CountStatementLoc(string inputPath)
        {
            FileAttributes attr = File.GetAttributes(@inputPath);
            // if inputPath is a directory
            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
            {
                DirectoryInfo dirPath = new DirectoryInfo(@inputPath);
                return DirStatement(dirPath);
            }
            // if inputPath is a file
            else
            {
                return FileStatement(inputPath);
            }
        }

        // count  sum of statements of all files in directory
        private static int DirStatement(DirectoryInfo dirPath)
        {
            var sum = 0;
            FileInfo[] files = dirPath.GetFiles("*.*");
            foreach (FileInfo file in files)
            {
                String fi = file.FullName;
                var fiLoc = FileStatement(fi);
                sum += fiLoc;
                Console.WriteLine(fi + " | stmt=" + fiLoc);
            }
            DirectoryInfo[] dirs = dirPath.GetDirectories("*.*");
            foreach (DirectoryInfo dir in dirs)
            {
                sum += DirStatement(dir);
            }
            return sum;
        }

        // count number of statements of a file
        private static int FileStatement(string filePath)
        {
            var ext = Path.GetExtension(filePath);
            switch (ext.ToLower())
            {
                case ".c":
                    return CountStmt(new CProgramGenerator().GenerateFromFile(filePath));
                case ".cs":
                    return CountStmt(new CSharpProgramGenerator().GenerateFromFile(filePath));
                case ".java":
                    return CountStmt(new JavaProgramGenerator().GenerateFromFile(filePath));
                case ".js":
                    return CountStmt(new JavaScriptProgramGenerator().GenerateFromFile(filePath));
                case ".py":
                    return CountStmt(new Python2ProgramGenerator().GenerateFromFile(filePath));
                case ".rb":
                    return CountStmt(new Ruby18ProgramGenerator().GenerateFromFile(filePath));
                default:
                    return 0;
            }
        }

        // count statements of a unified code object
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
