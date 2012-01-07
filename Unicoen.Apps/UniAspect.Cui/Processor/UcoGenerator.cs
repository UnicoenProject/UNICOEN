using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Code2Xml.Languages.C.CodeToXmls;
using Code2Xml.Languages.CSharp.CodeToXmls;
using Code2Xml.Languages.Java.CodeToXmls;
using Code2Xml.Languages.JavaScript.CodeToXmls;
using Code2Xml.Languages.Python2.CodeToXmls;
using Unicoen.Languages.C;
using Unicoen.Languages.C.ProgramGenerators;
using Unicoen.Languages.CSharp;
using Unicoen.Languages.CSharp.ProgramGenerators;
using Unicoen.Languages.Java;
using Unicoen.Languages.Java.ProgramGenerators;
using Unicoen.Languages.JavaScript;
using Unicoen.Languages.JavaScript.ProgramGenerators;
using Unicoen.Languages.Python2;
using Unicoen.Languages.Python2.ProgramGenerators;
using Unicoen.Model;

namespace Unicoen.Apps.UniAspect.Cui.Processor {
	public class UcoGenerator {

		/// <summary>
		///   与えられたソースコードを共通モデルに変換します
		/// </summary>
		/// <param name = "ext">対象言語の拡張子</param>
		/// <param name = "code">対象ソースコードの中身</param>
		/// <returns></returns>
		public static UnifiedProgram CreateModel(string ext, string code) {
			switch (ext.ToLower()) {
			case ".cs":
				return CSharpFactory.GenerateModel(code);
			case ".java":
				return JavaFactory.GenerateModel(code);
			case ".js":
				return JavaScriptFactory.GenerateModel(code);
			case ".c":
			case ".h":
				return CFactory.GenerateModel(code);
			case ".py":
				return Python2Factory.GenerateModel(code);
			}
			//Ruby
			throw new InvalidOperationException("対応していない言語ファイルが指定されました");
		}

		/// <summary>
		///   与えられたコードを共通コードモデルとして生成します。
		/// </summary>
		/// <param name = "language">対象言語</param>
		/// <param name = "code">コード断片</param>
		/// <returns></returns>
		public static UnifiedBlock CreateAdvice(string language, string code) {
			//generate model from string advice (as UnifiedBlock)
			XElement ast = null;
			UnifiedBlock actual = null;

			switch (language) {
			case "Java":
				code = "{ " + code + " }";
				ast = JavaCodeToXml.Instance.Generate(code, p => p.block());
				actual = JavaProgramGeneratorHelper.CreateBlock(ast);
				break;
			case "JavaScript":
				code = "{ " + code + " }";
				ast = JavaScriptCodeToXml.Instance.Generate(code, p => p.statementBlock());
				actual = JavaScriptProgramGeneratorHelper.CreateStatementBlock(ast);
				break;
			case "C":
				code = "{ " + code + " }";
				ast = CCodeToXml.Instance.Generate(code, p => p.compound_statement());
				actual = CProgramGeneratorHelper.CreateCompoundStatement(ast);
				break;
			case "CSharp":
				actual = CreateAdviceForCSharp(code);
				break;
			case "Python":
				actual = CreateAdviceForPython(code);
				break;
			default:
				//Ruby
				throw new InvalidOperationException("対応していない言語が指定されました");
			}
			actual.Normalize();

			return actual;
		}

		private static UnifiedBlock CreateAdviceForCSharp(string code) {
			// TODO テストを書く
			code = "public class C { public int M() {" + code + "}}";
			var gen = new CSharpProgramGenerator();
			var model = gen.Generate(code);
			var block = model.Descendants<UnifiedFunctionDefinition>().First().Body;
			return block;
		}

		private static UnifiedBlock CreateAdviceForPython(string code) {
			// TODO テストを書く
			var gen = new Python2ProgramGenerator();
			var model = gen.Generate(code);
			var block = model.Descendants<UnifiedBlock>().First();
			return block;
		}
		
		/// <summary>
		///   与えられたコードをインタータイプ宣言のために共通コードモデルとして生成します
		/// </summary>
		/// <param name = "language">対象言語</param>
		/// <param name = "code">コード断片</param>
		/// <returns></returns>
		public static List<IUnifiedExpression> CreateIntertype(
				string language, string code) {
			XElement ast = null;
			var actual = new List<IUnifiedExpression>();

			switch (language) {
			case "Java":
				//classBodyとしてパースするために中括弧を補う
				code = "{ " + code + " }";
				ast = JavaCodeToXml.Instance.Generate(code, p => p.classBody());
				var classBody = JavaProgramGeneratorHelper.CreateClassBody(ast);
				foreach (var e in classBody) {
					var method = e as UnifiedFunctionDefinition;
					var field = e as UnifiedVariableDefinitionList;
					if (field != null)
						actual.Add(field);
					if (method != null)
						actual.Add(method);
				}
				break;

			case "JavaScript":
				ast = JavaScriptCodeToXml.Instance.Generate(code, p => p.program());
				var program = JavaScriptProgramGeneratorHelper.CreateProgram(ast);
				actual.AddRange(program.Body);
				break;
			default:
				//TODO implement 他の言語についても実装する
				throw new NotImplementedException();
			}
			return actual;
		}

	}
}
