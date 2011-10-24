using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Unicoen.Languages.Java;
using Unicoen.Model;
using Unicoen.Tests;

namespace Unicoen.Apps.RefactoringDSL.EncapsulateField {
	class EncapsulateFieldTest_ {
		private UnifiedProgram _model;
		private UnifiedProgram _after;

		[SetUp]
		public void SetUp() {
			var inPath = FixtureUtil.GetInputPath("Java", "default", "Encapsulate.java");
			var code = File.ReadAllText(inPath, Encoding.Default);
			_model = JavaFactory.GenerateModel(code);

			inPath = FixtureUtil.GetInputPath("Java", "default", "Encapsulated.java");
			code = File.ReadAllText(inPath, Encoding.Default);
			_after = JavaFactory.GenerateModel(code);
		}

		[Test]
		public void Sandbox() {
			// クラス一覧
			var classes = _model.Descendants<UnifiedClassDefinition>();
			foreach (var classItem in classes) {
				Console.WriteLine((classItem.Name as UnifiedIdentifier).Name);
			}

			foreach (var classNode in classes) {
				var variables = classNode.Descendants<UnifiedVariableDefinition>();
				foreach (var variable in variables) {
					Console.WriteLine(variable.Name);

				}
			}
		}

		[Test]
		public void Sandbox2() {
			// ターゲットのクラスを取得
			var targetClass = EncapsulateFieldHelper.FindByClassName(_model, "Foo").First();
			var publicVariables = EncapsulateFieldHelper.FindPublicFields(targetClass);

			var getters = new List<UnifiedFunctionDefinition>();
			var setters = new List<UnifiedFunctionDefinition>();

			// ゲッタとセッタを生成
			foreach (var v in publicVariables) {
				getters.Add(EncapsulateFieldHelper.GenerateGetter(v));
				setters.Add(EncapsulateFieldHelper.GenerateSetter(v));
			}

			foreach (var setter in setters) {
				Console.WriteLine(JavaFactory.GenerateCode(setter));
			}

			foreach (var getter in getters) {
				Console.WriteLine(JavaFactory.GenerateCode(getter));
			}

		}

		[Test]
		public void リファクタリングしてみるテスト() {
			// 一応コピー
			var model = _model.DeepCopy();
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

			Console.WriteLine(JavaFactory.GenerateCode(targetClass));

		}

		[Test]
		public void アクセッサ宣言部分を取得するテスト() {
			var classes = FindByClassName(_after, "Foo");
			foreach (var c in classes) {
				Console.WriteLine((c.Name as UnifiedIdentifier).Name);
			}

			var targetClass = classes.First();
			var functionDefinitions = targetClass.Descendants<UnifiedFunctionDefinition>();
			foreach (var f in functionDefinitions) {
				foreach (var modifier in f.Modifiers) {
					Console.WriteLine(modifier.Name);
				}
				Console.WriteLine(f.Name.Name);
			}

			var code = JavaFactory.GenerateCode(functionDefinitions.ElementAt(2));
			Console.WriteLine(code);
			Console.Write(functionDefinitions.ElementAt(2).ToXml());


		}

		[Test]
		public void 任意にモデルを作ってみるテスト() {
			var func = UnifiedFunctionDefinition.Create();
			var identifier = UnifiedIdentifier.CreateLabel("getField");
			var modifier = UnifiedModifier.Create("public");
			func.Modifiers = UnifiedModifierCollection.Create(modifier);
			func.Type = UnifiedType.Create("int");

			var returnValue = UnifiedIdentifier.CreateVariable("field");
			var statemenet = UnifiedReturn.Create(returnValue);
			func.Body = UnifiedBlock.Create(statemenet);

			func.Name = identifier;
			Console.WriteLine(JavaFactory.GenerateCode(func));
		}

