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
	///   辞書リテラルを表します．
	/// </summary>
	internal class UnifiedDictonary : UnifiedElement, IUnifiedExpression {
		private UnifiedKeyValueCollection _keyValues;

		/// <summary>
		///   辞書を構成する要素の集合を表します．
		/// </summary>
		public UnifiedKeyValueCollection KeyValues {
			get { return _keyValues; }
			set { _keyValues = SetParentOfChild(value, _keyValues); }
		}

		private UnifiedDictonary() {}

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
			yield return KeyValues;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(KeyValues, v => KeyValues = (UnifiedKeyValueCollection)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndDirectSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_keyValues, v => _keyValues = (UnifiedKeyValueCollection)v);
		}

		public static UnifiedDictonary Create(
				UnifiedKeyValueCollection keyValues) {
			return new UnifiedDictonary {
					KeyValues = keyValues,
			};
		}
	}
}