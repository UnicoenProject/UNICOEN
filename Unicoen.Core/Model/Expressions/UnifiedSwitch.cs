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

using System.Collections.Generic;
using Unicoen.Core.Visitors;

namespace Unicoen.Core.Model {
	/// <summary>
	///   switch文を表します。
	///   e.g. Javaにおける<c>switch(v){...}</c>
	/// </summary>
	public class UnifiedSwitch : UnifiedElement, IUnifiedExpression {
		private IUnifiedExpression _value;

		/// <summary>
		///   caseの分岐に使用される式を表します
		///   e.g. Javaにおける<c>switch(v){...}</c>の<c>v</c>
		/// </summary>
		public IUnifiedExpression Value {
			get { return _value; }
			set { _value = SetParentOfChild(value, _value); }
		}

		private UnifiedCaseCollection _cases;

		/// <summary>
		///   switch文に付随するcase節の集合を表します
		/// </summary>
		public UnifiedCaseCollection Cases {
			get { return _cases; }
			set { _cases = SetParentOfChild(value, _cases); }
		}

		private UnifiedSwitch() {}

		public UnifiedSwitch AddToCases(UnifiedCase kase) {
			Cases.Add(kase);
			return this;
		}

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
			yield return Value;
			yield return Cases;
		}

		public override IEnumerable<ElementReference>
				GetElementReferences() {
			yield return ElementReference.Create
					(() => Value, v => Value = (IUnifiedExpression)v);
			yield return ElementReference.Create
					(() => Cases, v => Cases = (UnifiedCaseCollection)v);
		}

		public override IEnumerable<ElementReference>
				GetElementReferenecesOfPrivateFields() {
			yield return ElementReference.Create
					(() => _value, v => _value = (IUnifiedExpression)v);
			yield return ElementReference.Create
					(() => _cases, v => _cases = (UnifiedCaseCollection)v);
		}

		public static UnifiedSwitch Create(IUnifiedExpression value) {
			return new UnifiedSwitch {
					Value = value,
			};
		}

		public static UnifiedSwitch Create(
				IUnifiedExpression value,
				UnifiedCaseCollection cases) {
			return new UnifiedSwitch {
					Value = value,
					Cases = cases,
			};
		}
	}
}