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
using System.Diagnostics.Contracts;
using Unicoen.Processor;

namespace Unicoen.Model {
	public class UnifiedGoto : UnifiedExpression {
		private UnifiedExpression _target;

		public UnifiedExpression Target {
			get { return _target; }
			set { _target = SetChild(value, _target); }
		}

		protected UnifiedGoto() {}

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

		public static UnifiedGoto Create(UnifiedLabelIdentifier target) {
			Contract.Requires(target != null);
			return new UnifiedGoto {
					Target = target,
			};
		}

		public static UnifiedGoto Create(string target) {
			Contract.Requires(target != null);
			return new UnifiedGoto {
					Target = UnifiedLabelIdentifier.Create(target),
			};
		}

		public static UnifiedGoto Create(UnifiedCase target) {
			Contract.Requires(target != null);
			return new UnifiedGoto {
					Target = target,
			};
		}
	}
}