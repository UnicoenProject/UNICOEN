#region License

// Copyright (C) 2011 The Unicoen Project
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System;
using System.IO;
using System.Linq;
using Unicoen.Languages.C.ProgramGenerators;
using Unicoen.Languages.CSharp.ProgramGenerators;
using Unicoen.Languages.Java.ProgramGenerators;
using Unicoen.Languages.JavaScript.ProgramGenerators;
using Unicoen.Languages.Python2.ProgramGenerators;
using Unicoen.Languages.Ruby18.Model;
using Unicoen.Model;

namespace Unicoen.Apps.Loc.Util {
    public class StatementLoc {
        // measure number of statements as the logical lines of code
        public static int Count(string inputPath) {
            FileAttributes attr = File.GetAttributes(@inputPath);
            // if inputPath is a directory
            if ((attr & FileAttributes.Directory) == FileAttributes.Directory) {
                DirectoryInfo dirPath = new DirectoryInfo(@inputPath);
                return CountForDirectory(dirPath);
            }
                    // if inputPath is a file
            else {
                return CountForFile(inputPath);
            }
        }

        // count  sum of statements of all files in directory
        private static int CountForDirectory(DirectoryInfo dirPath) {
            var sum = 0;
            var files = dirPath.GetFiles("*.*");
            foreach (FileInfo file in files) {
                String fi = file.FullName;
                var fiLoc = CountForFile(fi);
                sum += fiLoc;
                Console.WriteLine(fi + " | stmt=" + fiLoc);
            }
            var dirs = dirPath.GetDirectories("*.*");
            foreach (DirectoryInfo dir in dirs) {
                sum += CountForDirectory(dir);
            }
            return sum;
        }

        // count number of statements of a file
        private static int CountForFile(string filePath) {
            var ext = Path.GetExtension(filePath);
            switch (ext.ToLower()) {
            case ".c":
                return
                        StatementNumber(
                                new CProgramGenerator().GenerateFromFile(
                                        filePath));
            case ".cs":
                return
                        StatementNumber(
                                new CSharpProgramGenerator().GenerateFromFile(
                                        filePath));
            case ".java":
                return
                        StatementNumber(
                                new JavaProgramGenerator().GenerateFromFile(
                                        filePath));
            case ".js":
                return
                        StatementNumber(
                                new JavaScriptProgramGenerator().
                                        GenerateFromFile(filePath));
            case ".py":
                return
                        StatementNumber(
                                new Python2ProgramGenerator().GenerateFromFile(
                                        filePath));
            case ".rb":
                return
                        StatementNumber(
                                new Ruby18ProgramGenerator().GenerateFromFile(
                                        filePath));
            default:
                return 0;
            }
        }

        // count statements of a unified code object
        private static int StatementNumber(UnifiedProgram codeObject) {
            var blocks = codeObject.Descendants<UnifiedBlock>();
            var sum = 0;
            foreach (var block in blocks) {
                sum += block.Elements().Count();
            }
            return sum;
        }
    }
}