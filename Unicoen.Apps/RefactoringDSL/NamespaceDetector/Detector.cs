using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unicoen.Apps.RefactoringDSL.Util;
using Unicoen.Model;

namespace Unicoen.Apps.RefactoringDSL.NamespaceDetector {
	class Detector {
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

		public static Namespace GetNamespace(UnifiedClassDefinition classNode) {
			var type = NamespaceType.Class;
			var className = classNode.FirstDescendant<UnifiedVariableIdentifier>().Name;
			var parents = Helper.GetParentTypes(type).Select(t => Helper.Namespace2UnifiedType(t));
			var parentNode = Helper.GetFirstFoundNode(classNode, parents);

			return new Namespace() {
				Value = className,
				NamespaceType = type,
				Parent = Dispatcher(parentNode),
			};

		}

		public static Namespace GetNamespace(UnifiedFunctionDefinition functionNode) {
			var type = NamespaceType.Function;
			var functionName = functionNode.Name.Name;
			var parents = Helper.GetParentTypes(type).Select(t => Helper.Namespace2UnifiedType(t));
			var parentNode = Helper.GetFirstFoundNode(functionNode, parents);

			return new Namespace() {
				Value = functionName,
				NamespaceType = type,
				Parent = Dispatcher(parentNode),
			};
		}

		public static Namespace GetNamespace(UnifiedVariableDefinition variableNode) {
			var type = NamespaceType.Variable;
			var variableName = variableNode.Name.Name;
			var parents = Helper.GetParentTypes(type).Select(t => Helper.Namespace2UnifiedType(t));
			var parentNode = Helper.GetFirstFoundNode(variableNode, parents);

			return new Namespace() {
				Value = variableName,
				NamespaceType = type,
				Parent = Dispatcher(parentNode),
			};
		}

		public static Namespace GetNamespace(UnifiedFor forNode) {
			var type = NamespaceType.TemporaryScope;
			var parents = Helper.GetParentTypes(type).Select(t => Helper.Namespace2UnifiedType(t));
			var parentNode = Helper.GetFirstFoundNode(forNode, parents);
			return new Namespace() {
				Value = "(for)",
				NamespaceType = type,
				Parent = Dispatcher(parentNode)
			};
		}

		public static Namespace GetNamespace(UnifiedWhile whileNode) {
			var type = NamespaceType.TemporaryScope;
			var parents = Helper.GetParentTypes(type).Select(t => Helper.Namespace2UnifiedType(t));
			var parentNode = Helper.GetFirstFoundNode(whileNode, parents);
			return new Namespace() {
				Value = "(while)",
				NamespaceType = type,
				Parent = Dispatcher(parentNode)
			};
		}

		public static Namespace GetNamespace(UnifiedDoWhile dowhileNode) {
			return null;
			throw new NotImplementedException();			
		}

		// ディスパッチ先がなかった時用
		public static Namespace GetNamespace(UnifiedElement element) {
			return null;
		}

		// element の種類によって，GetNamespace を使い分けるディスパッチャ
		// 関数名だけ変えて，ダッグタイピング的な
		public static Namespace Dispatcher(dynamic element) {
			return GetNamespace(element);
		}

	}
}
