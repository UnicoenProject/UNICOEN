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
	///   LINQのクエリ式を構成するgroup by句を表します。 e.g. C#における <c>group p.W in p.X into g</c>
	/// </summary>
	public class UnifiedGroupByQuery : UnifiedLinqQuery {
		private UnifiedExpression _element;
		private UnifiedExpression _key;
		private UnifiedVariableIdentifier _receiver;

		/// <summary>
		///   グループ化した各要素となる式を取得もしくは設定します． e.g. C#における <c>group p.W in p.X into g</c> の <c>p.W</c>
		/// </summary>
		public UnifiedExpression Element {
			get { return _element; }
			set { _element = SetChild(value, _element); }
		}

		/// <summary>
		///   グループ化する際のキーとなる式を取得もしくは設定します． e.g. C#における <c>group p.W in p.X into g</c> の <c>p.X</c>
		/// </summary>
		public UnifiedExpression Key {
			get { return _key; }
			set { _key = SetChild(value, _key); }
		}

		/// <summary>
		///   クエリを継続するために要素を受け取る変数を取得もしくは設定します． e.g. C#における <c>group p.W in p.X into g</c> の <c>g</c>
		/// </summary>
		public UnifiedVariableIdentifier Receiver {
			get { return _receiver; }
			set { _receiver = SetChild(value, _receiver); }
		}

		protected UnifiedGroupByQuery() {}

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

		public static UnifiedGroupByQuery Create(
				UnifiedExpression element, UnifiedExpression key,
				UnifiedVariableIdentifier receiver = null) {
			return new UnifiedGroupByQuery {
					Element = element,
					Key = key,
					Receiver = receiver
			};
		}
	}
}