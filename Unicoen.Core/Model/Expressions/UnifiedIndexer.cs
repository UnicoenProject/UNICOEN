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
	/// 配列の添え字を表します。
	/// e.g. Javaにおける <c>int x = a[10][5]</c> の <c>[10][5]</c>
	/// e.g. C#における <c>int x = a[1, 2]</c> の <c>[1, 2]</c>
	/// </summary>
	public class UnifiedIndexer : UnifiedExpression {
		private UnifiedExpression _target;

		public UnifiedExpression Target {
			get { return _target; }
			set { _target = SetChild(value, _target); }
		}

		private UnifiedSet<UnifiedArgument> _arguments;

		/// <summary>
		/// 配列の添え字を表します。
		/// e.g. Javaにおける <c>a[10][5]</c> の <c>[10]</c>と<c>[5]</c>
		/// e.g. C#における <c>a[1, 2]</c> の <c>[1, 2]</c>
		/// </summary>
		public UnifiedSet<UnifiedArgument> Arguments {
			get { return _arguments; }
			set { _arguments = SetChild(value, _arguments); }
		}

		private UnifiedIndexer() {}

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

		public static UnifiedIndexer Create(
				UnifiedExpression current = null,
				UnifiedSet<UnifiedArgument> create = null) {
			return new UnifiedIndexer {
					Target = current,
					Arguments = create
			};
		}
	}
}