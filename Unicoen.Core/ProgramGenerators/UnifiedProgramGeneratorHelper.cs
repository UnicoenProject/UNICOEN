#region License

// Copyright (C) 2011-2012 The Unicoen Project
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
using System.Linq;
using System.Xml.Linq;
using Paraiba.Linq;
using Paraiba.Xml.Linq;
using Unicoen.Model;

namespace Unicoen.ProgramGenerators {
	public static class UnifiedProgramGeneratorHelper {
		/// <summary>
		///   指定したXMLノードから演算子が項の前に付くUnaryExpressionを作成します．
		/// </summary>
		/// <param name="node"> </param>
		/// <param name="createExpression"> </param>
		/// <param name="op2Kind"> </param>
		/// <returns> </returns>
		public static UnifiedExpression CreatePrefixUnaryExpression(
				XElement node,
				Func<XElement, UnifiedExpression> createExpression,
				IDictionary<string, UnifiedUnaryOperator> op2Kind) {
			return UnifiedUnaryExpression.Create(
					createExpression(node.NthElement(1)),
					op2Kind[node.FirstElement().Value].DeepCopy());
		}

		/// <summary>
		///   指定したXMLノードから右結合のBinaryExpressionを作成します．
		/// </summary>
		/// <param name="node"> </param>
		/// <param name="firstCreateExpression"> </param>
		/// <param name="otherCreateExpression"> </param>
		/// <param name="op2Kind"> </param>
		/// <returns> </returns>
		public static UnifiedExpression
				CreateBinaryExpressionForRightAssociation(
				XElement node,
				Func<XElement, UnifiedExpression> firstCreateExpression,
				Func<XElement, UnifiedExpression> otherCreateExpression,
				IDictionary<string, UnifiedBinaryOperator> op2Kind) {
			var nodes = node.Elements().OddIndexElements().ToList();
			var count = nodes.Count - 1;
			var n = nodes[count];
			var seed = count > 0
			           		? otherCreateExpression(n)
			           		: firstCreateExpression(n);
			for (count--; count >= 0; count--) {
				n = nodes[count];
				seed = UnifiedBinaryExpression.Create(
						count > 0
								? otherCreateExpression(n)
								: firstCreateExpression(n),
						op2Kind[n.NextElement().Value].DeepCopy(),
						seed);
			}
			return seed;
		}

		/// <summary>
		///   指定したXMLノードから右結合のBinaryExpressionを作成します．
		/// </summary>
		/// <param name="node"> </param>
		/// <param name="createExpression"> </param>
		/// <param name="op2Kind"> </param>
		/// <returns> </returns>
		public static UnifiedExpression
				CreateBinaryExpressionForRightAssociation(
				XElement node,
				Func<XElement, UnifiedExpression> createExpression,
				IDictionary<string, UnifiedBinaryOperator> op2Kind) {
			return CreateBinaryExpressionForRightAssociation(
					node,
					createExpression,
					createExpression,
					op2Kind);
		}

		/// <summary>
		///   指定したXMLノードから左結合のBinaryExpressionを作成します．
		/// </summary>
		/// <param name="node"> </param>
		/// <param name="firstCreateExpression"> </param>
		/// <param name="otherCreateExpression"> </param>
		/// <param name="op2Kind"> </param>
		/// <returns> </returns>
		public static UnifiedExpression CreateBinaryExpression(
				XElement node,
				Func<XElement, UnifiedExpression> firstCreateExpression,
				Func<XElement, UnifiedExpression> otherCreateExpression,
				IDictionary<string, UnifiedBinaryOperator> op2Kind) {
			var nodes = node.Elements().OddIndexElements();
			return nodes.AggregateApartFirst(
					firstCreateExpression,
					(e, n) => UnifiedBinaryExpression.Create(
							e,
							op2Kind[n.PreviousElement().Value].DeepCopy(),
							otherCreateExpression(n)));
		}

