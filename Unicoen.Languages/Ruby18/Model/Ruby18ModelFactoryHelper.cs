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
using System.Diagnostics.Contracts;
using System.Linq;
using System.Xml.Linq;
using UniUni.Xml.Linq;
using Unicoen.Model;

// ReSharper disable InvocationIsSkipped

namespace Unicoen.Languages.Ruby18.Model {
	public partial class Ruby18ModelFactoryHelper {
		private static readonly Dictionary<string, Func<XElement, IUnifiedExpression>>
				ExpressionFuncs;

		static Ruby18ModelFactoryHelper() {
			ExpressionFuncs =
					new Dictionary<string, Func<XElement, IUnifiedExpression>>();
			InitializeExpressions();
			InitializeLiterals();
		}

		public static UnifiedProgram CreateProgram(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "block");
			return UnifiedProgram.Create(CreateBlock(node));
		}

		public static UnifiedParameterCollection CreateArgs(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "args");
			Contract.Requires(
					node.Elements().All(e => e.Name() == "Symbol" || e.Name() == "block"));
			var args = node.Elements("Symbol")
					.Select(e => e.Value.ToVariableIdentifier().ToParameter())
					.ToCollection();
			if (node.LastElement().Name.LocalName == "block") {
				// デフォルト引数付き
				var asgnNodes = node.LastElement().Elements();
				foreach (var asgnNode in asgnNodes) {
					var name = asgnNode.FirstElement().Value;
					args.First(arg => arg.Names[0].Name == name)
							.DefaultValue = CreateExpresion(asgnNode.NthElement(1));
				}
			}
			return args;
		}

		public static IEnumerable<UnifiedVariableIdentifier> CreateLasgnOrMasgn(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "lasgn" || node.Name() == "masgn");
			Contract.Requires(node.Elements().Count() == 1);
			Contract.Requires(
					node.Name() != "masgn" || node.FirstElement().Name() == "array");
			return node.Descendants("Symbol")
					.Select(CreateSymbol);
		}

		public static UnifiedArgumentCollection CreateArglist(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "arglist");
			return node.Elements()
					.Select(e => CreateExpresion(e).ToArgument())
					.ToCollection();
		}
	}
}