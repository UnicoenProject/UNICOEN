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
	///   配列の生成を含むコンストラクタ呼び出しを表します。
	///   e.g. Javaにおける<c>Object o = new Object();</c>の<c>new Object()</c>の部分
	/// </summary>
	public class UnifiedNew : UnifiedExpressionWithBlock {
		private IUnifiedExpression _target;

		public IUnifiedExpression Target {
			get { return _target; }
			set { _target = SetChild(value, _target); }
		}

		private UnifiedArgumentCollection _arguments;

		public UnifiedArgumentCollection Arguments {
			get { return _arguments; }
			set { _arguments = SetChild(value, _arguments); }
		}

		private UnifiedTypeArgumentCollection _typeArguments;

		public UnifiedTypeArgumentCollection TypeArguments {
			get { return _typeArguments; }
			set { _typeArguments = SetChild(value, _typeArguments); }
		}

		private UnifiedArray _initialValue;

		/// <summary>
		///   配列生成時の初期値を表します。
		///   e.g. Javaにおける<c>new int[10] { 0, 1 }</c>の<c>{ 0, 1 }</c>部分
		/// </summary>
		public UnifiedArray InitialValue {
			get { return _initialValue; }
			set { _initialValue = SetChild(value, _initialValue); }
		}

		private UnifiedNew() {}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override void Accept<TData>(
				IUnifiedModelVisitor<TData> visitor,
				TData arg) {
			visitor.Visit(this, arg);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData arg) {
			return visitor.Visit(this, arg);
		}

		public static UnifiedNew Create(
				IUnifiedExpression target = null,
				UnifiedArgumentCollection arguments = null,
				UnifiedTypeArgumentCollection typeArguments = null,
				UnifiedArray initialValues = null,
				UnifiedBlock body = null) {
			return new UnifiedNew {
					Target = target,
					Arguments = arguments,
					TypeArguments = typeArguments,
					InitialValue = initialValues,
					Body = body,
			};
		}
	}
}