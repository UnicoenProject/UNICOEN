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
	public class UnifiedThrow : UnifiedExpression {
		private UnifiedExpression _value;

		public UnifiedExpression Value {
			get { return _value; }
			set { _value = SetChild(value, _value); }
		}

		private UnifiedExpression _data;

		public UnifiedExpression Data {
			get { return _data; }
			set { _data = SetChild(value, _data); }
		}

		private UnifiedExpression _trace;

		public UnifiedExpression Trace {
			get { return _trace; }
			set { _trace = SetChild(value, _trace); }
		}

		protected UnifiedThrow() {}

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

		public static UnifiedThrow Create(
				UnifiedExpression value = null,
				UnifiedExpression data = null,
				UnifiedExpression trace = null
				) {
			return new UnifiedThrow {
					Value = value,
					Data = data,
					Trace = trace,
			};
		}
	}
}