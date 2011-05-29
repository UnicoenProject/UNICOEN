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

using Unicoen.Core.Visitors;

namespace Unicoen.Core.Model {
	/// <summary>
	///   型を表します。
	///   Javaにおける<c>int, double, char</c>
	/// </summary>
	public class UnifiedSimpleType : UnifiedType {
		// パッケージ名が付いているときに
		// UnifiedProperty が name に入る時があるので
		// isntace.Class
		private IUnifiedExpression _nameExpression;

		/// <summary>
		///   型の名前を表します．
		///   e.g. Javaにおける<c>Package.ClassA instance = null;</c>の<c>Package.ClassA</c>(UnifiedPropertyで表現される)
		/// </summary>
		public override IUnifiedExpression NameExpression {
			get { return _nameExpression; }
			set { _nameExpression = SetChild(value, _nameExpression); }
		}

		internal UnifiedSimpleType() {}

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
	}
}