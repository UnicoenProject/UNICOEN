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

using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Unicoen.Languages.Tests {
	public class LanguageFixtureLoader {
#pragma warning disable 649
		/// <summary>
		///   有効な全てのLanguageFixtureのインスタンスを取得します．
		/// </summary>
		[ImportMany] private IEnumerable<LanguageFixture> _fixtures;
#pragma warning restore 649

		/// <summary>
		///   有効な全てのTestCodesのインスタンスを取得します．
		/// </summary>
		public static IEnumerable<TestCaseData> AllTestCodes {
			get {
				return Instance._fixtures.SelectMany(f => f.TestStatements)
						.Concat(Instance._fixtures.SelectMany(f => f.TestCodes));
			}
		}

		/// <summary>
		///   有効な全てのTestFilePathesのインスタンスを取得します．
		/// </summary>
		public static IEnumerable<TestCaseData> AllTestFilePathes {
			get { return Instance._fixtures.SelectMany(f => f.TestFilePathes); }
		}

		/// <summary>
		///   有効な全てのTestDirectoryPathesのインスタンスを取得します．
		/// </summary>
		public static IEnumerable<TestCaseData> AllTestDirectoryPathes {
			get { return Instance._fixtures.SelectMany(f => f.TestDirectoryPathes); }
		}

		private static LanguageFixtureLoader _instance;

		public static LanguageFixtureLoader Instance {
			get { return _instance ?? (_instance = new LanguageFixtureLoader()); }
		}

		private LanguageFixtureLoader() {
			var catalog = new AggregateCatalog();
			catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
			catalog.Catalogs.Add(new DirectoryCatalog(@"."));
			var container = new CompositionContainer(catalog);
			container.ComposeParts(this);
		}
	}
}