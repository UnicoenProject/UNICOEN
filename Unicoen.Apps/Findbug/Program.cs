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
using System.Collections.Generic;
using Unicoen.Languages.Java.ProgramGenerators;
using Unicoen.Model;
using Unicoen.TestUtils;
using Unicoen.Tests;

namespace Unicoen.Apps.Findbug {
    internal class Program {
        public static IEnumerable<UnifiedIdentifier> GetVariables(
                string name, UnifiedProgram codeObj) {
            var ids = codeObj.Descendants<UnifiedIdentifier>();
            foreach (var id in ids) {
                if (id.Name.Equals(UnifiedIdentifier.CreateVariable(name).Name)) {
                    yield return id;
                }
            }
        }

        private static void Main(string[] args) {
            try {
                var inputPath = FixtureUtil.GetInputPath(
                        "Java", "BugPatterns", "NULL_SAMPLE.java");
                var codeObj =
                        new JavaProgramGenerator().GenerateFromFile(inputPath);

                /*Console.WriteLine("{0}: " + idSet.Count(), idName);
                var nulls = codeObj.Descendants<UnifiedNullLiteral>();
                Console.WriteLine("null: " + nulls.Count());*/
            } catch (Exception e) {
                Console.WriteLine(e);
            }
        }
    }
}