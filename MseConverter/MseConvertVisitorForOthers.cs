using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unicoen.Model;
using Unicoen.Processor;

namespace MseConverter
{
	/// <summary>
	/// MSEフォーマット上に記述されない要素について出力します。
	/// </summary>
	public partial class MseConvertVisitor {

		//TODO 出力してほしい要素とそうでない要素をどのように見分けるのか

		public override bool Visit(UnifiedProgram element, VisitorArgument arg) {
			foreach (var e in element.Body) {
				e.TryAccept(this, arg);
			}
			return false;
		}

		public override bool Visit(UnifiedBlock element, VisitorArgument arg) {
			foreach (var e in element) {
				e.TryAccept(this, arg);
			}
			return false;
		}

		public override bool Visit(UnifiedVariableIdentifier element, VisitorArgument arg) {
			Writer.Write(element.Name);
			return false;
		}

		public override bool Visit(UnifiedParameterCollection element, VisitorArgument arg) {
			var delimiter = "";
			foreach (var parameter in element) {
				//e.g. int a
				Writer.Write(delimiter);
				parameter.Type.TryAccept(this, arg);
				Writer.Write(" ");
				parameter.Names.TryAccept(this, arg);
				delimiter = ", ";
			}
			return false;
		}

		public override bool Visit(UnifiedBasicType element, VisitorArgument arg) {
			element.BasicTypeName.TryAccept(this, arg);
			return false;
		}

		public override bool Visit(UnifiedIdentifierCollection element, VisitorArgument arg) {
			foreach (var identifier in element) {
				Writer.Write(identifier.Name);
			}
			return false;
		}

		public override bool Visit(UnifiedBinaryExpression element, VisitorArgument arg) {
			element.LeftHandSide.TryAccept(this, arg);
			element.RightHandSide.TryAccept(this, arg);
			return false;
		}

		public override bool Visit(UnifiedArrayType element, VisitorArgument arg) {
			//TODO どこまで探索するか考える
			//TODO とりあえずString[]などが出力されていないので対応する
			return false;
		}
	}
}
