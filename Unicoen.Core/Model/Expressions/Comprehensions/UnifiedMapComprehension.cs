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
	///   辞書内包表記を表します．
	/// </summary>
	public class UnifiedMapComprehension : UnifiedExpression {
		private UnifiedKeyValue _element;

		/// <summary>
		///   辞書内包表記によって生成される要素部分の式を表します．
		/// </summary>
		public UnifiedKeyValue Element {
			get { return _element; }
			set { _element = SetChild(value, _element); }
		}

		private UnifiedSet<UnifiedExpression> _generator;

		/// <summary>
		///   辞書内包表記の集合を生成する式を表します．
		/// </summary>
		public UnifiedSet<UnifiedExpression> Generator {
			get { return _generator; }
			set { _generator = SetChild(value, _generator); }
		}

		private UnifiedMapComprehension() {}

		[DebuggerStepThrough]
		public override void Accept(UnifiedVisitor visitor) {
			visitor.Visit(this);
		}

		[DebuggerStepThrough]
		public override void Accept<TArg>(
				UnifiedVisitor<TArg> visitor, TArg arg) {
			visitor.Visit(this, arg);
		}

		[DebuggerStepThrough]
		public override TResult Accept<TArg, TResult>(
				UnifiedVisitor<TArg, TResult> visitor, TArg arg) {
			return visitor.Visit(this, arg);
		}

		public static UnifiedMapComprehension Create(
				UnifiedKeyValue element = null,
				UnifiedSet<UnifiedExpression> generator = null) {
			return new UnifiedMapComprehension {
					Element = element,
					Generator = generator,
			};
		}
	}
}