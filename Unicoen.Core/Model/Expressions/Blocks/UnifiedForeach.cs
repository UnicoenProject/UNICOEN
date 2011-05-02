﻿#region License

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
	///   foreach文あるいは拡張for文を表します。
	///   e.g. Javaにおける<c>for(int n : array){...}</c>やC#における<c>foreach(var n in array){...}</c>
	/// </summary>
	public class UnifiedForeach : UnifiedExpressionWithBlock<UnifiedForeach> {
		private UnifiedVariableDefinition _element;

		/// <summary>
		/// 集合から取り出した要素を表します
		/// e.g. Javaにおける<c>for(int n : array){...}</c>の<c>int n</c>
		/// </summary>
		public UnifiedVariableDefinition Element {
			get { return _element; }
			set { _element = SetParentOfChild(value, _element); }
		}

		private IUnifiedExpression _set;

		/// <summary>
		/// 対象の集合を表します
		/// e.g. Javaにおける<c>for(int n : array){...}</c>の<c>array</c>
		/// </summary>
		public IUnifiedExpression Set {
			get { return _set; }
			set { _set = SetParentOfChild(value, _set); }
		}

		private UnifiedBlock _elseBody;

		public UnifiedBlock ElseBody {
			get { return _elseBody; }
			set { _elseBody = SetParentOfChild(value, _elseBody); }
		}

		private UnifiedForeach() {}

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
			yield return Element;
			yield return Set;
			yield return ElseBody;
			yield return Body;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Element, v => Element = (UnifiedVariableDefinition)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Set, v => Set = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(ElseBody, v => ElseBody = (UnifiedBlock)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Body, v => Body = (UnifiedBlock)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndDirectSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_element, v => _element = (UnifiedVariableDefinition)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_set, v => _set = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_elseBody, v => _elseBody = (UnifiedBlock)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_body, v => _body = (UnifiedBlock)v);
		}

		public static UnifiedForeach Create(
				UnifiedVariableDefinition element,
				IUnifiedExpression set) {
			return Create(element, set, null, null);
		}

		public static UnifiedForeach Create(
				UnifiedVariableDefinition element,
				IUnifiedExpression set, UnifiedBlock body) {
			return Create(element, set, body, null);
		}

		public static UnifiedForeach Create(UnifiedVariableDefinition element, IUnifiedExpression set, UnifiedBlock body, UnifiedBlock elseBody) {
			return new UnifiedForeach {
					Element = element,
					Set = set,
					Body = body,
					ElseBody = elseBody,
			};
		}
	}
}