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
	///   辞書リテラルにおけるキー/バリューペアを表します．
	/// </summary>
	public class UnifiedKeyValue : UnifiedExpression {
		private UnifiedExpression _key;

		/// <summary>
		///   辞書リテラルにおけるキーを表します． e.g. Pythonにおける <c>{ "key" : 1 }</c> の <c>"key"</c>
		/// </summary>
		public UnifiedExpression Key {
			get { return _key; }
			set { _key = SetChild(value, _key); }
		}

		private UnifiedExpression _value;

		/// <summary>
		///   辞書リテラルにおけるバリューを表します． e.g. Pythonにおける <c>{ "key" : 1 }</c> の <c>1</c>
		/// </summary>
		public UnifiedExpression Value {
			get { return _value; }
			set { _value = SetChild(value, _value); }
		}

		private UnifiedKeyValue() {}

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

		public static UnifiedKeyValue Create(
				UnifiedExpression key = null,
				UnifiedExpression value = null) {
			return new UnifiedKeyValue {
					Key = key,
					Value = value,
			};
		}
	}
}