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

using System.Linq;
using Unicoen.Core.Visitors;

namespace Unicoen.Core.Model {
	/// <summary>
	///   型を表します。
	///   Javaにおける<c>int, double, char</c>
	/// </summary>
	public class UnifiedType : UnifiedTypeBase {
		// パッケージ名が付いているときに
		// UnifiedProperty が name に入る時があるので
		// isntace.Class
		private IUnifiedExpression _nameExpression;

		/// <summary>
		///   型の名前を表します．
		///   e.g. Javaにおける<c>Package.ClassA instance = null;</c>の<c>Package.ClassA</c>(UnifiedPropertyで表現される)
		/// </summary>
		public IUnifiedExpression NameExpression {
			get { return _nameExpression; }
			set { _nameExpression = SetChild(value, _nameExpression); }
		}

		private UnifiedTypeArgumentCollection _arguments;

		/// <summary>
		///   ジェネリックタイプにおける実引数の集合を表します
		///   e.g. Javaにおける<c>HashMap&ltInteger, String&gt</c>の<c>Integer, String</c>
		/// </summary>
		public UnifiedTypeArgumentCollection Arguments {
			get { return _arguments; }
			set { _arguments = SetChild(value, _arguments); }
		}

		private UnifiedType() {}

		public UnifiedType AddToParameters(IUnifiedExpression expression) {
			Arguments.Add(expression.ToTypeParameter());
			return this;
		}

		public UnifiedType AddToParameters(UnifiedTypeArgument argument) {
			Arguments.Add(argument);
			return this;
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override void Accept<TData>(
				IUnifiedModelVisitor<TData> visitor,
				TData state) {
			visitor.Visit(this, state);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData state) {
			return visitor.Visit(this, state);
		}

		public static UnifiedType Create(
				IUnifiedExpression nameExpression,
				UnifiedTypeArgumentCollection arguments = null) {
			return new UnifiedType {
					NameExpression = nameExpression,
					Arguments = arguments,
			};
		}

		public static UnifiedType CreateUsingString(
				string name,
				UnifiedTypeArgumentCollection arguments = null) {
			return new UnifiedType {
					NameExpression = name != null
					                 		? UnifiedIdentifier.CreateType(name)
					                 		: null,
					Arguments = arguments,
			};
		}

		public static UnifiedArrayType CreateArray(
				string name, UnifiedArgument argument = null) {
			return UnifiedArrayType.Create(
					CreateUsingString(name),
					argument != null
							? argument.ToCollection()
							: null
					);
		}

		public static UnifiedArrayType CreateRectangleArray(
				string name, int dimension) {
			return UnifiedArrayType.Create(
					CreateUsingString(name),
					Enumerable.Repeat<UnifiedArgument>(null, dimension).ToCollection()
					);
		}

		public static UnifiedArrayType CreateRectangleArray(
				string name, UnifiedArgumentCollection arguments) {
			return UnifiedArrayType.Create(CreateUsingString(name), arguments);
		}
	}
}