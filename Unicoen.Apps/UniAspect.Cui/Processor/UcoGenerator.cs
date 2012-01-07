using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Code2Xml.Languages.C.CodeToXmls;
using Code2Xml.Languages.Java.CodeToXmls;
using Code2Xml.Languages.JavaScript.CodeToXmls;
using Unicoen.Languages.C.ProgramGenerators;
using Unicoen.Languages.CSharp.ProgramGenerators;
using Unicoen.Languages.Java.ProgramGenerators;
using Unicoen.Languages.JavaScript.ProgramGenerators;
using Unicoen.Languages.Python2.ProgramGenerators;
using Unicoen.Model;

namespace Unicoen.Apps.UniAspect.Cui.Processor {
	public class UcoGenerator {
		/// <summary>
		///   与えられたコードを共通コードオブジェクトとして生成します。
		/// </summary>
		/// <param name = "language">対象言語</param>
		/// <param name = "code">コード断片</param>
		/// <returns></returns>
		public static UnifiedBlock CreateAdvice(string language, string code) {
			XElement ast;
			UnifiedBlock actual;

			/*
			 * 与えられたコード断片をブロックとして統合コードオブジェクトに変換します
			 * これにより、シンタックス上では安全なオブジェクトの挿入を実現します
			 * (カスタムポイントカットは除く)
			 * 
			 * 部分的なコードを統合コードオブジェクトに変換する機能が提供されている言語の場合：
			 * (Java, JavaScript, C)
			 * コード断片全体を中括弧で括ることでブロックとしてのパースができるようにします
			 * したがって、ブロック内に記述できないプログラムはアドバイスとして記述できません
			 * 
			 * 上記の機能が提供されていない言語の場合：
			 * (CSharp, Python)
			 * 専用のメソッドを使用します
			 * 具体的には、コード断片に対して、それが１プログラムとしてパースできるまで最小限のコード補完を行い、
			 * 統合コードオブジェクトに変換後、元のコードに該当する部分だけを抽出します
			 */
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
				//Ruby, VB // TODO Ruby言語の対応
				throw new InvalidOperationException("対応していない言語が指定されました");
			}
			actual.Normalize();

			return actual;
		}

		// 与えられたC#のコードを共通コードオブジェクトとして生成します
		private static UnifiedBlock CreateAdviceForCSharp(string code) {
			// 1つのメソッドを持つクラスとして統合コードオブジェクトを生成するために、
			// そのメソッドが、与えられたコード断片を内部持つようにコードを補完します
			code = "public class C { public int M() {" + code + "}}";
			var gen = new CSharpProgramGenerator();
			var model = gen.Generate(code);
			var block = model.Descendants<UnifiedFunctionDefinition>().First().Body;
			return block;
		}

		// 与えられたPythonのコードを共通コードオブジェクトとして生成します
		private static UnifiedBlock CreateAdviceForPython(string code) {
			// Pythonはインタプリタ言語のため、
			// 文法的に正しいコード断片であればそのまま統合コードオブジェクトに変換できます
			// プログラム全体(UnifiedProgram)はブロックから構成されるため、そのブロックをアドバイスとして返します
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
			XElement ast;
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
			case "C":
				throw new NotImplementedException();
			case "CSharp":
				throw new NotImplementedException();
			case "Python":
				throw new NotImplementedException();
			default: //Ruby, VB // TODO Ruby言語の対応
				throw new InvalidOperationException("対応していない言語が指定されました");
			}
			return actual;
		}
	}
}
