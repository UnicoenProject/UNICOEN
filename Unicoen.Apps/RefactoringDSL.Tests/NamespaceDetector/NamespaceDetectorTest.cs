using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Unicoen.Apps.RefactoringDSL.Util;
using Unicoen.Languages.Java;
using Unicoen.Model;
using Unicoen.Tests;
using Unicoen.Apps.RefactoringDSL;

namespace Unicoen.Apps.RefactoringDSL.Tests.NamespaceDetector {
	class NamespaceDetectorTest {
		private UnifiedProgram _model;

		[SetUp]
		public void SetUp() {
			var inputPath = FixtureUtil.GetInputPath("Java", "default", "Namespace.java");
			var code = File.ReadAllText(inputPath, Encoding.Default);
			_model = JavaFactory.GenerateModel(code);
		}

		[Test]
		public void Xml表示用() {
			Console.WriteLine(_model.ToXml());
		}

		public static Namespace GetNamespace(UnifiedNamespaceDefinition packageNode) {
			if (packageNode.Descendants<UnifiedProperty>().Count() == 0) {
				return new Namespace() {
					Parent = null,
					Value = packageNode.Descendants<UnifiedVariableIdentifier>().First().Name,
					NamespaceType = NamespaceType.Package,
				};
			}
			var firstProperty = packageNode.Descendants<UnifiedProperty>().First();
			var delimiter = ".";
			return new Namespace() {
				Parent = null,
				Value = string.Join(delimiter, firstProperty.Descendants<UnifiedVariableIdentifier>().Select(e => e.Name)),
				NamespaceType = NamespaceType.Package,
			};
		}

		[Test]
		public void TestForGetNamespace_package() {
			var packageNode = _model.FirstDescendant<UnifiedNamespaceDefinition>();
			var nsString = GetNamespace(packageNode).ToString();
			Console.WriteLine(nsString);
		}

		public static Namespace GetNamespace(UnifiedClassDefinition classNode) {
			var type = NamespaceType.Class;
			var className = classNode.FirstDescendant<UnifiedVariableIdentifier>().Name;
			var parents = GetParentTypes(type).Select(t => Namespace2UnifiedType(t));
			var parentNode = GetFirstFoundNode(classNode, parents);

			return new Namespace() {
				Value = className,
				NamespaceType = type,
				Parent = Dispatcher(parentNode),
			};

		}

		[Test]
		public void TestForGetNamespace_class() {
			var targetClass = FindUtil.FindClassByClassName(_model, "Inner").First();
			var nsString = GetNamespace(targetClass).GetNamespaceString();
			Console.WriteLine(nsString);
		}

		public static Namespace GetNamespace(UnifiedFunctionDefinition functionNode) {
			var type = NamespaceType.Function;
			var functionName = functionNode.Name.Name;
			var parents = GetParentTypes(type).Select(t => Namespace2UnifiedType(t));
			var parentNode = GetFirstFoundNode(functionNode, parents);

			return new Namespace() {
				Value = functionName,
				NamespaceType = type,
				Parent = Dispatcher(parentNode),
			};
		}

		[Test]
		public void TestForGetNamespace_function() {
			var targetClass = FindUtil.FindClassByClassName(_model, "Cls").First();
			var functionNode = targetClass.FirstDescendant<UnifiedFunctionDefinition>();
			var nsString = GetNamespace(functionNode).GetNamespaceString();
			Console.WriteLine(nsString);
		}

		public static Namespace GetNamespace(UnifiedVariableDefinition variableNode) {
			var type = NamespaceType.Variable;
			var variableName = variableNode.Name.Name;
			var parents = GetParentTypes(type).Select(t => Namespace2UnifiedType(t));
			var parentNode = GetFirstFoundNode(variableNode, parents);

			return new Namespace() {
				Value = variableName,
				NamespaceType = type,
				Parent = Dispatcher(parentNode),
			};
		}

		[Test]
		public void TestForGetNamespace_variable() {
			var targetClass = FindUtil.FindClassByClassName(_model, "Cls").First();
			var functionNode = targetClass.FirstDescendant<UnifiedVariableDefinition>();
			var nsString = GetNamespace(functionNode).GetNamespaceString();
			var detailedNsString = GetNamespace(functionNode).GetDetailedNamespaceString();
			Console.WriteLine(nsString);
			Console.WriteLine(detailedNsString);
		}


		public static Namespace GetNamespace(UnifiedFor forNode) {
			var type = NamespaceType.TemporaryScope;
			var parents = GetParentTypes(type).Select(t => Namespace2UnifiedType(t));
			var parentNode = GetFirstFoundNode(forNode, parents);
			return new Namespace() {
				Value = "(for)",
				NamespaceType = type,
				Parent = Dispatcher(parentNode)
			};
		}

		[Test]
		public void TestForGetNamespace_for() {
			var targetClass = FindUtil.FindClassByClassName(_model, "Cls").First();
			var functionNode = targetClass.FirstDescendant<UnifiedFor>();
			var nsString = GetNamespace(functionNode).GetNamespaceString();
			var detailedNsString = GetNamespace(functionNode).GetDetailedNamespaceString();
			Console.WriteLine(nsString);
			Console.WriteLine(detailedNsString);
		}

		public static Namespace GetNamespace(UnifiedWhile whileNode) {
			var type = NamespaceType.TemporaryScope;
			var parents = GetParentTypes(type).Select(t => Namespace2UnifiedType(t));
			var parentNode = GetFirstFoundNode(whileNode, parents);
			return new Namespace() {
				Value = "(while)",
				NamespaceType = type,
				Parent = Dispatcher(parentNode)
			};
		}

