using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unicoen.Model {
	interface IDynamicFunctionDefinition {
		/// <summary>
		///   付与されているアノテーションを取得もしくは設定します．
		/// </summary>
		UnifiedAnnotationCollection Annotations { get; set; }

		/// <summary>
		///   付与されている修飾子の集合を取得もしくは設定します．
		///   e.g. Javaにおける<c>public static void method(int a){...}</c>の<c>public static</c>
		/// </summary>
		UnifiedModifierCollection Modifiers { get; set; }

		UnifiedIdentifier Name { get; set; }

		UnifiedParameterCollection Parameters { get; set; }

		/// <summary>
		///   関数の戻り値の情報を表す付与された式（主に文字列）を取得もしくは設定します．
		/// </summary>
		IUnifiedExpression AnnotationExpression { get; set; }

		/// <summary>
		///   ブロックを取得もしくは設定します．
		/// </summary>
		UnifiedBlock Body { get; set; }
	}
}
