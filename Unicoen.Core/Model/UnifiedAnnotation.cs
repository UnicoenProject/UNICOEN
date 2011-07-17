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
	///   アノテーション（属性）を表します．
	///   e.g. Javaにおける<c>@Override @Deprecated void method() { ... }</c>の<c>@Override</c>
	///   e.g. C#における<c>[Pure, DebuggerStepThrough] void Method() { ... }</c>の<c>Pure</c>
	/// </summary>
	public class UnifiedAnnotation : UnifiedElement, IUnifiedExpression {
		private IUnifiedExpression _name;

		/// <summary>
		///   アノテーションの名前を表します．
		///   e.g. Javaにおける<c>@org.junit.Test</c>
		/// </summary>
		public IUnifiedExpression Name {
			get { return _name; }
			set { _name = SetChild(value, _name); }
		}

		private UnifiedArgumentCollection _arguments;

		/// <summary>
		///   実引数の集合を表します
		///   e.g. Javaにおける<c>method(a, b, c)</c>の<c>a, b, c</c>の部分
		/// </summary>
		public UnifiedArgumentCollection Arguments {
			get { return _arguments; }
			set { _arguments = SetChild(value, _arguments); }
		}

		/// <summary>
		///   e.g. C#における<c>[assembly: AssemblyTitle("Title")]</c>の<c>assembly</c>の部分
		/// </summary>
		public UnifiedAnnotationTarget Target { get; set;}

		private UnifiedAnnotation() {}

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

		public static UnifiedAnnotation Create(
				IUnifiedExpression name = null,
				UnifiedArgumentCollection arguments = null) {
			return new UnifiedAnnotation {
					Name = name,
					Arguments = arguments,
			};
		}
	}
}