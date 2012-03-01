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

using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unicoen.CodeGenerators;
using Unicoen.Languages.Java.CodeGenerators;
using Unicoen.Model;
using Unicoen.Processor;

namespace Unicoen.Apps.MseConverter {
    /// <summary>
    ///   MSEフォーマット上に記述される要素について出力します。
    /// </summary>
    public class MseConvertVisitor : DefaultUnifiedVisitor {
        private readonly Dictionary<UnifiedElement, int> _attribute2Id;
        private readonly Dictionary<UnifiedClassDefinition, int> _class2Id;
        private readonly Dictionary<UnifiedFunctionDefinition, int> _method2Id;
        private readonly Dictionary<UnifiedNamespaceDefinition, int> _package2Id;
        private UnifiedClassDefinition _defaultClass;

        private UnifiedNamespaceDefinition _defaultNamespace;

        private int _id = 4;
        private UnifiedClassDefinition _lastGetDefaultClass;
        private UnifiedNamespaceDefinition _lastGetDefaultNamespace;

        public MseConvertVisitor(TextWriter writer) {
            Writer = writer;
            CodeGenerator = new JavaCodeGenerator();
            _package2Id =
                    new Dictionary<UnifiedNamespaceDefinition, int>(
                            new UnifiedNamespaceDefinitionEqualityComparer
                            { CodeGenerator = CodeGenerator });
            _class2Id = new Dictionary<UnifiedClassDefinition, int>();
            _method2Id = new Dictionary<UnifiedFunctionDefinition, int>();
            _attribute2Id = new Dictionary<UnifiedElement, int>();
        }

        public TextWriter Writer { get; private set; }
        public UnifiedCodeGenerator CodeGenerator { get; set; }
        public int LanguageValue { get; set; }

        public UnifiedClassDefinition DefaultClass {
            get {
                if (_lastGetDefaultClass != _defaultClass) {
                    _lastGetDefaultClass = _defaultClass;
                    WriteClass(
                            _defaultClass, _package2Id[DefaultNamespace],
                            _class2Id[_defaultClass]);
                }
                return _defaultClass;
            }
            set {
                if (_defaultClass != value) {
                    _defaultClass = value;
                    _class2Id[_defaultClass] = NextId();
                }
            }
        }

        public UnifiedNamespaceDefinition DefaultNamespace {
            get {
                if (_lastGetDefaultNamespace != _defaultNamespace) {
                    _lastGetDefaultNamespace = _defaultNamespace;
                    WriteNamespace(
                            _defaultNamespace, _package2Id[_defaultNamespace]);
                }
                return _defaultNamespace;
            }
            set {
                if (_defaultNamespace != value) {
                    _defaultNamespace = value;
                    _package2Id[_defaultNamespace] = NextId();
                }
            }
        }

        private int NextId() {
            return ++_id;
        }

        private static string GetAccessControlQualifier(
                IEnumerable<UnifiedModifier> modifiers) {
            if (modifiers == null) {
                return "";
            }

            foreach (var modifier in modifiers) {
                switch (modifier.Name) {
                case "public":
                    return "public";
                case "private":
                    return "private";
                case "protected":
                    return "protected";
                }
            }
            return "public";
        }

        public override void Visit(
                UnifiedNamespaceDefinition element) {
            //すでに登録されているか確認
            int id;
            if (_package2Id.TryGetValue(element, out id)) {
                return;
            }

            //登録されていなければ新しいIdを取得する
            id = NextId();
            _package2Id.Add(element, id);

            WriteNamespace(element, id);

            element.TryAcceptAllChildren(this);
        }

        private void WriteNamespace(UnifiedNamespaceDefinition element, int id) {
            //規定のフォーマットを出力
            Writer.Write("(FAMIX.Namespace ");
            Writer.WriteLine("(id: " + id + ")");

            //パッケージ名の出力
            //TODO element.Name as UnifiedVariableIdentifierなどで、CodeGeneratorを使わないようにする
            var packageName = CodeGenerator.Generate(element.Name).Replace(
                    ".", "::");
            Writer.WriteLine("(name \'" + packageName + "\'))");
        }

        public override void Visit(
                UnifiedClassDefinition element) {
            // パッケージがあるかどうかを確認
            var package = element.FirstAncestor<UnifiedNamespaceDefinition>()
                          ?? DefaultNamespace;
            var packageId = _package2Id[package];

            //すでに登録されているか確認
            //登録されていなければ新しいIdを取得する
            int id;
            if (!_class2Id.TryGetValue(element, out id)) {
                id = NextId();
                _class2Id.Add(element, id);
            }

            WriteClass(element, packageId, id);

            element.TryAcceptAllChildren(this);
        }

