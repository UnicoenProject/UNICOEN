﻿#region License

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

using System.Diagnostics;
using System.Numerics;
using UniUni.Numerics;
using Unicoen.Processor;

namespace Unicoen.Model {
	/// <summary>
	///   整数のリテラルを表します。
	///   e.g. Javaにおける<c>int i = 10;</c>の<c>10</c>の部分
	/// </summary>
	public class UnifiedIntegerLiteral : UnifiedTypedLiteral<BigInteger> {
		private BigInteger _value;

		public override BigInteger Value {
		    get { return _value; }
		    set {
		        switch (Kind) {
		        case UnifiedIntegerLiteralKind.Int32:
		            _value = value.ToForceInt32();
		            break;
		        case UnifiedIntegerLiteralKind.Int64:
		            _value = value.ToForceInt64();
		            break;
		        case UnifiedIntegerLiteralKind.BigInteger:
		            _value = value;
		            break;
		        }
		    }
		}

		public UnifiedIntegerLiteralKind Kind { get; set; }

		private UnifiedIntegerLiteral() {}

		[DebuggerStepThrough]
		public override void Accept(IUnifiedVisitor visitor) {
			visitor.Visit(this);
		}

		[DebuggerStepThrough]
		public override void Accept<TArg>(
				IUnifiedVisitor<TArg> visitor,
				TArg arg) {
			visitor.Visit(this, arg);
		}

		[DebuggerStepThrough]
		public override TResult Accept<TArg, TResult>(
				IUnifiedVisitor<TArg, TResult> visitor, TArg arg) {
			return visitor.Visit(this, arg);
		}

		public static UnifiedIntegerLiteral Create(
				BigInteger value,
				UnifiedIntegerLiteralKind kind) {
			return new UnifiedIntegerLiteral {
					// 先にKindを設定しないとプロパティの初期がで失敗する
					Kind = kind,
					Value = value,
			};
		}

		public static UnifiedIntegerLiteral CreateInt32(int value) {
			return Create(value, UnifiedIntegerLiteralKind.Int32);
		}

		public static UnifiedIntegerLiteral CreateBigInteger(BigInteger value) {
			return Create(value, UnifiedIntegerLiteralKind.BigInteger);
		}
	}
}