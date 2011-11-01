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

using System;
using Unicoen.Model;
using Unicoen.Processor;

namespace Unicoen.Languages.JavaScript.CodeGenerators {
	public partial class JavaScriptCodeFactoryVisitor {

		//2項演算子
		public override bool Visit(UnifiedBinaryOperator element, VisitorArgument arg) {
			Writer.Write(element.Sign);
			return false;
		}

		//単項演算子
		public override bool Visit(UnifiedUnaryOperator element, VisitorArgument arg) {
			var kind = element.Kind;
			switch (kind) {
			case (UnifiedUnaryOperatorKind.Negate):
				Writer.Write("-");
				break;
			case (UnifiedUnaryOperatorKind.Not):
				Writer.Write("!");
				break;
			case (UnifiedUnaryOperatorKind.PostDecrementAssign):
			case (UnifiedUnaryOperatorKind.PreDecrementAssign):
				Writer.Write("--");
				break;
			case (UnifiedUnaryOperatorKind.PostIncrementAssign):
			case (UnifiedUnaryOperatorKind.PreIncrementAssign):
				Writer.Write("++");
				break;
			case (UnifiedUnaryOperatorKind.UnaryPlus):
				Writer.Write("+");
				break;
			case (UnifiedUnaryOperatorKind.OnesComplement):
				Writer.Write("~");
				break;
			case (UnifiedUnaryOperatorKind.Unknown):
				Writer.Write(element.Sign);
				break;
			default:
				throw new InvalidOperationException();
			}
			return false;
		}

		//実引数
		public override bool Visit(UnifiedArgument element, VisitorArgument arg) {
			element.Value.TryAccept(this, arg);
			return false;
		}

		//ブロック
		public override bool Visit(UnifiedBlock element, VisitorArgument arg) {
			//「いわゆるブロック」と「式のリストの入れ物としてのブロック」があるため、decorationでどちらかを判断する
			var decoration = arg.Decoration;

			//いわゆるブロックの場合 : e.g. while(true){ }の{ }の部分
			if (decoration.MostLeft == "{") {
				Writer.WriteLine(decoration.MostLeft);
				arg = arg.IncrementDepth(); //ブロック内部ではインデントを1つ下げる

				//ブロック内部の式を出力
				foreach (var stmt in element) {
					WriteIndent(arg.IndentDepth);
					if (stmt.TryAccept(this, arg))
						Writer.Write(";");
					Writer.Write(decoration.EachRight);
				}

				arg = arg.DecrementDepth(); //インデントを元に戻す
				WriteIndent(arg.IndentDepth);
				Writer.Write(decoration.MostRight);
				return false;
			}

			//式のリストの入れ物としてのブロックの場合 : e.g. return 1,2,3;の1,2,3の部分
			//式の数が0個の場合は何も出力せずに終了
			if (element.Count == 0)
				return false;

			//式が1つ以上ある場合
			//TODO なぜ括弧を出力するのか確認
			Writer.Write("(");
			var comma = "";
			foreach (var e in element) {
				Writer.Write(comma);
				e.TryAccept(this, arg);
				comma = decoration.Delimiter;
			}
			Writer.Write(")");
			return false;
		}

		//関数定義 : e.g. function hoge() { }
		public override bool Visit(
				UnifiedFunctionDefinition element, VisitorArgument arg) {
			WriteIndent(arg.IndentDepth);
			Writer.Write("function ");
			element.Name.TryAccept(this, arg);
			element.Parameters.TryAccept(this, arg);
			element.Body.TryAccept(this, arg.Set(ForBlock));
			return element.Body == null;
		}

		//ラムダ式(無名関数)
		public override bool Visit(UnifiedLambda element, VisitorArgument arg) {
			//λ式の場合、即時発火があり得るので全体を()で囲っておく
			WriteIndent(arg.IndentDepth);
			Writer.Write("(");
			Writer.Write("function ");
			//TODO ラムダ式は名前があるのかどうか確認
			element.Name.TryAccept(this, arg);
			element.Parameters.TryAccept(this, arg);
			element.Body.TryAccept(this, arg.Set(ForBlock));
			Writer.Write(")");
			return element.Body == null;
		}

		//if文
		public override bool Visit(UnifiedIf ifStatement, VisitorArgument arg) {
			Writer.Write("if (");
			ifStatement.Condition.TryAccept(this, arg.Set(CommaDelimiter));
			Writer.Write(")");
			ifStatement.Body.TryAccept(this, arg.Set(ForBlock));
			if (ifStatement.ElseBody != null) {
				WriteIndent(arg.IndentDepth);
				Writer.WriteLine("else");
				ifStatement.ElseBody.TryAccept(this, arg.Set(ForBlock));
			}
			return false;
		}

		//仮引数
		public override bool Visit(UnifiedParameter element, VisitorArgument arg) {
			element.Names.TryAccept(this, arg);
			return false;
		}

		//変数
		public override bool Visit(
				UnifiedVariableIdentifier element, VisitorArgument arg) {
			Writer.Write(element.Name);
			return false;
		}

