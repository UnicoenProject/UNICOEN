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

using System;
using System.Diagnostics;
using Unicoen.Processor;

namespace Unicoen.Model {
	/// <summary>
	/// A class representing a part of an event declaration for C#.
	/// e.g. <c>OnKeyDown { add {} remove {} }</c>
	/// in <c>public event KeyboadEventHandler OnKeyDown { add {} remove {} }, OnKeyPush { add {} remove {} }</c>
	/// for C#.
	/// 
	/// </summary>
	public class UnifiedEventDefinitionPart : UnifiedExpression {
		#region fields & properties

		private UnifiedIdentifier _name;
		private UnifiedPropertyDefinitionPart _adder;
		private UnifiedPropertyDefinitionPart _remover;

		/// <summary>
		/// 名前を取得もしくは設定します．
		/// e.g. <c>OnKeyDown</c>
		/// in <c>OnKeyDown { add {} remove {} }</c>
		/// for C#.
		/// </summary>
		public UnifiedIdentifier Name {
			get { return _name; }
			set { _name = SetChild(value, _name); }
		}

		/// <summary>
		/// イベントの追加処理の定義を取得もしくは設定します．
		/// e.g. <c>add {}</c>
		/// in <c>OnKeyDown { add {} remove {} }</c>
		/// for C#.
		/// </summary>
		public UnifiedPropertyDefinitionPart Adder {
			get { return _adder; }
			set { _adder = SetChild(value, _adder); }
		}

		/// <summary>
		/// イベントの追加処理の定義を取得もしくは設定します．
		/// e.g. <c>remove {}</c>
		/// in <c>OnKeyDown { add {} remove {} }</c>
		/// for C#.
		/// </summary>
		public UnifiedPropertyDefinitionPart Remover {
			get { return _remover; }
			set { _remover = SetChild(value, _remover); }
		}

		#endregion

		protected UnifiedEventDefinitionPart() {}

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

		public static UnifiedEventDefinitionPart Create(
				UnifiedIdentifier name = null,
				UnifiedPropertyDefinitionPart adder = null,
				UnifiedPropertyDefinitionPart remover = null) {
			return new UnifiedEventDefinitionPart {
					Name = name,
					Adder = adder,
					Remover = remover,
			};
		}
	}
}