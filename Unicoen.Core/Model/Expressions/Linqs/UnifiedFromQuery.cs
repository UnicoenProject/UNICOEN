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
	///   LINQのクエリ式を構成するfrom句を表します。
	///   e.g. C#における<c>from int element in array</c>
	/// </summary>
	public class UnifiedFromQuery : UnifiedLinqQuery {
		private UnifiedType _receiverType;
		private UnifiedVariableIdentifier _receiver;
		private IUnifiedExpression _source;

		/// <summary>
		///   fromで受け取る変数の型を取得もしくは設定します．
		///   e.g. C#における<c>from int element in array</c>の<c>int</c>
		/// </summary>
		public UnifiedType ReceiverType {
			get { return _receiverType; }
			set { _receiverType = SetChild(value, _receiverType); }
		}

		/// <summary>
		///   要素を受け取る変数を取得もしくは設定します．
		///   e.g. C#における<c>from int element in array</c>の<c>element</c>
		/// </summary>
		public UnifiedVariableIdentifier Receiver {
			get { return _receiver; }
			set { _receiver = SetChild(value, _receiver); }
		}

		/// <summary>
		///   クエリ式の対象となる式を取得もしくは設定します．
		///   e.g. C#における<c>from int element in array</c>の<c>array</c>
		/// </summary>
		public IUnifiedExpression Source {
			get { return _source; }
			set { _source = SetChild(value, _source); }
		}

		protected UnifiedFromQuery() {}

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

		public static UnifiedFromQuery Create(
				UnifiedVariableIdentifier receiver, IUnifiedExpression source,
				UnifiedType receiverType = null) {
			return new UnifiedFromQuery {
					ReceiverType = receiverType,
					Receiver = receiver,
					Source = source
			};
		}
	}
}