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

using Unicoen.Processor;

namespace Unicoen.Model {
	/// <summary>
	///   コンストラクタの定義やイニシャライザの定義に必要な機能を提供します．
	/// </summary>
	public abstract class UnifiedConstructorLike<TSelf>
			: UnifiedExpression, IUnifiedCreatable<TSelf>
			where TSelf : UnifiedConstructorLike<TSelf> {
		protected UnifiedSet<UnifiedAnnotation> _annotations;
		protected UnifiedSet<UnifiedModifier> _modifiers;
		protected UnifiedSet<UnifiedParameter> _parameters;
		protected UnifiedSet<UnifiedGenericParameter> _genericParameters;
		protected UnifiedSet<UnifiedType> _throws;
		protected UnifiedBlock _body;

		/// <summary>
		///   付与されているアノテーションを取得もしくは設定します．
		/// </summary>
		public UnifiedSet<UnifiedAnnotation> Annotations {
			get { return _annotations; }
			set { _annotations = SetChild(value, _annotations); }
		}

		public UnifiedSet<UnifiedModifier> Modifiers {
			get { return _modifiers; }
			set { _modifiers = SetChild(value, _modifiers); }
		}

		public UnifiedSet<UnifiedParameter> Parameters {
			get { return _parameters; }
			set { _parameters = SetChild(value, _parameters); }
		}

		public UnifiedSet<UnifiedGenericParameter> GenericParameters {
			get { return _genericParameters; }
			set { _genericParameters = SetChild(value, _genericParameters); }
		}

		public UnifiedSet<UnifiedType> Throws {
			get { return _throws; }
			set { _throws = SetChild(value, _throws); }
		}

		/// <summary>
		///   ブロックを取得します．
		/// </summary>
		public UnifiedBlock Body {
			get { return _body; }
			set { _body = SetChild(value, _body); }
		}

		public static TSelf Create(
				UnifiedBlock body = null,
				UnifiedSet<UnifiedAnnotation> annotations = null,
				UnifiedSet<UnifiedModifier> modifiers = null,
				UnifiedSet<UnifiedParameter> parameters = null,
				UnifiedSet<UnifiedGenericParameter> genericParameters = null,
				UnifiedSet<UnifiedType> throws = null) {
			var ret = UnifiedFactory<TSelf>.Create();
			ret.Body = body;
			ret.Annotations = annotations;
			ret.Modifiers = modifiers;
			ret.Parameters = parameters;
			ret.GenericParameters = genericParameters;
			ret.Throws = throws;
			return ret;
		}

		public abstract TSelf CreateSelf();
			}
}