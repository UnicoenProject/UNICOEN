using System;
using Ucpf.Core.Model;

namespace Ucpf.Languages.Java.CodeGeneraotr
{
	/// <summary>
	/// MostLeft EachLeft Element1 EachRight Delimiter EachLeft Element2 EachRight ... MostRight
	/// </summary>
	public struct TokenInfo
	{
		/// <summary>
		///   左端の文字
		/// </summary>
		public string MostLeft;

		/// <summary>
		///   右端の文字
		/// </summary>
		public string MostRight;

		/// <summary>
		///   各要素の直前
		/// </summary>
		public string EachLeft;

		/// <summary>
		///   各要素の直後
		/// </summary>
		public string EachRight;

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
		public void VisitCollection<T, TSelf>(
			UnifiedElementCollection<T, TSelf> elements, TokenInfo data)
			where T : class, IUnifiedElement
			where TSelf : UnifiedElementCollection<T, TSelf>
		{
			_writer.Write(data.MostLeft);
			var splitter = "";
			foreach (var e in elements) {
				_writer.Write(splitter);
				_writer.Write(data.EachLeft);
				e.Accept(this);
				_writer.Write(data.EachRight);
				splitter = data.Delimiter;
			}
			_writer.Write(data.MostRight);
		}

		public void Visit(UnifiedParameterCollection parameters)
		{
			VisitCollection(parameters, new TokenInfo {
				MostLeft = "(",
				MostRight = ")",
				EachLeft = "",
				EachRight = "",
				Delimiter = ", ",
			});
		}

		public void Visit(UnifiedModifierCollection modifiers)
		{
			VisitCollection(modifiers, new TokenInfo {
				MostLeft = "",
				MostRight = "",
				EachLeft = "",
				EachRight = " ",
				Delimiter = "",
			});
		}

		// e.g. throws E1, E2 ...
		public void Visit(UnifiedTypeCollection types)
		{
			VisitCollection(types, new TokenInfo {
				MostLeft = "",
				MostRight = " ",
				EachLeft = "",
				EachRight = "",
				Delimiter = ", ",
			});
		}

		// e.g. {...}catch(Exception1 e1){...}catch{Exception2 e2}{....}... ?
		public void Visit(UnifiedCatchCollection catches)
		{
			VisitCollection(catches, new TokenInfo {
				MostLeft = "",
				MostRight = "",
				EachLeft = "",
				EachRight = "\n",
				Delimiter = "",
			});
		}

		// e.g. Foo<A, B> ?
		public void Visit(UnifiedTypeParameterCollection parameters)
		{
			VisitCollection(parameters, new TokenInfo {
				MostLeft = "<",
				MostRight = ">",
				EachLeft = "",
				EachRight = "",
				Delimiter = ", ",
			});
		}

		public void Visit(UnifiedTypeConstrainCollection constrains)
		{
			throw new NotImplementedException();
		}

		public void Visit(UnifiedTypeSupplementCollection element)
		{
			foreach (var e in element) {
				e.Accept(this);
			}
		}

		public void Visit(UnifiedVariableDefinitionBodyCollection element)
		{
			foreach (var e in element) {
				e.Accept(this);
			}
			WriteIndent();
		}

		public void Visit(UnifiedIdentifierCollection element)
		{
			throw new NotImplementedException();
		}

		public void Visit(UnifiedArgumentCollection args)
		{
			//_writer.Write("(");
			var splitter = "";
			foreach (var arg in args) {
				_writer.Write(splitter);
				arg.Accept(this);
				splitter = ", ";
			}
			//_writer.Write(")");
		}

		public void Visit(UnifiedExpressionCollection element)
		{
			foreach (var exp in element) {
				if(exp != null)
					exp.Accept(this);
			}
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
	}
}