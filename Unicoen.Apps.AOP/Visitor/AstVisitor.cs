using System;
using System.Collections.Generic;
using Antlr.Runtime.Tree;
using Unicoen.Apps.Aop.AspectElement;

namespace Unicoen.Apps.Aop.Visitor
{
	public class AstVisitor {
		//field
		public List<Intertype> Intertypes = new List<Intertype>();
		public List<Pointcut>  Pointcuts  = new List<Pointcut>();
		public List<Advice>    Advices    = new List<Advice>();

 		//constructor
		public AstVisitor() { }

		//method
		public static void WriteIndent(int depth) {
			for (var i = 0; i < depth; i++) {
				Console.Write("  ");
			}
		}

		public IAspectElement Visit(CommonTree root, int depth, IAspectElement element) {
			if(root.Token == null)
				return element;

			var token = root.Token.Text;
			switch (token) {
				case "ASPECT":
					foreach (var child in root.Children) {
						element = Visit((CommonTree) child, depth + 1, element);
					}
					return element;

				case "ASPECT_BODY":
					foreach (var child in root.Children) {
						element = Visit((CommonTree) child, depth + 1, element);
					}
					return element;

				case "ELEMENTS":
					foreach (var child in root.Children) {
						element = Visit((CommonTree) child, depth + 1, element);
					}
					return element;

				case "ELEMENT" :
					foreach (var child in root.Children) {
						element = Visit((CommonTree) child, depth + 1, element);
					}
					return element;

				case "INTERTYPE_DECLARATION":
					element = new Intertype();
					foreach (var child in root.Children) {
						element = Visit((CommonTree) child, depth + 1, element);
					}
					Intertypes.Add((Intertype)element);
					return element;

				case "POINTCUT_DECLARATION":
					element = new Pointcut();
					foreach (var child in root.Children) {
						element = Visit((CommonTree) child, depth + 1, element);
					}
					Pointcuts.Add((Pointcut) element);
					return element;

				case "ADVICE_DECLARATION" :
					element = new Advice();
					foreach (var child in root.Children) {
						element = Visit((CommonTree) child, depth + 1, element);
					}
					Advices.Add((Advice)element);
					return element;

				case "TYPE" :
					element.SetType(root.GetChild(0).Text);
					return element;

				case "TARGET_CLASS":
					element.SetTarget(root.GetChild(0).Text);
					return element;

				case "POINTCUT_NAME" :
					element.SetName(root.GetChild(0).Text);
					return element;

				case "IDENTIFIER_WITH_CLASS_NAME" :
					foreach (var child in root.Children)
					{
						element.SetTarget(((CommonTree)child).Text);
					}
					return element;

				case "PARAMETERS" :
					if(root.ChildCount > 0) {
						foreach (var child in root.Children)
						{
							element = Visit((CommonTree) child, depth + 1, element);
						}
					}
					return element;

				case "PARAMETER" :
					element = Visit((CommonTree)root.Children[0], depth + 1, element);
					element.SetParameter(((CommonTree) root.Children[1]).Text);
					return element;

				case "PARAMETER_TYPE" :
					element.SetParameterType(root.GetChild(0).Text);
					return element;

				case "ARGUMENTS" :
					WriteIndent(depth);
					Console.WriteLine("<" + token + ">");
					foreach (var child in root.Children) {
						Visit((CommonTree) child, depth + 1, element);
					}
					WriteIndent(depth);
					Console.WriteLine("</ " + token + ">");
					return element;

				case "ARGUMENT" :
					WriteIndent(depth);
					Console.WriteLine("<" + token + ">");
					foreach (var child in root.Children) {
						Visit((CommonTree) child, depth + 1, element);
					}
					WriteIndent(depth);
					Console.WriteLine("</ " + token + ">");
					return element;

				case "POINTCUT_DECLARATOR" :
					foreach (var child in root.Children) {
						element = Visit((CommonTree) child, depth + 1, element);
					}
					return element;

				case "POINTCUT_TYPE" :
					element.SetElementType(root.GetChild(0).Text);
					return element;

				case "ADVICE_BODY" :
					foreach (var child in root.Children) {
						element = Visit((CommonTree) child, depth + 1, element);
					}
					return element;

				case "ADVICE_TYPE" :
					element.SetElementType(root.GetChild(0).Text);
					return element;

				case "ADVICE_TARGET" :
					element.SetTarget(root.GetChild(0).Text);
					return element;

				case "CONTENTS" :
					foreach (var child in root.Children) {
						element.SetContents(((CommonTree)child).Text);
					}
					return element;

				case "LANGUAGE_DECLARATION" :
					element.SetLanguageType(root.GetChild(0).Text);
					return element;

				case "LANGUAGE_DEPEND_BLOCK" :
					foreach (var child in root.Children) {
						element = Visit((CommonTree) child, depth + 1, element);
					}
					return element;

				default :
					return element;
			}
		}

	}
}
