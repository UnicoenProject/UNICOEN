using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unicoen.Apps.RefactoringDSL.Util;
using Unicoen.Model;

namespace Unicoen.Apps.RefactoringDSL {
	public class EncapsulateCollectionHelper {
		/// <summary>
		/// Remove メソッド（コレクションに対して，要素を削除するメソッド）を生成します
		/// </summary>
		/// <param name="collectionField">対象にするコレクション</param>
		/// <param name="functionName">Remove メソッドの名前(e.g. removeItem)</param>
		/// <param name="removingProcedure">Remove メソッドの中身</param>
		/// <returns>Remove メソッド</returns>
		public static UnifiedFunctionDefinition GenerateRemoveMethod(UnifiedElement collectionField, string functionName, UnifiedBlock removingProcedure) {
			// 関数本体
			var func = UnifiedFunctionDefinition.Create();
			func.Name = UnifiedIdentifier.CreateLabel(functionName);
			func.Modifiers = UnifiedModifierCollection.Create( UnifiedModifier.Create("public"));

			// 引数（操作対象のインデクス）
			var parameter = UnifiedParameter.Create();
			parameter.Type = UnifiedType.Create("int");
			parameter.Names = UnifiedIdentifierCollection.Create(UnifiedIdentifier.CreateLabel("i"));

			func.Parameters = UnifiedParameterCollection.Create(parameter);

			func.Type = UnifiedType.Create("void");
			func.Body = removingProcedure;
			return func;
		}


		/// <summary>
		/// Add メソッド（コレクションに対して，要素を追加するメソッド）を生成します
		/// </summary>
		/// <param name="collectionField">対象のコレクション</param>
		/// <param name="functionName">Add メソッドの名前(e.g. addItem)</param>
		/// <param name="addingProcedure">Add メソッドの中身</param>
		/// <returns>Add メソッド</returns>
		public static UnifiedFunctionDefinition GenerateAddMethod(UnifiedElement collectionField, string functionName, UnifiedBlock addingProcedure) {
			var func = UnifiedFunctionDefinition.Create();
			func.Name = UnifiedIdentifier.CreateLabel(functionName);
			func.Modifiers = UnifiedModifierCollection.Create(UnifiedModifier.Create("public"));

			// 引数
			var parameter = UnifiedParameter.Create();
			parameter.Type = FindUtil.GetTypeParameterAsType((UnifiedGenericType)((UnifiedVariableDefinition)collectionField).Type);
			parameter.Names = UnifiedIdentifierCollection.Create(UnifiedIdentifier.CreateLabel("object"));

			func.Parameters = UnifiedParameterCollection.Create(parameter);
			func.Type = UnifiedType.Create("void");
			func.Body = addingProcedure;

			return func;
		}

		/// <summary>
		/// 入力されたフィールドをクローンしたフィールドを表すモデルを生成します 
		/// </summary>
		/// <param name="variable">クローン対象の（コレクション）フィールド</param>
		/// <param name="cloningMethodName">クローンに利用するメソッドの名前を指定します</param>
		/// <returns></returns>
		public static UnifiedCall GenerateClonedField(UnifiedVariableDefinition variable, string cloningMethodName = "clone") {
			// TODO 上2つと同じように，クローン方法を任意に与えられるようにする？
			var clonedField = UnifiedProperty.Create(
				".",
				variable.Name.DeepCopy(),
				UnifiedIdentifier.CreateLabel(cloningMethodName)
				);
			var cloned = UnifiedCall.Create(clonedField, UnifiedArgumentCollection.Create(UnifiedArgument.Create(null)));

			return cloned;
		}

		/// <summary>
		/// コレクションのコピーを返すメソッドを生成します
		/// </summary>
		/// <param name="variable">対象のコレクション</param>
		/// <param name="getterName">生成するメソッドの名前</param>
		public static UnifiedFunctionDefinition GenerateClonedFieldGetter(UnifiedVariableDefinition variable, string getterName = "getCollection") {
			var func = UnifiedFunctionDefinition.Create();
			func.Name = UnifiedIdentifier.CreateLabel(getterName);
			func.Modifiers = UnifiedModifierCollection.Create(UnifiedModifier.Create("public"));
			func.Type = UnifiedType.Create("void");
			func.Parameters = UnifiedParameterCollection.Create(UnifiedParameter.Create());

			var body = UnifiedBlock.Create();
			var returnStmt = UnifiedReturn.Create();
			returnStmt.Value = GenerateClonedField(variable);
			body.Add(returnStmt);

			func.Body = body;

			return func;

		}

		/// <summary>
		/// コレクションフィールドをそのまま返却している関数を検索し取得します
		/// </summary>
		/// <param name="element">検索対象のトップノード</param>
		/// <param name="collections">コレクションフィールド群</param>
		/// <returns></returns>
		public static IEnumerable<UnifiedFunctionDefinition> FindReturningCollectionFunction(UnifiedElement element, IEnumerable<UnifiedElement> collections) {
			var func =
					element.Descendants<UnifiedFunctionDefinition>().Where(
							f => f.Body.Count == 1 && f.Body.First() is UnifiedReturn);
			var collectionNames = collections.Select(e => e as UnifiedVariableDefinition).Select(e => e.Name.Name);

			var result = func.Where(
					f => collectionNames.Contains(
							((UnifiedVariableIdentifier)((UnifiedReturn)f.Body.First()).Value).Name));

			return result;
		}

		/// <summary>
		/// コレクションにコレクションを代入している関数を検索し取得します．
		/// </summary>
		/// <param name="element">検索対象のトップノード</param>
		/// <param name="collections">コレクションフィールド群</param>
		/// <returns></returns>
		public static IEnumerable<UnifiedFunctionDefinition> FindSettingCollectionFunction(UnifiedElement element, IEnumerable<UnifiedElement> collections) {
			var collectionNames = collections.Select(e => e as UnifiedVariableDefinition).Select(e => e.Name.Name);
			var func = element.Descendants<UnifiedFunctionDefinition>()
					.Where(e => e.Body.Count == 1 && e.Body.First() is UnifiedBinaryExpression) // 2項演算式で
					.Where(e => ((UnifiedBinaryExpression)e.Body.First()).Operator.Kind == UnifiedBinaryOperatorKind.Assign)
					.Where(e => collectionNames.Contains((((UnifiedBinaryExpression)e.Body.First()).LeftHandSide as UnifiedVariableIdentifier).Name));  // とりあえずは名前で判断
			return func;
		}
	}
}
