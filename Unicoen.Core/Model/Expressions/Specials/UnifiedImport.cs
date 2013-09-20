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

using System.Diagnostics;
using Unicoen.Processor;

namespace Unicoen.Model {
	/// <summary>
	///   使用する名前空間の指定や外部ファイルの読み込みを表します。 e.g. Javaにおける <c>import package;</c> e.g. C#における <c>using Gen = System.Collections.Generic</c> e.g. Pythonにおける <c>import sys</c> e.g. Pythonにおける <c>from lib.package import func as f</c>
	/// </summary>
	public class UnifiedImport : UnifiedExpression {
		private UnifiedExpression _member;

		/// <summary>
		///   Pythonにおいてパッケージ名を省略して使用できるようにする変数もしくは関数名 e.g. Pythonにおける <c>from lib.package import func as f</c> の <c>func</c>
		/// </summary>
		public UnifiedExpression Member {
			get { return _member; }
			set { _member = SetChild(value, _member); }
		}

		private UnifiedExpression _name;

		/// <summary>
		///   使用する名前空間や関数名を表します． e.g. Javaにおける <c>import package;</c> の <c>package</c> e.g. C#における <c>using Gen = System.Collections.Generic</c> の <c>System.Collections.Generic</c> e.g. Pythonにおける <c>import sys</c> の <c>sys</c> e.g. Pythonにおける <c>from lib.package import funcas f</c> の <c>lib.package</c>
		/// </summary>
		public UnifiedExpression Name {
			get { return _name; }
			set { _name = SetChild(value, _name); }
		}

		private UnifiedIdentifier _alias;

		/// <summary>
		///   使用する名前空間や関数名のエイリアスを表します． e.g. C#における <c>using Gen = System.Collections.Generic</c> の <c>Gen</c> e.g. Pythonにおける <c>from lib.package import funcas f</c> の <c>f</c>
		/// </summary>
		public UnifiedIdentifier Alias {
			get { return _alias; }
			set { _alias = SetChild(value, _alias); }
		}

		private UnifiedSet<UnifiedModifier> _modifiers;

		public UnifiedSet<UnifiedModifier> Modifiers {
			get { return _modifiers; }
			set { _modifiers = SetChild(value, _modifiers); }
		}

		private UnifiedImport() {}

		[DebuggerStepThrough]
		public override void Accept(UnifiedVisitor visitor) {
			visitor.Visit(this);
		}

		[DebuggerStepThrough]
		public override void Accept<TArg>(
				UnifiedVisitor<TArg> visitor,
				TArg arg) {
			visitor.Visit(this, arg);
		}

		[DebuggerStepThrough]
		public override TResult Accept<TArg, TResult>(
				UnifiedVisitor<TArg, TResult> visitor, TArg arg) {
			return visitor.Visit(this, arg);
		}

		public static UnifiedImport Create(
				UnifiedExpression name = null, string alias = null,
				UnifiedExpression member = null,
				UnifiedSet<UnifiedModifier> modifiers = null) {
			return new UnifiedImport {
					Member = member,
					Name = name,
					Alias = alias != null
					        		? UnifiedVariableIdentifier.Create(alias)
					        		: null,
					Modifiers = modifiers,
			};
		}
	}
}