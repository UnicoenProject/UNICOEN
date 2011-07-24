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
using System.Collections.Generic;
using System.IO;
using Unicoen.Languages.Java.CodeFactories;
using Unicoen.Model;
using Unicoen.Processor;

namespace MseConverter {
	/// <summary>
	///   MSEフォーマット上に記述される要素について出力します。
	/// </summary>
	public partial class MseConvertVisitor : DefaultUnifiedVisitor {
		public TextWriter Writer { get; protected set; }
		public JavaCodeFactory Generator = new JavaCodeFactory();

		private int _id = 2;

		public int Id = 2;
		public int CurrentPackage = 2;
		public int CurrentClass = 2;
		public int CurrentMethod = 2;

		public MseConvertVisitor(TextWriter writer) {
			Writer = writer;
		}

		private static string GetAccessControlQualifier(
				IEnumerable<UnifiedModifier> modifiers) {
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
			return "public";
		}

		public override void Visit(
				UnifiedNamespaceDefinition element) {
			Writer.Write("(FAMIX.Package ");
			Writer.WriteLine("(id: " + Id + ")");
			CurrentPackage = Id++;

			//パッケージ名の出力
			Writer.Write("(name \'");
			element.Name.TryAccept(this);
			Writer.WriteLine("\'))");

			element.Body.TryAccept(this);
		}

		public override void Visit(
				UnifiedClassDefinition element) {
			Writer.Write("(FAMIX.Class ");
			Writer.WriteLine("(id: " + Id + ")");
			CurrentClass = Id++;

			Writer.Write("(name \'");
			element.Name.TryAccept(this);
			Writer.WriteLine("\')");

			//パッケージ化されているパッケージIDを出力
			Writer.WriteLine("(packagedIn (idref: " + CurrentPackage + "))");

			var isAbstract = false;
			var modifiers = element.Modifiers;
			foreach (var modifier in modifiers) {
				if (modifier.Name == "abstract")
					isAbstract = true;
			}
			Writer.WriteLine(isAbstract ? "(isAbstract true))" : "(isAbstract false))");

			element.Body.TryAccept(this);
		}

		public override void Visit(
				UnifiedFunctionDefinition element) {
			Writer.Write("(FAMIX.Method ");
			Writer.WriteLine("(id: " + Id++ + ")");

			Writer.Write("(name \'");
			element.Name.TryAccept(this);
			Writer.WriteLine("\')");

			Writer.WriteLine(
					"(accessControlQualifier \'" +
					GetAccessControlQualifier(element.Modifiers) + "\')");

			Writer.WriteLine("(belongsTo (idref: " + CurrentClass + "))");
			//TODO LOCの計算
			Writer.WriteLine("(LOC 100)");
			Writer.WriteLine("(packagedIn (idref: " + CurrentPackage + "))");

			Writer.Write("(signature \'");
			Generator.Generate(element.Name, Writer);
			Writer.Write("(");
			Generator.Generate(element.Parameters, Writer);
			Writer.WriteLine(")\'))");
		}

		public override void Visit(
				UnifiedVariableDefinitionList element) {
			foreach (var variableDefinition in element) {
				variableDefinition.TryAccept(this);
			}
		}

		public override void Visit(UnifiedVariableDefinition element) {
			Writer.Write("(FAMIX.Attribute ");
			Writer.WriteLine("(id: " + Id++ + ")");

			Writer.Write("(name \'");
			element.Type.TryAccept(this);
			Writer.WriteLine("\')");

			Writer.WriteLine(
					"(accessControlQualifier \'" +
					GetAccessControlQualifier(element.Modifiers) + "\')");

			Writer.WriteLine("(belongsTo (idref: " + CurrentClass + "))");
		}

		public override void Visit(UnifiedCall element) {
			Writer.Write("(FAMIX.Invocation ");
			Writer.WriteLine("(id: " + Id++ + ")");

			//TODO どうやってメソッド定義のidを取得するか
			Writer.Write("(candidate (idref: ");

			Writer.Write("(invokedBy (idref: " + CurrentClass + "))");

			Writer.Write("(invokes )");
			Generator.Generate(element, Writer);
			Writer.WriteLine(")");

			Writer.WriteLine("(stub false))");
		}

		public override void Visit(UnifiedConstructor element) {
			//TODO コンストラクタはMethodに含まれるのか確認
			//element.Body.TryAccept(this);
		}
	}
}