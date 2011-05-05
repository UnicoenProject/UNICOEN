#region License

// Copyright (C) 2011 The Unicoen Project
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

namespace Mocomoco.Linq {
	public static class ListExtensions {
		/// <summary>
		///   指定したリストの指定したインデックスの要素を取得します．
		/// </summary>
		/// <typeparam name = "T"></typeparam>
		/// <param name = "list"></param>
		/// <param name = "index"></param>
		/// <returns></returns>
		public static T AtOrDefault<T>(this IList<T> list, int index) {
			return 0 <= index && index < list.Count()
			       		? list[index] : default(T);
		}

		/// <summary>
		///   指定したリストの逆順のシーケンスを取得します．
		/// </summary>
		/// <typeparam name = "T"></typeparam>
		/// <param name = "list"></param>
		/// <returns></returns>
		public static IEnumerable<T> Reverse<T>(this IList<T> list) {
			for (int i = list.Count - 1; i >= 0; i--) {
				yield return list[i];
			}
		}

		/// <summary>
		///   リストに指定した要素を追加して、有効要素数を拡張します．
		/// </summary>
		/// <param name = "count">拡張するリストのサイズ</param>
		public static List<T> Extend<T>(this List<T> list, int count) {
			return Extend(list, count, default(T));
		}

		/// <summary>
		///   リストに指定した要素を追加して、有効要素数を拡張します．
		/// </summary>
		/// <param name = "count">拡張するリストのサイズ</param>
		/// <param name = "defaultElement">拡張する際に追加する要素</param>
		public static List<T> Extend<T>(
				this List<T> list, int count, T defaultElement) {
			for (int i = list.Count; i < count; i++)
				list.Add(defaultElement);
			return list;
		}

		/// <summary>
		///   リストに指定した要素を追加して、有効要素数を拡張します．
		/// </summary>
		/// <param name = "count">拡張するリストのサイズ</param>
		/// <param name = "defaultElementFunc">拡張する際に追加する要素を取得するデリゲート</param>
		public static List<T> Extend<T>(
				this List<T> list, int count, Func<T> defaultElementFunc) {
			for (int i = list.Count; i < count; i++)
				list.Add(defaultElementFunc());
			return list;
		}

		/// <summary>
		///   リストの全要素に指定した要素を設定します．
		/// </summary>
		/// <typeparam name = "TValue"></typeparam>
		/// <param name = "list"></param>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static IList<T> Fill<T>(this IList<T> list, T element) {
			var count = list.Count;
			for (int i = 0; i < count; i++)
				list[i] = element;
			return list;
		}

		/// <summary>
		///   リストの各要素に指定したデリゲートの戻り値を設定します．
		/// </summary>
		/// <typeparam name = "TValue"></typeparam>
		/// <param name = "list"></param>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static IList<T> Fill<T>(this IList<T> list, Func<T> func) {
			for (int i = 0; i < list.Count; i++)
				list[i] = func();
			return list;
		}

		/// <summary>
		///   リストの各要素に指定したデリゲートの戻り値を設定します．
		/// </summary>
		/// <typeparam name = "TValue"></typeparam>
		/// <param name = "list"></param>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static IList<T> Fill<T>(this IList<T> list, Func<int, T> func) {
			for (int i = 0; i < list.Count; i++)
				list[i] = func(i);
			return list;
		}
	}
}