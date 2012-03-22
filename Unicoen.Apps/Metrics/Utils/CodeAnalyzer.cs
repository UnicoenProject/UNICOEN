#region License

// Copyright (C) 2011-2012 The Unicoen Project
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
using System.Linq;
using Paraiba.Collections.Generic;
using Unicoen.Languages.Java;
using Unicoen.Model;

namespace Unicoen.Apps.Metrics.Utils {
    public static class CodeAnalyzer {
        private static void InitializeCounter(
                IUnifiedElement model,
                IDictionary<string, int> counter) {
            var outers = model.Elements()
                    .Where(
                            e => e is UnifiedClassLikeDefinition ||
                                 e is UnifiedFunctionDefinition);
            foreach (var e in outers) {
                var outerStr = GetOutersString(e);
                counter[outerStr] = 0;
            }
        }

        private static void CountElements(
                IEnumerable<IUnifiedElement> targets,
                IDictionary<string, int> counter) {
            foreach (var e in targets) {
                var outerStr = GetOutersString(e);
                counter.Increment(outerStr);
            }
        }

        private static string GetOutersName(IUnifiedElement element) {
            var klass = element as UnifiedClassLikeDefinition;
            if (klass != null) {
                return "[class] " + JavaFactory.GenerateCode(klass.Name);
            }
            var method = element as UnifiedFunctionDefinition;
            if (method != null) {
                return "[method] " + JavaFactory.GenerateCode(method.Name);
            }
            return null;
        }

        private static string GetOutersString(IUnifiedElement target) {
            var result = "::";
            foreach (var e in target.AncestorsAndSelf()) {
                var name = GetOutersName(e);
                if (name == null) {
                    continue;
                }
                result = "::" + name + result;
            }
            //var outerName = target.Ancestors()
            //        .Select(
            //                e => {
            //                    var klass = e as UnifiedClassLikeDefinition;
            //                    if (klass != null)
            //                        return klass.Name;
            //                    var method = e as UnifiedFunctionDefinition;
            //                    if (method != null)
            //                        return method.Name;
            //                    return null;
            //                })
            //        .Where(e => e != null)
            //        .FirstOrDefault();
            //if (outerName != null) {
            //    result = JavaFactory.GenerateCode(outerName);
            //} else {
            //    result = "";
            //}
            return result;
        }

        public static Dictionary<string, int> Measure(
                IUnifiedElement codeObject,
                Func<IUnifiedElement, IEnumerable<IUnifiedElement>>
                        getTargetElementsFunc) {
            var counts = new Dictionary<string, int>();
            InitializeCounter(codeObject, counts);
            CountElements(getTargetElementsFunc(codeObject), counts);
            return counts;
        }

        public static Dictionary<string, int> Measure(
                string filePath,
                Func<IUnifiedElement, IEnumerable<IUnifiedElement>>
                        getTargetElementsFunc) {
            try {
                var counts = new Dictionary<string, int>();
                var prog = UnifiedGenerators.GenerateProgramFromFile(filePath);
                if (prog == null) {
                    return new Dictionary<string, int>();
                }
                InitializeCounter(prog, counts);
                CountElements(getTargetElementsFunc(prog), counts);
                return counts;
            } catch {
                return new Dictionary<string, int>();
            }
        }
    }
}