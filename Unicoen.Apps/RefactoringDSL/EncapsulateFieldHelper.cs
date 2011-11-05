using System;
using System.Collections.Generic;
using System.Linq;
using Unicoen.Apps.RefactoringDSL.Util;
using Unicoen.Model;

namespace Unicoen.Apps.RefactoringDSL{
	class EncapsulateFieldHelper {
		/// <summary>
		/// クラス内から public なインスタンスフィールドを検索して取得します
		/// </summary>
		/// <param name="cls">クラスオブジェクト</param>
		/// <returns>public なインスタンスフィールドの UnifiedVariableDefinition オブジェクトの集合</returns>
		public static IEnumerable<UnifiedVariableDefinition> FindPublicFields(UnifiedClassDefinition cls) {
			return cls.Descendants<UnifiedVariableDefinition>()
					.Where(
							e => e.Modifiers
							     		.Any(m => m.Name == "public"))
					.Where(
							e => e.Modifiers
							     		.All(m => m.Name != "static"));
		}

		/// <summary>
		/// 指定されたクラス名を持つクラスを，プログラム中から検索して取得します
		/// </summary>
		/// <param name="program">（トップノードの）プログラムオブジェクト</param>
		/// <param name="className">検索するクラス名</param>
		/// <returns>検索したクラスの UnifiedClassDefinition オブジェクト（の集合）</returns>
		public static IEnumerable<UnifiedClassDefinition> FindByClassName(UnifiedProgram program, string className) {
			var result =
					program.Descendants<UnifiedClassDefinition>().Where(e => ((UnifiedIdentifier)(e.Name)).Name == className);
			return result;
		}

		/// <summary>
		/// 変数のアクセス修飾子を付け替えます（UnifiedVariableDefinition オブジェクトの，Modifires プロパティを書き換えます）
		/// </summary>
		/// <param name="variable">対象の変数</param>
		/// <param name="newModifierStrings">付け替えるアクセス修飾子</param>
		public static void ChangeModifier(UnifiedVariableDefinition variable, params string[] newModifierStrings) {
			// TODO: Clear() するとアクセス修飾子以外（e.g. static） なども消えてしまうので，ignoredKeywordList とかどこかに用意して対処する
			variable.Modifiers.Clear();
			variable.Modifiers = UnifiedModifierCollection.Create(
					newModifierStrings.Select(UnifiedModifier.Create));
		}

		/// <summary>
		/// フィールドからそれに対応するゲッタ（UnifiedFunctionDefinition オブジェクト）を生成します
		/// </summary>
		/// <param name="variable">対象の変数</param>
		/// <param name="accessModifierString">ゲッタのアクセス修飾子（デフォルトは public ）</param>
		/// <returns>生成されたゲッタ（UnifiedFunctionDefinition オブジェクト）</returns>
		public static UnifiedFunctionDefinition GenerateGetter(UnifiedVariableDefinition variable, string accessModifierString = "public") {
			var getter = UnifiedFunctionDefinition.Create();
			var getterName = "get" + StringUtil.UpperFirstChar(variable.Name.Name); 
			getter.Name = UnifiedIdentifier.CreateLabel(getterName);
			getter.Type = variable.Type.DeepCopy();
			getter.Modifiers = UnifiedModifierCollection.Create(UnifiedModifier.Create(accessModifierString));

			getter.Parameters = UnifiedParameterCollection.Create(
					UnifiedParameter.Create());

			var returnValue = UnifiedIdentifier.CreateVariable(variable.Name.Name);
			var returnStatemenet = UnifiedReturn.Create(returnValue);
			var block = UnifiedBlock.Create(returnStatemenet);
			getter.Body = block;

			return getter;
		}

		/// <summary>
		/// フィールドからそれに対応するセッタ（UnifiedFunctionDefinition オブジェクト）を生成します
		/// </summary>
		/// <param name="variable">対象の変数</param>
		/// <param name="accessModifierString">セッタのアクセス修飾子（デフォルトは public ）</param>
		/// <returns>生成されたセッタ（UnifiedFunctionDefinition オブジェクト）</returns>
		public static UnifiedFunctionDefinition GenerateSetter(UnifiedVariableDefinition variable, string accessModifierString = "public") {
			var setter = UnifiedFunctionDefinition.Create();
			setter.Name = UnifiedIdentifier.CreateLabel(
					"set" + StringUtil.UpperFirstChar(variable.Name.Name));
			setter.Type = UnifiedType.Create("void");

			var modifier = UnifiedModifier.Create(accessModifierString);
			setter.Modifiers = UnifiedModifierCollection.Create(modifier);

			var parameter = UnifiedParameter.Create(
					null,
					null,
					variable.Type.DeepCopy(),
					UnifiedIdentifierCollection.Create(variable.Name.DeepCopy())
					);
			setter.Parameters = UnifiedParameterCollection.Create(parameter);

			var assignStatement = UnifiedBinaryExpression.Create(
				UnifiedProperty.Create(
					".",
					UnifiedIdentifier.CreateThis("this"),
					variable.Name.DeepCopy()
					),
				UnifiedBinaryOperator.Create("=", UnifiedBinaryOperatorKind.Assign),
				parameter.Names.First().DeepCopy()
				);

			var block = UnifiedBlock.Create(assignStatement);
			setter.Body = block;

			return setter;

		}
	}
}
