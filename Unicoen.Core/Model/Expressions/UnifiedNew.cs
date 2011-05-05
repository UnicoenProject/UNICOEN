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
	///   配列の生成を含むコンストラクタ呼び出しを表します。
	///   e.g. Javaにおける<c>Object o = new Object();</c>の<c>new Object()</c>の部分
	/// </summary>
	public class UnifiedNew : UnifiedExpressionWithBlock<UnifiedNew> {
		private IUnifiedExpression _target;

		public IUnifiedExpression Target {
			get { return _target; }
			set { _target = SetParentOfChild(value, _target); }
		}

		private UnifiedArgumentCollection _arguments;

		public UnifiedArgumentCollection Arguments {
			get { return _arguments; }
			set { _arguments = SetParentOfChild(value, _arguments); }
		}

		private UnifiedTypeArgumentCollection _typeArguments;

		public UnifiedTypeArgumentCollection TypeArguments {
			get { return _typeArguments; }
			set { _typeArguments = SetParentOfChild(value, _typeArguments); }
		}

		private UnifiedExpressionList _initialValue;

		/// <summary>
		///   配列生成時の初期値を表します。
		///   e.g. Javaにおける<c>new int[10] { 0, 1 }</c>の<c>{ 0, 1 }</c>部分
		/// </summary>
		public UnifiedExpressionList InitialValue {
			get { return _initialValue; }
			set { _initialValue = SetParentOfChild(value, _initialValue); }
		}

		private UnifiedNew() {}

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
			yield return Target;
			yield return Arguments;
			yield return TypeArguments;
			yield return InitialValue;
			yield return Body;
		}

		public override IEnumerable<ElementReference>
				GetElementAndSetters() {
			yield return
					ElementReference.Create(
							() => Target,
							v => Target = (UnifiedType)v);
			yield return
					ElementReference.Create(
							() => Arguments,
							v => Arguments = (UnifiedArgumentCollection)v);
			yield return
					ElementReference.Create(
							() => TypeArguments,
							v => TypeArguments = (UnifiedTypeArgumentCollection)v);
			yield return
					ElementReference.Create(
							() => InitialValue,
							v => InitialValue = (UnifiedExpressionList)v);
			yield return
					ElementReference.Create(
							() => Body,
							v => Body = (UnifiedBlock)v);
		}

		public override IEnumerable<ElementReference>
				GetElementAndDirectSetters() {
			yield return
					ElementReference.Create(
							() => _target,
							v => _target = (UnifiedType)v);
			yield return
					ElementReference.Create(
							() => _arguments,
							v => _arguments = (UnifiedArgumentCollection)v);
			yield return
					ElementReference.Create(
							() => _typeArguments,
							v => _typeArguments = (UnifiedTypeArgumentCollection)v);
			yield return
					ElementReference.Create(
							() => _initialValue,
							v => _initialValue = (UnifiedExpressionList)v);
			yield return
					ElementReference.Create(
							() => _body,
							v => _body = (UnifiedBlock)v);
		}

		public static UnifiedNew Create(IUnifiedExpression target) {
			return Create(target, null, null, null, null);
		}

		public static UnifiedNew Create(
				IUnifiedExpression target,
				UnifiedArgumentCollection arguments) {
			return Create(target, arguments, null, null, null);
		}

		public static UnifiedNew Create(
				IUnifiedExpression target,
				UnifiedBlock body) {
			return new UnifiedNew {
					Target = target,
					Arguments = null,
					Body = body
			};
		}

		public static UnifiedNew Create(
				IUnifiedExpression target,
				UnifiedArgumentCollection arguments,
				UnifiedExpressionList initialValues) {
			return Create(target, arguments, null, initialValues, null);
		}

		public static UnifiedNew Create(
				IUnifiedExpression target,
				UnifiedArgumentCollection arguments,
				UnifiedTypeArgumentCollection typeArguments,
				UnifiedExpressionList initialValues,
				UnifiedBlock body) {
			return new UnifiedNew {
					Target = target,
					Arguments = arguments,
					TypeArguments = typeArguments,
					InitialValue = initialValues,
					Body = body,
			};
		}

		public static UnifiedNew CreateArray(string name, UnifiedArgument argument) {
			return Create(
					UnifiedType.CreateUsingString(
							name,
							null,
							UnifiedTypeSupplementCollection.Create(
									UnifiedTypeSupplement.CreateArray(argument))));
		}

		public static UnifiedNew CreateArray(UnifiedExpressionList initialValues) {
			return Create(
					UnifiedType.CreateUsingString(
							null,
							null,
							UnifiedTypeSupplementCollection.Create(
									UnifiedTypeSupplement.CreateArray())),
					null,
					null,
					initialValues,
					null);
		}
	}
}