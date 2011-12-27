using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unicoen.Model;

namespace Unicoen.Apps.Findbug {
	public class DefUseAnalyzer {
		public static IEnumerable<IUnifiedElement>[] FindDefines(UnifiedBlock codeObj) {
			/*
			 * Binary Expressionを探索
			 * "="だけ
			 * 左辺の変数名を調べる
			 * 左辺のやつを表示するものを作る
			 * 
			 */
			var binaryExpressions = new[] { codeObj.Descendants<UnifiedBinaryExpression>() };
            var binaryExpressions2 = codeObj.Descendants<UnifiedBinaryExpression>();


			var a = codeObj.Descendants<UnifiedIdentifier>();
		    var count = a.Count();
            var aa = new IEnumerable<UnifiedIdentifier>[count];

		    var array = new[] { codeObj.Descendants<UnifiedIdentifier>() };
		    IEnumerable<UnifiedIdentifier> lis = new UnifiedIdentifier[10];
            Console.WriteLine(array);
            Console.WriteLine(lis);

            return array;


		    /*foreach (var be in binaryExpressions) {
				if (be.Operator.Sign.Equals("=")) {
					var leftName = "";
					var left = be.LeftHandSide as UnifiedVariableIdentifier;
					if (left != null) {
						Console.WriteLine("left is {0}", left);
						leftName = left.Name;
						Console.WriteLine(leftName);
					}
					var right = be.RightHandSide as UnifiedNullLiteral;
					if (right != null) {
						Console.WriteLine("{0} is NULL", leftName);
					}
					yield return left;
				}
			}*/
		}

		public static IEnumerable<IUnifiedElement> FindUses() {
			throw new NotImplementedException();
		}
	}
}
