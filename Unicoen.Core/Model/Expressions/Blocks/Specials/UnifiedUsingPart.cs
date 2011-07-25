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
	///   リソース管理に用いられるローンパターンを提供する構文（try/using/with文）の構成要素を表します。
	///   e.g. C#における<c>using(var w1 = new StringWriter(), w2 = new StringWriter()){...}</c>の<c>var w1 = new StringWriter(), w2 = new StringWriter()</c>
	///   e.g. Pythonにおける<c>with file(p1) as f1, file(p2) as f2:</c>の<c>file(p1) as f1</c>
	/// </summary>
	public class UnifiedUsingPart : UnifiedElement {
		private IUnifiedExpression _expression;
		private IUnifiedExpression _assign;

		/// <summary>
		///   管理対象のリソースが得られる変数宣言か式を取得もしくは設定します．
		///   e.g. C#における<c>using(var w1 = new StringWriter(), w2 = new StringWriter()){...}</c>の<c>var w1 = new StringWriter(), w2 = new StringWriter()</c>
		///   e.g. C#における<c>using(w1 = new StringWriter()){...}</c>の<c>w1 = new StringWriter()</c>
		///   e.g. Pythonにおける<c>with file(p1) as f1:</c>の<c>file(p1)</c>
		/// </summary>
		public IUnifiedExpression Expression {
			get { return _expression; }
			set { _expression = SetChild(value, _expression); }
		}

		/// <summary>
		///   管理対象のリソースの値を受け取る左辺式（≠変数宣言）を取得もしくは設定します．
		///   e.g. Pythonにおける<c>with file(p1) as f1:</c>の<c>f1</c>
		/// </summary>
		public IUnifiedExpression Assign {
			get { return _assign; }
			set { _assign = SetChild(value, _assign); }
		}

		private UnifiedUsingPart() {}

		[DebuggerStepThrough]
		public override void Accept(IUnifiedVisitor visitor) {
			visitor.Visit(this);
		}

		[DebuggerStepThrough]
		public override void Accept<TArg>(
				IUnifiedVisitor<TArg> visitor, TArg arg) {
			visitor.Visit(this, arg);
		}

		[DebuggerStepThrough]
		public override TResult Accept<TArg, TResult>(
				IUnifiedVisitor<TArg, TResult> visitor, TArg arg) {
			return visitor.Visit(this, arg);
		}

		/// <summary>
		///   変数宣言と代入先から構成されるリソース管理の構文（try/using/with文）の構成要素オブジェクトを作成します．
		///   変数を宣言せずにリソースを変数に代入する際はassignに代入先を指定します．
		/// </summary>
		/// <param name = "expression"></param>
		/// <param name = "assign"></param>
		/// <returns></returns>
		public static UnifiedUsingPart Create(
				IUnifiedExpression expression, IUnifiedExpression assign = null) {
			return new UnifiedUsingPart {
					Expression = expression,
					Assign = assign,
			};
		}
	}
}