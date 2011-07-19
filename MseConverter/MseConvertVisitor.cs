using System;
using System.Collections.Generic;
using System.IO;
using Unicoen.Model;
using Unicoen.Processor;

namespace MseConverter
{
	/// <summary>
	/// MSEフォーマット上に記述される要素について出力します。
	/// </summary>
	public partial class MseConvertVisitor : ExplicitDefaultUnifiedVisitor<VisitorArgument, bool> {
		
		public TextWriter Writer { get; protected set; }
		public int Id = 2;
		public int CurrentPackage = 2;
		public int CurrentMethod = 2;

		public MseConvertVisitor(TextWriter writer) {
			Writer = writer;
		}

		private static string GetAccessControlQualifier(IEnumerable<UnifiedModifier> modifiers) {
			foreach (var modifier in modifiers) {
				switch (modifier.Name) {
					case "public":
						return "public";
					case "private":
						return "private";
					case "protected":
						return "protected";
				}
			}
			//TODO アクセス修飾子がない場合への対応
			throw new NotImplementedException();
		}

		private void WriteIndent(int n) {
			for(var i = 0; i < n; i++) {
				Writer.Write("\t");
			}
		}

		public override bool Visit(
				UnifiedNamespaceDefinition element, VisitorArgument arg) {
			WriteIndent(2);
			Writer.Write("(FAMIX.Package ");
			WriteIndent(3);
			Writer.WriteLine("(id: " + Id + ")");
			CurrentPackage = Id++;

			//パッケージ名の出力
			Writer.Write("(name \'");
			element.Name.TryAccept(this, arg);
			Writer.WriteLine("\')");
			Writer.WriteLine(")");

			//TODO ここでうまいことIdを渡せればあとが楽かも
			element.Body.TryAccept(this, arg);
			return false;
		}

		public override bool Visit(
				UnifiedClassDefinition element, VisitorArgument arg) {
			WriteIndent(2);
			Writer.Write("(FAMIX.Class ");
			Writer.WriteLine("(id: " + Id + ")");
			CurrentMethod = Id++;

			WriteIndent(3);
			Writer.Write("(name \'");
			element.Name.TryAccept(this, arg);
			Writer.WriteLine("\')");
			
			//パッケージ化されているパッケージIDを出力
			//TODO ここで上からIdを受け取っているとやりやすい
			WriteIndent(3);
			Writer.WriteLine("(packagedIn (idref: " + CurrentPackage + "))");

			var isAbstract = false;
			var modifiers = element.Modifiers;
			foreach (var modifier in modifiers) {
				if(modifier.Name == "abstract")
					isAbstract = true;
			}
			WriteIndent(3);
			Writer.WriteLine(isAbstract ? "(isAbstract true))" : "(isAbstract false))");

			element.Body.TryAccept(this, arg);

			return false;
		}

		public override bool Visit(
				UnifiedFunctionDefinition element, VisitorArgument arg) {
			WriteIndent(2);
			Writer.Write("(FAMIX.Method ");
			Writer.WriteLine("(id: " + Id++ + ")");

			WriteIndent(3);
			Writer.Write("(name \'");
			element.Name.TryAccept(this, arg);
			Writer.WriteLine("\')");

			WriteIndent(3);
			Writer.WriteLine("(accessControlQualifier \'" + 
				GetAccessControlQualifier(element.Modifiers) + "\')");
			
			WriteIndent(3);
			Writer.WriteLine("(belongsTo (idref: " + CurrentMethod + "))");
			//TODO LOCの計算
			WriteIndent(3);
			Writer.WriteLine("(LOC 100)");
			WriteIndent(3);
			Writer.WriteLine("(packagedIn (idref: " + CurrentPackage + "))");

			WriteIndent(3);
			Writer.Write("(signature \'");
			element.Name.TryAccept(this, arg);
			Writer.Write("(");
			element.Parameters.TryAccept(this, arg);
			Writer.WriteLine(")\'))");

			return false;
		}

		public override bool Visit(
				UnifiedVariableDefinitionList element, VisitorArgument arg) {
			foreach (var variableDefinition in element) {
				variableDefinition.TryAccept(this, arg);
			}
			return false;
		}

		public override bool Visit(UnifiedVariableDefinition element, VisitorArgument arg) {
			WriteIndent(2);
			Writer.Write("(FAMIX.Attribute ");
			Writer.WriteLine("(id: " + Id++ + ")");

			WriteIndent(3);
			Writer.Write("(name \'");
			element.Type.TryAccept(this, arg);
			Writer.WriteLine("\')");

			WriteIndent(3);
			Writer.WriteLine("(accessControlQualifier \'" + 
				GetAccessControlQualifier(element.Modifiers) + "\')");
			
			WriteIndent(3);
			Writer.WriteLine("(belongsTo (idref: " + CurrentMethod + "))");

			return false;
		}

		public override bool Visit(UnifiedConstructor element, VisitorArgument arg) {
			//TODO コンストラクタはMethodに含まれるのか確認
			//element.Body.TryAccept(this, arg);
			return false;
		}
	}
}