		//ラベル
		public override bool Visit(
				UnifiedLabelIdentifier element, VisitorArgument arg) {
			Writer.Write(element.Name);
			return false;
		}

		//TODO JavaScriptでは出現しないか確認。言語変換向け？
		public override bool Visit(
				UnifiedSuperIdentifier element, VisitorArgument arg) {
			Writer.Write("");
			return false;
		}

		//this識別子
		public override bool Visit(UnifiedThisIdentifier element, VisitorArgument arg) {
			Writer.Write("this");
			return false;
		}

		//修飾子 : JavaScriptでは出現しない
		public override bool Visit(UnifiedModifier element, VisitorArgument arg) {
			return false;
		}

		//Import文 : JavaScriptでは出現しない
		public override bool Visit(UnifiedImport element, VisitorArgument arg) {
			return false;
		}

		//コンストラクタ : JavaScriptでは出現しない
		public override bool Visit(UnifiedConstructor element, VisitorArgument arg) {
			return false;
		}

		//インスタンスイニシャライザ : JavaScriptでは出現しない
		public override bool Visit(
				UnifiedInstanceInitializer element, VisitorArgument arg) {
			return false;
		}

		//staticイニシャライザ : JavaScriptでは出現しない
		public override bool Visit(
				UnifiedStaticInitializer element, VisitorArgument arg) {
			return false;
		}

		//プログラム全体
		public override bool Visit(UnifiedProgram element, VisitorArgument arg) {
			foreach (var sourceElement in element.Body) {
				if (sourceElement.TryAccept(this, arg))
					Writer.Write(";");
				Writer.Write("\n");
			}
			return false;
		}

		//単項式
		public override bool Visit(
				UnifiedUnaryExpression element, VisitorArgument arg) {
			//後置演算子が付く場合 : a++ || a--
			if (element.Operator.Kind == UnifiedUnaryOperatorKind.PostIncrementAssign ||
			    element.Operator.Kind == UnifiedUnaryOperatorKind.PostDecrementAssign) {
				element.Operand.TryAccept(this, arg.Set(Paren));
				element.Operator.TryAccept(this, arg);
			} 
			//それ以外の場合は前置演算子(または演算子なし)
			else {
				element.Operator.TryAccept(this, arg);
				element.Operand.TryAccept(this, arg.Set(Paren));
			}
			return true;
		}
		
		//プロパティ : e.g. A.B
		public override bool Visit(UnifiedProperty element, VisitorArgument arg) {
			element.Owner.TryAccept(this, arg);
			Writer.Write(element.Delimiter);
			element.Name.TryAccept(this, arg);
			return true;
		}

		//while文
		public override bool Visit(UnifiedWhile element, VisitorArgument arg) {
			Writer.Write("while(");
			element.Condition.TryAccept(this, arg.Set(CommaDelimiter));
			Writer.Write(")");

			element.Body.TryAccept(this, arg.Set(ForBlock));
			return false;
		}

		//do-while文
		public override bool Visit(UnifiedDoWhile element, VisitorArgument arg) {
			Writer.Write("do");
			element.Body.TryAccept(this, arg.Set(ForBlock));
			Writer.Write("while(");
			element.Condition.TryAccept(this, arg.Set(CommaDelimiter));
			Writer.Write(");"); //TODO なぜここでセミコロンを打つのか確認
			return false;
		}

		//配列のインデクサ : e.g. a[10]
		public override bool Visit(UnifiedIndexer element, VisitorArgument arg) {
			element.Target.TryAccept(this, arg);
			element.Arguments.TryAccept(this, arg.Set(Bracket));
			return false;
		}
		
		//ジェネリックタイプ : JavaScriptでは出現しない
		public override bool Visit(
				UnifiedGenericArgument element, VisitorArgument arg) {
			return false;
		}

		//switch文
		public override bool Visit(UnifiedSwitch element, VisitorArgument arg) {
			Writer.Write("switch(");
			element.Value.TryAccept(this, arg.Set(CommaDelimiter));
			Writer.WriteLine(") {");

			element.Cases.TryAccept(this, arg);
			Writer.Write("}");
			return false;
		}

		//case文
		public override bool Visit(UnifiedCase element, VisitorArgument arg) {
			//case条件がない場合はデフォルト文
			if (element.Condition == null) {
				Writer.Write("default:\n");
			} else {
				Writer.Write("case ");
				element.Condition.TryAccept(this, arg);
				Writer.Write(":\n");
			}
			element.Body.TryAccept(this, arg.Set(ForBlock));
			return false;
		}

		//with文
		public override bool Visit(UnifiedWith element, VisitorArgument arg) {
			Writer.Write("with (");
			element.Value.TryAccept(this, arg);
			Writer.Write(")");
			element.Body.TryAccept(this, arg.Set(ForBlock));
			return false;
		}

		//try文
		public override bool Visit(UnifiedTry element, VisitorArgument arg) {
			//tryブロック
			Writer.Write("try");
			element.Body.TryAccept(this, arg.Set(ForBlock));

			//catchブロック
			element.Catches.TryAccept(this, arg.Set(SemiColonDelimiter));

			//finallyブロック
			var finallyBlock = element.FinallyBody;
			//finallyブロックがある場合はその内容を出力
			if (finallyBlock != null) {
				Writer.Write("finally");
				finallyBlock.TryAccept(this, arg.Set(ForBlock));
			}
			return false;
		}

