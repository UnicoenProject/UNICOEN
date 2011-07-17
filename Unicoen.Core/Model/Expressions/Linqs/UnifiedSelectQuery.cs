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

using System.Diagnostics;
using Unicoen.Processor;

namespace Unicoen.Model {
	/// <summary>
	///   LINQのクエリ式を構成するselect句を表します。
	///   e.g. C#における<c>select new { p.X, p.Y } into x</c>
	/// </summary>
	public class UnifiedSelectQuery : UnifiedLinqQuery {
		private IUnifiedExpression _expression;
		private UnifiedVariableIdentifier _receiver;

		/// <summary>
		///   射影する際のクエリ式の各要素の変換式を取得もしくは設定します．
		///   e.g. C#における<c>select new { p.X, p.Y } into x</c>の<c>new { p.X, p.Y }</c>
		/// </summary>
		public IUnifiedExpression Expression {
			get { return _expression; }
			set { _expression = SetChild(value, _expression); }
		}

		/// <summary>
		///   クエリを継続するために要素を受け取る変数を取得もしくは設定します．
		///   e.g. C#における<c>select new { p.X, p.Y } into x</c>の<c>x</c>
		/// </summary>
		public UnifiedVariableIdentifier Receiver {
			get { return _receiver; }
			set { _receiver = SetChild(value, _receiver); }
		}

		protected UnifiedSelectQuery() {}

		[DebuggerStepThrough]
		public override void Accept(IUnifiedVisitor visitor) {
			visitor.Visit(this);
		}

		[DebuggerStepThrough]
		public override void Accept<TArg>(IUnifiedVisitor<TArg> visitor, TArg arg) {
			visitor.Visit(this, arg);
		}

		[DebuggerStepThrough]
		public override TResult Accept<TArg, TResult>(
				IUnifiedVisitor<TArg, TResult> visitor, TArg arg) {
			return visitor.Visit(this, arg);
		}

		public static UnifiedSelectQuery Create(
				IUnifiedExpression expression, UnifiedVariableIdentifier receiver) {
			return new UnifiedSelectQuery {
					Expression = expression,
					Receiver = receiver,
			};
		}
	}
}