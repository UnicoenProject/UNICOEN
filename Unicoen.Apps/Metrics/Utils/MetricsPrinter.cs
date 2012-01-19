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
using System.IO;
using System.Linq;
using Unicoen.Model;

namespace Unicoen.Apps.Metrics.Utils {
    public abstract class MetricsPrinter {
        protected abstract string MeticName { get; }

        protected virtual int AdditionalCount {
            get { return 0; }
        }

        public bool Run(IList<string> args) {
            var filePaths = ExtendFilePath(args);
            foreach (var filePath in filePaths) {
                PrintMetrics(filePath);
            }
            return true;
        }

        protected abstract IEnumerable<IUnifiedElement>
                ProtectedGetTargetElements(IUnifiedElement codeObject);

        /// <summary>
        ///   Print cyclomatic of give file
        /// </summary>
        /// <param name="filePath"> a target file path </param>
        protected virtual void PrintMetrics(string filePath) {
            var codeObject = CodeAnalyzer.CreateCodeObjectOrDefault(filePath);
            if (codeObject == null) {
                return;
            }

            Console.WriteLine("**** " + MeticName + " of " + filePath + " ****");

            var result = CodeAnalyzer.Measure(
                    filePath, ProtectedGetTargetElements);

            var newTagSet = TagProcessor.HierarchizeTags(result.Keys);

            foreach (var tag in newTagSet) {
                var count = result.Where(p => p.Key.StartsWith(tag))
                        .Aggregate(AdditionalCount, (s, p) => s + p.Value);
                Console.WriteLine(tag + " " + count);
            }
        }

        private static IEnumerable<string> ExtendFilePath(
                IEnumerable<string> paths) {
            return paths.SelectMany(
                    path => {
                        // do a given path indicate directory?
                        if (Directory.Exists(path)) {
                            return Directory.EnumerateFiles(
                                    path, "*", SearchOption.AllDirectories);
                        }
                        // or do a given path indicate file?
                        if (File.Exists(path)) {
                            return Enumerable.Repeat(path, 1);
                        }
                        return Enumerable.Empty<string>();
                    });
        }
    }
}