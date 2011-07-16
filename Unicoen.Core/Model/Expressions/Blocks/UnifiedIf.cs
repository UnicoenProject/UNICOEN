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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Unicoen.Processor;

namespace Unicoen.Model {
	/// <summary>
	///   if文を表します。
	///   e.g. C, Java, C#における<c>if (i == 1) { ... } else { ... }</c>
	/// </summary>
	public class UnifiedIf : UnifiedElement, IUnifiedExpression {
		private IUnifiedExpression _condition;
		private UnifiedBlock _body;
		private UnifiedBlock _elseBody;

		/// <summary>
		///   条件式を取得もしくは設定します．
		///   e.g. C, Java, C#における<c>if (i == 1) a = 1; else a = 2;</c>の<c>i == 1</c>
		/// </summary>
		public IUnifiedExpression Condition {
			get { return _condition; }
			set { _condition = SetChild(value, _condition); }
		}

		/// <summary>
		///   条件式が真であったときに実行されるブロックを取得もしくは設定します．
		///   e.g. C, Java, C#における<c>if (i == 1) a = 1; else a = 2;</c>の<c>a = 1;</c>
		/// </summary>
		public UnifiedBlock Body {
			get { return _body; }
			set { _body = SetChild(value, _body); }
		}

		/// <summary>
		///   条件式が偽であったときに実行されるブロックを取得もしくは設定します．
		///   e.g. C, Java, C#における<c>if (i == 1) a = 1; else a = 2;</c>の<c>a = 2;</c>
		/// </summary>
		public UnifiedBlock ElseBody {
			get { return _elseBody; }
			set { _elseBody = SetChild(value, _elseBody); }
		}

		private UnifiedIf() {}

		public UnifiedIf AddToFalseBody(IUnifiedExpression expression) {
			ElseBody.Add(expression);
			return this;
		}

		public UnifiedIf RemoveFalseBody() {
			ElseBody = null;
			return this;
		}

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

		public static UnifiedIf Create(UnifiedBlock body) {
			return new UnifiedIf {
					Body = body,
			};
		}

		public static UnifiedIf Create(
				IUnifiedExpression condition, UnifiedBlock body) {
			return new UnifiedIf {
					Body = body,
					Condition = condition,
			};
		}

		/// <summary>
		///   一個以上のelse if節によって構成されているif-else式に分解してモデルを構築します．
		/// </summary>
		/// <param name = "conditionAndBodies"></param>
		/// <param name = "lastElseBody"></param>
		/// <returns></returns>
		public static UnifiedIf Create(
				IEnumerable<Tuple<IUnifiedExpression, UnifiedBlock>> conditionAndBodies,
				UnifiedBlock lastElseBody) {
			var ifs = conditionAndBodies
					.Select(t => Create(t.Item1, t.Item2))
					.ToList();
			for (int i = 1; i < ifs.Count; i++) {
				ifs[i - 1].ElseBody = ifs[i].ToBlock();
			}
			if (lastElseBody != null) {
				ifs[ifs.Count - 1].ElseBody = lastElseBody;
			}
			return ifs[0];
		}

		public static UnifiedIf Create(
				IUnifiedExpression condition = null,
				UnifiedBlock body = null,
				UnifiedBlock falseBody = null) {
			return new UnifiedIf {
					Body = body,
					Condition = condition,
					ElseBody = falseBody,
			};
		}
	}
}