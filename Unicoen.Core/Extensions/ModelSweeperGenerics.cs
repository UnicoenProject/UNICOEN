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

using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

// ReSharper disable InvocationIsSkipped

namespace Unicoen.Model {
	public static class ModelSweeperGenerics {
		/// <summary>
		///   指定した型に限定して，指定した要素の子要素を列挙します．
		/// </summary>
		/// <typeparam name="T"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummyForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<T> Elements<T>(
				this UnifiedElement element, T dummyForInference = default(T)) {
			Contract.Requires(element != null);
			return element.Elements().OfType<T>();
		}

		/// <summary>
		///   指定した型に限定して，指定した要素の祖先を列挙します．
		/// </summary>
		/// <typeparam name="T"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummyForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<T> Ancestors<T>(
				this UnifiedElement element, T dummyForInference = default(T)) {
			Contract.Requires(element != null);
			return element.Ancestors().OfType<T>();
		}

		/// <summary>
		///   指定した型に限定して，指定した要素とその祖先を列挙します．
		/// </summary>
		/// <typeparam name="T"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummyForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<T> AncestorsAndSelf<T>(
				this UnifiedElement element, T dummyForInference = default(T)) {
			Contract.Requires(element != null);
			return element.AncestorsAndSelf().OfType<T>();
		}

		/// <summary>
		///   指定した型に限定して，指定した要素の子孫を列挙します．
		/// </summary>
		/// <typeparam name="T"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummyForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<T> Descendants<T>(
				this UnifiedElement element, T dummyForInference = default(T)) {
			Contract.Requires(element != null);
			return element.Descendants().OfType<T>();
		}

		/// <summary>
		///   指定した型に限定して，指定した要素とその子孫を列挙します．
		/// </summary>
		/// <typeparam name="T"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummyForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<T> DescendantsAndSelf<T>(
				this UnifiedElement element, T dummyForInference = default(T)) {
			Contract.Requires(element != null);
			return element.DescendantsAndSelf().OfType<T>();
		}

		#region DescendantsAndSelf

		/// <summary>
		///   指定した型に限定して，指定した要素とその子孫を列挙します．
		/// </summary>
		/// <typeparam name="T1"> </typeparam>
		/// <typeparam name="T2"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummy1ForInference"> </param>
		/// <param name="dummy2ForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<UnifiedElement> DescendantsAndSelf<T1, T2>(
				this UnifiedElement element,
				T1 dummy1ForInference = default(T1),
				T2 dummy2ForInference = default(T2)) {
			Contract.Requires(element != null);
			return element.DescendantsAndSelf().Where(e => e is T1 || e is T2);
		}

		/// <summary>
		///   指定した型に限定して，指定した要素とその子孫を列挙します．
		/// </summary>
		/// <typeparam name="T1"> </typeparam>
		/// <typeparam name="T2"> </typeparam>
		/// <typeparam name="T3"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummy1ForInference"> </param>
		/// <param name="dummy2ForInference"> </param>
		/// <param name="dummy3ForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<UnifiedElement> DescendantsAndSelf
				<T1, T2, T3>(
				this UnifiedElement element,
				T1 dummy1ForInference = default(T1),
				T2 dummy2ForInference = default(T2),
				T3 dummy3ForInference = default(T3)) {
			Contract.Requires(element != null);
			return
					element.DescendantsAndSelf().Where(
							e => e is T1 || e is T2 || e is T3);
		}

		/// <summary>
		///   指定した型に限定して，指定した要素とその子孫を列挙します．
		/// </summary>
		/// <typeparam name="T1"> </typeparam>
		/// <typeparam name="T2"> </typeparam>
		/// <typeparam name="T3"> </typeparam>
		/// <typeparam name="T4"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummy1ForInference"> </param>
		/// <param name="dummy2ForInference"> </param>
		/// <param name="dummy3ForInference"> </param>
		/// <param name="dummy4ForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<UnifiedElement> DescendantsAndSelf
				<T1, T2, T3, T4>(
				this UnifiedElement element,
				T1 dummy1ForInference = default(T1),
				T2 dummy2ForInference = default(T2),
				T3 dummy3ForInference = default(T3),
				T4 dummy4ForInference = default(T4)) {
			Contract.Requires(element != null);
			return element.DescendantsAndSelf().Where(
					e => e is T1 || e is T2 || e is T3 || e is T4);
		}

		/// <summary>
		///   指定した型に限定して，指定した要素とその子孫を列挙します．
		/// </summary>
		/// <typeparam name="T1"> </typeparam>
		/// <typeparam name="T2"> </typeparam>
		/// <typeparam name="T3"> </typeparam>
		/// <typeparam name="T4"> </typeparam>
		/// <typeparam name="T5"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummy1ForInference"> </param>
		/// <param name="dummy2ForInference"> </param>
		/// <param name="dummy3ForInference"> </param>
		/// <param name="dummy4ForInference"> </param>
		/// <param name="dummy5ForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<UnifiedElement> DescendantsAndSelf
				<T1, T2, T3, T4, T5>(
				this UnifiedElement element,
				T1 dummy1ForInference = default(T1),
				T2 dummy2ForInference = default(T2),
				T3 dummy3ForInference = default(T3),
				T4 dummy4ForInference = default(T4),
				T5 dummy5ForInference = default(T5)) {
			Contract.Requires(element != null);
			return
					element.DescendantsAndSelf().Where(
							e =>
							e is T1 || e is T2 || e is T3 || e is T4 || e is T5);
		}

		/// <summary>
		///   指定した型に限定して，指定した要素とその子孫を列挙します．
		/// </summary>
		/// <typeparam name="T1"> </typeparam>
		/// <typeparam name="T2"> </typeparam>
		/// <typeparam name="T3"> </typeparam>
		/// <typeparam name="T4"> </typeparam>
		/// <typeparam name="T5"> </typeparam>
		/// <typeparam name="T6"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummy1ForInference"> </param>
		/// <param name="dummy2ForInference"> </param>
		/// <param name="dummy3ForInference"> </param>
		/// <param name="dummy4ForInference"> </param>
		/// <param name="dummy5ForInference"> </param>
		/// <param name="dummy6ForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<UnifiedElement> DescendantsAndSelf
				<T1, T2, T3, T4, T5, T6>(
				this UnifiedElement element,
				T1 dummy1ForInference = default(T1),
				T2 dummy2ForInference = default(T2),
				T3 dummy3ForInference = default(T3),
				T4 dummy4ForInference = default(T4),
				T5 dummy5ForInference = default(T5),
				T6 dummy6ForInference = default(T6)) {
			Contract.Requires(element != null);
			return
					element.DescendantsAndSelf().Where(
							e =>
							e is T1 || e is T2 || e is T3 || e is T4 || e is T5
							|| e is T6);
		}

		/// <summary>
		///   指定した型に限定して，指定した要素とその子孫を列挙します．
		/// </summary>
		/// <typeparam name="T1"> </typeparam>
		/// <typeparam name="T2"> </typeparam>
		/// <typeparam name="T3"> </typeparam>
		/// <typeparam name="T4"> </typeparam>
		/// <typeparam name="T5"> </typeparam>
		/// <typeparam name="T6"> </typeparam>
		/// <typeparam name="T7"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummy1ForInference"> </param>
		/// <param name="dummy2ForInference"> </param>
		/// <param name="dummy3ForInference"> </param>
		/// <param name="dummy4ForInference"> </param>
		/// <param name="dummy5ForInference"> </param>
		/// <param name="dummy6ForInference"> </param>
		/// <param name="dummy7ForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<UnifiedElement> DescendantsAndSelf
				<T1, T2, T3, T4, T5, T6, T7>(
				this UnifiedElement element,
				T1 dummy1ForInference = default(T1),
				T2 dummy2ForInference = default(T2),
				T3 dummy3ForInference = default(T3),
				T4 dummy4ForInference = default(T4),
				T5 dummy5ForInference = default(T5),
				T6 dummy6ForInference = default(T6),
				T7 dummy7ForInference = default(T7)
				) {
			Contract.Requires(element != null);
			return
					element.DescendantsAndSelf().Where(
							e =>
							e is T1 || e is T2 || e is T3 || e is T4 || e is T5
							|| e is T6 || e is T7);
		}

		/// <summary>
		///   指定した型に限定して，指定した要素とその子孫を列挙します．
		/// </summary>
		/// <typeparam name="T1"> </typeparam>
		/// <typeparam name="T2"> </typeparam>
		/// <typeparam name="T3"> </typeparam>
		/// <typeparam name="T4"> </typeparam>
		/// <typeparam name="T5"> </typeparam>
		/// <typeparam name="T6"> </typeparam>
		/// <typeparam name="T7"> </typeparam>
		/// <typeparam name="T8"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummy1ForInference"> </param>
		/// <param name="dummy2ForInference"> </param>
		/// <param name="dummy3ForInference"> </param>
		/// <param name="dummy4ForInference"> </param>
		/// <param name="dummy5ForInference"> </param>
		/// <param name="dummy6ForInference"> </param>
		/// <param name="dummy7ForInference"> </param>
		/// <param name="dummy8ForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<UnifiedElement> DescendantsAndSelf
				<T1, T2, T3, T4, T5, T6, T7, T8>(
				this UnifiedElement element,
				T1 dummy1ForInference = default(T1),
				T2 dummy2ForInference = default(T2),
				T3 dummy3ForInference = default(T3),
				T4 dummy4ForInference = default(T4),
				T5 dummy5ForInference = default(T5),
				T6 dummy6ForInference = default(T6),
				T7 dummy7ForInference = default(T7),
				T8 dummy8ForInference = default(T8)
				) {
			Contract.Requires(element != null);
			return
					element.DescendantsAndSelf().Where(
							e =>
							e is T1 || e is T2 || e is T3 || e is T4 || e is T5
							|| e is T6 || e is T7
							|| e is T8);
		}

		/// <summary>
		///   指定した型に限定して，指定した要素とその子孫を列挙します．
		/// </summary>
		/// <typeparam name="T1"> </typeparam>
		/// <typeparam name="T2"> </typeparam>
		/// <typeparam name="T3"> </typeparam>
		/// <typeparam name="T4"> </typeparam>
		/// <typeparam name="T5"> </typeparam>
		/// <typeparam name="T6"> </typeparam>
		/// <typeparam name="T7"> </typeparam>
		/// <typeparam name="T8"> </typeparam>
		/// <typeparam name="T9"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummy1ForInference"> </param>
		/// <param name="dummy2ForInference"> </param>
		/// <param name="dummy3ForInference"> </param>
		/// <param name="dummy4ForInference"> </param>
		/// <param name="dummy5ForInference"> </param>
		/// <param name="dummy6ForInference"> </param>
		/// <param name="dummy7ForInference"> </param>
		/// <param name="dummy8ForInference"> </param>
		/// <param name="dummy9ForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<UnifiedElement> DescendantsAndSelf
				<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
				this UnifiedElement element,
				T1 dummy1ForInference = default(T1),
				T2 dummy2ForInference = default(T2),
				T3 dummy3ForInference = default(T3),
				T4 dummy4ForInference = default(T4),
				T5 dummy5ForInference = default(T5),
				T6 dummy6ForInference = default(T6),
				T7 dummy7ForInference = default(T7),
				T8 dummy8ForInference = default(T8),
				T9 dummy9ForInference = default(T9)
				) {
			Contract.Requires(element != null);
			return
					element.DescendantsAndSelf().Where(
							e =>
							e is T1 || e is T2 || e is T3 || e is T4 || e is T5
							|| e is T6 || e is T7
							|| e is T8 || e is T9);
		}

		/// <summary>
		///   指定した型に限定して，指定した要素とその子孫を列挙します．
		/// </summary>
		/// <typeparam name="T1"> </typeparam>
		/// <typeparam name="T2"> </typeparam>
		/// <typeparam name="T3"> </typeparam>
		/// <typeparam name="T4"> </typeparam>
		/// <typeparam name="T5"> </typeparam>
		/// <typeparam name="T6"> </typeparam>
		/// <typeparam name="T7"> </typeparam>
		/// <typeparam name="T8"> </typeparam>
		/// <typeparam name="T9"> </typeparam>
		/// <typeparam name="T10"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummy1ForInference"> </param>
		/// <param name="dummy2ForInference"> </param>
		/// <param name="dummy3ForInference"> </param>
		/// <param name="dummy4ForInference"> </param>
		/// <param name="dummy5ForInference"> </param>
		/// <param name="dummy6ForInference"> </param>
		/// <param name="dummy7ForInference"> </param>
		/// <param name="dummy8ForInference"> </param>
		/// <param name="dummy9ForInference"> </param>
		/// <param name="dummy10ForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<UnifiedElement> DescendantsAndSelf
				<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
				this UnifiedElement element,
				T1 dummy1ForInference = default(T1),
				T2 dummy2ForInference = default(T2),
				T3 dummy3ForInference = default(T3),
				T4 dummy4ForInference = default(T4),
				T5 dummy5ForInference = default(T5),
				T6 dummy6ForInference = default(T6),
				T7 dummy7ForInference = default(T7),
				T8 dummy8ForInference = default(T8),
				T9 dummy9ForInference = default(T9),
				T10 dummy10ForInference = default(T10)
				) {
			Contract.Requires(element != null);
			return
					element.DescendantsAndSelf().Where(
							e =>
							e is T1 || e is T2 || e is T3 || e is T4 || e is T5
							|| e is T6 || e is T7
							|| e is T8 || e is T9 || e is T10);
		}

		#endregion

		#region Descendants

		/// <summary>
		///   指定した型に限定して，指定した要素の子孫を列挙します．
		/// </summary>
		/// <typeparam name="T1"> </typeparam>
		/// <typeparam name="T2"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummy1ForInference"> </param>
		/// <param name="dummy2ForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<UnifiedElement> Descendants<T1, T2>(
				this UnifiedElement element,
				T1 dummy1ForInference = default(T1),
				T2 dummy2ForInference = default(T2)) {
			Contract.Requires(element != null);
			return element.Descendants().Where(e => e is T1 || e is T2);
		}

		/// <summary>
		///   指定した型に限定して，指定した要素の子孫を列挙します．
		/// </summary>
		/// <typeparam name="T1"> </typeparam>
		/// <typeparam name="T2"> </typeparam>
		/// <typeparam name="T3"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummy1ForInference"> </param>
		/// <param name="dummy2ForInference"> </param>
		/// <param name="dummy3ForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<UnifiedElement> Descendants<T1, T2, T3>(
				this UnifiedElement element,
				T1 dummy1ForInference = default(T1),
				T2 dummy2ForInference = default(T2),
				T3 dummy3ForInference = default(T3)) {
			Contract.Requires(element != null);
			return
					element.Descendants().Where(
							e => e is T1 || e is T2 || e is T3);
		}

		/// <summary>
		///   指定した型に限定して，指定した要素の子孫を列挙します．
		/// </summary>
		/// <typeparam name="T1"> </typeparam>
		/// <typeparam name="T2"> </typeparam>
		/// <typeparam name="T3"> </typeparam>
		/// <typeparam name="T4"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummy1ForInference"> </param>
		/// <param name="dummy2ForInference"> </param>
		/// <param name="dummy3ForInference"> </param>
		/// <param name="dummy4ForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<UnifiedElement> Descendants<T1, T2, T3, T4>(
				this UnifiedElement element,
				T1 dummy1ForInference = default(T1),
				T2 dummy2ForInference = default(T2),
				T3 dummy3ForInference = default(T3),
				T4 dummy4ForInference = default(T4)) {
			Contract.Requires(element != null);
			return element.Descendants().Where(
					e => e is T1 || e is T2 || e is T3 || e is T4);
		}

		/// <summary>
		///   指定した型に限定して，指定した要素の子孫を列挙します．
		/// </summary>
		/// <typeparam name="T1"> </typeparam>
		/// <typeparam name="T2"> </typeparam>
		/// <typeparam name="T3"> </typeparam>
		/// <typeparam name="T4"> </typeparam>
		/// <typeparam name="T5"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummy1ForInference"> </param>
		/// <param name="dummy2ForInference"> </param>
		/// <param name="dummy3ForInference"> </param>
		/// <param name="dummy4ForInference"> </param>
		/// <param name="dummy5ForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<UnifiedElement> Descendants
				<T1, T2, T3, T4, T5>(
				this UnifiedElement element,
				T1 dummy1ForInference = default(T1),
				T2 dummy2ForInference = default(T2),
				T3 dummy3ForInference = default(T3),
				T4 dummy4ForInference = default(T4),
				T5 dummy5ForInference = default(T5)) {
			Contract.Requires(element != null);
			return
					element.Descendants().Where(
							e =>
							e is T1 || e is T2 || e is T3 || e is T4 || e is T5);
		}

		/// <summary>
		///   指定した型に限定して，指定した要素の子孫を列挙します．
		/// </summary>
		/// <typeparam name="T1"> </typeparam>
		/// <typeparam name="T2"> </typeparam>
		/// <typeparam name="T3"> </typeparam>
		/// <typeparam name="T4"> </typeparam>
		/// <typeparam name="T5"> </typeparam>
		/// <typeparam name="T6"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummy1ForInference"> </param>
		/// <param name="dummy2ForInference"> </param>
		/// <param name="dummy3ForInference"> </param>
		/// <param name="dummy4ForInference"> </param>
		/// <param name="dummy5ForInference"> </param>
		/// <param name="dummy6ForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<UnifiedElement> Descendants
				<T1, T2, T3, T4, T5, T6>(
				this UnifiedElement element,
				T1 dummy1ForInference = default(T1),
				T2 dummy2ForInference = default(T2),
				T3 dummy3ForInference = default(T3),
				T4 dummy4ForInference = default(T4),
				T5 dummy5ForInference = default(T5),
				T6 dummy6ForInference = default(T6)) {
			Contract.Requires(element != null);
			return
					element.Descendants().Where(
							e =>
							e is T1 || e is T2 || e is T3 || e is T4 || e is T5
							|| e is T6);
		}

		/// <summary>
		///   指定した型に限定して，指定した要素の子孫を列挙します．
		/// </summary>
		/// <typeparam name="T1"> </typeparam>
		/// <typeparam name="T2"> </typeparam>
		/// <typeparam name="T3"> </typeparam>
		/// <typeparam name="T4"> </typeparam>
		/// <typeparam name="T5"> </typeparam>
		/// <typeparam name="T6"> </typeparam>
		/// <typeparam name="T7"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummy1ForInference"> </param>
		/// <param name="dummy2ForInference"> </param>
		/// <param name="dummy3ForInference"> </param>
		/// <param name="dummy4ForInference"> </param>
		/// <param name="dummy5ForInference"> </param>
		/// <param name="dummy6ForInference"> </param>
		/// <param name="dummy7ForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<UnifiedElement> Descendants
				<T1, T2, T3, T4, T5, T6, T7>(
				this UnifiedElement element,
				T1 dummy1ForInference = default(T1),
				T2 dummy2ForInference = default(T2),
				T3 dummy3ForInference = default(T3),
				T4 dummy4ForInference = default(T4),
				T5 dummy5ForInference = default(T5),
				T6 dummy6ForInference = default(T6),
				T7 dummy7ForInference = default(T7)
				) {
			Contract.Requires(element != null);
			return
					element.Descendants().Where(
							e =>
							e is T1 || e is T2 || e is T3 || e is T4 || e is T5
							|| e is T6 || e is T7);
		}

		/// <summary>
		///   指定した型に限定して，指定した要素の子孫を列挙します．
		/// </summary>
		/// <typeparam name="T1"> </typeparam>
		/// <typeparam name="T2"> </typeparam>
		/// <typeparam name="T3"> </typeparam>
		/// <typeparam name="T4"> </typeparam>
		/// <typeparam name="T5"> </typeparam>
		/// <typeparam name="T6"> </typeparam>
		/// <typeparam name="T7"> </typeparam>
		/// <typeparam name="T8"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummy1ForInference"> </param>
		/// <param name="dummy2ForInference"> </param>
		/// <param name="dummy3ForInference"> </param>
		/// <param name="dummy4ForInference"> </param>
		/// <param name="dummy5ForInference"> </param>
		/// <param name="dummy6ForInference"> </param>
		/// <param name="dummy7ForInference"> </param>
		/// <param name="dummy8ForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<UnifiedElement> Descendants
				<T1, T2, T3, T4, T5, T6, T7, T8>(
				this UnifiedElement element,
				T1 dummy1ForInference = default(T1),
				T2 dummy2ForInference = default(T2),
				T3 dummy3ForInference = default(T3),
				T4 dummy4ForInference = default(T4),
				T5 dummy5ForInference = default(T5),
				T6 dummy6ForInference = default(T6),
				T7 dummy7ForInference = default(T7),
				T8 dummy8ForInference = default(T8)
				) {
			Contract.Requires(element != null);
			return
					element.Descendants().Where(
							e =>
							e is T1 || e is T2 || e is T3 || e is T4 || e is T5
							|| e is T6 || e is T7
							|| e is T8);
		}

		/// <summary>
		///   指定した型に限定して，指定した要素の子孫を列挙します．
		/// </summary>
		/// <typeparam name="T1"> </typeparam>
		/// <typeparam name="T2"> </typeparam>
		/// <typeparam name="T3"> </typeparam>
		/// <typeparam name="T4"> </typeparam>
		/// <typeparam name="T5"> </typeparam>
		/// <typeparam name="T6"> </typeparam>
		/// <typeparam name="T7"> </typeparam>
		/// <typeparam name="T8"> </typeparam>
		/// <typeparam name="T9"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummy1ForInference"> </param>
		/// <param name="dummy2ForInference"> </param>
		/// <param name="dummy3ForInference"> </param>
		/// <param name="dummy4ForInference"> </param>
		/// <param name="dummy5ForInference"> </param>
		/// <param name="dummy6ForInference"> </param>
		/// <param name="dummy7ForInference"> </param>
		/// <param name="dummy8ForInference"> </param>
		/// <param name="dummy9ForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<UnifiedElement> Descendants
				<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
				this UnifiedElement element,
				T1 dummy1ForInference = default(T1),
				T2 dummy2ForInference = default(T2),
				T3 dummy3ForInference = default(T3),
				T4 dummy4ForInference = default(T4),
				T5 dummy5ForInference = default(T5),
				T6 dummy6ForInference = default(T6),
				T7 dummy7ForInference = default(T7),
				T8 dummy8ForInference = default(T8),
				T9 dummy9ForInference = default(T9)
				) {
			Contract.Requires(element != null);
			return
					element.Descendants().Where(
							e =>
							e is T1 || e is T2 || e is T3 || e is T4 || e is T5
							|| e is T6 || e is T7
							|| e is T8 || e is T9);
		}

		/// <summary>
		///   指定した型に限定して，指定した要素の子孫を列挙します．
		/// </summary>
		/// <typeparam name="T1"> </typeparam>
		/// <typeparam name="T2"> </typeparam>
		/// <typeparam name="T3"> </typeparam>
		/// <typeparam name="T4"> </typeparam>
		/// <typeparam name="T5"> </typeparam>
		/// <typeparam name="T6"> </typeparam>
		/// <typeparam name="T7"> </typeparam>
		/// <typeparam name="T8"> </typeparam>
		/// <typeparam name="T9"> </typeparam>
		/// <typeparam name="T10"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummy1ForInference"> </param>
		/// <param name="dummy2ForInference"> </param>
		/// <param name="dummy3ForInference"> </param>
		/// <param name="dummy4ForInference"> </param>
		/// <param name="dummy5ForInference"> </param>
		/// <param name="dummy6ForInference"> </param>
		/// <param name="dummy7ForInference"> </param>
		/// <param name="dummy8ForInference"> </param>
		/// <param name="dummy9ForInference"> </param>
		/// <param name="dummy10ForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<UnifiedElement> Descendants
				<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
				this UnifiedElement element,
				T1 dummy1ForInference = default(T1),
				T2 dummy2ForInference = default(T2),
				T3 dummy3ForInference = default(T3),
				T4 dummy4ForInference = default(T4),
				T5 dummy5ForInference = default(T5),
				T6 dummy6ForInference = default(T6),
				T7 dummy7ForInference = default(T7),
				T8 dummy8ForInference = default(T8),
				T9 dummy9ForInference = default(T9),
				T10 dummy10ForInference = default(T10)
				) {
			Contract.Requires(element != null);
			return
					element.Descendants().Where(
							e =>
							e is T1 || e is T2 || e is T3 || e is T4 || e is T5
							|| e is T6 || e is T7
							|| e is T8 || e is T9 || e is T10);
		}

		#endregion

		#region AncestorsAndSelf

		/// <summary>
		///   指定した型に限定して，指定した要素とその祖先を列挙します．
		/// </summary>
		/// <typeparam name="T1"> </typeparam>
		/// <typeparam name="T2"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummy1ForInference"> </param>
		/// <param name="dummy2ForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<UnifiedElement> AncestorsAndSelf<T1, T2>(
				this UnifiedElement element,
				T1 dummy1ForInference = default(T1),
				T2 dummy2ForInference = default(T2)) {
			Contract.Requires(element != null);
			return element.AncestorsAndSelf().Where(e => e is T1 || e is T2);
		}

		/// <summary>
		///   指定した型に限定して，指定した要素とその祖先を列挙します．
		/// </summary>
		/// <typeparam name="T1"> </typeparam>
		/// <typeparam name="T2"> </typeparam>
		/// <typeparam name="T3"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummy1ForInference"> </param>
		/// <param name="dummy2ForInference"> </param>
		/// <param name="dummy3ForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<UnifiedElement> AncestorsAndSelf<T1, T2, T3>(
				this UnifiedElement element,
				T1 dummy1ForInference = default(T1),
				T2 dummy2ForInference = default(T2),
				T3 dummy3ForInference = default(T3)) {
			Contract.Requires(element != null);
			return
					element.AncestorsAndSelf().Where(
							e => e is T1 || e is T2 || e is T3);
		}

		/// <summary>
		///   指定した型に限定して，指定した要素とその祖先を列挙します．
		/// </summary>
		/// <typeparam name="T1"> </typeparam>
		/// <typeparam name="T2"> </typeparam>
		/// <typeparam name="T3"> </typeparam>
		/// <typeparam name="T4"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummy1ForInference"> </param>
		/// <param name="dummy2ForInference"> </param>
		/// <param name="dummy3ForInference"> </param>
		/// <param name="dummy4ForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<UnifiedElement> AncestorsAndSelf
				<T1, T2, T3, T4>(
				this UnifiedElement element,
				T1 dummy1ForInference = default(T1),
				T2 dummy2ForInference = default(T2),
				T3 dummy3ForInference = default(T3),
				T4 dummy4ForInference = default(T4)) {
			Contract.Requires(element != null);
			return element.AncestorsAndSelf().Where(
					e => e is T1 || e is T2 || e is T3 || e is T4);
		}

		/// <summary>
		///   指定した型に限定して，指定した要素とその祖先を列挙します．
		/// </summary>
		/// <typeparam name="T1"> </typeparam>
		/// <typeparam name="T2"> </typeparam>
		/// <typeparam name="T3"> </typeparam>
		/// <typeparam name="T4"> </typeparam>
		/// <typeparam name="T5"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummy1ForInference"> </param>
		/// <param name="dummy2ForInference"> </param>
		/// <param name="dummy3ForInference"> </param>
		/// <param name="dummy4ForInference"> </param>
		/// <param name="dummy5ForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<UnifiedElement> AncestorsAndSelf
				<T1, T2, T3, T4, T5>(
				this UnifiedElement element,
				T1 dummy1ForInference = default(T1),
				T2 dummy2ForInference = default(T2),
				T3 dummy3ForInference = default(T3),
				T4 dummy4ForInference = default(T4),
				T5 dummy5ForInference = default(T5)) {
			Contract.Requires(element != null);
			return
					element.AncestorsAndSelf().Where(
							e =>
							e is T1 || e is T2 || e is T3 || e is T4 || e is T5);
		}

		/// <summary>
		///   指定した型に限定して，指定した要素とその祖先を列挙します．
		/// </summary>
		/// <typeparam name="T1"> </typeparam>
		/// <typeparam name="T2"> </typeparam>
		/// <typeparam name="T3"> </typeparam>
		/// <typeparam name="T4"> </typeparam>
		/// <typeparam name="T5"> </typeparam>
		/// <typeparam name="T6"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummy1ForInference"> </param>
		/// <param name="dummy2ForInference"> </param>
		/// <param name="dummy3ForInference"> </param>
		/// <param name="dummy4ForInference"> </param>
		/// <param name="dummy5ForInference"> </param>
		/// <param name="dummy6ForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<UnifiedElement> AncestorsAndSelf
				<T1, T2, T3, T4, T5, T6>(
				this UnifiedElement element,
				T1 dummy1ForInference = default(T1),
				T2 dummy2ForInference = default(T2),
				T3 dummy3ForInference = default(T3),
				T4 dummy4ForInference = default(T4),
				T5 dummy5ForInference = default(T5),
				T6 dummy6ForInference = default(T6)) {
			Contract.Requires(element != null);
			return
					element.AncestorsAndSelf().Where(
							e =>
							e is T1 || e is T2 || e is T3 || e is T4 || e is T5
							|| e is T6);
		}

		/// <summary>
		///   指定した型に限定して，指定した要素とその祖先を列挙します．
		/// </summary>
		/// <typeparam name="T1"> </typeparam>
		/// <typeparam name="T2"> </typeparam>
		/// <typeparam name="T3"> </typeparam>
		/// <typeparam name="T4"> </typeparam>
		/// <typeparam name="T5"> </typeparam>
		/// <typeparam name="T6"> </typeparam>
		/// <typeparam name="T7"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummy1ForInference"> </param>
		/// <param name="dummy2ForInference"> </param>
		/// <param name="dummy3ForInference"> </param>
		/// <param name="dummy4ForInference"> </param>
		/// <param name="dummy5ForInference"> </param>
		/// <param name="dummy6ForInference"> </param>
		/// <param name="dummy7ForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<UnifiedElement> AncestorsAndSelf
				<T1, T2, T3, T4, T5, T6, T7>(
				this UnifiedElement element,
				T1 dummy1ForInference = default(T1),
				T2 dummy2ForInference = default(T2),
				T3 dummy3ForInference = default(T3),
				T4 dummy4ForInference = default(T4),
				T5 dummy5ForInference = default(T5),
				T6 dummy6ForInference = default(T6),
				T7 dummy7ForInference = default(T7)
				) {
			Contract.Requires(element != null);
			return
					element.AncestorsAndSelf().Where(
							e =>
							e is T1 || e is T2 || e is T3 || e is T4 || e is T5
							|| e is T6 || e is T7);
		}

		/// <summary>
		///   指定した型に限定して，指定した要素とその祖先を列挙します．
		/// </summary>
		/// <typeparam name="T1"> </typeparam>
		/// <typeparam name="T2"> </typeparam>
		/// <typeparam name="T3"> </typeparam>
		/// <typeparam name="T4"> </typeparam>
		/// <typeparam name="T5"> </typeparam>
		/// <typeparam name="T6"> </typeparam>
		/// <typeparam name="T7"> </typeparam>
		/// <typeparam name="T8"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummy1ForInference"> </param>
		/// <param name="dummy2ForInference"> </param>
		/// <param name="dummy3ForInference"> </param>
		/// <param name="dummy4ForInference"> </param>
		/// <param name="dummy5ForInference"> </param>
		/// <param name="dummy6ForInference"> </param>
		/// <param name="dummy7ForInference"> </param>
		/// <param name="dummy8ForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<UnifiedElement> AncestorsAndSelf
				<T1, T2, T3, T4, T5, T6, T7, T8>(
				this UnifiedElement element,
				T1 dummy1ForInference = default(T1),
				T2 dummy2ForInference = default(T2),
				T3 dummy3ForInference = default(T3),
				T4 dummy4ForInference = default(T4),
				T5 dummy5ForInference = default(T5),
				T6 dummy6ForInference = default(T6),
				T7 dummy7ForInference = default(T7),
				T8 dummy8ForInference = default(T8)
				) {
			Contract.Requires(element != null);
			return
					element.AncestorsAndSelf().Where(
							e =>
							e is T1 || e is T2 || e is T3 || e is T4 || e is T5
							|| e is T6 || e is T7
							|| e is T8);
		}

		/// <summary>
		///   指定した型に限定して，指定した要素とその祖先を列挙します．
		/// </summary>
		/// <typeparam name="T1"> </typeparam>
		/// <typeparam name="T2"> </typeparam>
		/// <typeparam name="T3"> </typeparam>
		/// <typeparam name="T4"> </typeparam>
		/// <typeparam name="T5"> </typeparam>
		/// <typeparam name="T6"> </typeparam>
		/// <typeparam name="T7"> </typeparam>
		/// <typeparam name="T8"> </typeparam>
		/// <typeparam name="T9"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummy1ForInference"> </param>
		/// <param name="dummy2ForInference"> </param>
		/// <param name="dummy3ForInference"> </param>
		/// <param name="dummy4ForInference"> </param>
		/// <param name="dummy5ForInference"> </param>
		/// <param name="dummy6ForInference"> </param>
		/// <param name="dummy7ForInference"> </param>
		/// <param name="dummy8ForInference"> </param>
		/// <param name="dummy9ForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<UnifiedElement> AncestorsAndSelf
				<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
				this UnifiedElement element,
				T1 dummy1ForInference = default(T1),
				T2 dummy2ForInference = default(T2),
				T3 dummy3ForInference = default(T3),
				T4 dummy4ForInference = default(T4),
				T5 dummy5ForInference = default(T5),
				T6 dummy6ForInference = default(T6),
				T7 dummy7ForInference = default(T7),
				T8 dummy8ForInference = default(T8),
				T9 dummy9ForInference = default(T9)
				) {
			Contract.Requires(element != null);
			return
					element.AncestorsAndSelf().Where(
							e =>
							e is T1 || e is T2 || e is T3 || e is T4 || e is T5
							|| e is T6 || e is T7
							|| e is T8 || e is T9);
		}

		/// <summary>
		///   指定した型に限定して，指定した要素とその祖先を列挙します．
		/// </summary>
		/// <typeparam name="T1"> </typeparam>
		/// <typeparam name="T2"> </typeparam>
		/// <typeparam name="T3"> </typeparam>
		/// <typeparam name="T4"> </typeparam>
		/// <typeparam name="T5"> </typeparam>
		/// <typeparam name="T6"> </typeparam>
		/// <typeparam name="T7"> </typeparam>
		/// <typeparam name="T8"> </typeparam>
		/// <typeparam name="T9"> </typeparam>
		/// <typeparam name="T10"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummy1ForInference"> </param>
		/// <param name="dummy2ForInference"> </param>
		/// <param name="dummy3ForInference"> </param>
		/// <param name="dummy4ForInference"> </param>
		/// <param name="dummy5ForInference"> </param>
		/// <param name="dummy6ForInference"> </param>
		/// <param name="dummy7ForInference"> </param>
		/// <param name="dummy8ForInference"> </param>
		/// <param name="dummy9ForInference"> </param>
		/// <param name="dummy10ForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<UnifiedElement> AncestorsAndSelf
				<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
				this UnifiedElement element,
				T1 dummy1ForInference = default(T1),
				T2 dummy2ForInference = default(T2),
				T3 dummy3ForInference = default(T3),
				T4 dummy4ForInference = default(T4),
				T5 dummy5ForInference = default(T5),
				T6 dummy6ForInference = default(T6),
				T7 dummy7ForInference = default(T7),
				T8 dummy8ForInference = default(T8),
				T9 dummy9ForInference = default(T9),
				T10 dummy10ForInference = default(T10)
				) {
			Contract.Requires(element != null);
			return
					element.AncestorsAndSelf().Where(
							e =>
							e is T1 || e is T2 || e is T3 || e is T4 || e is T5
							|| e is T6 || e is T7
							|| e is T8 || e is T9 || e is T10);
		}

		#endregion

		#region Ancestors

		/// <summary>
		///   指定した型に限定して，指定した要素の祖先を列挙します．
		/// </summary>
		/// <typeparam name="T1"> </typeparam>
		/// <typeparam name="T2"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummy1ForInference"> </param>
		/// <param name="dummy2ForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<UnifiedElement> Ancestors<T1, T2>(
				this UnifiedElement element,
				T1 dummy1ForInference = default(T1),
				T2 dummy2ForInference = default(T2)) {
			Contract.Requires(element != null);
			return element.Ancestors().Where(e => e is T1 || e is T2);
		}

		/// <summary>
		///   指定した型に限定して，指定した要素の祖先を列挙します．
		/// </summary>
		/// <typeparam name="T1"> </typeparam>
		/// <typeparam name="T2"> </typeparam>
		/// <typeparam name="T3"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummy1ForInference"> </param>
		/// <param name="dummy2ForInference"> </param>
		/// <param name="dummy3ForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<UnifiedElement> Ancestors<T1, T2, T3>(
				this UnifiedElement element,
				T1 dummy1ForInference = default(T1),
				T2 dummy2ForInference = default(T2),
				T3 dummy3ForInference = default(T3)) {
			Contract.Requires(element != null);
			return element.Ancestors().Where(e => e is T1 || e is T2 || e is T3);
		}

		/// <summary>
		///   指定した型に限定して，指定した要素の祖先を列挙します．
		/// </summary>
		/// <typeparam name="T1"> </typeparam>
		/// <typeparam name="T2"> </typeparam>
		/// <typeparam name="T3"> </typeparam>
		/// <typeparam name="T4"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummy1ForInference"> </param>
		/// <param name="dummy2ForInference"> </param>
		/// <param name="dummy3ForInference"> </param>
		/// <param name="dummy4ForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<UnifiedElement> Ancestors<T1, T2, T3, T4>(
				this UnifiedElement element,
				T1 dummy1ForInference = default(T1),
				T2 dummy2ForInference = default(T2),
				T3 dummy3ForInference = default(T3),
				T4 dummy4ForInference = default(T4)) {
			Contract.Requires(element != null);
			return element.Ancestors().Where(
					e => e is T1 || e is T2 || e is T3 || e is T4);
		}

		/// <summary>
		///   指定した型に限定して，指定した要素の祖先を列挙します．
		/// </summary>
		/// <typeparam name="T1"> </typeparam>
		/// <typeparam name="T2"> </typeparam>
		/// <typeparam name="T3"> </typeparam>
		/// <typeparam name="T4"> </typeparam>
		/// <typeparam name="T5"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummy1ForInference"> </param>
		/// <param name="dummy2ForInference"> </param>
		/// <param name="dummy3ForInference"> </param>
		/// <param name="dummy4ForInference"> </param>
		/// <param name="dummy5ForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<UnifiedElement> Ancestors<T1, T2, T3, T4, T5>
				(
				this UnifiedElement element,
				T1 dummy1ForInference = default(T1),
				T2 dummy2ForInference = default(T2),
				T3 dummy3ForInference = default(T3),
				T4 dummy4ForInference = default(T4),
				T5 dummy5ForInference = default(T5)) {
			Contract.Requires(element != null);
			return
					element.Ancestors().Where(
							e =>
							e is T1 || e is T2 || e is T3 || e is T4 || e is T5);
		}

		/// <summary>
		///   指定した型に限定して，指定した要素の祖先を列挙します．
		/// </summary>
		/// <typeparam name="T1"> </typeparam>
		/// <typeparam name="T2"> </typeparam>
		/// <typeparam name="T3"> </typeparam>
		/// <typeparam name="T4"> </typeparam>
		/// <typeparam name="T5"> </typeparam>
		/// <typeparam name="T6"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummy1ForInference"> </param>
		/// <param name="dummy2ForInference"> </param>
		/// <param name="dummy3ForInference"> </param>
		/// <param name="dummy4ForInference"> </param>
		/// <param name="dummy5ForInference"> </param>
		/// <param name="dummy6ForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<UnifiedElement> Ancestors
				<T1, T2, T3, T4, T5, T6>(
				this UnifiedElement element,
				T1 dummy1ForInference = default(T1),
				T2 dummy2ForInference = default(T2),
				T3 dummy3ForInference = default(T3),
				T4 dummy4ForInference = default(T4),
				T5 dummy5ForInference = default(T5),
				T6 dummy6ForInference = default(T6)) {
			Contract.Requires(element != null);
			return
					element.Ancestors().Where(
							e =>
							e is T1 || e is T2 || e is T3 || e is T4 || e is T5
							|| e is T6);
		}

		/// <summary>
		///   指定した型に限定して，指定した要素の祖先を列挙します．
		/// </summary>
		/// <typeparam name="T1"> </typeparam>
		/// <typeparam name="T2"> </typeparam>
		/// <typeparam name="T3"> </typeparam>
		/// <typeparam name="T4"> </typeparam>
		/// <typeparam name="T5"> </typeparam>
		/// <typeparam name="T6"> </typeparam>
		/// <typeparam name="T7"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummy1ForInference"> </param>
		/// <param name="dummy2ForInference"> </param>
		/// <param name="dummy3ForInference"> </param>
		/// <param name="dummy4ForInference"> </param>
		/// <param name="dummy5ForInference"> </param>
		/// <param name="dummy6ForInference"> </param>
		/// <param name="dummy7ForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<UnifiedElement> Ancestors
				<T1, T2, T3, T4, T5, T6, T7>(
				this UnifiedElement element,
				T1 dummy1ForInference = default(T1),
				T2 dummy2ForInference = default(T2),
				T3 dummy3ForInference = default(T3),
				T4 dummy4ForInference = default(T4),
				T5 dummy5ForInference = default(T5),
				T6 dummy6ForInference = default(T6),
				T7 dummy7ForInference = default(T7)
				) {
			Contract.Requires(element != null);
			return
					element.Ancestors().Where(
							e =>
							e is T1 || e is T2 || e is T3 || e is T4 || e is T5
							|| e is T6 || e is T7);
		}

		/// <summary>
		///   指定した型に限定して，指定した要素の祖先を列挙します．
		/// </summary>
		/// <typeparam name="T1"> </typeparam>
		/// <typeparam name="T2"> </typeparam>
		/// <typeparam name="T3"> </typeparam>
		/// <typeparam name="T4"> </typeparam>
		/// <typeparam name="T5"> </typeparam>
		/// <typeparam name="T6"> </typeparam>
		/// <typeparam name="T7"> </typeparam>
		/// <typeparam name="T8"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummy1ForInference"> </param>
		/// <param name="dummy2ForInference"> </param>
		/// <param name="dummy3ForInference"> </param>
		/// <param name="dummy4ForInference"> </param>
		/// <param name="dummy5ForInference"> </param>
		/// <param name="dummy6ForInference"> </param>
		/// <param name="dummy7ForInference"> </param>
		/// <param name="dummy8ForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<UnifiedElement> Ancestors
				<T1, T2, T3, T4, T5, T6, T7, T8>(
				this UnifiedElement element,
				T1 dummy1ForInference = default(T1),
				T2 dummy2ForInference = default(T2),
				T3 dummy3ForInference = default(T3),
				T4 dummy4ForInference = default(T4),
				T5 dummy5ForInference = default(T5),
				T6 dummy6ForInference = default(T6),
				T7 dummy7ForInference = default(T7),
				T8 dummy8ForInference = default(T8)
				) {
			Contract.Requires(element != null);
			return
					element.Ancestors().Where(
							e =>
							e is T1 || e is T2 || e is T3 || e is T4 || e is T5
							|| e is T6 || e is T7
							|| e is T8);
		}

		/// <summary>
		///   指定した型に限定して，指定した要素の祖先を列挙します．
		/// </summary>
		/// <typeparam name="T1"> </typeparam>
		/// <typeparam name="T2"> </typeparam>
		/// <typeparam name="T3"> </typeparam>
		/// <typeparam name="T4"> </typeparam>
		/// <typeparam name="T5"> </typeparam>
		/// <typeparam name="T6"> </typeparam>
		/// <typeparam name="T7"> </typeparam>
		/// <typeparam name="T8"> </typeparam>
		/// <typeparam name="T9"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummy1ForInference"> </param>
		/// <param name="dummy2ForInference"> </param>
		/// <param name="dummy3ForInference"> </param>
		/// <param name="dummy4ForInference"> </param>
		/// <param name="dummy5ForInference"> </param>
		/// <param name="dummy6ForInference"> </param>
		/// <param name="dummy7ForInference"> </param>
		/// <param name="dummy8ForInference"> </param>
		/// <param name="dummy9ForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<UnifiedElement> Ancestors
				<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
				this UnifiedElement element,
				T1 dummy1ForInference = default(T1),
				T2 dummy2ForInference = default(T2),
				T3 dummy3ForInference = default(T3),
				T4 dummy4ForInference = default(T4),
				T5 dummy5ForInference = default(T5),
				T6 dummy6ForInference = default(T6),
				T7 dummy7ForInference = default(T7),
				T8 dummy8ForInference = default(T8),
				T9 dummy9ForInference = default(T9)
				) {
			Contract.Requires(element != null);
			return
					element.Ancestors().Where(
							e =>
							e is T1 || e is T2 || e is T3 || e is T4 || e is T5
							|| e is T6 || e is T7
							|| e is T8 || e is T9);
		}

		/// <summary>
		///   指定した型に限定して，指定した要素の祖先を列挙します．
		/// </summary>
		/// <typeparam name="T1"> </typeparam>
		/// <typeparam name="T2"> </typeparam>
		/// <typeparam name="T3"> </typeparam>
		/// <typeparam name="T4"> </typeparam>
		/// <typeparam name="T5"> </typeparam>
		/// <typeparam name="T6"> </typeparam>
		/// <typeparam name="T7"> </typeparam>
		/// <typeparam name="T8"> </typeparam>
		/// <typeparam name="T9"> </typeparam>
		/// <typeparam name="T10"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummy1ForInference"> </param>
		/// <param name="dummy2ForInference"> </param>
		/// <param name="dummy3ForInference"> </param>
		/// <param name="dummy4ForInference"> </param>
		/// <param name="dummy5ForInference"> </param>
		/// <param name="dummy6ForInference"> </param>
		/// <param name="dummy7ForInference"> </param>
		/// <param name="dummy8ForInference"> </param>
		/// <param name="dummy9ForInference"> </param>
		/// <param name="dummy10ForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<UnifiedElement> Ancestors
				<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
				this UnifiedElement element,
				T1 dummy1ForInference = default(T1),
				T2 dummy2ForInference = default(T2),
				T3 dummy3ForInference = default(T3),
				T4 dummy4ForInference = default(T4),
				T5 dummy5ForInference = default(T5),
				T6 dummy6ForInference = default(T6),
				T7 dummy7ForInference = default(T7),
				T8 dummy8ForInference = default(T8),
				T9 dummy9ForInference = default(T9),
				T10 dummy10ForInference = default(T10)
				) {
			Contract.Requires(element != null);
			return
					element.Ancestors().Where(
							e =>
							e is T1 || e is T2 || e is T3 || e is T4 || e is T5
							|| e is T6 || e is T7
							|| e is T8 || e is T9 || e is T10);
		}

		#endregion

		#region Elements

		/// <summary>
		///   指定した型に限定して，指定した要素の子要素を列挙します．
		/// </summary>
		/// <typeparam name="T1"> </typeparam>
		/// <typeparam name="T2"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummy1ForInference"> </param>
		/// <param name="dummy2ForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<UnifiedElement> Elements<T1, T2>(
				this UnifiedElement element,
				T1 dummy1ForInference = default(T1),
				T2 dummy2ForInference = default(T2)) {
			Contract.Requires(element != null);
			return element.Elements().Where(e => e is T1 || e is T2);
		}

		/// <summary>
		///   指定した型に限定して，指定した要素の子要素を列挙します．
		/// </summary>
		/// <typeparam name="T1"> </typeparam>
		/// <typeparam name="T2"> </typeparam>
		/// <typeparam name="T3"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummy1ForInference"> </param>
		/// <param name="dummy2ForInference"> </param>
		/// <param name="dummy3ForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<UnifiedElement> Elements<T1, T2, T3>(
				this UnifiedElement element,
				T1 dummy1ForInference = default(T1),
				T2 dummy2ForInference = default(T2),
				T3 dummy3ForInference = default(T3)) {
			Contract.Requires(element != null);
			return element.Elements().Where(e => e is T1 || e is T2 || e is T3);
		}

		/// <summary>
		///   指定した型に限定して，指定した要素の子要素を列挙します．
		/// </summary>
		/// <typeparam name="T1"> </typeparam>
		/// <typeparam name="T2"> </typeparam>
		/// <typeparam name="T3"> </typeparam>
		/// <typeparam name="T4"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummy1ForInference"> </param>
		/// <param name="dummy2ForInference"> </param>
		/// <param name="dummy3ForInference"> </param>
		/// <param name="dummy4ForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<UnifiedElement> Elements<T1, T2, T3, T4>(
				this UnifiedElement element,
				T1 dummy1ForInference = default(T1),
				T2 dummy2ForInference = default(T2),
				T3 dummy3ForInference = default(T3),
				T4 dummy4ForInference = default(T4)) {
			Contract.Requires(element != null);
			return element.Elements().Where(
					e => e is T1 || e is T2 || e is T3 || e is T4);
		}

		/// <summary>
		///   指定した型に限定して，指定した要素の子要素を列挙します．
		/// </summary>
		/// <typeparam name="T1"> </typeparam>
		/// <typeparam name="T2"> </typeparam>
		/// <typeparam name="T3"> </typeparam>
		/// <typeparam name="T4"> </typeparam>
		/// <typeparam name="T5"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummy1ForInference"> </param>
		/// <param name="dummy2ForInference"> </param>
		/// <param name="dummy3ForInference"> </param>
		/// <param name="dummy4ForInference"> </param>
		/// <param name="dummy5ForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<UnifiedElement> Elements<T1, T2, T3, T4, T5>(
				this UnifiedElement element,
				T1 dummy1ForInference = default(T1),
				T2 dummy2ForInference = default(T2),
				T3 dummy3ForInference = default(T3),
				T4 dummy4ForInference = default(T4),
				T5 dummy5ForInference = default(T5)) {
			Contract.Requires(element != null);
			return
					element.Elements().Where(
							e =>
							e is T1 || e is T2 || e is T3 || e is T4 || e is T5);
		}

		/// <summary>
		///   指定した型に限定して，指定した要素の子要素を列挙します．
		/// </summary>
		/// <typeparam name="T1"> </typeparam>
		/// <typeparam name="T2"> </typeparam>
		/// <typeparam name="T3"> </typeparam>
		/// <typeparam name="T4"> </typeparam>
		/// <typeparam name="T5"> </typeparam>
		/// <typeparam name="T6"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummy1ForInference"> </param>
		/// <param name="dummy2ForInference"> </param>
		/// <param name="dummy3ForInference"> </param>
		/// <param name="dummy4ForInference"> </param>
		/// <param name="dummy5ForInference"> </param>
		/// <param name="dummy6ForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<UnifiedElement> Elements
				<T1, T2, T3, T4, T5, T6>(
				this UnifiedElement element,
				T1 dummy1ForInference = default(T1),
				T2 dummy2ForInference = default(T2),
				T3 dummy3ForInference = default(T3),
				T4 dummy4ForInference = default(T4),
				T5 dummy5ForInference = default(T5),
				T6 dummy6ForInference = default(T6)) {
			Contract.Requires(element != null);
			return
					element.Elements().Where(
							e =>
							e is T1 || e is T2 || e is T3 || e is T4 || e is T5
							|| e is T6);
		}

		/// <summary>
		///   指定した型に限定して，指定した要素の子要素を列挙します．
		/// </summary>
		/// <typeparam name="T1"> </typeparam>
		/// <typeparam name="T2"> </typeparam>
		/// <typeparam name="T3"> </typeparam>
		/// <typeparam name="T4"> </typeparam>
		/// <typeparam name="T5"> </typeparam>
		/// <typeparam name="T6"> </typeparam>
		/// <typeparam name="T7"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummy1ForInference"> </param>
		/// <param name="dummy2ForInference"> </param>
		/// <param name="dummy3ForInference"> </param>
		/// <param name="dummy4ForInference"> </param>
		/// <param name="dummy5ForInference"> </param>
		/// <param name="dummy6ForInference"> </param>
		/// <param name="dummy7ForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<UnifiedElement> Elements
				<T1, T2, T3, T4, T5, T6, T7>(
				this UnifiedElement element,
				T1 dummy1ForInference = default(T1),
				T2 dummy2ForInference = default(T2),
				T3 dummy3ForInference = default(T3),
				T4 dummy4ForInference = default(T4),
				T5 dummy5ForInference = default(T5),
				T6 dummy6ForInference = default(T6),
				T7 dummy7ForInference = default(T7)
				) {
			Contract.Requires(element != null);
			return
					element.Elements().Where(
							e =>
							e is T1 || e is T2 || e is T3 || e is T4 || e is T5
							|| e is T6 || e is T7);
		}

		/// <summary>
		///   指定した型に限定して，指定した要素の子要素を列挙します．
		/// </summary>
		/// <typeparam name="T1"> </typeparam>
		/// <typeparam name="T2"> </typeparam>
		/// <typeparam name="T3"> </typeparam>
		/// <typeparam name="T4"> </typeparam>
		/// <typeparam name="T5"> </typeparam>
		/// <typeparam name="T6"> </typeparam>
		/// <typeparam name="T7"> </typeparam>
		/// <typeparam name="T8"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummy1ForInference"> </param>
		/// <param name="dummy2ForInference"> </param>
		/// <param name="dummy3ForInference"> </param>
		/// <param name="dummy4ForInference"> </param>
		/// <param name="dummy5ForInference"> </param>
		/// <param name="dummy6ForInference"> </param>
		/// <param name="dummy7ForInference"> </param>
		/// <param name="dummy8ForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<UnifiedElement> Elements
				<T1, T2, T3, T4, T5, T6, T7, T8>(
				this UnifiedElement element,
				T1 dummy1ForInference = default(T1),
				T2 dummy2ForInference = default(T2),
				T3 dummy3ForInference = default(T3),
				T4 dummy4ForInference = default(T4),
				T5 dummy5ForInference = default(T5),
				T6 dummy6ForInference = default(T6),
				T7 dummy7ForInference = default(T7),
				T8 dummy8ForInference = default(T8)
				) {
			Contract.Requires(element != null);
			return
					element.Elements().Where(
							e =>
							e is T1 || e is T2 || e is T3 || e is T4 || e is T5
							|| e is T6 || e is T7
							|| e is T8);
		}

		/// <summary>
		///   指定した型に限定して，指定した要素の子要素を列挙します．
		/// </summary>
		/// <typeparam name="T1"> </typeparam>
		/// <typeparam name="T2"> </typeparam>
		/// <typeparam name="T3"> </typeparam>
		/// <typeparam name="T4"> </typeparam>
		/// <typeparam name="T5"> </typeparam>
		/// <typeparam name="T6"> </typeparam>
		/// <typeparam name="T7"> </typeparam>
		/// <typeparam name="T8"> </typeparam>
		/// <typeparam name="T9"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummy1ForInference"> </param>
		/// <param name="dummy2ForInference"> </param>
		/// <param name="dummy3ForInference"> </param>
		/// <param name="dummy4ForInference"> </param>
		/// <param name="dummy5ForInference"> </param>
		/// <param name="dummy6ForInference"> </param>
		/// <param name="dummy7ForInference"> </param>
		/// <param name="dummy8ForInference"> </param>
		/// <param name="dummy9ForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<UnifiedElement> Elements
				<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
				this UnifiedElement element,
				T1 dummy1ForInference = default(T1),
				T2 dummy2ForInference = default(T2),
				T3 dummy3ForInference = default(T3),
				T4 dummy4ForInference = default(T4),
				T5 dummy5ForInference = default(T5),
				T6 dummy6ForInference = default(T6),
				T7 dummy7ForInference = default(T7),
				T8 dummy8ForInference = default(T8),
				T9 dummy9ForInference = default(T9)
				) {
			Contract.Requires(element != null);
			return
					element.Elements().Where(
							e =>
							e is T1 || e is T2 || e is T3 || e is T4 || e is T5
							|| e is T6 || e is T7
							|| e is T8 || e is T9);
		}

		/// <summary>
		///   指定した型に限定して，指定した要素の子要素を列挙します．
		/// </summary>
		/// <typeparam name="T1"> </typeparam>
		/// <typeparam name="T2"> </typeparam>
		/// <typeparam name="T3"> </typeparam>
		/// <typeparam name="T4"> </typeparam>
		/// <typeparam name="T5"> </typeparam>
		/// <typeparam name="T6"> </typeparam>
		/// <typeparam name="T7"> </typeparam>
		/// <typeparam name="T8"> </typeparam>
		/// <typeparam name="T9"> </typeparam>
		/// <typeparam name="T10"> </typeparam>
		/// <param name="element"> </param>
		/// <param name="dummy1ForInference"> </param>
		/// <param name="dummy2ForInference"> </param>
		/// <param name="dummy3ForInference"> </param>
		/// <param name="dummy4ForInference"> </param>
		/// <param name="dummy5ForInference"> </param>
		/// <param name="dummy6ForInference"> </param>
		/// <param name="dummy7ForInference"> </param>
		/// <param name="dummy8ForInference"> </param>
		/// <param name="dummy9ForInference"> </param>
		/// <param name="dummy10ForInference"> </param>
		/// <returns> </returns>
		public static IEnumerable<UnifiedElement> Elements
				<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
				this UnifiedElement element,
				T1 dummy1ForInference = default(T1),
				T2 dummy2ForInference = default(T2),
				T3 dummy3ForInference = default(T3),
				T4 dummy4ForInference = default(T4),
				T5 dummy5ForInference = default(T5),
				T6 dummy6ForInference = default(T6),
				T7 dummy7ForInference = default(T7),
				T8 dummy8ForInference = default(T8),
				T9 dummy9ForInference = default(T9),
				T10 dummy10ForInference = default(T10)
				) {
			Contract.Requires(element != null);
			return
					element.Elements().Where(
							e =>
							e is T1 || e is T2 || e is T3 || e is T4 || e is T5
							|| e is T6 || e is T7
							|| e is T8 || e is T9 || e is T10);
		}

		#endregion
	}
}