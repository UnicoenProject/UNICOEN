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

using System.Diagnostics.Contracts;
using System.Linq;

// ReSharper disable InvocationIsSkipped

namespace Unicoen.Model {
    public static class ModelSweeperGenericsForElement {
        /// <summary>
        ///   指定した型に限定して，指定した要素の最初の子要素を取得します．
        /// </summary>
        /// <typeparam name="T"> </typeparam>
        /// <param name="element"> </param>
        /// <param name="dummyForInference"> </param>
        /// <returns> </returns>
        public static T FirstElement<T>(
                this IUnifiedElement element, T dummyForInference = null)
                where T : class {
            Contract.Requires(element != null);
            return element.Elements<T>().FirstOrDefault();
        }

        /// <summary>
        ///   指定した型に限定して，指定した要素の最初の祖先を取得します．
        /// </summary>
        /// <typeparam name="T"> </typeparam>
        /// <param name="element"> </param>
        /// <param name="dummyForInference"> </param>
        /// <returns> </returns>
        public static T FirstAncestor<T>(
                this IUnifiedElement element, T dummyForInference = null)
                where T : class {
            Contract.Requires(element != null);
            return element.Ancestors<T>().FirstOrDefault();
        }

        /// <summary>
        ///   指定した型に限定して，最初の指定した要素もしくはその祖先を取得します．
        /// </summary>
        /// <typeparam name="T"> </typeparam>
        /// <param name="element"> </param>
        /// <param name="dummyForInference"> </param>
        /// <returns> </returns>
        public static T FirstAncestorOrSelf<T>(
                this IUnifiedElement element, T dummyForInference = null)
                where T : class {
            Contract.Requires(element != null);
            return element.AncestorsAndSelf<T>().FirstOrDefault();
        }

        /// <summary>
        ///   指定した型に限定して，指定した要素の最初の子孫を取得します．
        /// </summary>
        /// <typeparam name="T"> </typeparam>
        /// <param name="element"> </param>
        /// <param name="dummyForInference"> </param>
        /// <returns> </returns>
        public static T FirstDescendant<T>(
                this IUnifiedElement element, T dummyForInference = null)
                where T : class {
            Contract.Requires(element != null);
            return element.Descendants<T>().FirstOrDefault();
        }

        /// <summary>
        ///   指定した型に限定して，最初の指定した要素もしくはその子孫を取得します．
        /// </summary>
        /// <typeparam name="T"> </typeparam>
        /// <param name="element"> </param>
        /// <param name="dummyForInference"> </param>
        /// <returns> </returns>
        public static T FirstDescendantOrSelf<T>(
                this IUnifiedElement element, T dummyForInference = null)
                where T : class {
            Contract.Requires(element != null);
            return element.DescendantsAndSelf<T>().FirstOrDefault();
        }
    }
}