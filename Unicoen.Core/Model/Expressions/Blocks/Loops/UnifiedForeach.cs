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
	///   foreach文あるいは拡張for文を表します。 e.g. Javaにおける <c>for(int n : array){...}</c> やC#における <c>foreach(var n in array){...}</c>
	/// </summary>
	public class UnifiedForeach : UnifiedExpression {
		private UnifiedExpression _element;
		private UnifiedExpression _set;
		private UnifiedBlock _body;
		private UnifiedBlock _elseBody;

		/// <summary>
		///   集合から取り出した要素を表します e.g. Javaにおける <c>for(int n : array){...}</c> の <c>int n</c>
		/// </summary>
		public UnifiedExpression Element {
			get { return _element; }
			set { _element = SetChild(value, _element); }
		}

		/// <summary>
		///   対象の集合を表します e.g. Javaにおける <c>for(int n : array){...}</c> の <c>array</c>
		/// </summary>
		public UnifiedExpression Set {
			get { return _set; }
			set { _set = SetChild(value, _set); }
		}

		/// <summary>
		///   ループ中に実行するブロックを取得もしくは設定します．
		/// </summary>
		public UnifiedBlock Body {
			get { return _body; }
			set { _body = SetChild(value, _body); }
		}

		public UnifiedBlock ElseBody {
			get { return _elseBody; }
			set { _elseBody = SetChild(value, _elseBody); }
		}

		private UnifiedForeach() {}

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

		public static UnifiedForeach Create(
				UnifiedExpression element,
				UnifiedExpression set) {
			return Create(element, set, null, null);
		}

		public static UnifiedForeach Create(
				UnifiedExpression element,
				UnifiedExpression set, UnifiedBlock body) {
			return Create(element, set, body, null);
		}

		public static UnifiedForeach Create(
				UnifiedExpression element, UnifiedExpression set,
				UnifiedBlock body,
				UnifiedBlock elseBody) {
			return new UnifiedForeach {
					Element = element,
					Set = set,
					Body = body,
					ElseBody = elseBody,
			};
		}

		public static UnifiedForeach Create() {
			return new UnifiedForeach();
		}
	}
}