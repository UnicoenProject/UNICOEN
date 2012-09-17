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
	///   LINQのクエリ式を構成するjoin句を表します。 e.g. C#における <c>join q in array2 on p.X equals q.X</c>
	/// </summary>
	public class UnifiedJoinQuery : UnifiedLinqQuery {
		private UnifiedVariableIdentifier _receiver;
		private UnifiedExpression _joinSource;
		private UnifiedExpression _firstEqualsKey;
		private UnifiedExpression _secondEqualsKey;

		/// <summary>
		///   クエリ式を継続するために要素を受け取る変数を取得もしくは設定します． e.g. C#における <c>group p.W in p.X into g</c> の <c>g</c>
		/// </summary>
		public UnifiedVariableIdentifier Receiver {
			get { return _receiver; }
			set { _receiver = SetChild(value, _receiver); }
		}

		/// <summary>
		///   結合対象となる式を取得もしくは設定します． e.g. C#における <c>join q in array2 on p.X equals q.X</c> の <c>array2</c>
		/// </summary>
		public UnifiedExpression JoinSource {
			get { return _joinSource; }
			set { _joinSource = SetChild(value, _joinSource); }
		}

		/// <summary>
		///   結合条件となる比較対象のクエリ式の入力元の要素の式を取得もしくは設定します． e.g. C#における <c>join q in array2 on p.X equals q.X</c> の <c>array2</c>
		/// </summary>
		public UnifiedExpression FirstEqualsKey {
			get { return _firstEqualsKey; }
			set { _firstEqualsKey = SetChild(value, _firstEqualsKey); }
		}

		/// <summary>
		///   結合条件となる比較対象の結合対象の要素の式を取得もしくは設定します． e.g. C#における <c>join q in array2 on p.X equals q.X</c> の <c>array2</c>
		/// </summary>
		public UnifiedExpression SecondEqualsKey {
			get { return _secondEqualsKey; }
			set { _secondEqualsKey = SetChild(value, _secondEqualsKey); }
		}

		protected UnifiedJoinQuery() {}

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

		public static UnifiedJoinQuery Create(
				UnifiedVariableIdentifier receiver,
				UnifiedExpression joinSource,
				UnifiedExpression firstEqualsKey,
				UnifiedExpression secondEqualsKey) {
			return new UnifiedJoinQuery {
					Receiver = receiver,
					JoinSource = joinSource,
					FirstEqualsKey = firstEqualsKey,
					SecondEqualsKey = secondEqualsKey,
			};
		}
	}
}