		// catchブロック
		public override bool Visit(UnifiedCatch element, VisitorArgument arg) {
			Writer.Write("catch(");
			element.Annotations.TryAccept(this, arg);
			element.Modifiers.TryAccept(this, arg);
			Writer.Write(" ");
			element.Assign.TryAccept(this, arg);
			Writer.Write(")");
			element.Body.TryAccept(this, arg.Set(ForBlock));
			return false;
		}

		//継承 : JavaScriptでは出現しない
		public override bool Visit(
				UnifiedTypeConstrainCollection element, VisitorArgument arg) {
			return false;
		}

		//ジェネリックパラメータ : JavaScriptでは出現しない
		public override bool Visit(
				UnifiedGenericParameter element, VisitorArgument arg) {
			return false;
		}
		
		//ラベル
		public override bool Visit(UnifiedLabel element, VisitorArgument arg) {
			element.Name.TryAccept(this, arg);
			Writer.Write(":");
			return false;
		}

		//論理型リテラル
		public override bool Visit(UnifiedBooleanLiteral element, VisitorArgument arg) {
			Writer.Write(element.Value ? "true" : "false");
			return false;
		}

		//数値リテラルはサフィックスをつけずに出力
		public override bool Visit(UnifiedBigIntLiteral element, VisitorArgument arg) {
			Writer.Write(element.Value);
			return false;
		}
		public override bool Visit(UnifiedUInt64Literal element, VisitorArgument arg) {
			Writer.Write(element.Value);
			return false;
		}
		public override bool Visit(UnifiedInt64Literal element, VisitorArgument arg) {
			Writer.Write(element.Value);
			return false;
		}
		
		//小数リテラル
		public override bool Visit(
				UnifiedFractionLiteral element, VisitorArgument arg) {
			// TODO: そのまま出力しても良いのか？
			Writer.Write(element.Value.ToString("r"));
			return false;
		}

		//文字列リテラル
		public override bool Visit(UnifiedStringLiteral element, VisitorArgument arg) {
			Writer.Write(element.Value);
			return false;
		}

		//charリテラル
		public override bool Visit(UnifiedCharLiteral element, VisitorArgument arg) {
			Writer.Write(element.Value);
			return false;
		}

		//名前空間宣言 : JavaScriptでは出現しない
		public override bool Visit(
				UnifiedNamespaceDefinition element, VisitorArgument arg) {
			return false;
		}

		//nullリテラル
		public override bool Visit(UnifiedNullLiteral element, VisitorArgument arg) {
			Writer.Write("null");
			return false;
		}
		
		//using文 : JavaScriptでは出現しない
		public override bool Visit(UnifiedUsing element, VisitorArgument arg) {
			return false;
		}

		//リスト内包表記式やジェネレータ式 : JavaScriptでは出現しない
		public override bool Visit(
				UnifiedListComprehension element, VisitorArgument arg) {
			return false;
		}
		
		//リストリテラル? : JavaScriptでは出現しない
		public override bool Visit(UnifiedListLiteral element, VisitorArgument arg) {
			return false;
		}
		
		//KeyValue式(オブジェクト) : e.g. {a : 1, b : 2, c : 3}
		public override bool Visit(UnifiedKeyValue element, VisitorArgument arg) {
			WriteIndent(arg.IndentDepth);
			element.Key.TryAccept(this, arg);
			Writer.Write(":");
			element.Value.TryAccept(this, arg);
			return false;
		}

		//TODO 辞書リテラル : JavaScriptでは出現しない?
		public override bool Visit(UnifiedMapLiteral element, VisitorArgument arg) {
			Writer.Write("{");
			VisitCollection(element, arg.Set(CommaDelimiter));
			WriteIndent(arg.IndentDepth);
			Writer.Write("}");
			return false;
		}

		//スライス表記 : JavaScriptでは出現しない
		public override bool Visit(UnifiedSlice element, VisitorArgument arg) {
			return false;
		}

		//コメント
		public override bool Visit(UnifiedComment element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		//正規表現リテラル : e.g. /abc/gim
		public override bool Visit(
				UnifiedRegularExpressionLiteral element, VisitorArgument arg) {
			Writer.Write("/");
			Writer.Write(element.Value);
			Writer.Write("/");
			Writer.Write(element.Options);
			return false;
		}

		//配列リテラル
		public override bool Visit(UnifiedArrayLiteral element, VisitorArgument arg) {
			Writer.Write("[");
			var comma = "";
			foreach (var e in element) {
				Writer.Write(comma);
				e.TryAccept(this, arg);
				comma = ",";
			}
			Writer.Write("]");
			return false;
		}

		//型
		public override bool Visit(UnifiedBasicType element, VisitorArgument arg) {
			element.BasicTypeName.TryAccept(this, arg);
			return false;
		}
	}
}