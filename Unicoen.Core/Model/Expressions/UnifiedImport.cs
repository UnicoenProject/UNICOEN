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

using Unicoen.Core.Processor;

namespace Unicoen.Core.Model {
	/// <summary>
	///   使用する名前空間の指定や外部ファイルの読み込みを表します。
	///   e.g. Javaにおける<c>import package;</c>
	/// </summary>
	public class UnifiedImport : UnifiedElement, IUnifiedExpression {
		private IUnifiedExpression _from;

		public IUnifiedExpression From {
			get { return _from; }
			set { _from = SetChild(value, _from); }
		}

		private IUnifiedExpression _name;

		public IUnifiedExpression Name {
			get { return _name; }
			set { _name = SetChild(value, _name); }
		}

		private UnifiedIdentifier _alias;

		public UnifiedIdentifier Alias {
			get { return _alias; }
			set { _alias = SetChild(value, _alias); }
		}

		private UnifiedModifierCollection _modifiers;

		public UnifiedModifierCollection Modifiers {
			get { return _modifiers; }
			set { _modifiers = SetChild(value, _modifiers); }
		}

		private UnifiedImport() {}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override void Accept<TData>(
				IUnifiedModelVisitor<TData> visitor,
				TData state) {
			visitor.Visit(this, state);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData state) {
			return visitor.Visit(this, state);
		}

		public static UnifiedImport Create(
				IUnifiedExpression from = null,
				IUnifiedExpression name = null,
				string alias = null,
				UnifiedModifierCollection modifiers = null) {
			return new UnifiedImport {
					From = from,
					Name = name,
					Alias = alias != null
					        		? UnifiedIdentifier.Create(alias, UnifiedIdentifierKind.Unknown)
					        		: null,
					Modifiers = modifiers,
			};
		}
	}
}