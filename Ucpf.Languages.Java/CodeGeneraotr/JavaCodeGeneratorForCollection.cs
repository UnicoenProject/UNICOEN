using System;
using Ucpf.Core.Model;

namespace Ucpf.Languages.Java.CodeGeneraotr
{
	public struct TokenInfo
	{
		/// <summary>
		///   左端の文字
		/// </summary>
		public string Left;

		/// <summary>
		///   右端の文字
		/// </summary>
		public string Right;

		/// <summary>
		///   区切り文字
		/// </summary>
		public string Delimiter;

		///// <summary>
		///// 親要素が集合である場合の自分自身の要素位置
		///// </summary>
		//public int Index;
	}

	public partial class JavaCodeGenerator
	{
		#region collection

		public void VisitCollection<T, TSelf>(
			UnifiedElementCollection<T, TSelf> elements, TokenInfo data)
			where T : class, IUnifiedElement
			where TSelf : UnifiedElementCollection<T, TSelf>
		{
			_writer.Write(data.Left);
			var splitter = "";
			foreach (var e in elements) {
				_writer.Write(splitter);
				e.Accept(this);
				splitter = data.Delimiter;
			}
			_writer.Write(data.Right);
		}

		public void Visit(UnifiedParameterCollection parameters)
		{
			VisitCollection(parameters, new TokenInfo {
				Left = "(",
				Delimiter = ", ",
				Right = ")",
			});
		}

		public void Visit(UnifiedModifierCollection modifiers)
		{
			VisitCollection(modifiers, new TokenInfo {
				Left = "",
				Delimiter = " ",
				Right = "",
			});
		}

		// e.g. Class : Class', Class''  ?
		public void Visit(UnifiedTypeCollection element)
		{
			var delimiter = "";
			foreach (var type in element) {
				_writer.Write(delimiter);
				type.Accept(this);
				delimiter = " ,";
			}
		}

		// e.g. {...}catch(Exception1 e1){...}catch{Exception2 e2}{....}... ?
		public void Visit(UnifiedCatchCollection catchCollection)
		{
			foreach (var element in catchCollection) {
				element.Accept(this);
			}
		}

		// e.g. Foo<A, B> ?
		public void Visit(UnifiedTypeParameterCollection element)
		{
			foreach (var parameter in element) {
				parameter.Type.Accept(this);
			}
		}

		public void Visit(UnifiedTypeConstrainCollection element)
		{
			throw new NotImplementedException();
		}

		public void Visit(UnifiedTypeSupplementCollection element)
		{
			throw new NotImplementedException();
		}

		public void Visit(UnifiedVariableDefinitionBodyCollection element)
		{
			throw new NotImplementedException();
		}

		public void Visit(UnifiedIdentifierCollection element)
		{
			throw new NotImplementedException();
		}

		public void Visit(UnifiedArgumentCollection args)
		{
			_writer.Write("(");
			var splitter = "";
			foreach (var arg in args) {
				_writer.Write(splitter);
				arg.Accept(this);
				splitter = ", ";
			}
			_writer.Write(")");
		}

		// when to use ?
		public void Visit(UnifiedExpressionCollection element)
		{
			throw new NotImplementedException();
		}

		public void Visit(UnifiedTypeArgumentCollection element)
		{
			throw new NotImplementedException();
		}

		public void Visit(UnifiedCaseCollection element)
		{
			_indent++;
			foreach (var caseElement in element) {
				WriteIndent();
				caseElement.Accept(this);
			}
			_indent--;
		}

		#endregion
	}
}