using System;
using Ucpf.Core.Model;
using Ucpf.Core.Model.Extensions;

namespace Ucpf.Languages.Java.CodeGeneraotr {
	/// <summary>
	///   MostLeft EachLeft Element1 EachRight Delimiter EachLeft Element2 EachRight ... MostRight
	/// </summary>
	public class TokenInfo {
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

		public TokenInfo() {
			MostLeft = "";
			MostRight = "";
			EachLeft = "";
			EachRight = "";
			Delimiter = "";
		}

		///// <summary>
		///// 親要素が集合である場合の自分自身の要素位置
		///// </summary>
		//public int Index;
	}

	public partial class JavaCodeGenerator {
		public void VisitCollection<T, TSelf>(
				UnifiedElementCollection<T, TSelf> elements, TokenInfo data)
				where T : class, IUnifiedElement
				where TSelf : UnifiedElementCollection<T, TSelf> {
			Writer.Write(data.MostLeft);
			var splitter = "";
			foreach (var e in elements) {
				Writer.Write(splitter);
				Writer.Write(data.EachLeft);
				e.TryAccept(this, data);
				Writer.Write(data.EachRight);
				splitter = data.Delimiter;
			}
			Writer.Write(data.MostRight);
		}

		public bool Visit(UnifiedParameterCollection element, TokenInfo data) {
			VisitCollection(element, new TokenInfo {
					MostLeft = "(",
					MostRight = ")",
					Delimiter = ", ",
			});
			return false;
		}

		public bool Visit(UnifiedModifierCollection element, TokenInfo data) {
			VisitCollection(element, new TokenInfo {
					EachRight = " ",
			});
			return false;
		}

		// e.g. throws E1, E2 ...
		public bool Visit(UnifiedTypeCollection element, TokenInfo data) {
			VisitCollection(element, new TokenInfo {
					MostRight = " ",
					Delimiter = ", ",
			});
			return false;
		}

		// e.g. {...}catch(Exception1 e1){...}catch{Exception2 e2}{....}... ?
		public bool Visit(UnifiedCatchCollection element, TokenInfo data) {
			VisitCollection(element, new TokenInfo {
					EachRight = "\n",
			});
			return false;
		}

		// e.g. Foo<A, B> ?
		public bool Visit(UnifiedTypeParameterCollection element, TokenInfo data) {
			VisitCollection(element, new TokenInfo {
					MostLeft = "<",
					MostRight = ">",
					Delimiter = ", ",
			});
			return false;
		}

		public static string GetKeyword(UnifiedTypeConstrainKind kind) {
			switch (kind) {
			case UnifiedTypeConstrainKind.Extends:
			case UnifiedTypeConstrainKind.ExtendsOrImplements:
				return "extends";
			case UnifiedTypeConstrainKind.Implements:
				return "implements";
			case UnifiedTypeConstrainKind.Super:
				return "super";
			default:
				break;
			}
			return "";
		}

		public bool Visit(UnifiedTypeConstrainCollection element, TokenInfo data) {
			UnifiedTypeConstrain last = null;
			for (int i = 0; i < element.Count; i++) {
				var current = element[i];
				var keyword = GetKeyword(current.Kind);
				if (last == null || last.Kind != current.Kind)
					Writer.Write(" " + keyword + " ");
				else
					Writer.Write(data.Delimiter);
				current.Type.TryAccept(this, data);
				last = current;
			}
			return false;
		}

		public bool Visit(UnifiedTypeSupplementCollection element, TokenInfo data) {
			VisitCollection(element, new TokenInfo { });
			return false;
		}

		public bool Visit(UnifiedVariableDefinitionBodyCollection element,
		                  TokenInfo data) {
			VisitCollection(element, new TokenInfo { Delimiter = ", " });
			return false;
		}

		public bool Visit(UnifiedIdentifierCollection element, TokenInfo data) {
			throw new InvalidOperationException();
		}

		public bool Visit(UnifiedArgumentCollection element, TokenInfo data) {
			VisitCollection(element, data);
			return false;
		}

		public bool Visit(UnifiedExpressionCollection element, TokenInfo data) {
			throw new InvalidOperationException();
		}

		public bool Visit(UnifiedTypeArgumentCollection element, TokenInfo data) {
			VisitCollection(element, new TokenInfo {
					Delimiter = ", ",
					MostLeft = "<",
					MostRight = ">",
			});
			return false;
		}

		public bool Visit(UnifiedCaseCollection element, TokenInfo data) {
			_indent++;
			foreach (var caseElement in element) {
				WriteIndent();
				caseElement.TryAccept(this, data);
			}
			_indent--;
			return false;
		}

		public bool Visit(UnifiedExpressionList element, TokenInfo data) {
			VisitCollection(element, data);
			return false;
		}
	}
}