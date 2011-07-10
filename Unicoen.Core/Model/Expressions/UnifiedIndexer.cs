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

using Unicoen.Core.Processor;

namespace Unicoen.Core.Model {
	/// <summary>
	///   配列の添え字を表します。
	///   e.g. Javaにおける<c>int x = a[10]</c>の<c>[10]</c>
	/// </summary>
	public class UnifiedIndexer : UnifiedElement, IUnifiedExpression {
		private IUnifiedExpression _target;

		public IUnifiedExpression Target {
			get { return _target; }
			set { _target = SetChild(value, _target); }
		}

		private UnifiedArgumentCollection _arguments;

		public UnifiedArgumentCollection Arguments {
			get { return _arguments; }
			set { _arguments = SetChild(value, _arguments); }
		}

		private UnifiedIndexer() {}

		public override void Accept(IUnifiedVisitor visitor) {
			visitor.Visit(this);
		}

		public override void Accept<TArg>(
				IUnifiedVisitor<TArg> visitor,
				TArg arg) {
			visitor.Visit(this, arg);
		}

		public override TResult Accept<TArg, TResult>(
				IUnifiedVisitor<TArg, TResult> visitor, TArg arg) {
			return visitor.Visit(this, arg);
		}

		public static UnifiedIndexer Create(
				IUnifiedExpression current = null,
				UnifiedArgumentCollection create = null) {
			return new UnifiedIndexer {
					Target = current,
					Arguments = create
			};
		}
	}
}