		[Test]
		public void TestForGetNamespace_while() {
			var targetClass = FindUtil.FindClassByClassName(_model, "Cls").First();
			var whileNode = targetClass.FirstDescendant<UnifiedWhile>();
			var nsString = GetNamespace(whileNode).GetNamespaceString();
			var detailedNsString = GetNamespace(whileNode).GetDetailedNamespaceString();
			Console.WriteLine(nsString);
			Console.WriteLine(detailedNsString);
		}

		public static Namespace GetNamespace(UnifiedDoWhile dowhileNode) {
			return null;
			throw new NotImplementedException();			
		}

		// 名前空間文字列からコードオブジェクトを検索する
		public static IEnumerable<IUnifiedElement> FindUnifiedElementByNamespace(string nsString, IUnifiedElement element) {
			var result = new List<IUnifiedElement>();
			foreach (var e in element.Descendants()) {
				var ns = Dispatcher(e);
				if(ns != null) {
					if(ns.GetNamespaceString().Equals(nsString)) {
						result.Add(e);
					}
				}
			}

			return result;
		}

		// ディスパッチ先がなかった時用
		public static Namespace GetNamespace(UnifiedElement element) {
			return null;
		}

		[Test]
		public void TestForFindUnifiedElementByNamespace() {
			var nsString = "pkg.subpkg.subsubpkg.subsubsubpkg.Cls";
			nsString = "pkg.subpkg.subsubpkg.subsubsubpkg.Cls.method2.(for)";
			var found = FindUnifiedElementByNamespace(nsString, _model);
			
			Console.WriteLine(found.Count());
			foreach (var f in found) {
				Console.WriteLine(f);
			}
		}

		[Test]
		public void 名前空間に対応する要素は必ず1() {
			var variableNodes = _model.Descendants<UnifiedVariableDefinition>();
			Console.WriteLine(variableNodes.Count() + " assertions");
			foreach (var vn in variableNodes) {
				var namespaceString = GetNamespace(vn).GetNamespaceString();
				Assert.That(FindUnifiedElementByNamespace(namespaceString, _model).Count(), Is.EqualTo(1));
			}
		}



		// element の種類によって，GetNamespace を使い分けるディスパッチャ
		// 関数名だけ変えて，ダッグタイピング的な
		public static Namespace Dispatcher(dynamic element) {
			return GetNamespace(element);
		}
		// node から親をたどって行って，types のうち一番早く見つかったものを返す．見つからなかったら null
		public static IUnifiedElement GetFirstFoundNode(UnifiedElement node, IEnumerable<IEnumerable<Type>> typeArray) {
			foreach (var ancestor in node.Ancestors()) {
				foreach (var types in typeArray) {
					foreach (var t in types) {
						if (ancestor.GetType().Equals(t)) {
							return ancestor;
						}
					}
				}
			}
			return null;

		}

		// 自分の親になりうる，かつ，名前空間構成要素になり得る要素タイプを返却する
		public static NamespaceType[] GetParentTypes(NamespaceType type) {
			switch(type) {
				case NamespaceType.Package:
					return new NamespaceType[] { };
				case NamespaceType.Class:
					return new NamespaceType[] { NamespaceType.Class, NamespaceType.Package };
				case NamespaceType.Function:
					return new NamespaceType[] { NamespaceType.Class, NamespaceType.Package, NamespaceType.Function};
				case NamespaceType.Variable:
					return new NamespaceType[] {NamespaceType.Class, NamespaceType.Function, NamespaceType.TemporaryScope};
				case NamespaceType.TemporaryScope:
					return new NamespaceType[] {NamespaceType.Function};
				default:
					throw new InvalidOperationException();

			}
		}

		// タイプから型へ変換（上へトラバースするときに使う）
		public static IEnumerable<Type> Namespace2UnifiedType(NamespaceType type) {
			switch(type) {
				case NamespaceType.Package:
					return new List<Type> { UnifiedNamespaceDefinition.Create().GetType() };
				case NamespaceType.Class:
					return new List<Type> { UnifiedClassDefinition.Create().GetType() };
				case NamespaceType.Function:
					return new List<Type> { UnifiedFunctionDefinition.Create().GetType() };
				case NamespaceType.TemporaryScope:
					return new List<Type> {
						UnifiedFor.Create().GetType(),
						UnifiedWhile.Create().GetType(),
						UnifiedDoWhile.Create().GetType(),
				};
				default:
					throw new InvalidOperationException();

			}
			
		}
	}

	// 名前空間オブジェクトを表すクラス
	public class Namespace {
		public Namespace Parent { get; set; }
		public string Value { get; set; }
		public NamespaceType NamespaceType { get; set; }

		public override string ToString() {
			return Value;
		}

		public override bool Equals(object obj) {
			if (obj is Namespace) {
				return this.GetNamespaceString().Equals(((Namespace)obj).GetNamespaceString());
			} else {
				return false;
			}
		}

		// 自分を含めて親を全部たどって，名前空間文字列くっつける
		public string GetNamespaceString(string originalDelimiter = ".") {
			var delimiter = "";
			var ns = "";
			var node = this;
			while(node != null) {
				ns = node.Value + delimiter + ns;
				node = node.Parent;
				delimiter = originalDelimiter;
			}

			return ns;
		}

		// 詳細名前空間文字列を生成する
		public string GetDetailedNamespaceString(string originalDelimiter = ".") {
			var delimiter = "";
			var ns = "";
			var node = this;
			while(node != null) {
				ns = node.Value + "[" + node.NamespaceType.ToString() + "]" + delimiter + ns;
				node = node.Parent;
				delimiter = originalDelimiter;
			}

			return ns;
			
		}
	}


	// 名前空間を作りうる言語要素
	public enum NamespaceType {
		Package, Class, Function, Variable, TemporaryScope
	}



}
