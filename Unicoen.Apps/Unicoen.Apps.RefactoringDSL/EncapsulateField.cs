using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unicoen.Languages.Java;
using Unicoen.Model;

namespace Unicoen.Apps.RefactoringDSL{
	/// <summary>
	/// EncapsulateField リファクタリングを行うためのクラス
	/// </summary>
	public class EncapsulateField{
		private UnifiedProgram Program { get; set; }

		// コンストラクタ
		public EncapsulateField(UnifiedProgram program) {
			this.Program = program;
		}

		public UnifiedProgram Refactor(String className) {
			// 一応コピー
			var model = Program.DeepCopy();
			var targetClass = EncapsulateFieldHelper.FindByClassName(model, "Foo").First();
			var publicVariables = EncapsulateFieldHelper.FindPublicFields(targetClass);

			var getters = new List<UnifiedFunctionDefinition>();
			var setters = new List<UnifiedFunctionDefinition>();
			// ゲッタとセッタを生成
			foreach (var v in publicVariables) {
				getters.Add(EncapsulateFieldHelper.GenerateGetter(v));
				setters.Add(EncapsulateFieldHelper.GenerateSetter(v));
			}
			
			// フィールドを private に変更
			foreach (var pv in publicVariables) {
				EncapsulateFieldHelper.ChangeModifier(pv, "private");
			}

			var list = targetClass.Body.DeepCopy();
			// 元の要素群とアクセッサを結合
			// var list = new List<IUnifiedExpression>();
			foreach (var getter in getters) {
				list.Add(getter);
			}
			foreach (var setter in setters) {
				list.Add(setter);
			}
			
			// var newBody = UnifiedBlock.Create(list);
			// var newBody = list;

			targetClass.Body = list;

			return model;

		}
	}
}