        private void WriteClass(
                UnifiedClassDefinition element, int packageId, int id) {
            //クラス名の取得
            var className = CodeGenerator.Generate(element.Name);
            //規定のフォーマットを出力
            Writer.Write("(FAMIX.Class ");
            Writer.WriteLine("(id: " + id + ")");
            Writer.WriteLine("(name \'" + className + "\')");
            Writer.WriteLine("(belongsTo (idref: " + packageId + "))");

            //抽象クラスかどうかを出力
            var modifiers = element.Modifiers;
            var isAbstract = modifiers != null
                             && modifiers.Any(m => m.Name == "abstract");
            Writer.WriteLine(
                    isAbstract ? "(isAbstract true)" : "(isAbstract false)");
            Writer.WriteLine("(WMC " + LanguageValue + ".00))");
        }

        public override void Visit(
                UnifiedFunctionDefinition element) {
            //関数本体がない場合は対象としない
            if (element.Body == null) {
                return;
            }

            var klass = element.FirstAncestor<UnifiedClassDefinition>()
                        ?? DefaultClass;
            var klassId = _class2Id[klass];

            //関数名の取得
            var functionName = CodeGenerator.Generate(element.Name);

            //すでに登録されているか確認
            //登録されていなければ新しいIdを取得する
            int id;
            if (!_method2Id.TryGetValue(element, out id)) {
                id = NextId();
                _method2Id.Add(element, id);
            }

            WriteMethod(element, klassId, id, functionName);

            element.TryAcceptAllChildren(this);
        }

        private void WriteMethod(
                UnifiedFunctionDefinition element, int klassId, int id,
                string functionName) {
            //規定のフォーマットを出力
            Writer.Write("(FAMIX.Method ");
            Writer.WriteLine("(id: " + id + ")");
            Writer.WriteLine("(name \'" + functionName + "\')");
            Writer.WriteLine(
                    "(accessControlQualifier \'" +
                    GetAccessControlQualifier(element.Modifiers) + "\')");
            Writer.WriteLine("(belongsTo (idref: " + klassId + "))");
            var loc = element.Body.Descendants<UnifiedExpression>()
                    .Where(e => e.Parent is UnifiedBlock)
                    .Count();
            Writer.WriteLine("(LOC " + loc + "))");
        }

        public override void Visit(UnifiedVariableDefinition element) {
            var klass = element.FirstAncestor<UnifiedClassDefinition>()
                        ?? DefaultClass;
            var klassId = _class2Id[klass];

            //すでに登録されているか確認
            //登録されていなければ新しいIdを取得する
            int id;
            if (!_attribute2Id.TryGetValue(element, out id)) {
                _attribute2Id.Add(element, id);
                id = NextId();
            }

            WriteAttribute(element, klassId, id);

            element.TryAcceptAllChildren(this);
        }

        private void WriteAttribute(
                UnifiedVariableDefinition element, int klassId, int id) {
            //変数名の取得
            var attributeName = CodeGenerator.Generate(element.Name);
            //規定のフォーマットを出力
            Writer.Write("(FAMIX.Attribute ");
            Writer.WriteLine("(id: " + id + ")");
            Writer.WriteLine("(name \'" + attributeName + "\')");
            Writer.WriteLine(
                    "(accessControlQualifier \'" +
                    GetAccessControlQualifier(element.Modifiers) + "\')");
            Writer.WriteLine("(belongsTo (idref: " + klassId + ")))");
        }

        public override void Visit(UnifiedCall element) {
            element.TryAcceptAllChildren(this);
            return;
            //TODO 将来的にはCall,Accessも実装する
        }

        #region Nested type: UnifiedNamespaceDefinitionEqualityComparer

        public class UnifiedNamespaceDefinitionEqualityComparer
                : EqualityComparer<UnifiedNamespaceDefinition> {
            public UnifiedCodeGenerator CodeGenerator { get; set; }

            public override bool Equals(
                    UnifiedNamespaceDefinition x, UnifiedNamespaceDefinition y) {
                if (x == y) {
                    return true;
                }
                if (x == null || y == null) {
                    return false;
                }
                return CodeGenerator.Generate(x.Name)
                       == CodeGenerator.Generate(y.Name);
            }

            public override int GetHashCode(UnifiedNamespaceDefinition obj) {
                if (obj == null || obj.Name == null) {
                    return 0;
                }
                return CodeGenerator.Generate(obj.Name).GetHashCode();
            }
                }

        #endregion
    }
}