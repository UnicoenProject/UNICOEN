using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unicoen.Model;

namespace Unicoen.Apps.Findbug {
	public class DefUseAnalyzer {
		public static IEnumerable<IUnifiedElement> FindDefines(UnifiedBlock codeObj) {
			/*
			 * Binary Expressionを探索
			 * "="だけ
			 * 左辺の変数名を調べる
			 * 左辺のやつを表示するものを作る
			 * 
			 */
			var binaryExpressions = codeObj.Descendants<UnifiedBinaryExpression>();
            /*var binaryExpressions2 = codeObj.Descendants<UnifiedIdentifier>();

		    foreach (var be2 in binaryExpressions2) {
		        yield return be2;
		    }*/
            
		    foreach (var be in binaryExpressions) {
				if (be.Operator.Sign.Equals("=")) {
					var leftName = "";
					var left = be.LeftHandSide as UnifiedVariableIdentifier;
					if (left != null) {
						Console.WriteLine("left is \n{0}", left);
						leftName = left.Name;
						//Console.WriteLine(leftName);
					}
					var right = be.RightHandSide as UnifiedNullLiteral;
					if (right != null) {
						Console.WriteLine("{0} is NULL", leftName);
					}
					yield return left;
				}
			}
		}

		public static IEnumerable<IUnifiedElement> FindUses(UnifiedBlock codeObj) {
            var binaryExpressions = codeObj.Descendants<UnifiedBinaryExpression>();

            foreach (var be in binaryExpressions) {
                if (be.Operator.Sign.Equals("=")) {
                    var right = be.RightHandSide as UnifiedVariableIdentifier;
                    if (right != null) {
                        var rightName = right.Name;
                        Console.WriteLine("{0} is used", rightName);
                    }
                    yield return right;
                }
            }
		}
	}
}
