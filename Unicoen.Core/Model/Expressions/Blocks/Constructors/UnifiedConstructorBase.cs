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

namespace Unicoen.Core.Model {
	/// <summary>
	///   コンストラクタの定義部分を表します。
	///   e.g. Javaにおける<c>class C{ C(){...} }</c>の<c>C(){...}</c>
	/// </summary>
	public abstract class UnifiedConstructorBase<TSelf>
			: UnifiedExpressionBlock, IUnifiedCreatable<TSelf>
			where TSelf : UnifiedConstructorBase<TSelf> {
		protected UnifiedAnnotationCollection _annotations;

		/// <summary>
		///   付与されているアノテーションを取得もしくは設定します．
		/// </summary>
		public UnifiedAnnotationCollection Annotations {
			get { return _annotations; }
			set { _annotations = SetChild(value, _annotations); }
		}

		protected UnifiedModifierCollection _modifiers;

		public UnifiedModifierCollection Modifiers {
			get { return _modifiers; }
			set { _modifiers = SetChild(value, _modifiers); }
		}

		protected UnifiedParameterCollection _parameters;

		public UnifiedParameterCollection Parameters {
			get { return _parameters; }
			set { _parameters = SetChild(value, _parameters); }
		}

		protected UnifiedTypeParameterCollection _typeParameters;

		public UnifiedTypeParameterCollection TypeParameters {
			get { return _typeParameters; }
			set { _typeParameters = SetChild(value, _typeParameters); }
		}

		protected UnifiedTypeCollection _throws;

		public UnifiedTypeCollection Throws {
			get { return _throws; }
			set { _throws = SetChild(value, _throws); }
		}

		protected internal UnifiedConstructorBase() {}

		public static TSelf Create(
				UnifiedBlock body = null,
				UnifiedAnnotationCollection annotations = null,
				UnifiedModifierCollection modifiers = null,
				UnifiedParameterCollection parameters = null,
				UnifiedTypeParameterCollection typeParameters = null,
				UnifiedTypeCollection throws = null) {
			var ret = UnifiedFactory<TSelf>.Create();
			ret.Body = body;
			ret.Annotations = annotations;
			ret.Modifiers = modifiers;
			ret.Parameters = parameters;
			ret.TypeParameters = typeParameters;
			ret.Throws = throws;
			return ret;
		}

		public abstract TSelf CreateSelf();
			}
}