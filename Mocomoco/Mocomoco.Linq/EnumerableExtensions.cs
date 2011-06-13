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
	public static class EnumerableExtensions {
		/// <summary>
		///   指定したシーケンスに対して最初の要素をシード(seed)としてAggregateを計算します．
		/// </summary>
		/// <typeparam name = "T"></typeparam>
		/// <typeparam name = "TAccumulate"></typeparam>
		/// <param name = "source"></param>
		/// <param name = "firstSelector"></param>
		/// <param name = "func"></param>
		/// <returns></returns>
		public static TAccumulate AggregateApartFirst<T, TAccumulate>(
				this IEnumerable<T> source, Func<T, TAccumulate> firstSelector,
				Func<TAccumulate, T, TAccumulate> func) {
			using (var enumerator = source.GetEnumerator()) {
				if (!enumerator.MoveNext())
					throw new ArgumentException();
				var seed = firstSelector(enumerator.Current);
				while (enumerator.MoveNext()) {
					seed = func(seed, enumerator.Current);
				}
				return seed;
			}
		}

		/// <summary>
		///   指定したシーケンスに対して最初の要素をシード(seed)としてAggregateを計算します．
		/// </summary>
		/// <typeparam name = "T"></typeparam>
		/// <typeparam name = "TAccumulate"></typeparam>
		/// <typeparam name = "TResult"></typeparam>
		/// <param name = "source"></param>
		/// <param name = "firstSelector"></param>
		/// <param name = "func"></param>
		/// <param name = "resultSelector"></param>
		/// <returns></returns>
		public static TResult AggregateApartFirst<T, TAccumulate, TResult>(
				this IEnumerable<T> source, Func<T, TAccumulate> firstSelector,
				Func<TAccumulate, T, TAccumulate> func,
				Func<TAccumulate, TResult> resultSelector) {
			using (var enumerator = source.GetEnumerator()) {
				if (!enumerator.MoveNext())
					throw new ArgumentException();
				var seed = firstSelector(enumerator.Current);
				while (enumerator.MoveNext()) {
					seed = func(seed, enumerator.Current);
				}
				return resultSelector(seed);
			}
		}

		/// <summary>
		///   指定したシーケンスを逆順にしてAggregateを計算します．
		/// </summary>
		/// <typeparam name = "T"></typeparam>
		/// <param name = "source"></param>
		/// <param name = "func"></param>
		/// <returns></returns>
		public static T AggregateRight<T>(
				this IEnumerable<T> source, Func<T, T, T> func) {
			return source.Reverse().Aggregate(func);
		}

		/// <summary>
		///   指定したシーケンスを逆順にしてAggregateを計算します．
		/// </summary>
		/// <typeparam name = "T"></typeparam>
		/// <typeparam name = "TAccumulate"></typeparam>
		/// <param name = "source"></param>
		/// <param name = "seed"></param>
		/// <param name = "func"></param>
		/// <returns></returns>
		public static TAccumulate AggregateRight<T, TAccumulate>(
				this IEnumerable<T> source, TAccumulate seed,
				Func<TAccumulate, T, TAccumulate> func) {
			return source.Reverse().Aggregate(seed, func);
		}

		/// <summary>
		///   指定したシーケンスを要素数が2個のタプル列に分解します．
		/// </summary>
		/// <typeparam name = "T"></typeparam>
		/// <param name = "source"></param>
		/// <returns></returns>
		public static IEnumerable<Tuple<T, T>> Split2<T>(this IEnumerable<T> source) {
			using (var enumerator = source.GetEnumerator()) {
				while (enumerator.MoveNext()) {
					var item1 = enumerator.Current;
					if (!enumerator.MoveNext())
						yield break;
					var item2 = enumerator.Current;
					yield return Tuple.Create(item1, item2);
				}
			}
		}
	}
}