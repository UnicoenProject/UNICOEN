﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unicoen.Model;

namespace Unicoen.Apps.RefactoringDSL.Util {
	public class FindUtil {
		/// <summary>
		/// 指定されたクラス名を持つクラスを，プログラム中から検索して取得します
		/// </summary>
		/// <param name="program">（トップノードの）プログラムオブジェクト</param>
		/// <param name="className">検索するクラス名</param>
		/// <returns>検索したクラスの UnifiedClassDefinition オブジェクト（の集合）</returns>
		public static IEnumerable<UnifiedClassDefinition> FindClassByClassName(UnifiedProgram program, string className) {
			var result =
					program.Descendants<UnifiedClassDefinition>().Where(e => ((UnifiedIdentifier)(e.Name)).Name == className);
			return result;
		}

		/// <summary>
		/// ジェネリックタイプから，型引数（[]の中身）をUnifiedTypeオブジェクトにして取得する 
		/// (e.g. List[T] なる UnifiedGenericType オブジェクトから，T (UnifiedType オブジェクト） を生成して返却） 
		/// </summary>
		/// <param name="genericType"></param>
		/// <returns></returns>
		public static UnifiedType GetTypeParameterAsType(UnifiedGenericType genericType) {
			return ((UnifiedBasicType)genericType.Arguments.First().Value).DeepCopy();
		}

		/// <summary>
		/// 指定されたノード以下の，配列フィールドの定義を検索し，取得します 
		/// </summary>
		/// <param name="element">検索するトップノード</param>
		/// <returns>配列フィールドの定義</returns>
		public static IEnumerable<UnifiedElement> SearchArrayField(UnifiedElement element) {
			var fields = element.Descendants<UnifiedVariableDefinition>();
			return fields.Where(
				f => f.Descendants().Any(e => e is UnifiedArrayType));
		}

		/// <summary>
		/// 指定されたトップノード以下で，指定されたジェネリクスを持つフィールドを検索し，取得します
		/// </summary>
		/// <param name="element">検索するトップノード</param>
		/// <param name="containerType">コンテナの型名(e.g. List[T] の List)</param>
		/// <param name="type">型引数の型名(e.g. List[T] の T，'*'はワイルドカード)</param>
		/// <returns></returns>
		public static IEnumerable<UnifiedElement> SearchGenericsField(UnifiedElement element, string containerType, string type = "*") {
			var fields = element.Descendants<UnifiedVariableDefinition>();
			var genericsFields = fields.Where(
					f => f.Descendants().Any(e => e is UnifiedGenericType));

			var result =
					genericsFields.Where(
							f =>
							f.Descendants<UnifiedGenericType>()
							.Select(gt => ((UnifiedVariableIdentifier)gt.Type.BasicTypeName).Name).Contains(containerType));

			if (type != "*") {
				result =
						result.Where(
								f =>
								f.Descendants<UnifiedGenericType>().Select(gt => gt.Arguments).Select(
										arg => arg.Descendants<UnifiedIdentifier>().First().Name).Contains(type));

			}


			return result;

		}

	}
}
