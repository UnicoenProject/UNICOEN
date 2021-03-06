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
	///   関数やメソッドなどのサブルーチンの定義部分を表します。 e.g. Javaにおける <c>public void method(int a){...}</c>
	/// </summary>
	public class UnifiedFunctionDefinition
			: UnifiedExpression, IDynamicFunctionDefinition {
		#region fields & properties

		private UnifiedSet<UnifiedAnnotation> _annotations;

		/// <summary>
		///   付与されているアノテーションを取得もしくは設定します．
		/// </summary>
		public UnifiedSet<UnifiedAnnotation> Annotations {
			get { return _annotations; }
			set { _annotations = SetChild(value, _annotations); }
		}

		private UnifiedSet<UnifiedModifier> _modifiers;

		/// <summary>
		///   付与されている修飾子の集合を取得もしくは設定します． e.g. Javaにおける <c>public static void method(int a){...}</c> の <c>public static</c>
		/// </summary>
		public UnifiedSet<UnifiedModifier> Modifiers {
			get { return _modifiers; }
			set { _modifiers = SetChild(value, _modifiers); }
		}

		private UnifiedType _type;

		/// <summary>
		///   名前を取得もしくは設定します． e.g. Javaにおける <c>public void method(int a){...}</c> の <c>method</c>
		/// </summary>
		public UnifiedType Type {
			get { return _type; }
			set { _type = SetChild(value, _type); }
		}

		private UnifiedSet<UnifiedGenericParameter> _genericParameters;

		public UnifiedSet<UnifiedGenericParameter> GenericParameters {
			get { return _genericParameters; }
			set { _genericParameters = SetChild(value, _genericParameters); }
		}

		private UnifiedIdentifier _name;

		public UnifiedIdentifier Name {
			get { return _name; }
			set { _name = SetChild(value, _name); }
		}

		private UnifiedSet<UnifiedParameter> _parameters;

		public UnifiedSet<UnifiedParameter> Parameters {
			get { return _parameters; }
			set { _parameters = SetChild(value, _parameters); }
		}

		private UnifiedSet<UnifiedType> _throws;

		public UnifiedSet<UnifiedType> Throws {
			get { return _throws; }
			set { _throws = SetChild(value, _throws); }
		}

		private UnifiedExpression _annotationExpression;

		/// <summary>
		///   関数の戻り値の情報を表す付与された式（主に文字列）を取得もしくは設定します．
		/// </summary>
		public UnifiedExpression AnnotationExpression {
			get { return _annotationExpression; }
			set { _annotationExpression = SetChild(value, _annotationExpression); }
		}

		private UnifiedBlock _body;

		/// <summary>
		///   ブロックを取得もしくは設定します．
		/// </summary>
		public UnifiedBlock Body {
			get { return _body; }
			set { _body = SetChild(value, _body); }
		}

		#endregion

		protected UnifiedFunctionDefinition() {}

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

		public static UnifiedFunctionDefinition Create(
				UnifiedSet<UnifiedAnnotation> annotations = null,
				UnifiedSet<UnifiedModifier> modifiers = null,
				UnifiedType type = null,
				UnifiedSet<UnifiedGenericParameter> genericParameters = null,
				UnifiedIdentifier name = null,
				UnifiedSet<UnifiedParameter> parameters = null,
				UnifiedSet<UnifiedType> throws = null,
				UnifiedBlock body = null,
				UnifiedExpression annotationExpression = null) {
			return new UnifiedFunctionDefinition {
					Name = name,
					Annotations = annotations,
					Type = type,
					GenericParameters = genericParameters,
					Modifiers = modifiers,
					Parameters = parameters,
					Throws = throws,
					Body = body,
					AnnotationExpression = annotationExpression,
			};
		}
			}
}