		/// <summary>
		///   指定したXMLノードから左結合のBinaryExpressionを作成します．
		/// </summary>
		/// <param name="node"> </param>
		/// <param name="createExpression"> </param>
		/// <param name="op2Kind"> </param>
		/// <returns> </returns>
		public static UnifiedExpression CreateBinaryExpression(
				XElement node,
				Func<XElement, UnifiedExpression> createExpression,
				IDictionary<string, UnifiedBinaryOperator> op2Kind) {
			return CreateBinaryExpression(
					node, createExpression, createExpression, op2Kind);
		}

		/// <summary>
		///   二項演算子の文字列からUnifiedBinaryOperatorへの標準的な辞書を作成します．
		/// </summary>
		/// <returns> </returns>
		public static Dictionary<string, UnifiedBinaryOperator>
				CreateBinaryOperatorDictionary() {
			var dict = new[] {
					// Arithmetic
					UnifiedBinaryOperator.Create(
							"+", UnifiedBinaryOperatorKind.Add),
					UnifiedBinaryOperator.Create(
							"-", UnifiedBinaryOperatorKind.Subtract),
					UnifiedBinaryOperator.Create(
							"*", UnifiedBinaryOperatorKind.Multiply),
					UnifiedBinaryOperator.Create(
							"**", UnifiedBinaryOperatorKind.Power),
					UnifiedBinaryOperator.Create(
							"/", UnifiedBinaryOperatorKind.Divide),
					UnifiedBinaryOperator.Create(
							"//", UnifiedBinaryOperatorKind.FloorDivide),
					UnifiedBinaryOperator.Create(
							"%", UnifiedBinaryOperatorKind.Modulo),
					// Shift
					UnifiedBinaryOperator.Create(
							"<<", UnifiedBinaryOperatorKind.LogicalLeftShift),
					UnifiedBinaryOperator.Create(
							">>", UnifiedBinaryOperatorKind.ArithmeticRightShift)
					,
					UnifiedBinaryOperator.Create(
							">>>", UnifiedBinaryOperatorKind.LogicalRightShift),
					// Comparison
					UnifiedBinaryOperator.Create(
							">", UnifiedBinaryOperatorKind.GreaterThan),
					UnifiedBinaryOperator.Create(
							">=", UnifiedBinaryOperatorKind.GreaterThanOrEqual),
					UnifiedBinaryOperator.Create(
							"<", UnifiedBinaryOperatorKind.LessThan),
					UnifiedBinaryOperator.Create(
							"<=", UnifiedBinaryOperatorKind.LessThanOrEqual),
					UnifiedBinaryOperator.Create(
							"==", UnifiedBinaryOperatorKind.Equal),
					UnifiedBinaryOperator.Create(
							"!=", UnifiedBinaryOperatorKind.NotEqual),
					UnifiedBinaryOperator.Create(
							"<>", UnifiedBinaryOperatorKind.NotEqual),
					UnifiedBinaryOperator.Create(
							"===", UnifiedBinaryOperatorKind.StrictEqual),
					UnifiedBinaryOperator.Create(
							"!==", UnifiedBinaryOperatorKind.StrictNotEqual),
					UnifiedBinaryOperator.Create(
							"is", UnifiedBinaryOperatorKind.ReferenceEqual),
					UnifiedBinaryOperator.Create(
							"in", UnifiedBinaryOperatorKind.In),
					// Logocal
					UnifiedBinaryOperator.Create(
							"&&", UnifiedBinaryOperatorKind.AndAlso),
					UnifiedBinaryOperator.Create(
							"||", UnifiedBinaryOperatorKind.OrElse),
					UnifiedBinaryOperator.Create(
							"and", UnifiedBinaryOperatorKind.AndAlso),
					UnifiedBinaryOperator.Create(
							"or", UnifiedBinaryOperatorKind.OrElse),
					// Bit
					UnifiedBinaryOperator.Create(
							"&", UnifiedBinaryOperatorKind.And),
					UnifiedBinaryOperator.Create(
							"|", UnifiedBinaryOperatorKind.Or),
					UnifiedBinaryOperator.Create(
							"^", UnifiedBinaryOperatorKind.ExclusiveOr),
					// Arithmetic Assignment
					UnifiedBinaryOperator.Create(
							"=", UnifiedBinaryOperatorKind.Assign),
					UnifiedBinaryOperator.Create(
							"+=", UnifiedBinaryOperatorKind.AddAssign),
					UnifiedBinaryOperator.Create(
							"-=", UnifiedBinaryOperatorKind.SubtractAssign),
					UnifiedBinaryOperator.Create(
							"*=", UnifiedBinaryOperatorKind.MultiplyAssign),
					UnifiedBinaryOperator.Create(
							"**=", UnifiedBinaryOperatorKind.PowerAssign),
					UnifiedBinaryOperator.Create(
							"/=", UnifiedBinaryOperatorKind.DivideAssign),
					UnifiedBinaryOperator.Create(
							"//=", UnifiedBinaryOperatorKind.FloorDivideAssign),
					UnifiedBinaryOperator.Create(
							"%=", UnifiedBinaryOperatorKind.ModuloAssign),
					// Bit Assignment
					UnifiedBinaryOperator.Create(
							"&=", UnifiedBinaryOperatorKind.AndAssign),
					UnifiedBinaryOperator.Create(
							"|=", UnifiedBinaryOperatorKind.OrAssign),
					UnifiedBinaryOperator.Create(
							"^=", UnifiedBinaryOperatorKind.ExclusiveOrAssign),
					// Logocal Assignment
					UnifiedBinaryOperator.Create(
							"&&=", UnifiedBinaryOperatorKind.AndAlsoAssign),
					UnifiedBinaryOperator.Create(
							"||=", UnifiedBinaryOperatorKind.OrElseAssign),
					// Shift Assignment
					UnifiedBinaryOperator.Create(
							"<<=",
							UnifiedBinaryOperatorKind.LogicalLeftShiftAssign),
					UnifiedBinaryOperator.Create(
							">>=",
							UnifiedBinaryOperatorKind.ArithmeticRightShiftAssign)
					,
					UnifiedBinaryOperator.Create(
							">>>=",
							UnifiedBinaryOperatorKind.LogicalRightShiftAssign),
					// InstanceOf
					UnifiedBinaryOperator.Create(
							"instanceof", UnifiedBinaryOperatorKind.InstanceOf),
			}
					.ToDictionary(o => o.Sign);
			dict["isnot"] = UnifiedBinaryOperator.Create(
					"is not", UnifiedBinaryOperatorKind.ReferenceNotEqual);
			dict["notin"] = UnifiedBinaryOperator.Create(
					"not in", UnifiedBinaryOperatorKind.NotIn);
			return dict;
		}

		/// <summary>
		///   項の前に付く単項演算子の文字列からUnifiedUnaryOperatorへの標準的な辞書を作成します．
		/// </summary>
		/// <returns> </returns>
		public static Dictionary<string, UnifiedUnaryOperator>
				CreatePrefixUnaryOperatorDictionaryForJava() {
			return new[] {
					// Arithmetic
					UnifiedUnaryOperator.Create(
							"+", UnifiedUnaryOperatorKind.UnaryPlus),
					UnifiedUnaryOperator.Create(
							"-", UnifiedUnaryOperatorKind.Negate),
					UnifiedUnaryOperator.Create(
							"++", UnifiedUnaryOperatorKind.PreIncrementAssign),
					UnifiedUnaryOperator.Create(
							"--", UnifiedUnaryOperatorKind.PreDecrementAssign),
					// Bit
					UnifiedUnaryOperator.Create(
							"~", UnifiedUnaryOperatorKind.OnesComplement),
					// Logical
					UnifiedUnaryOperator.Create(
							"!", UnifiedUnaryOperatorKind.Not),
					UnifiedUnaryOperator.Create(
							"not", UnifiedUnaryOperatorKind.Not),
			}
					.ToDictionary(o => o.Sign);
		}
	}
}