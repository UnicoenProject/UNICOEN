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
using Antlr.Runtime.Tree;

namespace Unicoen.Apps.Aop.Visitor {
	public class DebugVisitor {
		//constructor

		//method
		public static void WriteIndent(int depth) {
			for (var i = 0; i < depth; i++) {
				Console.Write("  ");
			}
		}

		public void Visit(CommonTree root, int depth) {
			if (root.Token == null)
				return;

			var token = root.Token.Text;
			switch (token) {
			case "ASPECT":
				WriteIndent(depth);
				Console.WriteLine("<" + token + ">");
				foreach (var child in root.Children) {
					Visit((CommonTree)child, depth + 1);
				}
				WriteIndent(depth);
				Console.WriteLine("</ " + token + ">");
				return;

			case "ASPECT_BODY":
				WriteIndent(depth);
				Console.WriteLine("<" + token + ">");
				foreach (var child in root.Children) {
					Visit((CommonTree)child, depth + 1);
				}
				WriteIndent(depth);
				Console.WriteLine("</ " + token + ">");
				return;

			case "ELEMENTS":
				WriteIndent(depth);
				Console.WriteLine("<" + token + ">");
				foreach (var child in root.Children) {
					Visit((CommonTree)child, depth + 1);
				}
				WriteIndent(depth);
				Console.WriteLine("</ " + token + ">");
				return;

			case "ELEMENT":
				WriteIndent(depth);
				Console.WriteLine("<" + token + ">");
				foreach (var child in root.Children) {
					Visit((CommonTree)child, depth + 1);
				}
				WriteIndent(depth);
				Console.WriteLine("</ " + token + ">");
				return;

			case "INTERTYPE_DECLARATION":
				WriteIndent(depth);
				Console.WriteLine("<" + token + ">");
				foreach (var child in root.Children) {
					Visit((CommonTree)child, depth + 1);
				}
				WriteIndent(depth);
				Console.WriteLine("</ " + token + ">");
				return;

			case "POINTCUT_DECLARATION":
				WriteIndent(depth);
				Console.WriteLine("<" + token + ">");
				foreach (var child in root.Children) {
					Visit((CommonTree)child, depth + 1);
				}
				WriteIndent(depth);
				Console.WriteLine("</ " + token + ">");
				return;

			case "ADVICE_DECLARATION":
				WriteIndent(depth);
				Console.WriteLine("<" + token + ">");
				foreach (var child in root.Children) {
					Visit((CommonTree)child, depth + 1);
				}
				WriteIndent(depth);
				Console.WriteLine("</ " + token + ">");
				return;

			case "MODIFIERS":
				WriteIndent(depth);
				Console.WriteLine("<" + token + ">");
				foreach (var child in root.Children) {
					Visit((CommonTree)child, depth + 1);
				}
				WriteIndent(depth);
				Console.WriteLine("</ " + token + ">");
				return;

			case "TYPE":
				WriteIndent(depth);
				Console.WriteLine("<" + token + ">");
				foreach (var child in root.Children) {
					Visit((CommonTree)child, depth + 1);
				}
				WriteIndent(depth);
				Console.WriteLine("</ " + token + ">");
				return;

			case "TARGET_CLASS":
				WriteIndent(depth);
				Console.WriteLine("<" + token + ">");
				foreach (var child in root.Children) {
					Visit((CommonTree)child, depth + 1);
				}
				WriteIndent(depth);
				Console.WriteLine("</ " + token + ">");
				return;

			case "POINTCUT_NAME":
				WriteIndent(depth);
				Console.WriteLine("<" + token + ">");
				foreach (var child in root.Children) {
					Visit((CommonTree)child, depth + 1);
				}
				WriteIndent(depth);
				Console.WriteLine("</ " + token + ">");
				return;

			case "IDENTIFIER_WITH_CLASS_NAME":
				WriteIndent(depth);
				Console.WriteLine("<" + token + ">");
				foreach (var child in root.Children) {
					Visit((CommonTree)child, depth + 1);
				}
				WriteIndent(depth);
				Console.WriteLine("</ " + token + ">");
				return;

			case "PARAMETERS":
				WriteIndent(depth);
				Console.WriteLine("<" + token + ">");
				if (root.ChildCount > 0) {
					foreach (var child in root.Children) {
						Visit((CommonTree)child, depth + 1);
					}
				}
				WriteIndent(depth);
				Console.WriteLine("</ " + token + ">");
				return;

			case "PARAMETER":
				WriteIndent(depth);
				Console.WriteLine("<" + token + ">");
				foreach (var child in root.Children) {
					Visit((CommonTree)child, depth + 1);
				}
				WriteIndent(depth);
				Console.WriteLine("</ " + token + ">");
				return;

			case "PARAMETER_TYPE":
				WriteIndent(depth);
				Console.WriteLine("<" + token + ">");
				foreach (var child in root.Children) {
					Visit((CommonTree)child, depth + 1);
				}
				WriteIndent(depth);
				Console.WriteLine("</ " + token + ">");
				return;

			case "METHOD_BODY":
				WriteIndent(depth);
				Console.WriteLine("<" + token + ">");
				foreach (var child in root.Children) {
					Visit((CommonTree)child, depth + 1);
				}
				WriteIndent(depth);
				Console.WriteLine("</ " + token + ">");
				return;

			case "ARGUMENTS":
				WriteIndent(depth);
				Console.WriteLine("<" + token + ">");
				foreach (var child in root.Children) {
					Visit((CommonTree)child, depth + 1);
				}
				WriteIndent(depth);
				Console.WriteLine("</ " + token + ">");
				return;

			case "ARGUMENT":
				WriteIndent(depth);
				Console.WriteLine("<" + token + ">");
				foreach (var child in root.Children) {
					Visit((CommonTree)child, depth + 1);
				}
				WriteIndent(depth);
				Console.WriteLine("</ " + token + ">");
				return;

			case "POINTCUT_DECLARATOR":
				WriteIndent(depth);
				Console.WriteLine("<" + token + ">");
				foreach (var child in root.Children) {
					Visit((CommonTree)child, depth + 1);
				}
				WriteIndent(depth);
				Console.WriteLine("</ " + token + ">");
				return;

			case "ADVICE_BODY":
				WriteIndent(depth);
				Console.WriteLine("<" + token + ">");
				foreach (var child in root.Children) {
					Visit((CommonTree)child, depth + 1);
				}
				WriteIndent(depth);
				Console.WriteLine("</ " + token + ">");
				return;

			case "CODE_FRAGMENTS":
				WriteIndent(depth);
				Console.WriteLine("<" + token + ">");
				foreach (var child in root.Children) {
					Visit((CommonTree)child, depth + 1);
				}
				WriteIndent(depth);
				Console.WriteLine("</ " + token + ">");
				return;

			case "CODE_FRAGMENT":
				WriteIndent(depth);
				Console.WriteLine("<" + token + ">");
				foreach (var child in root.Children) {
					Visit((CommonTree)child, depth + 1);
				}
				WriteIndent(depth);
				Console.WriteLine("</ " + token + ">");
				return;

			case "CONTENTS":
				WriteIndent(depth);
				Console.WriteLine("<" + token + ">");
				foreach (var child in root.Children) {
					Visit((CommonTree)child, depth + 1);
				}
				WriteIndent(depth);
				Console.WriteLine("</ " + token + ">");
				return;

			case "LANGUAGE_DECLARATION":
				WriteIndent(depth);
				Console.WriteLine("<" + token + ">");
				foreach (var child in root.Children) {
					Visit((CommonTree)child, depth + 1);
				}
				WriteIndent(depth);
				Console.WriteLine("</ " + token + ">");
				return;

			case "LANGUAGE_DEPEND_BLOCK":
				WriteIndent(depth);
				Console.WriteLine("<" + token + ">");
				foreach (var child in root.Children) {
					Visit((CommonTree)child, depth + 1);
				}
				WriteIndent(depth);
				Console.WriteLine("</ " + token + ">");
				return;

			case "POINTCUT_TYPE":
				WriteIndent(depth);
				Console.WriteLine("<" + token + ">");
				foreach (var child in root.Children) {
					Visit((CommonTree)child, depth + 1);
				}
				WriteIndent(depth);
				Console.WriteLine("</ " + token + ">");
				return;

			case "ADVICE_TYPE":
				WriteIndent(depth);
				Console.WriteLine("<" + token + ">");
				foreach (var child in root.Children) {
					Visit((CommonTree)child, depth + 1);
				}
				WriteIndent(depth);
				Console.WriteLine("</ " + token + ">");
				return;

			case "ADVICE_TARGET":
				WriteIndent(depth);
				Console.WriteLine("<" + token + ">");
				foreach (var child in root.Children) {
					Visit((CommonTree)child, depth + 1);
				}
				WriteIndent(depth);
				Console.WriteLine("</ " + token + ">");
				return;

			default:
				WriteIndent(depth);
				Console.WriteLine("<TOKEN>" + token + "</TOKEN>");
				return;
			}
		}
	}
}