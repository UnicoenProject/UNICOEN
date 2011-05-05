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
	///   辞書リテラルにおけるキー/バリューペアを表します．
	/// </summary>
	public class UnifiedKeyValue : UnifiedElement, IUnifiedExpression {
		private IUnifiedExpression _key;

		/// <summary>
		///   辞書リテラルにおけるキーを表します．
		///   e.g. Pythonにおける<c>{ "key" : 1 }</c>の<c>"key"</c>
		/// </summary>
		public IUnifiedExpression Key {
			get { return _key; }
			set { _key = SetParentOfChild(value, _key); }
		}

		private IUnifiedExpression _value;

		/// <summary>
		///   辞書リテラルにおけるバリューを表します．
		///   e.g. Pythonにおける<c>{ "key" : 1 }</c>の<c>1</c>
		/// </summary>
		public IUnifiedExpression Value {
			get { return _value; }
			set { _value = SetParentOfChild(value, _value); }
		}

		private UnifiedKeyValue() {}

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
			yield return Key;
		}

		public override IEnumerable<ElementReference>
				GetElementAndSetters() {
			yield return ElementReference.Create
					(() => Key, v => Key = (IUnifiedExpression)v);
		}

		public override IEnumerable<ElementReference>
				GetElementAndDirectSetters() {
			yield return ElementReference.Create
					(() => _key, v => _key = (IUnifiedExpression)v);
		}

		public static UnifiedKeyValue Create(
				IUnifiedExpression key, IUnifiedExpression value) {
			return new UnifiedKeyValue {
					Key = key,
					Value = value,
			};
		}

		public static UnifiedKeyValue Create(
				Tuple<IUnifiedExpression, IUnifiedExpression> keyValue) {
			return new UnifiedKeyValue {
					Key = keyValue.Item1,
					Value = keyValue.Item2,
			};
		}
	}
}