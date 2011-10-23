using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unicoen.Languages.Java;
using Unicoen.Model;

namespace Unicoen.Apps.RefactoringDSL.EncapsulateField {
	public class EncapsulateField{
		private UnifiedProgram Program { get; set; }

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

			var body = targetClass.Body;
			var elements = new List<IUnifiedExpression>();
			foreach (var e in body.Elements()) {
				elements.Add(e.DeepCopy() as IUnifiedExpression);
			}

			// 元の要素群とアクセッサを結合
			var list = new List<IUnifiedExpression>();
			foreach (var e in elements) {
				list.Add(e);
			}
			foreach (var getter in getters) {
				list.Add(getter);
			}
			foreach (var setter in setters) {
				list.Add(setter);
			}
			
			var newBody = UnifiedBlock.Create(list);

			targetClass.Body = newBody;

			return model;

		}
	}
}
