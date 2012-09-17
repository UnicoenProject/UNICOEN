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
	/// A class representing a delegate declration.
	/// e.g. <c>[Pure] public delegate void Delegate&lt;T&gt;(T v);</c>
	/// for C#.
	/// </summary>
	public class UnifiedDelegateDefinition : UnifiedExpression {
		#region fields & properties

		private UnifiedSet<UnifiedAnnotation> _annotations;

		/// <summary>
		/// Gets or sets the annotations.
		/// e.g. <c>[Pure]</c>
		/// in <c>[Pure] public delegate void Delegate&lt;T&gt;(T v);</c>
		/// for C#.
		/// </summary>
		public UnifiedSet<UnifiedAnnotation> Annotations {
			get { return _annotations; }
			set { _annotations = SetChild(value, _annotations); }
		}

		private UnifiedSet<UnifiedModifier> _modifiers;

		/// <summary>
		/// Gets or sets the modifiers.
		/// e.g. <c>public</c>
		/// in <c>[Pure] public delegate void Delegate&lt;T&gt;(T v);</c>
		/// for C#.
		/// </summary>
		public UnifiedSet<UnifiedModifier> Modifiers {
			get { return _modifiers; }
			set { _modifiers = SetChild(value, _modifiers); }
		}

		private UnifiedType _type;

		/// <summary>
		/// Gets or sets the type of the return target.
		/// e.g. <c>void</c>
		/// in <c>[Pure] public delegate void Delegate&lt;T&gt;(T v);</c>
		/// for C#.
		/// </summary>
		public UnifiedType Type {
			get { return _type; }
			set { _type = SetChild(value, _type); }
		}

		private UnifiedSet<UnifiedGenericParameter> _genericParameters;

		/// <summary>
		/// Gets or sets the type of the generic parameters.
		/// e.g. <c>T</c>
		/// in <c>[Pure] public delegate void Delegate&lt;T&gt;(T v);</c>
		/// for C#.
		/// </summary>
		public UnifiedSet<UnifiedGenericParameter> GenericParameters {
			get { return _genericParameters; }
			set { _genericParameters = SetChild(value, _genericParameters); }
		}

		private UnifiedIdentifier _name;

		/// <summary>
		/// Gets or sets the name of this delegate.
		/// e.g. <c>Delegate</c>
		/// in <c>[Pure] public delegate void Delegate&lt;T&gt;(T v);</c>
		/// for C#.
		/// </summary>
		public UnifiedIdentifier Name {
			get { return _name; }
			set { _name = SetChild(value, _name); }
		}

		private UnifiedSet<UnifiedParameter> _parameters;

		/// <summary>
		/// Gets or sets the parameters.
		/// e.g. <c>T v</c>
		/// in <c>[Pure] public delegate void Delegate&lt;T&gt;(T v);</c>
		/// for C#.
		/// </summary>
		public UnifiedSet<UnifiedParameter> Parameters {
			get { return _parameters; }
			set { _parameters = SetChild(value, _parameters); }
		}

		#endregion

		protected UnifiedDelegateDefinition() {}

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

		public static UnifiedDelegateDefinition Create(
				UnifiedSet<UnifiedAnnotation> annotations = null,
				UnifiedSet<UnifiedModifier> modifiers = null,
				UnifiedType type = null,
				UnifiedSet<UnifiedGenericParameter> genericParameters = null,
				UnifiedIdentifier name = null,
				UnifiedSet<UnifiedParameter> parameters = null) {
			return new UnifiedDelegateDefinition {
					Name = name,
					Annotations = annotations,
					Type = type,
					GenericParameters = genericParameters,
					Modifiers = modifiers,
					Parameters = parameters,
			};
		}
	}
}