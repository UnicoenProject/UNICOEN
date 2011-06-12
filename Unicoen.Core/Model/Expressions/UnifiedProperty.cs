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
	///   フィールド、メンバー、プロパティなどへのアクセス式を表します。
	///   e.g. Javaにおける<c>int a = b.c;</c>の<c>b.c</c>
	///   e.g. Javaにおける<c>Package.ClassA a = null;</c>の<c>Package.ClassA</c>
	///   e.g. Javaにおける<c>import Package.SubPackage;</c>の<c>Package.SubPackage</c>
	/// </summary>
	public class UnifiedProperty : UnifiedElement, IUnifiedExpression {
		private IUnifiedExpression _owner;

		public IUnifiedExpression Owner {
			get { return _owner; }
			set { _owner = SetChild(value, _owner); }
		}

		private IUnifiedExpression _name;

		public IUnifiedExpression Name {
			get { return _name; }
			set { _name = SetChild(value, _name); }
		}

		public string Delimiter { get; set; }

		private UnifiedProperty() {}

		public override void Accept(IUnifiedVisitor visitor) {
			visitor.Visit(this);
		}

		public override void Accept<TArg>(
				IUnifiedVisitor<TArg> visitor,
				TArg arg) {
			visitor.Visit(this, arg);
		}

		public override TResult Accept<TResult, TArg>(
				IUnifiedVisitor<TResult, TArg> visitor, TArg arg) {
			return visitor.Visit(this, arg);
		}

		public static UnifiedProperty Create(
				IUnifiedExpression owner = null,
				IUnifiedExpression name = null,
				string delimiter = null) {
			return new UnifiedProperty {
					Owner = owner,
					Name = name,
					Delimiter = delimiter,
			};
		}
	}
}