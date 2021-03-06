﻿#region License

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
	///   スライス表記を表します． e.g. Pythonにおける <c>[0 : 10 : 2]</c>
	/// </summary>
	public class UnifiedSlice : UnifiedExpression {
		private UnifiedExpression _start;

		/// <summary>
		///   開始インデックスを表します． e.g. Pythonにおける <c>[0 : 10 : 2]</c> の <c>0</c>
		/// </summary>
		public UnifiedExpression Start {
			get { return _start; }
			set { _start = SetChild(value, _start); }
		}

		private UnifiedExpression _end;

		/// <summary>
		///   終了インデックスを表します． e.g. Pythonにおける <c>[0 : 10 : 2]</c> の <c>10</c>
		/// </summary>
		public UnifiedExpression End {
			get { return _end; }
			set { _end = SetChild(value, _end); }
		}

		private UnifiedExpression _step;

		/// <summary>
		///   ステップを表します． e.g. Pythonにおける <c>[0 : 10 : 2]</c> の <c>2</c>
		/// </summary>
		public UnifiedExpression Step {
			get { return _step; }
			set { _step = SetChild(value, _step); }
		}

		private UnifiedSlice() {}

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

		public static UnifiedSlice Create(
				UnifiedExpression initializer = null,
				UnifiedExpression condition = null,
				UnifiedExpression step = null) {
			return new UnifiedSlice {
					Start = initializer,
					End = condition,
					Step = step,
			};
		}
	}
}