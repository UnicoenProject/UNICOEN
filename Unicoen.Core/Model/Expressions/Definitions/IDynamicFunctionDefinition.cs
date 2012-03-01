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

namespace Unicoen.Model {
	internal interface IDynamicFunctionDefinition {
		/// <summary>
		///   付与されているアノテーションを取得もしくは設定します．
		/// </summary>
		UnifiedAnnotationCollection Annotations { get; set; }

		/// <summary>
		///   付与されている修飾子の集合を取得もしくは設定します． e.g. Javaにおける <c>public static void method(int a){...}</c> の <c>public static</c>
		/// </summary>
		UnifiedModifierCollection Modifiers { get; set; }

		UnifiedIdentifier Name { get; set; }

		UnifiedParameterCollection Parameters { get; set; }

		/// <summary>
		///   関数の戻り値の情報を表す付与された式（主に文字列）を取得もしくは設定します．
		/// </summary>
		UnifiedExpression AnnotationExpression { get; set; }

		/// <summary>
		///   ブロックを取得もしくは設定します．
		/// </summary>
		UnifiedBlock Body { get; set; }
	}
}