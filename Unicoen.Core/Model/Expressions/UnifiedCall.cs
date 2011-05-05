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
using Unicoen.Core.Visitors;

namespace Unicoen.Core.Model {
	/// <summary>
	///   関数呼び出しを表します。
	///   e.g. Javaにおける<c>method(a, b, c)</c>
	/// </summary>
	public class UnifiedCall : UnifiedElement, IUnifiedExpression {
		private IUnifiedExpression _function;

		public IUnifiedExpression Function {
			get { return _function; }
			set { _function = SetParentOfChild(value, _function); }
		}

		private UnifiedTypeArgumentCollection _typeArguments;

		public UnifiedTypeArgumentCollection TypeArguments {
			get { return _typeArguments; }
			set { _typeArguments = SetParentOfChild(value, _typeArguments); }
		}

		private UnifiedArgumentCollection _arguments;

		/// <summary>
		///   実引数の集合を表します
		///   e.g. Javaにおける<c>method(a, b, c)</c>の<c>a, b, c</c>の部分
		/// </summary>
		public UnifiedArgumentCollection Arguments {
			get { return _arguments; }
			set { _arguments = SetParentOfChild(value, _arguments); }
		}

		private UnifiedCall() {}

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

		public override IEnumerable<IUnifiedElement> GetElements() {
			yield return Function;
			yield return TypeArguments;
			yield return Arguments;
		}

		public override IEnumerable<ElementReference>
				GetElementAndSetters() {
			yield return ElementReference.Create
					(() => Function, v => Function = (IUnifiedExpression)v);
			yield return ElementReference.Create
					(() => TypeArguments, v => TypeArguments = (UnifiedTypeArgumentCollection)v);
			yield return ElementReference.Create
					(() => Arguments, v => Arguments = (UnifiedArgumentCollection)v);
		}

		public override IEnumerable<ElementReference>
				GetElementAndDirectSetters() {
			yield return ElementReference.Create
					(() => _function, v => _function = (IUnifiedExpression)v);
			yield return ElementReference.Create
					(() => _typeArguments, v => _typeArguments = (UnifiedTypeArgumentCollection)v);
			yield return ElementReference.Create
					(() => _arguments, v => _arguments = (UnifiedArgumentCollection)v);
		}

		public static UnifiedCall Create(
				IUnifiedExpression target,
				UnifiedArgumentCollection args) {
			return new UnifiedCall {
					Function = target,
					Arguments = args,
			};
		}

		public static UnifiedCall Create(
				IUnifiedExpression target,
				UnifiedArgumentCollection args,
				UnifiedTypeArgumentCollection typeArguments) {
			return new UnifiedCall {
					Function = target,
					Arguments = args,
					TypeArguments = typeArguments
			};
		}
	}
}