		[Test]
		public void publicなクラス変数宣言を取得してみるテスト() {
			var classes = FindByClassName(_model, "Foo");

			var targetClass = classes.First();
			var variables = targetClass.Descendants<UnifiedVariableDefinition>();
			foreach (var v in variables) {
				foreach (var m in v.Modifiers) {
					// Console.WriteLine(m.Name);
				}
			}
			var publicVariables = variables.Where(
					e => e.Modifiers.Any(v => v.Name.Equals("public")));
			foreach (var v in publicVariables) {
				Console.WriteLine(v.Name);
			}

		}

		[Test]
		public void ゲッタを作るテスト() {
			var identifier = UnifiedIdentifier.CreateLabel("field");
			var type = UnifiedType.Create("int");
			var modifier = UnifiedModifier.Create("public");
			var variable = UnifiedVariableDefinition.Create();
			variable.Modifiers = UnifiedModifierCollection.Create(modifier);
			variable.Type = type;
			variable.Name = identifier;

			var getter = UnifiedFunctionDefinition.Create();
			var getterName = "";
			var charArray = variable.Name.Name.ToCharArray();
			getterName += charArray[0].ToString().ToUpper();
			for (int i = 1; i < charArray.Length; i++) {
				getterName += charArray[i];
			}
			getter.Name = UnifiedIdentifier.CreateLabel("get" + getterName);
			getter.Type = variable.Type.DeepCopy();
			getter.Modifiers = UnifiedModifierCollection.Create(UnifiedModifier.Create("public"));

			var returnValue = UnifiedIdentifier.CreateVariable(variable.Name.Name);
			var returnStatemenet = UnifiedReturn.Create(returnValue);
			var block = UnifiedBlock.Create(returnStatemenet);
			getter.Body = block;

			Console.WriteLine(JavaFactory.GenerateCode(getter));

			var funcList = UnifiedVariableDefinitionList.Create(variable);

		}
		[Test]
		public void セッタを作るテスト() {
			var variable = GenerateTestVariable();
			var setter = UnifiedFunctionDefinition.Create();
			setter.Name = UnifiedIdentifier.CreateLabel(
					"set" + UpperFirstChar(variable.Name.Name));
			setter.Type = UnifiedType.Create("void");

			var modifier = UnifiedModifier.Create("public");
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

			// Console.WriteLine(JavaFactory.GenerateCode(setter));

			var privateModifier = UnifiedModifier.Create("private");
			var modifierCollection = setter.Modifiers;
			foreach (var m in modifierCollection) {
				Console.WriteLine(m.Name);
			}
			modifierCollection.Clear();
			modifierCollection.Add(privateModifier);

			Console.WriteLine(JavaFactory.GenerateCode(setter));
			Console.WriteLine(setter.ToXml());
		}
		
		// テスト用の変数モデルを作るユーティリティ
		private UnifiedVariableDefinition GenerateTestVariable() {
			var identifier = UnifiedIdentifier.CreateVariable("field");
			var type = UnifiedType.Create("int");
			var modifier = UnifiedModifier.Create("public");
			var variable = UnifiedVariableDefinition.Create();
			variable.Modifiers = UnifiedModifierCollection.Create(modifier);
			variable.Type = type;
			variable.Name = identifier;

			return variable;

		}

		// 文字列の先頭の文字だけ大文字にするユーティリティ
		public string UpperFirstChar(string str) {
			if (string.IsNullOrEmpty(str)) {
				return "";
			}

			var result = "";
			var charArray = str.ToCharArray();
			result += charArray[0].ToString().ToUpper();

			for (int i = 1; i < charArray.Length; i++) {
				result += charArray[i];
			}

			return result;
		}


		// クラス名からクラスモデルを探す	
		public IEnumerable<UnifiedClassDefinition> FindByClassName(UnifiedProgram program, string className) {
			var result =
					program.Descendants<UnifiedClassDefinition>().Where(e => (e.Name as UnifiedIdentifier).Name.Equals(className));
			return result;
		}

	}
}
