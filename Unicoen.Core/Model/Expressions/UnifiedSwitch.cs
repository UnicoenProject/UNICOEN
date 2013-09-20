#region License

// Copyright (C) 2011-2012 The Unicoen Project
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

using System.Diagnostics;
using Unicoen.Processor;

namespace Unicoen.Model {
	/// <summary>
	///   switch文を表します。 e.g. Javaにおける <c>switch(v){...}</c>
	/// </summary>
	public class UnifiedSwitch : UnifiedExpression {
		private UnifiedExpression _value;

		/// <summary>
		///   caseの分岐に使用される式を表します e.g. Javaにおける <c>switch(v){...}</c> の <c>v</c>
		/// </summary>
		public UnifiedExpression Value {
			get { return _value; }
			set { _value = SetChild(value, _value); }
		}

		private UnifiedSet<UnifiedCase> _cases;

		/// <summary>
		///   switch文に付随するcase節の集合を表します
		/// </summary>
		public UnifiedSet<UnifiedCase> Cases {
			get { return _cases; }
			set { _cases = SetChild(value, _cases); }
		}

		private UnifiedSwitch() {}

		public UnifiedSwitch AddToCases(UnifiedCase kase) {
			Cases.Add(kase);
			return this;
		}

		[DebuggerStepThrough]
		public override void Accept(UnifiedVisitor visitor) {
			visitor.Visit(this);
		}

		[DebuggerStepThrough]
		public override void Accept<TArg>(
				UnifiedVisitor<TArg> visitor,
				TArg arg) {
			visitor.Visit(this, arg);
		}

		[DebuggerStepThrough]
		public override TResult Accept<TArg, TResult>(
				UnifiedVisitor<TArg, TResult> visitor, TArg arg) {
			return visitor.Visit(this, arg);
		}

		public static UnifiedSwitch Create(
				UnifiedExpression value = null,
				UnifiedSet<UnifiedCase> cases = null) {
			return new UnifiedSwitch {
					Value = value,
					Cases = cases,
			};
		}
	}
}