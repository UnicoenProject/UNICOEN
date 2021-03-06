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
	///   単項演算子を表します。 e.g. Javaにおける <c>^a</c> の <c>^</c> e.g. Javaにおける <c>b++</c> の <c>++</c>
	/// </summary>
	public class UnifiedUnaryOperator : UnifiedElement {
		public string Sign { get; private set; }
		public UnifiedUnaryOperatorKind Kind { get; private set; }

		private UnifiedUnaryOperator() {}

		public static UnifiedUnaryOperator Create(
				string sign,
				UnifiedUnaryOperatorKind kind) {
			return new UnifiedUnaryOperator {
					Sign = sign,
					Kind = kind,
			};
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
	}
}