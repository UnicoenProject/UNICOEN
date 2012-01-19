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
using Paraiba.Collections.Generic;
using Paraiba.Text;
using Unicoen.Languages.C;
using Unicoen.Languages.CSharp;
using Unicoen.Languages.Java;
using Unicoen.Languages.JavaScript;
using Unicoen.Languages.Python2;
using Unicoen.Languages.Ruby18.Model;
using Unicoen.Model;

namespace Unicoen.Apps.Metrics.Utils {
    public static class CodeAnalyzer {
        public static UnifiedProgram CreateCodeObject(string ext, string code) {
            switch (ext.ToLower()) {
            case ".c":
                return CFactory.GenerateModel(code);
            case ".vb":
                return CSharpFactory.GenerateModel(code);
            case ".cs":
                return CSharpFactory.GenerateModel(code);
            case ".java":
                return JavaFactory.GenerateModel(code);
            case ".js":
                return JavaScriptFactory.GenerateModel(code);
            case ".py":
                return Python2Factory.GenerateModel(code);
            case ".rb":
                return Ruby18ProgramGenerator.Instance.Generate(code);
            }
            return null;
        }

        public static UnifiedProgram CreateCodeObjectOrDefault(
                string ext, string code) {
            try {
                switch (ext.ToLower()) {
                case ".c":
                    return CFactory.GenerateModel(code);
                case ".vb":
                    return CSharpFactory.GenerateModel(code);
                case ".cs":
                    return CSharpFactory.GenerateModel(code);
                case ".java":
                    return JavaFactory.GenerateModel(code);
                case ".js":
                    return JavaScriptFactory.GenerateModel(code);
                case ".py":
                    return Python2Factory.GenerateModel(code);
                case ".rb":
                    return Ruby18ProgramGenerator.Instance.Generate(code);
                }
            } catch {}
            return null;
        }

        public static UnifiedProgram CreateCodeObjectOrDefault(string filePath) {
            try {
                var code = GuessEncoding.ReadAllText(filePath);
                switch ((Path.GetExtension(filePath) ?? "").ToLower()) {
                case ".c":
                    return CFactory.GenerateModel(code);
                case ".vb":
                    return CSharpFactory.GenerateModel(code);
                case ".cs":
                    return CSharpFactory.GenerateModel(code);
                case ".java":
                    return JavaFactory.GenerateModel(code);
                case ".js":
                    return JavaScriptFactory.GenerateModel(code);
                case ".py":
                    return Python2Factory.GenerateModel(code);
                case ".rb":
                    return Ruby18ProgramGenerator.Instance.Generate(code);
                }
            } catch {}
            return null;
        }

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
                var ext = Path.GetExtension(filePath);
                var code = File.ReadAllText(filePath, XEncoding.SJIS);
                var model = CreateCodeObject(ext, code);
                if (model == null) {
                    return new Dictionary<string, int>();
                }
                InitializeCounter(model, counts);
                CountElements(getTargetElementsFunc(model), counts);
                return counts;
            } catch {
                return new Dictionary<string, int>();
            }
        }
    }
}