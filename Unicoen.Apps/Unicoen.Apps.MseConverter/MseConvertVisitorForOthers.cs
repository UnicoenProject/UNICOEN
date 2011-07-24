using Unicoen.Model;

namespace Unicoen.Apps.MseConverter
{
	/// <summary>
	/// MSEフォーマット上に記述されない要素について出力します。
	/// </summary>
	public partial class MseConvertVisitor {

		//TODO 出力してほしい要素とそうでない要素をどのように見分けるのか

		public override void Visit(UnifiedProgram element) {
			element.Body.TryAccept(this);
		}

		public override void Visit(UnifiedBlock element) {
			foreach (var e in element) {
				e.TryAccept(this);
			}
		}

		public override void Visit(UnifiedVariableIdentifier element) {
			Writer.Write(element.Name);
			
		}

		public override void Visit(UnifiedParameterCollection element) {
			var delimiter = "";
			foreach (var parameter in element) {
				//e.g. int a
				Writer.Write(delimiter);
				parameter.Type.TryAccept(this);
				Writer.Write(" ");
				parameter.Names.TryAccept(this);
				delimiter = ", ";
			}
			
		}

		public override void Visit(UnifiedBasicType element) {
			element.BasicTypeName.TryAccept(this);
			
		}

		public override void Visit(UnifiedIdentifierCollection element) {
			foreach (var identifier in element) {
				Writer.Write(identifier.Name);
			}
			
		}

		public override void Visit(UnifiedBinaryExpression element) {
			element.LeftHandSide.TryAccept(this);
			element.RightHandSide.TryAccept(this);
			
		}

		public override void Visit(UnifiedProperty element) {
			//TODO 何もしなくていいか確認
			
		}

		public override void Visit(UnifiedImport element) {
			//TODO 何もしなくていいか確認
			
		}

		public override void Visit(UnifiedGenericType element) {
			//TODO 何もしなくていいか確認
			
		}

		public override void Visit(UnifiedInterfaceDefinition element) {
			//TODO 何もしなくていいか確認
			
		}

		public override void Visit(UnifiedStaticInitializer element) {
			//TODO 何もしなくていいか確認
			
		}

		public override void Visit(UnifiedAnnotationDefinition element) {
			//TODO 何もしなくていいか確認
			
		}

		public override void Visit(UnifiedArrayType element) {
			//TODO どこまで探索するか考える
			//TODO とりあえずString[]などが出力されていないので対応する
			
		}
	}
}
